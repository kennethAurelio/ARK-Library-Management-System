using LibrarySystem.Core;
using MySql.Data.MySqlClient;
 
namespace LibrarySystem.Staff {
    // Information and Account Management (IAM) tab for admins.
    public partial class StaffDashboard {

        private int? _editingUserId = null;   // null = adding a new account
        private const string DefaultPassword = "ARK@2026";
        private const string DefaultEducationLevel = "Senior High School";

        public static bool IsAdmin { get; } = LoggedInUser.Role.Equals("admin", StringComparison.OrdinalIgnoreCase);
        private static readonly Dictionary<string, char> StrandLastSection =
            new(StringComparer.OrdinalIgnoreCase) {
                ["STEM"] = 'J',   // A to J
                ["TVL"] = 'D',   // A to D
                ["ABM"] = 'D',   // A to D
                ["HUMSS"] = 'E'    // A to E
            };

        // Archived accounts are left out: they are shown in their own place.
        private const string AccountsQuery = $@"
            SELECT a.user_id, a.login_id, a.first_name, a.middle_name, a.last_name, a.role,
                   si.education_level, si.grade_level, s.strand_code, si.section
            FROM accounts a
            LEFT JOIN student_infos si ON si.user_id = a.user_id
            LEFT JOIN shs_strands s ON s.strand_id = si.strand_id
            WHERE COALESCE(a.account_status, 'active') <> '{ArchivedStatus}'
            ORDER BY FIELD(a.role, 'admin', 'librarian', 'student'), a.last_name, a.first_name";

        // Archiving logic: a student can only be archived if they have no borrowed books and no unresolved penalties (lost books).
        private const string ArchivedStatus = "archived";

        // Locks the account row until the transaction ends (a new loan can't be inserted meanwhile,
        // because book_loans has a foreign key to accounts).
        private const string LockAccountQuery =
            "SELECT role, account_status FROM accounts WHERE user_id = @userId FOR UPDATE";

        // active loan  = book still Borrowed (includes overdue); a Pending request does NOT block
        // penalty      = a loan marked Lost (no penalty table exists, so Lost = unresolved penalty)
        // active loan = book still Borrowed (includes overdue); a Pending request does NOT block
        private const string ArchiveBlockersQuery = @"
            SELECT COUNT(*) AS active_loans
            FROM book_loans
            WHERE user_id = @userId
              AND status = 'Borrowed'";

