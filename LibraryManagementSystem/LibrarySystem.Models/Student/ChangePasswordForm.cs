using MySql.Data.MySqlClient;
using LibrarySystem.Core;

namespace LibrarySystem.Student {
    public partial class ChangePasswordForm : Form {
        private const int MinPasswordLength = 8;
        private const string CurrentPasswordPlaceholder = "Current Password";
        private const string NewPasswordPlaceholder = "New Password";
        private const string ConfirmPasswordPlaceholder = "Re-type new password";
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color NormalTextColor = Color.Black;

        // Which placeholder / "show password" checkbox belongs to which TextBox.
        private readonly Dictionary<TextBox, string> _placeholders = new();
        private readonly Dictionary<TextBox, CheckBox> _showChecks = new();

        public ChangePasswordForm() {
            InitializeComponent();

            InitializePasswordBox(txtCurrentPassword, CurrentPasswordPlaceholder, chkShowPassword_current);
            InitializePasswordBox(txtNewPassword, NewPasswordPlaceholder, chkShowPassword_new);
            InitializePasswordBox(txtConfirmPassword, ConfirmPasswordPlaceholder, chkShowPassword_confirm);

            // Keeps focus off the first TextBox so its placeholder doesn't vanish when the form opens.
            this.ActiveControl = btnChangePassword;

            foreach (var box in new[] { txtCurrentPassword, txtNewPassword, txtConfirmPassword }) {
                box.TextChanged -= PasswordBox_TextChanged;
                box.TextChanged += PasswordBox_TextChanged;
            }
            UpdateChangeButtonState();
        }

        private void PasswordBox_TextChanged(object? sender, EventArgs e) {
            UpdateChangeButtonState();
        }

        // ReadPassword returns "" for a box that only shows its placeholder,
        // so "Current Password" etc. never count as filled-in text.
        private void UpdateChangeButtonState() {
            btnChangePassword.Enabled =
                !string.IsNullOrWhiteSpace(ReadPassword(txtCurrentPassword)) &&
                !string.IsNullOrWhiteSpace(ReadPassword(txtNewPassword)) &&
                !string.IsNullOrWhiteSpace(ReadPassword(txtConfirmPassword));
        }

        // Wires up the placeholder + show-password behavior for one password box.
        private void InitializePasswordBox(TextBox box, string placeholder, CheckBox showCheck) {
            _placeholders[box] = placeholder;
            _showChecks[box] = showCheck;

            // -= first so handlers are never attached twice
            box.Enter -= PasswordBox_Enter;
            box.Leave -= PasswordBox_Leave;
            box.Enter -= FocusChanged;
            box.Leave -= FocusChanged;
            showCheck.Enter -= FocusChanged;
            showCheck.Leave -= FocusChanged;
            showCheck.CheckedChanged -= ShowPassword_CheckedChanged;

            box.Enter += PasswordBox_Enter;
            box.Leave += PasswordBox_Leave;
            box.Enter += FocusChanged;
            box.Leave += FocusChanged;
            showCheck.Enter += FocusChanged;
            showCheck.Leave += FocusChanged;
            showCheck.CheckedChanged += ShowPassword_CheckedChanged;

            showCheck.Visible = false;   // hidden until its TextBox has the cursor
            RestorePlaceholder(box);
        }

        // ---------- Placeholder logic ----------

        // Shows the placeholder text if the box is empty.
        private void RestorePlaceholder(TextBox box) {
            if (string.IsNullOrWhiteSpace(box.Text)) {
                box.UseSystemPasswordChar = false;   // so the placeholder is readable, not dots
                box.Text = _placeholders[box];
                box.ForeColor = PlaceholderColor;
            }
        }

        // Clears the placeholder when the user clicks into the box.
        private void PasswordBox_Enter(object? sender, EventArgs e) {
            if (sender is not TextBox box) return;

            if (box.Text == _placeholders[box]) {
                box.Text = string.Empty;
                box.ForeColor = NormalTextColor;
                box.UseSystemPasswordChar = !_showChecks[box].Checked;   // masked unless "show" is ticked
            }
        }

        // Brings the placeholder back if the user leaves the box empty.
        private void PasswordBox_Leave(object? sender, EventArgs e) {
            if (sender is not TextBox box) return;

            if (string.IsNullOrWhiteSpace(box.Text)) {
                RestorePlaceholder(box);
            }
        }

        // ---------- Show-password checkbox logic ----------

        // Runs whenever a TextBox or its checkbox gains/loses focus.
        private void FocusChanged(object? sender, EventArgs e) {
            // Wait until focus has actually moved, then decide what to show.
            // (Without this, clicking the checkbox would hide it before the click registers.)
            if (IsHandleCreated)
                BeginInvoke(new Action(UpdateShowCheckboxes));
        }

        // A checkbox is visible only while its TextBox (or the checkbox itself) has focus.
        private void UpdateShowCheckboxes() {
            foreach (var pair in _showChecks) {
                pair.Value.Visible = pair.Key.Focused || pair.Value.Focused;
            }
        }

        // Ticking the checkbox reveals or masks the password.
        private void ShowPassword_CheckedChanged(object? sender, EventArgs e) {
            if (sender is not CheckBox chk) return;

            foreach (var pair in _showChecks) {
                if (pair.Value != chk) continue;

                TextBox box = pair.Key;
                if (box.Text != _placeholders[box])      // never mask the placeholder text
                    box.UseSystemPasswordChar = !chk.Checked;
            }
        }

        // For the button later: returns "" when the box only shows its placeholder,
        // so "New Password" is never mistaken for a real password.
        private string ReadPassword(TextBox box) {
            return box.Text == _placeholders[box] ? string.Empty : box.Text;
        }

        private void btnChangePassword_Click(object sender, EventArgs e) {
            string currentPassword = ReadPassword(txtCurrentPassword);
            string newPassword = ReadPassword(txtNewPassword);
            string confirmPassword = ReadPassword(txtConfirmPassword);

            // 1. Validate the inputs before touching the database
            if (currentPassword == "" || newPassword == "" || confirmPassword == "") {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword != confirmPassword) {
                MessageBox.Show("New passwords do not match.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword.Length < MinPasswordLength) {
                MessageBox.Show($"New password must be at least {MinPasswordLength} characters.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword == currentPassword) {
                MessageBox.Show("New password must be different from your current password.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                using (var conn = DatabaseHelper.GetConnection()) {
                    conn.Open();

                    // 2. Get the stored hash and verify the current password
                    string? storedHash;
                    using (var cmd = new MySqlCommand("SELECT password FROM accounts WHERE user_id = @userId", conn)) {
                        cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);
                        storedHash = cmd.ExecuteScalar() as string;
                    }

                    if (storedHash == null) {
                        MessageBox.Show("User not found.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!BCrypt.Net.BCrypt.Verify(currentPassword, storedHash)) {
                        MessageBox.Show("Current password is incorrect.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 3. Save the new hash
                    string newHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    using (var cmd = new MySqlCommand("UPDATE accounts SET password = @newHash WHERE user_id = @userId", conn)) {
                        cmd.Parameters.AddWithValue("@newHash", newHash);
                        cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);

                        if (cmd.ExecuteNonQuery() != 1) {
                            MessageBox.Show("Could not update the password. Please try again.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            } catch (MySqlException ex) {
                MessageBox.Show("Database error: " + ex.Message, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Password changed successfully.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }
}
