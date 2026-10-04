using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem.Models {
    public partial class AccountForm : Form {
        public AccountForm() {
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo() {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(
                @"SELECT 
                    a.user_id,
                    a.login_id,
                    CONCAT_WS(' ', a.first_name, NULLIF(a.middle_name, ''), a.last_name) AS full_name,
                    si.education_level,
                    ss.strand_code,
                    si.section,
                    a.role
                FROM accounts a
                JOIN student_infos si ON a.user_id = si.user_id
                LEFT JOIN shs_strands ss ON si.strand_id = ss.strand_id
                WHERE a.user_id = @userId", conn)) {

                cmd.Parameters.AddWithValue("@userId", CurrentUser.UserId);
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        lblStudentName.Text = "Student Name: " + reader["full_name"].ToString();
                        lblStudentId.Text = "Student ID: " + reader["login_id"].ToString();
                        lblStrandAndSection.Text = "Strand and Section: " + reader["strand_code"].ToString() + " - " + reader["section"].ToString();
                        lblYearLevel.Text = "Year Level: Senior High School";
                        lblPrivilege.Text = "Privilege: " + reader["role"].ToString();
                    }
                }
            }
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
