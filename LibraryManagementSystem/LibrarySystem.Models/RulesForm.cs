using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem.Models {
    public partial class RulesForm : Form {
        public RulesForm() {
            InitializeComponent();
            btnConfirm.Enabled = false;
            chkAgree.CheckedChanged += (s, e) => btnConfirm.Enabled = chkAgree.Checked; // Enable the confirm button only when the checkbox is checked

            txtRules.Text =
                "1. Return the book on or before the due date." + Environment.NewLine + Environment.NewLine +
                "2. Handle the book with care. Do not write on, tear, or damage any page or the cover." + Environment.NewLine + Environment.NewLine +
                "3. Late returns may be subject to penalties set by the library." + Environment.NewLine + Environment.NewLine +
                "4. If the book is lost or damaged, you must replace it with the same title or pay its replacement cost, as decided by the librarian." + Environment.NewLine + Environment.NewLine +
                "5. Do not lend the book to other people." + Environment.NewLine + Environment.NewLine +
                "6. Reserved books must be claimed within 2 days. Unclaimed requests are automatically cancelled." + Environment.NewLine + Environment.NewLine +
                "7. Submitting this request only reserves the book. It becomes an official loan once the librarian hands it to you." + Environment.NewLine + Environment.NewLine +
                "Failure to follow these rules may affect your future borrowing privileges.";

            this.ActiveControl = chkAgree;
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            if (!chkAgree.Checked) return; // safety check

            DialogResult = DialogResult.OK;
        }
    }
}
