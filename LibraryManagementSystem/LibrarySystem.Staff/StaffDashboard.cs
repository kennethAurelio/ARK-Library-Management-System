using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System.Data;

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

            if (IsAdmin) {
                InitAccountsTab();
                //InitReportsTab();
            } else {
                tabControlStaff.TabPages.Remove(tabIAM);
                tabControlStaff.TabPages.Remove(tabReports);
            }

            GridHelper.Style(dgvLoanRequest);
            GridHelper.Style(dgvReturns);
            GridHelper.HighlightOverdue(dgvReturns);
            GridHelper.Style(dgvCatalog);
            dgvCatalog.SelectionChanged += dgvCatalog_SelectionChanged;
            GridHelper.Style(dgvTransactionHistory);

            LoadLoanRequests();
            LoadReturnDesk();
            LoadCatalog();
            LoadTransactionHistory();
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
            LoadTransactionHistory();
        }
    }

}
