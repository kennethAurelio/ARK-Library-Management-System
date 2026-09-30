using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibrarySystem.Models {
    public class UserRecord {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
