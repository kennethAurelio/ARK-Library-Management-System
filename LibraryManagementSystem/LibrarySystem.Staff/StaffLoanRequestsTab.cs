using LibrarySystem.Core;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Staff {
    public partial class StaffDashboard {

        private const int LoanDays = 3;

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

        private void LoadLoanRequests() {
            GridHelper.Bind(dgvLoanRequest, LoadTable(PendingRequestsQuery));
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
                            "due_date = DATE_ADD(NOW(), INTERVAL @days DAY) " +
                            "WHERE loan_id = @loanId AND status = 'Pending'", conn, tx)) {
                            cmd.Parameters.AddWithValue("@days", LoanDays);
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

        private void btnCancelRequest_Click(object sender, EventArgs e) {
            var loan = GetSelectedLoan(dgvLoanRequest);
            if (loan == null) return;

            if (MessageBox.Show($"Cancel this request?\n\nStudent: {loan.Student}\nBook: {loan.Title}",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE book_loans SET status = 'Cancelled' " +
                "WHERE loan_id = @loanId AND status = 'Pending'", conn)) {
                cmd.Parameters.AddWithValue("@loanId", loan.LoanId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadLoanRequests();
        }
    }
}
