using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibrarySystem.Staff {
    public partial class LibrarianDashboard : Form {
        private const int LoanDays = 3;
        private int? _editingBookId = null;

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

        private const string CatalogQuery = @"
            SELECT book_id, title, author, genre, publisher, year_published,
                   copies_available, book_status, synopsis
            FROM books
            ORDER BY title";


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
            WHERE l.status IN ('Pending', 'Returned', 'Lost', 'Cancelled')
            ORDER BY l.return_date DESC";

        // The row the librarian has selected in a loan grid.
        private record SelectedLoan(int LoanId, int BookId, string Student, string Title);

        public LibrarianDashboard() {
            InitializeComponent();
            GridHelper.Style(dgvLoanRequest);
            GridHelper.Style(dgvReturns);
            GridHelper.HighlightOverdue(dgvReturns);
            GridHelper.Style(dgvCatalog);
            dgvCatalog.SelectionChanged += dgvCatalog_SelectionChanged;

            // History grid style and filter initialization
            GridHelper.Style(dgvTransactionHistory);

            LoadLoanRequests();
            LoadReturnDesk();
            LoadCatalog();
            LoadTransactionHistory();
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
        private void LoadCatalog() {
            GridHelper.Bind(dgvCatalog, LoadTable(CatalogQuery));
            dgvCatalog.Columns["synopsis"].Visible = false;   // too long for a grid cell
            StartNewBook();
        }
        private void LoadTransactionHistory() {
            // !! WIP: Add filtering options for the history grid (e.g., by date range, status, student, etc.)
            GridHelper.Bind(dgvTransactionHistory, LoadTable(HistoryQuery));
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

        // Refresh both grids when the librarian clicks the refresh button.
        private void btnRefreshData_Click(object sender, EventArgs e) {
            LoadReturnDesk();
            LoadLoanRequests();
        }

        private void btnCancelRequest_Click(object sender, EventArgs e) {
            var loan = GetSelectedLoan(dgvLoanRequest);
            if (loan == null) return;

            if (MessageBox.Show($"Cancel this request?\n\nStudent: {loan.Student}\nBook: {loan.Title}",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE book_loans SET status = 'Cancelled'" +
                "WHERE loan_id = @loanId AND status = 'Pending'", conn)) {
                cmd.Parameters.AddWithValue("@loanId", loan.LoanId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadLoanRequests();
        }

        // Selecting a row fills the fields and switches to edit mode.
        private void dgvCatalog_SelectionChanged(object? sender, EventArgs e) {
            if (dgvCatalog.SelectedRows.Count == 0) return;

            var cells = dgvCatalog.SelectedRows[0].Cells;
            _editingBookId = Convert.ToInt32(cells["book_id"].Value);

            txtTitle.Text = cells["title"].Value?.ToString();
            txtAuthor.Text = cells["author"].Value?.ToString();
            txtGenre.Text = cells["genre"].Value?.ToString();
            txtPublisher.Text = cells["publisher"].Value?.ToString();
            txtYear.Text = cells["year_published"].Value?.ToString();
            txtSynopsis.Text = cells["synopsis"].Value?.ToString();

            int copies = int.TryParse(cells["copies_available"].Value?.ToString(), out int c) ? c : 0;
            nudCopies.Value = Math.Clamp(copies, (int)nudCopies.Minimum, (int)nudCopies.Maximum);

            lblMode.Text = $"Editing: {txtTitle.Text}";
            btnSaveBook.Text = "Save Changes";
        }

        // Clears everything and switches to add mode.
        private void StartNewBook() {
            _editingBookId = null;
            dgvCatalog.ClearSelection();

            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtPublisher.Clear();
            txtYear.Clear();
            txtSynopsis.Clear();
            nudCopies.Value = 3;

            lblMode.Text = "Adding a new book";
            btnSaveBook.Text = "Add Book";
            txtTitle.Focus();
        }

        private void btnNewBook_Click(object sender, EventArgs e) {
            StartNewBook();
        }

        private void btnSaveBook_Click(object sender, EventArgs e) {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();

            if (title == "" || author == "") {
                MessageBox.Show("Title and author are required.", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object year = DBNull.Value;
            if (txtYear.Text.Trim() != "") {
                if (!int.TryParse(txtYear.Text.Trim(), out int y)) {
                    MessageBox.Show("Year must be a number.", "Invalid Year",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                year = y;
            }

            int copies = (int)nudCopies.Value;
            string status = copies > 0 ? "Available" : "Unavailable";

            string sql = _editingBookId == null
                ? @"INSERT INTO books (title, author, genre, publisher, year_published, synopsis,
                               copies_available, book_status, date_added)
            VALUES (@title, @author, @genre, @publisher, @year, @synopsis, @copies, @status, NOW())"
                : @"UPDATE books
            SET title = @title, author = @author, genre = @genre, publisher = @publisher,
                year_published = @year, synopsis = @synopsis,
                copies_available = @copies, book_status = @status
            WHERE book_id = @bookId";

            try {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySqlCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@genre", txtGenre.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher", txtPublisher.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@synopsis", txtSynopsis.Text.Trim());
                    cmd.Parameters.AddWithValue("@copies", copies);
                    cmd.Parameters.AddWithValue("@status", status);
                    if (_editingBookId != null)
                        cmd.Parameters.AddWithValue("@bookId", _editingBookId.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            } catch (MySqlException ex) {
                MessageBox.Show("Could not save the book.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(_editingBookId == null ? "Book added." : "Book updated.", "Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadCatalog();        // refresh the grid and reset the form to add mode
            LoadLoanRequests();   // keep "Copies Left" in the requests grid current
        }

    }
}
