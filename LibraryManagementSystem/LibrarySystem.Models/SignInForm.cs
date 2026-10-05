using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem.Models {

    public partial class SignInForm : Form {
        private const string MemberIdPlaceholder = "Student/Login ID";
        private const string PasswordPlaceholder = "Password";
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color NormalTextColor = Color.Black;

        // Which placeholder belongs to which TextBox.
        private readonly Dictionary<TextBox, string> _placeholders = new();

        public SignInForm() {
            InitializeComponent();

            // Masking is handled by UseSystemPasswordChar now, so the old '*' must be off
            // (otherwise the placeholder would show as asterisks).
            txtPassword.PasswordChar = '\0';

            InitializePlaceholder(txtMemberID, MemberIdPlaceholder);
            InitializePlaceholder(txtPassword, PasswordPlaceholder);

            // Show-password checkbox: only visible while the password box (or the checkbox) has focus.
            chkShowPassword.Visible = false;
            txtPassword.Enter -= FocusChanged;
            txtPassword.Leave -= FocusChanged;
            chkShowPassword.Enter -= FocusChanged;
            chkShowPassword.Leave -= FocusChanged;
            txtPassword.Enter += FocusChanged;
            txtPassword.Leave += FocusChanged;
            chkShowPassword.Enter += FocusChanged;
            chkShowPassword.Leave += FocusChanged;

            // Keeps focus off the first TextBox so its placeholder doesn't vanish when the form opens.
            this.ActiveControl = btnSignIn;
        }

        private readonly AuthService authentication = new AuthService();

        private void btnSignIn_Click(object sender, EventArgs e) {
            // ReadText returns "" when a box only shows its placeholder.
            string memberId = ReadText(txtMemberID);
            string password = ReadText(txtPassword);

            // Validate that both fields are filled.
            if (string.IsNullOrWhiteSpace(memberId) || string.IsNullOrWhiteSpace(password)) {
                MessageBox.Show("Please enter both your Student ID and Password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(memberId)) {
                    txtMemberID.Focus();
                } else {
                    txtPassword.Focus();
                }

                return;
            }

            CurrentUser user = authentication.ValidateLogin(memberId, password);

            if (user != null) {
                LoggedInUser.UserId = user.UserId;
                LoggedInUser.FirstName = user.FirstName;
                LoggedInUser.MiddleName = user.MiddleName;
                LoggedInUser.LastName = user.LastName;
                LoggedInUser.Role = user.Role;
                LoggedInUser.isLoggedIn = true;


                if (LoggedInUser.Role == "admin") {
                    MessageBox.Show($"Welcome, {LoggedInUser.FullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show($"Welcome, {LoggedInUser.FullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            } else {
                MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetField(txtMemberID);
                ResetField(txtPassword);
            }

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e) {
            if (txtPassword.Text != PasswordPlaceholder)   // never mask the placeholder text
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        // Placeholder logic

        private void InitializePlaceholder(TextBox box, string placeholder) {
            _placeholders[box] = placeholder;

            box.Enter -= PlaceholderBox_Enter;
            box.Leave -= PlaceholderBox_Leave;
            box.Enter += PlaceholderBox_Enter;
            box.Leave += PlaceholderBox_Leave;

            RestorePlaceholder(box);
        }

        // Shows the placeholder text if the box is empty.
        private void RestorePlaceholder(TextBox box) {
            if (string.IsNullOrWhiteSpace(box.Text)) {
                if (box == txtPassword)
                    box.UseSystemPasswordChar = false;   // so the placeholder is readable, not dots
                box.Text = _placeholders[box];
                box.ForeColor = PlaceholderColor;
            }
        }

        // Clears the placeholder when the user clicks into the box.
        private void PlaceholderBox_Enter(object? sender, EventArgs e) {
            if (sender is not TextBox box) return;

            if (box.Text == _placeholders[box]) {
                box.Text = string.Empty;
                box.ForeColor = NormalTextColor;
                if (box == txtPassword)
                    box.UseSystemPasswordChar = !chkShowPassword.Checked;   // masked unless "show" is ticked
            }
        }

        // Brings the placeholder back if the user leaves the box empty.
        private void PlaceholderBox_Leave(object? sender, EventArgs e) {
            if (sender is not TextBox box) return;

            if (string.IsNullOrWhiteSpace(box.Text)) {
                RestorePlaceholder(box);
            }
        }

        // Returns "" when the box only shows its placeholder, so "Password" is never read as a real password.
        private string ReadText(TextBox box) {
            return box.Text == _placeholders[box] ? string.Empty : box.Text;
        }

        // a focused box restores its placeholder when it loses focus
        private void ResetField(TextBox box) {
            box.Clear();
            if (!box.Focused)          
                RestorePlaceholder(box);
        }

        // Show-password checkbox visibility 

        private void FocusChanged(object? sender, EventArgs e) {
            // Wait until focus has actually moved, so clicking the checkbox doesn't hide it first.
            if (IsHandleCreated)
                BeginInvoke(new Action(UpdateShowCheckbox));
        }

        private void UpdateShowCheckbox() {
            chkShowPassword.Visible = txtPassword.Focused || chkShowPassword.Focused;
        }

        // Password hashing test button
        private void button1_Click(object sender, EventArgs e) {
            string hash = BCrypt.Net.BCrypt.HashPassword("password123467");
            MessageBox.Show(hash);
        }

    }
}