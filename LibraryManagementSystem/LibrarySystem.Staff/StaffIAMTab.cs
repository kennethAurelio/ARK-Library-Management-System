using LibrarySystem.Core;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibrarySystem.Staff {
    // Information and Account Management (IAM) tab for admins.
    public partial class StaffDashboard {

        private int? _editingUserId = null;   // null = adding a new account
        private const string DefaultPassword = "ARK@2026";
        private const string DefaultEducationLevel = "Senior High School";

        private static bool IsAdmin =>
            LoggedInUser.Role.Equals("admin", StringComparison.OrdinalIgnoreCase);

        // student_infos / shs_strands are LEFT JOINs, so admins and librarians (no student info) still show up.
        private const string AccountsQuery = @"
            SELECT a.user_id, a.login_id, a.first_name, a.middle_name, a.last_name, a.role,
                   si.education_level, si.year_level, s.strand_code, si.section
            FROM accounts a
            LEFT JOIN student_infos si ON si.user_id = a.user_id
            LEFT JOIN shs_strands s ON s.strand_id = si.strand_id
            ORDER BY FIELD(a.role, 'admin', 'librarian', 'student'), a.last_name, a.first_name";

        // Called once from the constructor, only when the logged-in user is an admin.
        private void InitAccountsTab() {
            GridHelper.Style(dgvAccounts);
            dgvAccounts.SelectionChanged += dgvAccounts_SelectionChanged;

            cbAccountRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAccountRole.Items.AddRange(new object[] { "student", "librarian", "admin" });
            cbAccountRole.SelectedIndexChanged += cbAccountRole_SelectedIndexChanged;

            // Student-only fields
            cbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbYearLevel.Items.AddRange(new object[] { "11", "12" });   // match your year_level values

            cbStrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStrand.DisplayMember = "strand_code";
            cbStrand.ValueMember = "strand_id";
            cbStrand.DataSource = LoadTable("SELECT strand_id, strand_code FROM shs_strands ORDER BY strand_code");

            // Sections come from the database, but the admin can also type a new one.
            cbSection.DropDownStyle = ComboBoxStyle.DropDown;
            foreach (DataRow row in LoadTable(
                "SELECT DISTINCT section FROM student_infos WHERE section IS NOT NULL AND section <> '' ORDER BY section").Rows)
                cbSection.Items.Add(row["section"].ToString()!);

            txtAccountPassword.UseSystemPasswordChar = true;

            LoadAccounts();
        }

        private void LoadAccounts() {
            GridHelper.Bind(dgvAccounts, LoadTable(AccountsQuery));
            StartNewAccount();
        }

        // Show the student-only fields only when the role is "student".
        private void ShowStudentFields(bool show) {
            foreach (Control c in new Control[] {
                lblEducationLevel, txtEducationLevel,
                lblYearLevel, cbYearLevel,
                lblStrand, cbStrand,
                lblSection, cbSection })
                c.Visible = show;
        }

        private void cbAccountRole_SelectedIndexChanged(object? sender, EventArgs e) {
            ShowStudentFields(string.Equals(cbAccountRole.SelectedItem?.ToString(), "student",
                                            StringComparison.OrdinalIgnoreCase));
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
            txtAccountPassword.Clear();

            // Setting the role also shows/hides the student fields (see cbAccountRole_SelectedIndexChanged).
            cbAccountRole.SelectedItem = cells["role"].Value?.ToString()?.ToLower();

            // Student info (blank for admins/librarians or students without a student_infos row)
            txtEducationLevel.Text = cells["education_level"].Value?.ToString();
            cbYearLevel.SelectedIndex = cbYearLevel.FindStringExact(cells["year_level"].Value?.ToString() ?? "");
            cbStrand.SelectedIndex = cbStrand.FindStringExact(cells["strand_code"].Value?.ToString() ?? "");
            cbSection.Text = cells["section"].Value?.ToString() ?? "";

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
            cbAccountRole.SelectedItem = "student";   // also shows the student fields

            txtEducationLevel.Text = DefaultEducationLevel;
            cbYearLevel.SelectedIndex = -1;
            cbStrand.SelectedIndex = -1;
            cbSection.Text = "";

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

            // Student accounts also need their student info.
            bool isStudent = role.Equals("student", StringComparison.OrdinalIgnoreCase);
            string educationLevel = txtEducationLevel.Text.Trim();
            string? yearLevel = cbYearLevel.SelectedItem?.ToString();
            string section = cbSection.Text.Trim();

            if (isStudent && (educationLevel == "" || yearLevel == null || cbStrand.SelectedIndex < 0 || section == "")) {
                MessageBox.Show("Education level, year level, strand, and section are required for students.",
                                "Missing Student Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                using (var conn = DatabaseHelper.GetConnection()) {
                    conn.Open();

                    // The account and its student info are saved together: both succeed or neither does.
                    // (Disposing the transaction without Commit rolls it back.)
                    using (var tx = conn.BeginTransaction()) {
                        int userId;

                        using (var cmd = new MySqlCommand(sql, conn, tx)) {
                            cmd.Parameters.AddWithValue("@loginId", loginId);
                            cmd.Parameters.AddWithValue("@firstName", firstName);
                            cmd.Parameters.AddWithValue("@middleName", middleName);
                            cmd.Parameters.AddWithValue("@lastName", lastName);
                            cmd.Parameters.AddWithValue("@role", role);
                            if (password != "")
                                cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(password));
                            if (!isAdding)
                                cmd.Parameters.AddWithValue("@userId", _editingUserId!.Value);

                            cmd.ExecuteNonQuery();
                            userId = isAdding ? (int)cmd.LastInsertedId : _editingUserId!.Value;
                        }

                        if (isStudent) {
                            using (var cmd = new MySqlCommand(
                                @"INSERT INTO student_infos (user_id, education_level, year_level, strand_id, section)
                                  VALUES (@userId, @educationLevel, @yearLevel, @strandId, @section)
                                  ON DUPLICATE KEY UPDATE education_level = VALUES(education_level),
                                                          year_level = VALUES(year_level),
                                                          strand_id = VALUES(strand_id),
                                                          section = VALUES(section)", conn, tx)) {
                                cmd.Parameters.AddWithValue("@userId", userId);
                                cmd.Parameters.AddWithValue("@educationLevel", educationLevel);
                                cmd.Parameters.AddWithValue("@yearLevel", yearLevel);
                                cmd.Parameters.AddWithValue("@strandId", Convert.ToInt32(cbStrand.SelectedValue));
                                cmd.Parameters.AddWithValue("@section", section);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                    }
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
