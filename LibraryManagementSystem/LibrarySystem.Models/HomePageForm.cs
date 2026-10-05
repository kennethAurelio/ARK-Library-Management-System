using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Text;

namespace LibrarySystem.Models
{
    public partial class HomePageForm : Form {
        private const string SearchPlaceholder = "Search by title or author...";
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color NormalTextColor = Color.Black;

        public HomePageForm() {
            InitializeComponent();
            this.Activated += (s, e) => updateUIForLoginState(); // Refresh updates when the form is activated (e.g., after returning from another form)

            // Initialize placeholder for the search box
            InitializeSearchPlaceholder();
            this.ActiveControl = btnSearch;

            // Add click event handlers for the book cover PictureBoxes
            foreach (var pb in new[] { pbBookDisplay1, pbBookDisplay2, pbBookDisplay3, pbBookDisplay4 }) {
                pb.Click += BookCover_Click;
                pb.Cursor = Cursors.Hand;
            }

            LoadNewestBooks();
            rtbUpdates.TabStop = false;
        }

        // This method is called when the form is loaded. It checks the login state and updates the UI accordingly.
        private void HomePageForm_Load(object sender, EventArgs e) {
            updateUIForLoginState();
        }

        // This method updates the visibility of ui buttons based on the user's login state and refreshes the updates panel.
        private void updateUIForLoginState() {
            btnOpenLogin.Visible = !LoggedInUser.isLoggedIn;
            btnOpenUserControl.Visible = LoggedInUser.isLoggedIn;

            LoadUpdates();
        }

        // Adds one colored line to the updates box.
        private void AddUpdate(string text, Color color) {
            rtbUpdates.SelectionStart = rtbUpdates.TextLength;
            rtbUpdates.SelectionLength = 0;
            rtbUpdates.SelectionColor = color;
            rtbUpdates.AppendText(text + Environment.NewLine + Environment.NewLine);
        }

        // Loads the logged-in student's pending and borrowed books into rtbUpdates.
        private void LoadUpdates() {
            rtbUpdates.Clear();

            if (!LoggedInUser.isLoggedIn) {
                AddUpdate("Log in to see your updates.", Color.Gray);
                return;
            }

            // Pending loans have no due_date yet, so the ones with due dates (soonest first) come first.
            int count = 0; // count of updates added

            try {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySqlCommand(@"
            SELECT b.title, l.status, l.due_date
            FROM book_loans l
            JOIN books b ON b.book_id = l.book_id
            WHERE l.user_id = @userId
              AND l.status IN ('pending', 'borrowed')
            ORDER BY l.due_date IS NULL, l.due_date ASC, l.loan_date DESC", conn)) {
                    cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            string title = reader.GetString("title");
                            string status = reader.GetString("status");

                            if (status.Equals("pending", StringComparison.OrdinalIgnoreCase)) {
                                AddUpdate($"• {title} - Pending pickup", Color.DarkGoldenrod);
                            } else { // borrowed
                                if (reader.IsDBNull(reader.GetOrdinal("due_date"))) {
                                    AddUpdate($"• {title} - Borrowed (no due date set)", Color.Gray);
                                } else {
                                    DateTime due = reader.GetDateTime("due_date");
                                    int daysLeft = (due.Date - DateTime.Today).Days;

                                    if (daysLeft < 0)
                                        AddUpdate($"• {title} - OVERDUE by {-daysLeft} day(s)", Color.Red);
                                    else if (daysLeft <= 2)
                                        AddUpdate($"• {title} - Due {due:MMM dd} ({daysLeft} day(s) left)", Color.OrangeRed);
                                    else
                                        AddUpdate($"• {title} - Due {due:MMM dd}", Color.Black);
                                }
                            }
                            count++;
                        }
                    }
                }
            } catch (MySqlException ex) { // database connection or query error
                rtbUpdates.Clear();
                AddUpdate("Unable to load updates.", Color.Gray);
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return;
            }

