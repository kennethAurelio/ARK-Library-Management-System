using System.Data;

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

        private void SetUpFilter() {
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new object[] {
                "All", "Pending", "Currently Borrowing", "Returned", "Lost", "Cancelled"
            });
            // wire the event in code (the -= first prevents double subscription)
            cbFilterBy.SelectedIndexChanged -= cbFilterBy_SelectedIndexChanged;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            cbFilterBy.SelectedIndex = 0;   // starts on "All" and loads the grid

            //GridHelper.Style(dgvTransactionHistory);
            GridHelper.HighlightOverdue(dgvTransactionHistory);
        }

        private void cbFilterBy_SelectedIndexChanged(object? sender, EventArgs e) {
            LoadTransactionHistory();
        }

        private void LoadTransactionHistory() {
            DataTable dt = LoadTable(HistoryQuery);

            string? choice = cbFilterBy.SelectedItem?.ToString();
            dt.DefaultView.RowFilter = choice switch {
                "Pending" => "status = 'Pending'",
                "Currently Borrowing" => "status = 'Borrowed'",
                "Returned" => "status = 'Returned'",
                "Lost" => "status = 'Lost'",
                "Cancelled" => "status = 'Cancelled'",
                _ => string.Empty,    // "All" or nothing selected
            };

            GridHelper.Bind(dgvTransactionHistory, dt);
        }

    }
}
