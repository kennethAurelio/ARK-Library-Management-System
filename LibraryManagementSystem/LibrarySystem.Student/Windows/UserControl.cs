using LibrarySystem.Core;

namespace LibrarySystem.Student {
    public partial class UserControl : Form {
        public UserControl() {
            InitializeComponent();
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

                            lblStudentName.Text = "Student Name: " + fullName;
                            lblStudentId.Text = "Student/login Id: " + loginId;
                            if (string.IsNullOrEmpty(strandCode) && string.IsNullOrEmpty(section)) {
                                lblStrandAndSection.Text = "Strand and Section: Unable to load";
                            } else {
                                var strandSection = string.IsNullOrEmpty(strandCode) ? section : (string.IsNullOrEmpty(section) ? strandCode : $"{strandCode} - {section}");
                                lblStrandAndSection.Text = "Strand and Section: " + strandSection;
                            }
                            lblGradeLevel.Text = "Year Level: " + yearLevel;
                        } else {
                            lblStudentName.Text = "Student Name: Unable to load";
                            lblStudentId.Text = "Student/login Id: Unable to load";
                            lblStrandAndSection.Text = "Strand and Section: Unable to load";
                            lblGradeLevel.Text = "Year Level: Unable to load";
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStudentName.Text = "Student Name: Failed to load";
                lblStudentId.Text = "Student/login Id: Failed to load";
                lblStrandAndSection.Text = "Strand and Section: Failed to load";
                lblGradeLevel.Text = "Year Level: Failed to load";
            }
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
