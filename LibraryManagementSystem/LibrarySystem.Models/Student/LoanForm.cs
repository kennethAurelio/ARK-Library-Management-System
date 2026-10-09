using MySql.Data.MySqlClient;
using LibrarySystem.Core;

namespace LibrarySystem.Student {
    public partial class LoanForm : Form {
        private int _bookId;
        private int _userId;
        public LoanForm(int bookId, int userId) {
            InitializeComponent();
            _bookId = bookId;
            _userId = userId;
            LoadBook();
            txtSynopsis.TabStop = false;
            txtAuthor.TabStop = false;
        }

        private void LoadBook() {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT title, author, synopsis, copies_available, book_status, genre, book_cover FROM books WHERE book_id = @id", conn)) {
                cmd.Parameters.AddWithValue("@id", _bookId);
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    if (!reader.Read()) return;

                    lblTitle.Text = reader["title"]?.ToString() ?? "Unknown Title";
                    txtAuthor.Text = reader["author"]?.ToString() ?? "Unknown Author";
                    txtSynopsis.Text = reader["synopsis"]?.ToString() ?? "Synopsis Missing";
                    txtBookCopies.Text = reader["copies_available"]?.ToString() ?? "Copies Unavailable";
                    lblBookStatus.Text = "Status: " + reader["book_status"]?.ToString() ?? "Status Unknown";
                    lblGenre.Text = "Genre: " + reader["genre"]?.ToString() ?? "Genre Unknown";

                    if (reader["book_cover"] != DBNull.Value) {
                        byte[] data = (byte[])reader["book_cover"];
                        using (var stream = new MemoryStream(data))
                        using (var img = Image.FromStream(stream)) {
                            pbCover.BackgroundImage = new Bitmap(img);
                        }
                    } else {
                        pbCover.BackgroundImage = Properties.Resources.no_cover;
                    }
                }
            }
        }

        private void btnLoanBook_Click(object sender, EventArgs e) {
            if (!LoggedInUser.isLoggedIn) {
                DialogResult prompt = MessageBox.Show(
                    "You need to sign in before you can loan a book.",
                    "Sign in required",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                if (prompt != DialogResult.OK) return;

                using (var signIn = new SignInForm()) {
                    if (signIn.ShowDialog(this) != DialogResult.OK) return;
                }
                _userId = LoggedInUser.UserId;
            }

            // 1. Rules and agreement
            using (var rules = new RulesForm()) {
                if (rules.ShowDialog(this) != DialogResult.OK) return;
            }

            try {
                using (var conn = DatabaseHelper.GetConnection()) {
                    conn.Open();

                    // 2. Block duplicate active requests/loans for the same book
                    using (var check = new MySqlCommand(
                        "SELECT COUNT(*) FROM book_loans " +
                        "WHERE book_id = @book AND user_id = @user " +
                        "AND status IN ('Pending','Borrowed')", conn)) {
                        check.Parameters.AddWithValue("@book", _bookId);
                        check.Parameters.AddWithValue("@user", _userId);

                        if (Convert.ToInt32(check.ExecuteScalar()) > 0) {
                            MessageBox.Show("You already have an active request or loan for this book.",
                                "Already Requested", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // 3. Check availability from the DB (not from the textbox, which can be outdated)
                    using (var avail = new MySqlCommand(
                        "SELECT copies_available FROM books WHERE book_id = @book", conn)) {
                        avail.Parameters.AddWithValue("@book", _bookId);

                        if (Convert.ToInt32(avail.ExecuteScalar()) <= 0) {
                            MessageBox.Show("Sorry, no copies are available right now.",
                                "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // 4. Save the request
                    using (var cmd = new MySqlCommand(
                        "INSERT INTO book_loans (book_id, user_id, status) VALUES (@book, @user, 'Pending')", conn)) {
                        cmd.Parameters.AddWithValue("@book", _bookId);
                        cmd.Parameters.AddWithValue("@user", _userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Request submitted! Please claim your book from the librarian.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            } catch (MySqlException ex) {
                MessageBox.Show("Something went wrong while saving your request:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
