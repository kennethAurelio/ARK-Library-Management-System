namespace LibrarySystem.Student {
    public partial class RulesForm : Form {
        public RulesForm() {
            InitializeComponent();
            btnConfirm.Enabled = false;
            chkAgree.CheckedChanged += (s, e) => btnConfirm.Enabled = chkAgree.Checked; // Enable the confirm button only when the checkbox is checked

            txtRules.Text =
                "1. Books must be returned within 3 days from the date they are borrowed." + Environment.NewLine + Environment.NewLine +
                "2. A ₱5.00 fine per day will be charged for every day a book is returned late." + Environment.NewLine + Environment.NewLine +
                "3. Handle the book with care. Do not write on, tear, or damage any page or the cover." + Environment.NewLine + Environment.NewLine +
                "4. If a book is damaged or lost, the borrower must replace it with the exact same book title and edition, or a newer edition of the same book." + Environment.NewLine + Environment.NewLine +
                "5. Do not lend the borrowed book to other people." + Environment.NewLine + Environment.NewLine +
                "6. Reserved books must be claimed within 2 days. Unclaimed reservations will be cancelled by the librarian." + Environment.NewLine + Environment.NewLine +
                "7. Submitting a book request only reserves the book. It becomes an official loan once the librarian hands the book to the borrower." + Environment.NewLine + Environment.NewLine +
                "Failure to follow these rules may affect your future borrowing privileges.";

            this.ActiveControl = chkAgree;
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            if (!chkAgree.Checked) return; // safety check

            DialogResult = DialogResult.OK;
        }
    }
}
