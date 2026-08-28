using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace LibrarySystem.Models
{
    public partial class HomePageForm : Form {
        private const string SearchPlaceholder = "Search by title or author...";
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color NormalTextColor = Color.Black;

        public HomePageForm() {
            InitializeComponent();
            // Initialize placeholder for the search box
            InitializeSearchPlaceholder();
            this.ActiveControl = btnSearch;
        }

        // This method is called when the form is loaded. It checks the login state and updates the UI accordingly.
        private void HomePageForm_Load(object sender, EventArgs e) {
            updateUIForLoginState();
        }

        private void updateUIForLoginState() {
            if (CurrentUser.isLoggedIn) {
                btnOpenLogin.Visible = false;
                btnLogout.Visible = true;
            }
        }

        private void btnOpenLogin_Click(object sender, EventArgs e) {
            SignInForm signInForm = new SignInForm();
            Hide();
            signInForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(
                    "Do you really want to log out?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes) {
                MessageBox.Show("You have been logged out.");
                Environment.Exit(0);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string searchTerm = txtSearchBox.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm)) {
                MessageBox.Show("Please enter a search term.", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String query = @"SELECT
                                title, 
                                author, 
                                year_published, 
                                synopsis, 
                                genre, 
                                publisher, 
                                copies_available, 
                                status
                            FROM books 
                            WHERE title LIKE @search OR author LIKE @search";

            using (MySqlConnection conn = DatabaseHelper.GetConnection()) {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Pass results to SearchResultsForm
                        if (dt.Rows.Count > 0) {
                            SearchResultForm resultsForm = new SearchResultForm(dt);
                            resultsForm.Show();
                            // Reset the search box to show the placeholder again
                            RestoreSearchPlaceholder();
                        } else {
                            MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RestoreSearchPlaceholder();
                        }
                    }
                }
            }
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
    }
}
