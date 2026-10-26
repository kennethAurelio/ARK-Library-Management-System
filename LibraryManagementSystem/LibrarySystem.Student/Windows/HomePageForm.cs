using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibrarySystem.Student {
    public partial class HomePageForm : Form {
        private const string SearchPlaceholder = "Search by title or author...";
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color NormalTextColor = Color.Black;
        private bool _remindedThisSession = false;

        // Borrowed loans that are overdue or due within the DueSoonWindow (same rule as the Updates box)
        private const string DueSoonQuery = @"
            SELECT b.title, l.due_date
            FROM book_loans l
            JOIN books b ON b.book_id = l.book_id
            WHERE l.user_id = @userId
              AND l.status = 'Borrowed'
              AND l.due_date IS NOT NULL
              AND l.due_date <= @cutoff
            ORDER BY l.due_date ASC";

        private static readonly TimeSpan DueSoonWindow = TimeSpan.FromHours(24);   // same as HighlightOverdue

        // Each cancelled request is shown for 1 hour from when the student first sees it (kept in memory, no DB column)
        private static readonly TimeSpan CancelledShowWindow = TimeSpan.FromHours(1);
        private static int _cancelUserId = -1;                                        // whose timers these are
        private static readonly Dictionary<int, DateTime> _cancelFirstSeen = new();   // loan_id -> when the student first saw it

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

            this.Shown += (s, e) => BeginInvoke(new Action(TryShowDueReminders)); // Show due reminders when the form is first shown
            this.Activated += (s, e) => BeginInvoke(new Action(TryShowDueReminders)); // Show due reminders when the form is activated
        }

        private void TryShowDueReminders() {
            if (!LoggedInUser.isLoggedIn || _remindedThisSession) return;
            _remindedThisSession = true;

            var sb = new System.Text.StringBuilder();

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(DueSoonQuery, conn)) {
                cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);
                cmd.Parameters.AddWithValue("@cutoff", DateTime.Now + DueSoonWindow);   // same clock as the dashboard
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        string title = reader.GetString("title");
                        DateTime due = reader.GetDateTime("due_date");
                        TimeSpan left = due - DateTime.Now;

                        if (left < TimeSpan.Zero)
                            sb.AppendLine($"• {title} - OVERDUE by {FormatSpan(-left)}");
                        else
                            sb.AppendLine($"• {title} - Due {due:MMM dd, h:mm tt} ({FormatSpan(left)} left)");
                    }
                }
            }

            if (sb.Length > 0)
                MessageBox.Show(sb.ToString(), "Loan Reminders", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Loads the logged-in student's pending, borrowed, and cancelled books into rtbUpdates.
        // Pending/Borrowed always show. Each Cancelled request shows for 1 hour after it is first seen.
        private void LoadUpdates() {
            rtbUpdates.Clear();

            if (!LoggedInUser.isLoggedIn) {
                AddUpdate("Log in to see your updates.", Color.Gray);
                return;
            }

            // Different user than before: forget the previous user's cancel timers
            if (_cancelUserId != LoggedInUser.UserId) {
                _cancelUserId = LoggedInUser.UserId;
                _cancelFirstSeen.Clear();
            }

            int count = 0;
            var newCancelled = new List<string>();   // cancelled requests seen for the first time (for the popup)

            try {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySqlCommand(@"
                    SELECT l.loan_id, b.title, b.copies_available, b.is_active, l.status, l.due_date, l.date_requested
                    FROM book_loans l
                    JOIN books b ON b.book_id = l.book_id
                    WHERE l.user_id = @userId
                      AND (l.status IN ('Pending', 'Borrowed')
                           OR (l.status = 'Cancelled' AND l.date_requested >= NOW() - INTERVAL 7 DAY))
                    ORDER BY l.status = 'Cancelled', l.due_date IS NULL, l.due_date ASC, l.date_requested DESC",
                    conn)) {
                    cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            int loanId = reader.GetInt32("loan_id");
                            string title = reader.GetString("title");
                            string status = reader.GetString("status");
                            int copies = reader.IsDBNull(reader.GetOrdinal("copies_available"))
                                ? 0
                                : reader.GetInt32("copies_available");

                            // TINYINT(1) can come back as a bool, so use Convert instead of GetInt32
                            bool isActive = Convert.ToInt32(reader["is_active"]) == 1;

                            string requestedText = reader.IsDBNull(reader.GetOrdinal("date_requested"))
                                ? ""
                                : $" (requested {reader.GetDateTime("date_requested"):MMM dd})";

                            if (status.Equals("pending", StringComparison.OrdinalIgnoreCase)) {
                                if (!isActive)
                                    AddUpdate($"• {title} - No longer available (removed from the library){requestedText}", Color.Firebrick);
                                else if (copies <= 0)
                                    AddUpdate($"• {title} - Currently unavailable{requestedText}", Color.Firebrick);
                                else
                                    AddUpdate($"• {title} - Pending pickup{requestedText}", Color.DarkGoldenrod);

                            } else if (status.Equals("cancelled", StringComparison.OrdinalIgnoreCase)) {
                                // Each cancelled request gets its own 1-hour timer, started when first seen
                                if (!_cancelFirstSeen.TryGetValue(loanId, out DateTime firstSeen)) {
                                    firstSeen = DateTime.Now;
                                    _cancelFirstSeen[loanId] = firstSeen;
                                    newCancelled.Add($"• {title}");
                                }

                                if (DateTime.Now - firstSeen > CancelledShowWindow)
                                    continue;   // its hour is over: don't show it and don't count it

                                AddUpdate($"• {title} - Cancelled{requestedText}", Color.Firebrick);

                            } else { // borrowed
                                if (reader.IsDBNull(reader.GetOrdinal("due_date"))) {
                                    AddUpdate($"• {title} - Borrowed (no due date set)", Color.Gray);
                                } else {
                                    DateTime due = reader.GetDateTime("due_date");
                                    TimeSpan left = due - DateTime.Now;

                                    if (left < TimeSpan.Zero)
                                        AddUpdate($"• {title} - OVERDUE by {FormatSpan(-left)}", Color.Red);
                                    else if (left <= DueSoonWindow)
                                        AddUpdate($"• {title} - Due {due:MMM dd, h:mm tt} ({FormatSpan(left)} left)", Color.DarkOrange);
                                    else
                                        AddUpdate($"• {title} - Due {due:MMM dd, h:mm tt}", Color.Black);
                                }
                            }
                            count++;
                        }
                    }
                }
            } catch (MySqlException ex) {
                rtbUpdates.Clear();
                AddUpdate("Unable to load updates.", Color.Gray);
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return;
            }

            if (count == 0)
                AddUpdate("No updates yet.", Color.Gray);

            // Popup only for requests the student is seeing as cancelled for the first time.
            // BeginInvoke so it doesn't fire inside the Activated handler.
            if (newCancelled.Count > 0) {
                string message = "These requests were cancelled:" + Environment.NewLine + Environment.NewLine
                                 + string.Join(Environment.NewLine, newCancelled);
                BeginInvoke(new Action(() =>
                    MessageBox.Show(message, "Cancelled Requests", MessageBoxButtons.OK, MessageBoxIcon.Information)));
            }
        }

        // Formats a TimeSpan into a human-readable string, showing days, hours, or minutes as appropriate.
        private static string FormatSpan(TimeSpan t) {
            if (t.TotalDays >= 1)
                return $"{(int)t.TotalDays} day(s) {t.Hours} hr(s)";
            if (t.TotalHours >= 1)
                return $"{(int)t.TotalHours} hr(s) {t.Minutes} min(s)";
            return $"{Math.Max(1, (int)t.TotalMinutes)} min(s)";
        }

        private void btnOpenLogin_Click(object sender, EventArgs e) {
            using (var signInForm = new LogInForm()) {
                if (signInForm.ShowDialog(this) == DialogResult.OK) {
                    updateUIForLoginState();    // Refresh the updates panel after a successful login
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
                "SELECT b.book_id, b.title, b.author, b.copies_available, CASE WHEN b.copies_available > 0 THEN 'Available' " +
                "ELSE 'Unavailable' END AS book_status, " +
                "b.year_published, b.synopsis, g.genre AS genre, b.publisher " +
                "FROM books b LEFT JOIN genre g ON g.genre_id = b.genre " +
                "WHERE b.is_active = 1 AND (b.title LIKE @search OR b.author LIKE @search)", conn)) {
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

            txtSearchBox.Clear();
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
                "WHERE is_active = 1 " +
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
            // LEFT JOIN so a book with no genre still appears (shown as "Unknown").
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT " +
                    "b.book_id AS book_id, " +
                    "b.title AS title, " +
                    "b.author AS author, " +
                    "COALESCE(g.genre, 'Unknown') AS genre, " +
                    "b.publisher AS publisher, " +
                    "b.year_published AS year_published, " +
                    "b.copies_available AS copies_available, " +
                    "CASE WHEN b.copies_available > 0 THEN 'Available' ELSE 'Unavailable' END AS book_status, " +
                    "b.synopsis AS synopsis " +
                "FROM books b " +
                "LEFT JOIN genre g ON b.genre = g.genre_id " +
                "WHERE b.is_active = 1 " +
                "ORDER BY b.title", conn)) {
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
            using (var AccountForm = new UserControl()) {
                AccountForm.ShowDialog(this);
            }
        }

    }
}
