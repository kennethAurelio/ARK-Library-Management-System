using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models {
    public static class CurrentUser {
        public static int UserId { get; set; }
        public static string FirstName { get; set; }
        public static string MiddleName { get; set; }
        public static string LastName { get; set; }
        public static string FullName => string.Join(" ", new[] { FirstName, MiddleName, LastName }.Where(name => !string.IsNullOrWhiteSpace(name)));
        public static string Role {  get; set; }
        public static bool isLoggedIn = false;
    }
}
