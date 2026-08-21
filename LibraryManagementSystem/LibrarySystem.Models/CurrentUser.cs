using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models {
    public static class CurrentUser {
        public static int MemberID { get; set; }
        public static string FullName { get; set; }
        public static string Role {  get; set; }
        public static bool isLoggedIn = false;
    }
}
