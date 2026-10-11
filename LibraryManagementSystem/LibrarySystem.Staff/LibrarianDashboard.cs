using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibrarySystem.Staff {
    public partial class LibrarianDashboard : Form {

        private const int LoanDays = 7;

        private const string PendingRequestsQuery = @"
            SELECT l.loan_id,
                   l.book_id,
                   a.login_id AS student_id,
                   CONCAT(a.first_name, ' ', COALESCE(a.middle_name, ''), ' ', a.last_name) AS student_name,
                   b.title,
                   b.author,
                   b.copies_available,
                   l.loan_date AS requested_on
            FROM book_loans l
            JOIN accounts a ON a.user_id = l.user_id
            JOIN books b ON b.book_id = l.book_id
            WHERE l.status = 'Pending'
            ORDER BY l.loan_date ASC";

        private const string BorrowedLoansQuery = @"
            SELECT l.loan_id,
                   l.book_id,
                   a.login_id AS student_id,
                   CONCAT(a.first_name, ' ', COALESCE(a.middle_name, ''), ' ', a.last_name) AS student_name,
                   b.title,
                   l.loan_date,
                   l.due_date
            FROM book_loans l
            JOIN accounts a ON a.user_id = l.user_id
            JOIN books b ON b.book_id = l.book_id
            WHERE l.status = 'Borrowed'
            ORDER BY l.due_date IS NULL, l.due_date ASC";

        // The row the librarian has selected in a loan grid.
        private record SelectedLoan(int LoanId, int BookId, string Student, string Title);

        public LibrarianDashboard() {
            InitializeComponent();

            GridHelper.Style(dgvLoanRequest);
            GridHelper.Style(dgvReturns);
            GridHelper.HighlightOverdue(dgvReturns);

            LoadLoanRequests();
            LoadReturnDesk();
        }

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

        private void LoadLoanRequests() {
            GridHelper.Bind(dgvLoanRequest, LoadTable(PendingRequestsQuery));
        }

        private void LoadReturnDesk() {
            GridHelper.Bind(dgvReturns, LoadTable(BorrowedLoansQuery));
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

        private void btnAcceptRequest_Click(object sender, EventArgs e) {
            var loan = GetSelectedLoan(dgvLoanRequest);
            if (loan == null) return;

            if (MessageBox.Show(
                    $"Accept request?\n\nStudent: {loan.Student}\nBook: {loan.Title}\nDue in {LoanDays} days.",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (var conn = DatabaseHelper.GetConnection()) {
                conn.Open();
                using (var tx = conn.BeginTransaction()) {
                    try {
                        // 1. Take one copy, but only if one is left
                        using (var cmd = new MySqlCommand(
                            "UPDATE books SET copies_available = copies_available - 1 " +
                            "WHERE book_id = @bookId AND copies_available > 0", conn, tx)) {
                            cmd.Parameters.AddWithValue("@bookId", loan.BookId);

                            if (cmd.ExecuteNonQuery() == 0) {
                                tx.Rollback();
                                MessageBox.Show("No copies available for this book.", "Out of Stock",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // 2. Mark the loan as Borrowed, but only if it is still Pending
                        using (var cmd = new MySqlCommand(
                            "UPDATE book_loans SET status = 'Borrowed', loan_date = NOW(), " +
                            "due_date = DATE_ADD(NOW(), INTERVAL @days DAY)" +
                            "WHERE loan_id = @loanId AND status = 'Pending'", conn, tx)) {
                            cmd.Parameters.AddWithValue("@days", LoanDays);
                            cmd.Parameters.AddWithValue("@staffId", LoggedInUser.UserId);
                            cmd.Parameters.AddWithValue("@loanId", loan.LoanId);

                            if (cmd.ExecuteNonQuery() == 0) {
                                tx.Rollback();
                                MessageBox.Show("This request was already processed.", "Already Processed",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadLoanRequests();
                                return;
                            }
                        }

                        tx.Commit();
                    } catch (MySqlException ex) {
                        tx.Rollback();
                        MessageBox.Show("Could not process the request.\n" + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            LoadLoanRequests();   // the accepted request leaves this grid...
            LoadReturnDesk();     // ...and shows up in Returns
        }

        private void btnMarkReturned_Click(object sender, EventArgs e) {
            var loan = GetSelectedLoan(dgvReturns);
            if (loan == null) return;

            if (MessageBox.Show($"Mark as returned?\n\nStudent: {loan.Student}\nBook: {loan.Title}",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (var conn = DatabaseHelper.GetConnection()) {
                conn.Open();
                using (var tx = conn.BeginTransaction()) {
                    try {
                        // 1. Mark the loan as Returned, but only if it is still Borrowed
                        using (var cmd = new MySqlCommand(
                            "UPDATE book_loans SET status = 'Returned', return_date = NOW()" +
                            "WHERE loan_id = @loanId AND status = 'Borrowed'", conn, tx)) {
                            cmd.Parameters.AddWithValue("@staffId", LoggedInUser.UserId);
                            cmd.Parameters.AddWithValue("@loanId", loan.LoanId);

                            if (cmd.ExecuteNonQuery() == 0) {
                                tx.Rollback();
                                MessageBox.Show("This loan was already processed.", "Already Processed",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadReturnDesk();
                                return;
                            }
                        }

                        // 2. Put the copy back on the shelf
                        using (var cmd = new MySqlCommand(
                            "UPDATE books SET copies_available = copies_available + 1 WHERE book_id = @bookId", conn, tx)) {
                            cmd.Parameters.AddWithValue("@bookId", loan.BookId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    } catch (MySqlException ex) {
                        tx.Rollback();
                        MessageBox.Show("Could not process the return.\n" + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            LoadReturnDesk();      // the returned loan leaves this grid
            LoadLoanRequests();    // refresh "Copies Left" in the requests grid
        }

        private void BtnRefreshData(object sender, EventArgs e) {
            LoadReturnDesk();
            LoadLoanRequests();
        }
    }
}
