using LibrarySystem.Core;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Staff {
    // REPORTS TAB (admin only): count cards + overdue, lost, top books, genre, and monthly grids.
    public partial class StaffDashboard {

        private const string LoanCountsQuery = @"
            SELECT COALESCE(SUM(status = 'Pending'), 0)  AS pending,
                   COALESCE(SUM(status = 'Borrowed'), 0) AS borrowed,
                   COALESCE(SUM(status = 'Borrowed' AND due_date < NOW()), 0) AS overdue,
                   COALESCE(SUM(status = 'Returned'), 0) AS returned,
                   COALESCE(SUM(status = 'Lost/Damage'), 0) AS lost
            FROM book_loans";

        private const string OverdueQuery = @"
            SELECT a.login_id AS student_id,
                   CONCAT(a.first_name, ' ', COALESCE(a.middle_name, ''), ' ', a.last_name) AS student_name,
                   b.title,
                   l.due_date AS `Due date`,
                   CONCAT(TIMESTAMPDIFF(DAY, l.due_date, NOW()), 'd ',
                          MOD(TIMESTAMPDIFF(HOUR, l.due_date, NOW()), 24), 'h') AS `Late by`
            FROM book_loans l
            JOIN accounts a ON a.user_id = l.user_id
            JOIN books b ON b.book_id = l.book_id
            WHERE l.status = 'Borrowed'
              AND l.due_date < NOW()
            ORDER BY l.due_date ASC";

        // lost_on uses return_date if "Mark Lost" stores it, otherwise falls back to the due date.
        // LostBooksQuery
        private const string LostBooksQuery = @"
            SELECT a.login_id AS student_id,
                   CONCAT(a.first_name, ' ', COALESCE(a.middle_name, ''), ' ', a.last_name) AS student_name,
                   b.title,
                   l.lost_or_damaged_on AS `Lost/Damaged on`
            FROM book_loans l
            JOIN accounts a ON a.user_id = l.user_id
            JOIN books b ON b.book_id = l.book_id
            WHERE l.status = 'Lost/Damage'
            ORDER BY l.lost_or_damaged_on DESC";

        private const string TopBooksQuery = @"
            SELECT b.title,
                   b.author,
                   COUNT(*) AS `Times Borrowed`
            FROM book_loans l
            JOIN books b ON b.book_id = l.book_id
            WHERE l.status IN ('Borrowed', 'Returned', 'Lost/Damage')
            GROUP BY b.book_id, b.title, b.author
            ORDER BY COUNT(*) DESC, b.title
            LIMIT 5";

        private const string LoansByGenreQuery = @"
            SELECT COALESCE(NULLIF(g.genre, ''), 'Unknown') AS genre,
                   COUNT(*) AS Loans
            FROM book_loans l
            JOIN books b ON b.book_id = l.book_id
            LEFT JOIN genre g ON b.genre = g.genre_id
            WHERE l.status IN ('Borrowed', 'Returned', 'Lost/Damage')
            GROUP BY COALESCE(NULLIF(g.genre, ''), 'Unknown')
            ORDER BY Loans DESC";

        private const string LoansPerMonthQuery = @"
            SELECT DATE_FORMAT(l.loan_date, '%Y-%m') AS Month,
                   COUNT(*) AS Loans
            FROM book_loans l
            WHERE l.loan_date IS NOT NULL
              AND l.status IN ('Borrowed', 'Returned', 'Lost/Damage')
            GROUP BY DATE_FORMAT(l.loan_date, '%Y-%m')
            ORDER BY Month DESC";

        // Called once from the constructor, only when the logged-in user is an admin.
        private void InitReportsTab() {
            GridHelper.Style(dgvOverdue);
            GridHelper.Style(dgvLostBooks);
            GridHelper.Style(dgvTopBooks);
            GridHelper.Style(dgvGenreLoans);
            GridHelper.Style(dgvMonthlyLoans);
            LoadReports();
        }

        private void LoadReports() {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(LoanCountsQuery, conn)) {
                conn.Open();
                using (var reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        lblPendingCount.Text = Convert.ToInt32(reader["pending"]).ToString();
                        lblBorrowedCount.Text = Convert.ToInt32(reader["borrowed"]).ToString();
                        lblOverdueCount.Text = Convert.ToInt32(reader["overdue"]).ToString();
                        lblReturnedCount.Text = Convert.ToInt32(reader["returned"]).ToString();
                        lblLostCount.Text = Convert.ToInt32(reader["lost"]).ToString();
                    }
                }
            }

            GridHelper.Bind(dgvOverdue, LoadTable(OverdueQuery));
            GridHelper.Bind(dgvLostBooks, LoadTable(LostBooksQuery));
            GridHelper.Bind(dgvTopBooks, LoadTable(TopBooksQuery));
            GridHelper.Bind(dgvGenreLoans, LoadTable(LoansByGenreQuery));
            GridHelper.Bind(dgvMonthlyLoans, LoadTable(LoansPerMonthQuery));
        }

    }
}
