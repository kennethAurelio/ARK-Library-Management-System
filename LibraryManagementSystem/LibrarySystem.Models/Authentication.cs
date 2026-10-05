using MySql.Data.MySqlClient;

namespace LibrarySystem.Models {
    public class AuthService {
        public CurrentUser ValidateLogin(string memberID, string password) {
            using (MySqlConnection conn = DatabaseHelper.GetConnection()) {
                string query = "SELECT user_id, first_name, middle_name, last_name, role, password FROM accounts WHERE login_id = @login_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@login_id", memberID);
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            string storedHash = reader["password"].ToString();

                            if (BCrypt.Net.BCrypt.Verify(password, storedHash)) {
                                return new CurrentUser {
                                    UserId = reader.GetInt32("user_id"),
                                    FirstName = reader["first_name"].ToString(),
                                    MiddleName = reader["middle_name"].ToString(),
                                    LastName = reader["last_name"].ToString(),
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