            if (count == 0)
                AddUpdate("No updates yet.", Color.Gray);
        }

        private void btnOpenLogin_Click(object sender, EventArgs e) {
            using (var signInForm = new SignInForm()) {
                if (signInForm.ShowDialog(this) == DialogResult.OK) {
                    updateUIForLoginState();   // update lang ang UI, hindi gagawa ng bagong homepage
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string searchTerm = txtSearchBox.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm)) {
                MessageBox.Show("Please enter a search term.", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dt = new DataTable();

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT book_id, title, author, copies_available, book_status, year_published, synopsis, genre, publisher FROM books " +
                "WHERE title LIKE @search OR author LIKE @search", conn)) {
                cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    dt.Load(reader);
                }
            }

            if (dt.Rows.Count > 0) {
                var resultsForm = new SearchResultForm(dt);
                resultsForm.Show();
            } else {
                MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Reset the search box to show the placeholder again
            RestoreSearchPlaceholder();
        }

        // This method initializes the placeholder functionality for the search box.
        private void InitializeSearchPlaceholder() {
            // Ensure handlers are wired in case designer hasn't set them
            txtSearchBox.Enter -= TxtSearchBox_Enter;
            txtSearchBox.Leave -= TxtSearchBox_Leave;
            txtSearchBox.Enter += TxtSearchBox_Enter;
            txtSearchBox.Leave += TxtSearchBox_Leave;

            RestoreSearchPlaceholder();
        }

        // This method restores the placeholder text in the search box if it's empty.
        private void RestoreSearchPlaceholder() {
            if (string.IsNullOrWhiteSpace(txtSearchBox.Text)) {
                txtSearchBox.Text = SearchPlaceholder;
                txtSearchBox.ForeColor = PlaceholderColor;
            }
        }

        // Event handler for when the search box gains focus. It clears the placeholder text if present.
        private void TxtSearchBox_Enter(object? sender, EventArgs e) {
            if (txtSearchBox.Text == SearchPlaceholder) {
                txtSearchBox.Text = string.Empty;
                txtSearchBox.ForeColor = NormalTextColor;
            }
        }

        // Event handler for when the search box loses focus. It restores the placeholder text if the box is empty.
        private void TxtSearchBox_Leave(object? sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtSearchBox.Text)) {
                RestoreSearchPlaceholder();
            }
        }


        // This method loads the newest books from the database and displays their covers in the PictureBox controls.
        private void LoadNewestBooks() {
            // Array of PictureBox controls to display the newest books
            PictureBox[] covers = { pbBookDisplay1, pbBookDisplay2, pbBookDisplay3, pbBookDisplay4 };

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT book_id, title, author, book_cover FROM books " +
                "ORDER BY date_added DESC LIMIT 4", conn)) {
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    int i = 0;
                    while (reader.Read() && i < covers.Length) {
                        covers[i].BackgroundImageLayout = ImageLayout.Stretch;

                        if (reader["book_cover"] != DBNull.Value) {
                            byte[] data = (byte[])reader["book_cover"];
                            using (var stream = new MemoryStream(data))
                            using (var img = Image.FromStream(stream)) {
                                covers[i].BackgroundImage = new Bitmap(img);
                            }
                        } else {
                            covers[i].BackgroundImage = Properties.Resources.no_cover;
                        }

                        covers[i].Tag = reader["book_id"]; // saved so you can open the book when clicked
                        i++;
                    }
                }
            }
        }

        private void BookCover_Click(object? sender, EventArgs e) {
            if (sender is not PictureBox pb || pb.Tag == null) return;

            int bookId = Convert.ToInt32(pb.Tag);
            int userId = LoggedInUser.isLoggedIn ? LoggedInUser.UserId : 0;

            using (var loanForm = new LoanForm(bookId, LoggedInUser.UserId)) {
                loanForm.ShowDialog(this);
            }

            updateUIForLoginState();
            LoadNewestBooks();   // Refresh the newest books display in case a book was borrowed and its availability changed
        }

        private void btnBrowseAllBooks_Click(object sender, EventArgs e) {
            var dt = new DataTable();

            // book_id is still selected because the results grid needs it to open the LoanForm (hide it in the grid).
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT book_id, title, author, copies_available, book_status, year_published, synopsis, genre, publisher FROM books", conn)) {
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    dt.Load(reader);
                }
            }

            ShowResults(dt);
        }

        // This method displays the search results in a new SearchResultForm.
        private void ShowResults(DataTable dt) {
            if (dt == null) return;
            var resultsForm = new SearchResultForm(dt);
            resultsForm.Show();
        }

        private void btnOpenUserControl_Click(object sender, EventArgs e) {
            using (var AccountForm = new AccountForm()) {
                AccountForm.ShowDialog(this);
            }
        }

    }
}
