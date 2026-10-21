using LibrarySystem.Core;

namespace LibrarySystem.Staff {
    public partial class StaffSignInForm : Form {
        private const string LoginIdPlaceholder = "Enter your staff id";
        private const string PasswordPlaceholder = "Password";
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color NormalTextColor = Color.Black;
        private readonly Dictionary<TextBox, string> _placeholders = new();
        public StaffSignInForm() {
            InitializeComponent();
            txtPasswordField.PasswordChar = '\0';

            InitializePlaceholder(txtLogInField, LoginIdPlaceholder);
            InitializePlaceholder(txtPasswordField, PasswordPlaceholder);

            chkShowPassword.Visible = false;
            txtPasswordField.Enter -= FocusChanged;
            txtPasswordField.Leave -= FocusChanged;
            chkShowPassword.Enter -= FocusChanged;
            chkShowPassword.Leave -= FocusChanged;
            txtPasswordField.Enter += FocusChanged;
            txtPasswordField.Leave += FocusChanged;
            chkShowPassword.Enter += FocusChanged;
            chkShowPassword.Leave += FocusChanged;

            this.ActiveControl = btnSignIn;
        }

        private readonly AuthService authentication = new AuthService();

        private void InitializePlaceholder(TextBox box, string placeholder) {
            _placeholders[box] = placeholder;

            box.Enter -= PlaceholderBox_Enter;
            box.Leave -= PlaceholderBox_Leave;
            box.Enter += PlaceholderBox_Enter;
            box.Leave += PlaceholderBox_Leave;

            RestorePlaceholder(box);
        }

        private void RestorePlaceholder(TextBox box) {
            if (string.IsNullOrWhiteSpace(box.Text)) {
                if (box == txtPasswordField)
                    box.UseSystemPasswordChar = false;
                box.Text = _placeholders[box];
                box.ForeColor = PlaceholderColor;
            }
        }

        private void PlaceholderBox_Enter(object? sender, EventArgs e) {
            if (sender is not TextBox box) return;

            if (box.Text == _placeholders[box]) {
                box.Text = string.Empty;
                box.ForeColor = NormalTextColor;
                if (box == txtPasswordField)
                    box.UseSystemPasswordChar = !chkShowPassword.Checked;
            }
        }

        private void PlaceholderBox_Leave(object? sender, EventArgs e) {
            if (sender is not TextBox box) return;

            if (string.IsNullOrWhiteSpace(box.Text)) {
                RestorePlaceholder(box);
            }
        }

        private string ReadText(TextBox box) {
            return box.Text == _placeholders[box] ? string.Empty : box.Text;
        }

        private void ResetField(TextBox box) {
            box.Clear();
            if (!box.Focused)
                RestorePlaceholder(box);
        }

        private void FocusChanged(object? sender, EventArgs e) {
            if (IsHandleCreated)
                BeginInvoke(new Action(UpdateShowCheckbox));
        }

        private void UpdateShowCheckbox() {
            chkShowPassword.Visible = txtPasswordField.Focused || chkShowPassword.Focused;
        }

        private void btnSignIn_Click(object sender, EventArgs e) {
            string loginId = ReadText(txtLogInField);
            string password = ReadText(txtPasswordField);

            if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(password)) {
                MessageBox.Show("Please enter both your Student ID and Password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(loginId)) {
                    txtLogInField.Focus();
                } else {
                    txtPasswordField.Focus();
                }

                return;
            }

            CurrentUser user = authentication.ValidateLogin(loginId, password);

            if (user != null) {
                bool isStaff = user.Role.Equals("librarian", StringComparison.OrdinalIgnoreCase)
                            || user.Role.Equals("admin", StringComparison.OrdinalIgnoreCase);

                if (!isStaff) {
                    MessageBox.Show("This account does not have staff access. Please use the student app.",
                                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetField(txtLogInField);
                    ResetField(txtPasswordField);
                    return;
                }

                LoggedInUser.UserId = user.UserId;
                LoggedInUser.FirstName = user.FirstName;
                LoggedInUser.MiddleName = user.MiddleName;
                LoggedInUser.LastName = user.LastName;
                LoggedInUser.Role = user.Role;
                LoggedInUser.isLoggedIn = true;

                MessageBox.Show($"Welcome, {LoggedInUser.FullName}!", "Login Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                StaffDashboard staffDashboard = new StaffDashboard();
                staffDashboard.FormClosed += (s, args) => Application.Exit();
                staffDashboard.Show();
                this.Hide();
            } else {
                MessageBox.Show("Invalid credentials. Please try again.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetField(txtLogInField);
                ResetField(txtPasswordField);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e) {
            if (txtPasswordField.Text != PasswordPlaceholder)
                txtPasswordField.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

    }
}
