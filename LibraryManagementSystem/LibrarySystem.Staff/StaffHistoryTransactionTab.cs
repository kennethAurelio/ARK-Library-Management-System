namespace LibrarySystem.Staff {
    public partial class StaffDashboard {

        private const string HistoryQuery = @"
            SELECT l.loan_id,
                   l.book_id,
                   a.login_id AS student_id,
                   CONCAT(a.first_name, ' ', COALESCE(a.middle_name, ''), ' ', a.last_name) AS student_name,
                   b.title,
                   l.loan_date,
                   l.due_date,
                   l.return_date,
                   l.status
            FROM book_loans l
            JOIN accounts a ON a.user_id = l.user_id
            JOIN books b ON b.book_id = l.book_id
            WHERE l.status IN ('Pending', 'Borrowed', 'Returned', 'Lost', 'Cancelled')
            ORDER BY l.return_date DESC";

        private void LoadTransactionHistory() {
            // !! WIP: add filtering options for the history grid (date range, status, student, etc.)
            GridHelper.Bind(dgvTransactionHistory, LoadTable(HistoryQuery));
        }
    }
}
