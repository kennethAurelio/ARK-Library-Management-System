using LibrarySystem.Core;

namespace LibrarySystem.Student {
    public partial class UserControl : Form {
        public UserControl() {
            InitializeComponent();

            // Display-only box: no caret, no typing.
            rtbUserInformation.ReadOnly = true;
            rtbUserInformation.TabStop = false;

            LoadUserInfo();
        }

        private void LoadUserInfo() {
            try {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(
                    @"SELECT
                    a.user_id,
                    a.login_id,
                    CONCAT_WS(' ', a.first_name, NULLIF(a.middle_name, ''), a.last_name) AS full_name,
                    si.grade_level,
                    ss.strand_code,
                    si.section,
                    a.role
                FROM accounts a
                JOIN student_infos si ON a.user_id = si.user_id
                LEFT JOIN shs_strands ss ON si.strand_id = ss.strand_id
                WHERE a.user_id = @userId", conn)) {

                    cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            var fullName = SafeText(reader["full_name"], "Unable to load");
                            var loginId = SafeText(reader["login_id"], "Unable to load");
                            var yearLevel = SafeText(reader["grade_level"], "Unable to load");
                            var strandCode = SafeText(reader["strand_code"], "");
                            var section = SafeText(reader["section"], "");

                            string strandSection;
                            if (string.IsNullOrEmpty(strandCode) && string.IsNullOrEmpty(section)) {
                                strandSection = "Unable to load";
                            } else {
                                strandSection = string.IsNullOrEmpty(strandCode) ? section
                                              : (string.IsNullOrEmpty(section) ? strandCode : $"{strandCode} - {section}");
                            }

                            ShowUserInfo(fullName, loginId, strandSection, yearLevel);
                        } else {
                            ShowUserInfo("Unable to load", "Unable to load", "Unable to load", "Unable to load");
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowUserInfo("Failed to load", "Failed to load", "Failed to load", "Failed to load");
            }
        }

        // Fills the RichTextBox: bold label, normal value, one line each.
        private void ShowUserInfo(string name, string loginId, string strandSection, string yearLevel) {
            rtbUserInformation.Clear();

            var bold = new Font(rtbUserInformation.Font, FontStyle.Bold);
            var regular = new Font(rtbUserInformation.Font, FontStyle.Regular);

            AddLine("Student Name: ", name, bold, regular);
            AddLine("Student/login Id: ", loginId, bold, regular);
            AddLine("Strand and Section: ", strandSection, bold, regular);
            AddLine("Year Level: ", yearLevel, bold, regular, lastLine: true);
        }

        private void AddLine(string label, string value, Font bold, Font regular, bool lastLine = false) {
            AppendStyled(label, bold);
            AppendStyled(lastLine ? value : value + Environment.NewLine, regular);
        }

        private void AppendStyled(string text, Font font) {
            rtbUserInformation.SelectionStart = rtbUserInformation.TextLength;
            rtbUserInformation.SelectionLength = 0;
            rtbUserInformation.SelectionFont = font;
            rtbUserInformation.SelectedText = text;
        }

        private string SafeText(object value, string fallback = "Unable to load") {
            return (value == null || value == DBNull.Value || string.IsNullOrEmpty(value.ToString())) ? fallback : value.ToString();
        }

        private void btnLogout_Click_1(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(
                    "Do you want to log out?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes) {
                MessageBox.Show("You have been logged out.");
                Environment.Exit(0);
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e) {
            using (var userhistoryForm = new UserHistoryForm()) {
                userhistoryForm.ShowDialog();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e) {
            using (var changePasswordForm = new ChangePasswordForm()) {
                changePasswordForm.ShowDialog();
            }
        }

    }
}
