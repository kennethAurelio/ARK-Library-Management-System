using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace LibrarySystem.Staff {
    // MAIN FILE: constructor + helpers shared by every tab.
    // Each tab's code lives in its own partial file:
    //   LibrarianDashboard.LoanRequests.cs
    //   LibrarianDashboard.Returns.cs
    //   LibrarianDashboard.Catalog.cs
    //   LibrarianDashboard.History.cs
    public partial class StaffDashboard : Form {

        // The row the librarian has selected in a loan grid.
        private record SelectedLoan(int LoanId, int BookId, string Student, string Title);

        public StaffDashboard() {
            InitializeComponent();
            this.Text = $"JILCF-ARK-{LoggedInUser.Role.ToLower()}";
            this.Text = IsAdmin ? "JILCF-ARK-admin" : "JILCF-ARK-librarian";

            if (IsAdmin) {
                InitAccountsTab();
                InitReportsTab();
                InitArchivedTab();
            } else {
                tabControlStaff.TabPages.Remove(tabInformationAndAccountManagement);
                tabControlStaff.TabPages.Remove(tabReports);
                tabControlStaff.TabPages.Remove(tabArchivedUsers);
            }

            GridHelper.Style(dgvLoanRequest);
            GridHelper.Style(dgvReturns);
            GridHelper.HighlightOverdue(dgvReturns);
            GridHelper.Style(dgvCatalog);
            dgvCatalog.SelectionChanged += dgvCatalog_SelectionChanged;

            //dgvTransactionHistory.CellFormatting -= dgvTransactionHistory_CellFormatting;
            //dgvTransactionHistory.CellFormatting += dgvTransactionHistory_CellFormatting;

            GridHelper.Style(dgvTransactionHistory);

            InitArchivedBooksTab();
            LoadLoanRequests();
            LoadReturnDesk();
            LoadCatalog();
            SetUpFilter();
        }

        // Shared helpers

        // Runs a SELECT and returns the rows (reader style).
        private static DataTable LoadTable(string sql) {
            var dt = new DataTable();

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn)) {
                conn.Open();
                using (var reader = cmd.ExecuteReader()) {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        // Returns the selected row's loan info, or null (with a message) if nothing is selected.
        private static SelectedLoan? GetSelectedLoan(DataGridView dgv) {
            if (dgv.CurrentRow == null) {
                MessageBox.Show("Please select a row first.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            var cells = dgv.CurrentRow.Cells;
            return new SelectedLoan(
                Convert.ToInt32(cells["loan_id"].Value),
                Convert.ToInt32(cells["book_id"].Value),
                cells["student_name"].Value?.ToString() ?? "",
                cells["title"].Value?.ToString() ?? "");
        }

        // Refresh the loan grids when the librarian clicks the refresh button.
        private void btnRefreshData_Click(object sender, EventArgs e) {
            LoadReturnDesk();
            LoadLoanRequests();
            SetUpFilter();
            LoadReports();
        }


        private void ApplyTransactionTextColor() {
            foreach (DataGridViewRow row in dgvTransactionHistory.Rows) {
                if (row.IsNewRow)
                    continue;

                string status = Convert.ToString(
                    row.Cells["status"].Value
                ) ?? "";

                // Completed transactions should always be black.
                if (status is "Returned" or "Lost/Damage" or "Cancelled") {
                    foreach (DataGridViewCell cell in row.Cells) {
                        if (cell.OwningColumn.Name != "status")
                            cell.Style.ForeColor = Color.Black;
                    }

                    continue;
                }

                // Only active borrowed loans need due-date coloring.
                if (status != "Borrowed") {
                    foreach (DataGridViewCell cell in row.Cells) {
                        if (cell.OwningColumn.Name != "status")
                            cell.Style.ForeColor = Color.Black;
                    }

                    continue;
                }

                object dueValue = row.Cells["due_date"].Value;

                if (dueValue == null || dueValue == DBNull.Value)
                    continue;

                DateTime dueDate = Convert.ToDateTime(dueValue);
                TimeSpan remaining = dueDate - DateTime.Now;

                Color color = remaining < TimeSpan.Zero
                    ? Color.Red
                    : remaining <= TimeSpan.FromHours(24)
                        ? Color.DarkOrange
                        : Color.Black;

                foreach (DataGridViewCell cell in row.Cells) {
                    if (cell.OwningColumn.Name != "status")
                        cell.Style.ForeColor = color;
                }
            }
        }

        private void dgvTransactionHistory_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex < 0 || sender is not DataGridView dgv)
                return;

            string columnName = dgv.Columns[e.ColumnIndex].Name;

            // Preserve the existing status colors.
            if (columnName == "status")
                return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];
            string status = Convert.ToString(row.Cells["status"].Value) ?? "";

            // Completed, lost/damaged, and cancelled transactions use black text.
            if (status is "Returned" or "Lost/Damage" or "Cancelled") {
                e.CellStyle.ForeColor = Color.Black;
            } else if (status != "Borrowed") {
                e.CellStyle.ForeColor = Color.Black;
            } else {
                // Apply overdue and due-soon colors to borrowed books.
                object dueValue = row.Cells["due_date"].Value;

                if (dueValue == null || dueValue == DBNull.Value) {
                    e.CellStyle.ForeColor = Color.Black;
                } else {
                    DateTime dueDate = Convert.ToDateTime(dueValue);
                    TimeSpan remaining = dueDate - DateTime.Now;

                    e.CellStyle.ForeColor = remaining < TimeSpan.Zero
                        ? Color.Red
                        : remaining <= TimeSpan.FromHours(24)
                            ? Color.DarkOrange
                            : Color.Black;
                }
            }

            // Keep the text color visible even when the row is selected.
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }

    }
}
