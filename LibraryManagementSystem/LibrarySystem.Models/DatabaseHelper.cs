using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Models {
    internal class DatabaseHelper {
        private static readonly string connectionString =
            "Server=localhost;Database=ark_db;Uid=root;Pwd=SQLAurelio;";

        public static MySqlConnection GetConnection() {
            return new MySqlConnection(connectionString);
        }
    }
}
