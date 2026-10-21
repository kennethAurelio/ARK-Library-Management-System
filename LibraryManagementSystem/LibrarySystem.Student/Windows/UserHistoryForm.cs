using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibrarySystem.Student {
    public partial class UserHistoryForm : Form {
        public UserHistoryForm() {
            InitializeComponent();
            SetupGrid();
            SetupFilter();
        }

        // Fills the ComboBox once (NOT inside LoadHistory).
        private void SetupFilter() {
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new object[] {
                "All", "Currently Borrowing", "Pending", "Returned", "Lost/Damage", "Cancelled"
            });

            cbFilterBy.SelectedIndexChanged -= cbFilterBy_SelectedIndexChanged;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;

            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object? sender, EventArgs e) {
            LoadHistory();
        }

        // One-time grid look: read-only, list-style.
        private void SetupGrid() {
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.MultiSelect = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistory.CellFormatting += dgvHistory_CellFormatting;
            dgvHistory.SelectionChanged += dgvHistory_SelectionChanged;

            btnCancel.Enabled = false;
        }

        private void LoadHistory() {
            string choice = cbFilterBy.SelectedItem?.ToString() ?? "All";

            // Map what the user sees to the value stored in the database.
            object status = choice switch {
                "All" => DBNull.Value,
                "Currently Borrowing" => "Borrowed",
                _ => choice    // Pending, Returned, Lost/Damage, Cancelled
            };

            var historyTable = new DataTable();

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT l.loan_id, b.title, b.author, l.date_requested, l.loan_date, l.due_date,
                       l.return_date, l.lost_or_damaged_on, l.status
                FROM book_loans l
                JOIN books b ON b.book_id = l.book_id
                WHERE l.user_id = @userId
                  AND (@status IS NULL OR l.status = @status)
                ORDER BY FIELD(l.status, 'Borrowed', 'Pending', 'Returned', 'Lost/Damage', 'Cancelled'),
                         l.date_requested DESC", conn)) {
                cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);
                cmd.Parameters.AddWithValue("@status", status);
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    historyTable.Load(reader);
                }
            }

            dgvHistory.DataSource = historyTable;

            // loan_id is only needed internally (for cancelling)
            dgvHistory.Columns["loan_id"].Visible = false;

            // Headers
            dgvHistory.Columns["title"].HeaderText = "Title";
            dgvHistory.Columns["author"].HeaderText = "Author";
            dgvHistory.Columns["date_requested"].HeaderText = "Requested On";
            dgvHistory.Columns["loan_date"].HeaderText = "Loan Date";
            dgvHistory.Columns["due_date"].HeaderText = "Due Date";
            dgvHistory.Columns["return_date"].HeaderText = "Return Date";
            dgvHistory.Columns["lost_or_damaged_on"].HeaderText = "Lost/Damaged On";
            dgvHistory.Columns["status"].HeaderText = "Status";

            // Formats (dates that don't apply yet show a dash)
            foreach (var name in new[] { "date_requested", "loan_date", "due_date", "return_date", "lost_or_damaged_on" }) {
                dgvHistory.Columns[name].DefaultCellStyle.Format = "MMM dd, yyyy";
                dgvHistory.Columns[name].DefaultCellStyle.NullValue = "—";
            }

            // Show only the columns that make sense for the chosen filter
            dgvHistory.Columns["loan_date"].Visible = choice != "Pending" && choice != "Cancelled";
            dgvHistory.Columns["due_date"].Visible = choice != "Pending" && choice != "Cancelled";
            dgvHistory.Columns["return_date"].Visible = choice == "All" || choice == "Returned";
            dgvHistory.Columns["lost_or_damaged_on"].Visible = choice == "All" || choice == "Lost/Damage";
            dgvHistory.Columns["status"].Visible = (choice == "All");

            UpdateCancelButton();
        }

        // Colors the Status text per value.
        private void dgvHistory_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvHistory.Columns[e.ColumnIndex].Name != "status") return;

            switch (e.Value.ToString()?.ToLower()) {
                case "pending": e.CellStyle.ForeColor = Color.DarkGoldenrod; break;
                case "borrowed": e.CellStyle.ForeColor = Color.RoyalBlue; break;
                case "returned": e.CellStyle.ForeColor = Color.Gray; break;
                case "lost/damage": e.CellStyle.ForeColor = Color.Red; break;
                case "cancelled": e.CellStyle.ForeColor = Color.DarkGray; break;
            }
        }

        // Cancel logic

        // Reads the selected row from the data source, so it works even when the Status column is hidden.
        private (int LoanId, string Title, string Status)? GetSelectedHistoryRow() {
            if (dgvHistory.CurrentRow?.DataBoundItem is not DataRowView row) return null;

            return (Convert.ToInt32(row["loan_id"]),
                    row["title"]?.ToString() ?? "this book",
                    row["status"]?.ToString() ?? "");
        }

        private void dgvHistory_SelectionChanged(object? sender, EventArgs e) {
            UpdateCancelButton();
        }

        // The Cancel button is only usable when a Pending row is selected.
        private void UpdateCancelButton() {
            var selected = GetSelectedHistoryRow();
            btnCancel.Enabled = selected != null &&
                                selected.Value.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            var selected = GetSelectedHistoryRow();

            if (selected == null) {
                MessageBox.Show("Select a request first.", "No selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!selected.Value.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Only pending requests can be cancelled.", "Can't cancel",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Cancel your request for \"{selected.Value.Title}\"?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try {
                int affected;

                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySqlCommand(
                    "UPDATE book_loans SET status = 'Cancelled' " +
                    "WHERE loan_id = @loanId AND user_id = @userId AND status = 'Pending'", conn)) {
                    cmd.Parameters.AddWithValue("@loanId", selected.Value.LoanId);
                    cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);
                    conn.Open();
                    affected = cmd.ExecuteNonQuery();
                }

                if (affected == 0) {
                    MessageBox.Show("This request was already processed by the librarian, so it can't be cancelled anymore.",
                                    "Already processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Your request was cancelled.", "Cancelled",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (MySqlException ex) {
                MessageBox.Show("Could not cancel the request.\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadHistory();   // refresh so the row moves to its new status
        }

    }
}