        // Called once from the constructor, only when the logged-in user is an admin.
        private void InitAccountsTab() {
            GridHelper.Style(dgvAccounts);
            dgvAccounts.SelectionChanged += dgvAccounts_SelectionChanged;

            cbAccountRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAccountRole.Items.AddRange(new object[] { "student", "librarian", "admin" });
            cbAccountRole.SelectedIndexChanged += cbAccountRole_SelectedIndexChanged;

            cbGradeLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGradeLevel.Items.AddRange(new object[] { "11", "12" });
            cbGradeLevel.SelectedIndexChanged += (s, e) => { }; // dummy handler to avoid firing when binding

            cbStrand.DropDownStyle = ComboBoxStyle.DropDownList;
            BindCombo(cbStrand, "SELECT strand_id, strand_code FROM shs_strands ORDER BY strand_code",
                      "strand_code", "strand_id");
            cbStrand.SelectedIndexChanged += cbStrand_SelectedIndexChanged;   // after binding, so it doesn't fire early

            cbSection.DropDownStyle = ComboBoxStyle.DropDownList;

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
                lblGradeLevel, cbGradeLevel,
                lblStrand, cbStrand,
                lblSection, cbSection })
                c.Visible = show;
        }

        private void cbAccountRole_SelectedIndexChanged(object? sender, EventArgs e) {
            ShowStudentFields(string.Equals(cbAccountRole.SelectedItem?.ToString(), "student",
                                            StringComparison.OrdinalIgnoreCase));
        }

        // Section choices depend on the selected strand (STEM A-J, TVL A-D, ABM A-D, HUMSS A-E).
        private void cbStrand_SelectedIndexChanged(object? sender, EventArgs e) {
            cbSection.Items.Clear();

            if (cbStrand.SelectedIndex >= 0 && StrandLastSection.TryGetValue(cbStrand.Text, out char last)) {
                for (char c = 'A'; c <= last; c++)
                    cbSection.Items.Add(c.ToString());
            }
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
            cbGradeLevel.SelectedIndex = cbGradeLevel.FindStringExact(cells["grade_level"].Value?.ToString() ?? "");
            cbStrand.SelectedIndex = cbStrand.FindStringExact(cells["strand_code"].Value?.ToString() ?? "");   // fills the sections
            cbSection.SelectedIndex = cbSection.FindStringExact(cells["section"].Value?.ToString() ?? "");

            lblAccountMode.Text = $"Editing: {txtLoginId.Text}  (leave password blank to keep it)";
            btnSaveAccount.Text = "Save Changes";
            btnArchiveAccount.Enabled = true;   // archived accounts never show in this grid
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
            cbGradeLevel.SelectedIndex = -1;
            cbStrand.SelectedIndex = -1;

            lblAccountMode.Text = $"Adding a new account (blank password = {DefaultPassword})";
            btnSaveAccount.Text = "Add Account";
            btnArchiveAccount.Enabled = false;   // nothing selected, nothing to archive
            txtLoginId.Focus();
        }

        private void btnNewAccount_Click(object sender, EventArgs e) {
            StartNewAccount();
        }

        private void btnSaveAccount_Click(object sender, EventArgs e) {
            if (!IsAdmin) return;   // SAFETY NET: only admins manage accounts

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

            // SAFETY NET: Student login IDs must look like 00-00000 (2 digits, a dash, then 5 digits).
            if (role.Equals("student", StringComparison.OrdinalIgnoreCase) &&
                !System.Text.RegularExpressions.Regex.IsMatch(loginId, @"^\d{2}-\d{5}$")) {
                MessageBox.Show("Student Login ID must be in the format 00-00000 (2 digits, a dash, then 5 digits).",
                                "Invalid Login ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginId.Focus();
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
            string? yearLevel = cbGradeLevel.SelectedItem?.ToString();
            string section = cbSection.SelectedItem?.ToString() ?? "";

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
                                @"INSERT INTO student_infos (user_id, education_level, grade_level, strand_id, section)
                                  VALUES (@userId, @educationLevel, @yearLevel, @strandId, @section)
                                  ON DUPLICATE KEY UPDATE education_level = VALUES(education_level),
                                                          grade_level = VALUES(grade_level),
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

        private void btnArchiveAccount_Click(object sender, EventArgs e) {
            if (!IsAdmin) return;   // SAFETY NET: only admins manage accounts

            if (_editingUserId == null) {
                MessageBox.Show("Select an account first.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = _editingUserId.Value;
            string loginId = txtLoginId.Text.Trim();

            if (userId == LoggedInUser.UserId) {
                MessageBox.Show("You can't archive your own account.", "Not Allowed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Archive account {loginId}?\n\nThe account will be marked as archived (graduated).",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try {
                using (var conn = DatabaseHelper.GetConnection()) {
                    conn.Open();

                    // Check and update in one transaction. Leaving without Commit rolls it back.
                    using (var tx = conn.BeginTransaction()) {
                        string role;
                        string currentStatus;

                        // 1. Lock the account row and read its role/status
                        using (var cmd = new MySqlCommand(LockAccountQuery, conn, tx)) {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            using (var reader = cmd.ExecuteReader()) {
                                if (!reader.Read()) {
                                    MessageBox.Show("That account no longer exists.", "Not Found",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                role = reader["role"].ToString() ?? "";
                                currentStatus = reader["account_status"]?.ToString() ?? "";
                            }
                        }

                        if (currentStatus.Equals(ArchivedStatus, StringComparison.OrdinalIgnoreCase)) {
                            MessageBox.Show("This account is already archived.", "Already Archived",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // 2. Students: block if they still have a borrowed book
                        if (role.Equals("student", StringComparison.OrdinalIgnoreCase)) {
                            int activeLoans;

                            using (var cmd = new MySqlCommand(ArchiveBlockersQuery, conn, tx)) {
                                cmd.Parameters.AddWithValue("@userId", userId);
                                activeLoans = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            if (activeLoans > 0) {
                                MessageBox.Show(
                                    $"Can't archive {loginId} yet.\n\nThis student still has {activeLoans} borrowed book(s) not yet returned.\n\nResolve this first, then try again.",
                                    "Archive Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // 3. All clear: archive it
                        using (var cmd = new MySqlCommand(
                            "UPDATE accounts SET account_status = @status WHERE user_id = @userId", conn, tx)) {
                            cmd.Parameters.AddWithValue("@status", ArchivedStatus);
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }
            } catch (MySqlException ex) {
                MessageBox.Show("Could not archive the account.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"{loginId} has been archived.", "Archived",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadAccounts(); // refresh the grid and reset the form
            LoadArchivedUsers(); // refresh the archived users tab if it exists
        }

    }
}
