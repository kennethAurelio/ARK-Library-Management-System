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

    }
}
