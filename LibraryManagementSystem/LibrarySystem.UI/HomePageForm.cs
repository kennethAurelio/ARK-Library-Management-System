namespace LibrarySystem.UI
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
                // !! Other functions. e.g. :
                // btnLogout.Visible = true;
                // load the full version
            }
        }

        private void btnOpenLogin_Click(object sender, EventArgs e) {
            SignInForm signInForm = new SignInForm();
            Hide();
            signInForm.Show();
        }
    }
}
