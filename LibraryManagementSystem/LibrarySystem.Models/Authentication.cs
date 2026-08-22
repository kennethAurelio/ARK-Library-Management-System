using MySql.Data.MySqlClient;

namespace LibrarySystem.Models {
    public class AuthService {
        public UserRecord ValidateLogin(string memberID, string password) {
            using (MySqlConnection conn = DatabaseHelper.GetConnection()) {
                string query = "SELECT user_id, full_name, role, password FROM accounts WHERE member_id = @member_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@member_id", memberID);
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
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
