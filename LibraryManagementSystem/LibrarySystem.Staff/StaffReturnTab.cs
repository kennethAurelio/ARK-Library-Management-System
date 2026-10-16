using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibrarySystem.Staff {
    public partial class StaffDashboard {

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

        private void LoadReturnDesk() {
            GridHelper.Bind(dgvReturns, LoadTable(BorrowedLoansQuery));
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
                            "UPDATE book_loans SET status = 'Returned', return_date = NOW() " +
                            "WHERE loan_id = @loanId AND status = 'Borrowed'", conn, tx)) {
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
    }
}
