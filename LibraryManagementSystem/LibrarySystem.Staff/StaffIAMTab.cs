using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibrarySystem.Staff {
    // Information and Account Management (IAM) tab for admins.
    public partial class StaffDashboard {

        private int? _editingUserId = null;   // null = adding a new account
        private const string DefaultPassword = "ARK@2026";

        private static bool IsAdmin =>
            LoggedInUser.Role.Equals("admin", StringComparison.OrdinalIgnoreCase);

        private const string AccountsQuery = @"
            SELECT user_id, login_id, first_name, middle_name, last_name, role
            FROM accounts
            ORDER BY FIELD(role, 'admin', 'librarian', 'student'), last_name, first_name";

        // Called once from the constructor, only when the logged-in user is an admin.
        private void InitAccountsTab() {
            GridHelper.Style(dgvAccounts);
            dgvAccounts.SelectionChanged += dgvAccounts_SelectionChanged;

            cbAccountRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAccountRole.Items.AddRange(new object[] { "student", "librarian", "admin" });

            txtAccountPassword.UseSystemPasswordChar = true;

            LoadAccounts();
        }

        private void LoadAccounts() {
            GridHelper.Bind(dgvAccounts, LoadTable(AccountsQuery));
            StartNewAccount();
        }

        // Selecting a row fills the fields and switches to edit mode.
        private void dgvAccounts_SelectionChanged(object? sender, EventArgs e) {
            if (dgvAccounts.SelectedRows.Count == 0) return;

            var cells = dgvAccounts.SelectedRows[0].Cells;
            _editingUserId = Convert.ToInt32(cells["user_id"].Value);

            txtLoginId.Text = cells["login_id"].Value?.ToString();
            txtFirstName.Text = cells["first_name"].Value?.ToString();
            txtMiddleName.Text = cells["middle_name"].Value?.ToString();
            txtLastName.Text = cells["last_name"].Value?.ToString();
            cbAccountRole.SelectedItem = cells["role"].Value?.ToString()?.ToLower();
            txtAccountPassword.Clear();

            lblAccountMode.Text = $"Editing: {txtLoginId.Text}  (leave password blank to keep it)";
            btnSaveAccount.Text = "Save Changes";
        }

        // Clears everything and switches to add mode.
        private void StartNewAccount() {
            _editingUserId = null;
            dgvAccounts.ClearSelection();

            txtLoginId.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtAccountPassword.Clear();
            cbAccountRole.SelectedItem = "student";

            lblAccountMode.Text = $"Adding a new account (blank password = {DefaultPassword})";
            btnSaveAccount.Text = "Add Account";
            txtLoginId.Focus();
        }

        private void btnNewAccount_Click(object sender, EventArgs e) {
            StartNewAccount();
        }

        private void btnSaveAccount_Click(object sender, EventArgs e) {
            if (!IsAdmin) return;   // safety net: only admins manage accounts

            string loginId = txtLoginId.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMiddleName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string password = txtAccountPassword.Text;
            bool usedDefault = _editingUserId == null && password == "";
            if (usedDefault) password = DefaultPassword;
            string? role = cbAccountRole.SelectedItem?.ToString();

            if (loginId == "" || firstName == "" || lastName == "" || role == null) {
                MessageBox.Show("Login ID, first name, last name, and role are required.", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isAdding = _editingUserId == null;

            // A password is required for a new account; when editing, blank means "keep the current one".
            if ((isAdding || password != "") && password.Length < 8) {
                MessageBox.Show("Password must be at least 8 characters.", "Weak Password",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // An admin can't change their own role (prevents locking yourself out).
            if (!isAdding && _editingUserId == LoggedInUser.UserId &&
                !role.Equals("admin", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("You can't change your own role.", "Not Allowed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql;
            if (isAdding) {
                sql = @"INSERT INTO accounts (login_id, first_name, middle_name, last_name, password, role)
                        VALUES (@loginId, @firstName, @middleName, @lastName, @password, @role)";
            } else if (password != "") {
                sql = @"UPDATE accounts
                        SET login_id = @loginId, first_name = @firstName, middle_name = @middleName,
                            last_name = @lastName, password = @password, role = @role
                        WHERE user_id = @userId";
            } else {
                sql = @"UPDATE accounts
                        SET login_id = @loginId, first_name = @firstName, middle_name = @middleName,
                            last_name = @lastName, role = @role
                        WHERE user_id = @userId";
            }

            try {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySqlCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@loginId", loginId);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@role", role);
                    if (password != "")
                        cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(password));
                    if (!isAdding)
                        cmd.Parameters.AddWithValue("@userId", _editingUserId!.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            } catch (MySqlException ex) when (ex.Number == 1062) {   // duplicate key
                MessageBox.Show("That Login ID is already taken.", "Duplicate Login ID",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } catch (MySqlException ex) {
                MessageBox.Show("Could not save the account.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(isAdding
                     ? (usedDefault ? $"Account created.\nDefault password: {DefaultPassword}" : "Account created.")
                     : "Account updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadAccounts();   // refresh the grid and reset the form to add mode
        }
    }

}
