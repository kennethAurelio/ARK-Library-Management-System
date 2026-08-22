using MySql.Data.MySqlClient;
using System.Data;

namespace LibrarySystem.Models
{
    public partial class HomePageForm : Form {
        public HomePageForm() {
            InitializeComponent();
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
                                status, 
                                date_added 
                            FROM books 
                            WHERE title LIKE @search OR author LIKE @search";

            using (MySqlConnection conn = DatabaseHelper.GetConnection()) {
                conn.Open();
                
                using(MySqlCommand cmd = new MySqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Pass results to SearchResultsForm
                        if (dt.Rows.Count > 0) {
                            SearchResultForm resultsForm = new SearchResultForm(dt);
                            resultsForm.Show();
                        } else {
                            MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

    }
}
