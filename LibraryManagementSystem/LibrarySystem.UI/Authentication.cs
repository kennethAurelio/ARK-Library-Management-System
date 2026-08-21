using MySql.Data.MySqlClient;


namespace LibrarySystem.UI {
    public class AuthService {
        private readonly string connectionString = "Server=localhost;Database=ark_db;Uid=root;Pwd=SQLAurelio;";

        public UserRecord validateLogin(string studentID, string password) {
            using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                string query = "SELECT user_id, full_name, role, password FROM accounts WHERE member_id = @member_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@member_id", studentID);
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            // Convert the stored password hash to a string for comparison
                            string storedHash = reader["password"].ToString();

                            if (BCrypt.Net.BCrypt.Verify(password, storedHash)) {
                                return new UserRecord {
                                    MemberID = reader.GetInt32("user_id"),
                                    FullName = reader["full_name"].ToString(),
                                    Role = reader["role"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
