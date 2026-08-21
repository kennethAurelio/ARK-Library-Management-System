using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem.UI {

    public partial class SignInForm : Form {
        public SignInForm() {
            InitializeComponent();
        }

        private readonly AuthService authentication = new AuthService();

        private void btnLogin_Click(object sender, EventArgs e) {
            // Validate that both fields are filled.
            if (string.IsNullOrWhiteSpace(txtMemberID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)) {
                MessageBox.Show("Please enter both your Student ID and Password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(txtMemberID.Text)) {
                    txtMemberID.Focus();
                } else {
                    txtPassword.Focus();
                }

                return;
            }

            UserRecord user = authentication.validateLogin(txtMemberID.Text, txtPassword.Text);

            if (user != null) {
                CurrentUser.MemberID = user.MemberID;
                CurrentUser.FullName = user.FullName;
                CurrentUser.Role = user.Role;
                CurrentUser.isLoggedIn = true;

                Hide();

                if (CurrentUser.Role == "admin") {
                    MessageBox.Show($"Welcome, {CurrentUser.FullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Student", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberID.Clear();
                txtPassword.Clear();
            }

        }

        private void btnSignIn_Click(object sender, EventArgs e) {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e) {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        // Password hashing test button
        private void button1_Click(object sender, EventArgs e) {
            string hash = BCrypt.Net.BCrypt.HashPassword("password123467");
            MessageBox.Show(hash);
        }
    }
}
