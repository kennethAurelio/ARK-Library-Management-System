using LibrarySystem.Core;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Staff {
    public partial class StaffDashboard {

        private const string ArchivedUsersQuery = @"
            SELECT a.user_id,
                   a.login_id AS student_id,
                   CONCAT(a.first_name, ' ', COALESCE(a.middle_name, ''), ' ', a.last_name) AS student_name,
                   a.account_status
            FROM accounts a
            WHERE a.account_status = 'archived'
            ORDER BY a.last_name, a.first_name";

        private void InitArchivedTab() {
            GridHelper.Style(dgvArchivedUsers);
            LoadArchivedUsers();
        }

        private void LoadArchivedUsers() {
            GridHelper.Bind(dgvArchivedUsers, LoadTable(ArchivedUsersQuery));

            // Hide the internal id, but keep it for the restore button
            if (dgvArchivedUsers.Columns.Contains("user_id"))
                dgvArchivedUsers.Columns["user_id"].Visible = false;

            SetHeader(dgvArchivedUsers, "student_id", "Student ID");
            SetHeader(dgvArchivedUsers, "student_name", "Name");
            SetHeader(dgvArchivedUsers, "account_status", "Status");
        }

        private static void SetHeader(DataGridView grid, string column, string text) {
            if (grid.Columns.Contains(column))
                grid.Columns[column].HeaderText = text;
        }

        private void btnRestoreUser_Click(object sender, EventArgs e) {
            if (dgvArchivedUsers.CurrentRow == null) {
                MessageBox.Show("Select an archived user first.", "No selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvArchivedUsers.CurrentRow.Cells["user_id"].Value);
            string studentId = dgvArchivedUsers.CurrentRow.Cells["student_id"].Value?.ToString() ?? "this user";

            if (MessageBox.Show($"Restore {studentId} to active?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySqlCommand(
                    "UPDATE accounts SET account_status = 'active' " +
                    "WHERE user_id = @id AND account_status = 'archived'", conn)) {
                    cmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            } catch (MySqlException ex) {
                MessageBox.Show("Could not restore the user.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadArchivedUsers();
            LoadAccounts();
        }

    }
}
