using System.Data;
using LibrarySystem.Core;

namespace LibrarySystem.Student {
    public partial class SearchResultForm : Form {
        public SearchResultForm(DataTable results) {
            InitializeComponent();
            SetupGrid();
            dgvResults.DataSource = results;

            // Hide the book_id column since it's not needed for display
            if (dgvResults.Columns.Contains("book_id")) dgvResults.Columns["book_id"].Visible = false;
            if (dgvResults.Columns.Contains("year_published")) dgvResults.Columns["year_published"].Visible = false;
            if (dgvResults.Columns.Contains("synopsis")) dgvResults.Columns["synopsis"].Visible = false;
            if (dgvResults.Columns.Contains("genre")) dgvResults.Columns["genre"].Visible = false;
            if (dgvResults.Columns.Contains("publisher")) dgvResults.Columns["publisher"].Visible = false;

            // Apply friendly header texts and column settings
            ApplyColumnHeaders();

            // Enable text wrapping and let rows auto-size to fit wrapped content
            dgvResults.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Ensure each column also allows wrapping and is read-only
            foreach (DataGridViewColumn col in dgvResults.Columns) {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                col.ReadOnly = true;
            }

            // Make the whole grid non-editable and adjust behavior for read-only display
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SetupGrid() {
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.RowHeadersVisible = false;
            dgvResults.MultiSelect = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvResults.CellFormatting += dgvResults_CellFormatting;
        }

        // New helper: set friendly header text for columns (safe-checks for existence)
        private void ApplyColumnHeaders() {
            SetHeader("title", "Title");
            SetHeader("author", "Author");
            SetHeader("copies_available", "Copies Available");
            SetHeader("year_published", "Year Published");
            SetHeader("status", "Status");
            SetHeader("synopsis", "Synopsis");
            SetHeader("genre", "Genre");
            SetHeader("publisher", "Publisher");
            SetHeader("book_status", "Book Status");
            // Example: change display index or autosize mode if desired:
            if (dgvResults.Columns.Contains("title")) dgvResults.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (dgvResults.Columns.Contains("author")) dgvResults.Columns["author"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void SetHeader(string columnName, string headerText) {
            if (dgvResults.Columns.Contains(columnName)) {
                dgvResults.Columns[columnName].HeaderText = headerText;
            }
        }

        private void dgvResults_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvResults.Columns[e.ColumnIndex].Name != "status") return;

            switch (e.Value.ToString()?.ToLower()) {
                case "pending": e.CellStyle.ForeColor = Color.DarkGoldenrod; break;
                case "borrowed": e.CellStyle.ForeColor = Color.RoyalBlue; break;
                case "returned": e.CellStyle.ForeColor = Color.Gray; break;
                case "lost": e.CellStyle.ForeColor = Color.Red; break;
                case "cancelled": e.CellStyle.ForeColor = Color.DarkGray; break;
            }
        }


        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            var row = dgvResults.Rows[e.RowIndex];
            int bookId = Convert.ToInt32(row.Cells["book_id"].Value);
            int copies = Convert.ToInt32(row.Cells["copies_available"].Value);

            if (copies <= 0) {
                MessageBox.Show("Sorry, this book has no available copies right now.",
                                "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = LoggedInUser.isLoggedIn ? LoggedInUser.UserId : 0;

            using (var loanForm = new LoanForm(bookId, userId)) {
                if (loanForm.ShowDialog(this) == DialogResult.OK) {
                    row.Cells["copies_available"].Value = copies - 1;
                }
            }
        }

    }
}
