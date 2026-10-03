using System.Data;

namespace LibrarySystem.Models {
    public partial class SearchResultForm : Form {
        public SearchResultForm(DataTable results) {
            InitializeComponent();
            dgvResults.DataSource = results;

            // Hide the book_id column since it's not needed for display
            dgvResults.Columns["book_id"].Visible = false;
            dgvResults.Columns["year_published"].Visible = false;
            dgvResults.Columns["synopsis"].Visible = false;
            dgvResults.Columns["genre"].Visible = false;
            dgvResults.Columns["publisher"].Visible = false;

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

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Ensure the click is on a valid row and not on the header or an invalid index
            if (e.RowIndex < 0) return;

            var row = dgvResults.Rows[e.RowIndex];
            int bookId = Convert.ToInt32(row.Cells["book_id"].Value);
            string title = row.Cells["title"].Value.ToString();
            int copies = Convert.ToInt32(row.Cells["copies_available"].Value);

            if (copies <= 0) {
                MessageBox.Show("Sorry, this book has no available copies right now.",
                                "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!CurrentUser.isLoggedIn) {
                MessageBox.Show("Please log in to loan a book.", "Login Required",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var signIn = new SignInForm()) {
                    signIn.ShowDialog();
                }
                if (!CurrentUser.isLoggedIn) return;
            }

            using (var loanForm = new LoanForm(bookId, CurrentUser.UserId)) {
                if (loanForm.ShowDialog() == DialogResult.OK) {
                    // successfully loaned the book, update the copies available in the DataGridView
                    row.Cells["copies_available"].Value = copies - 1;
                }
            }

        }

    }
}
