using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem.Models {
    public partial class LoanForm : Form {
        public LoanForm(int bookId, int userId) {
            InitializeComponent();
            bookId = bookId;
            userId = userId;
        }
    }
}
