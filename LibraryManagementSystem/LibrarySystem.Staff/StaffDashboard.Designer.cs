namespace LibrarySystem.Staff {
    partial class StaffDashboard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            tabManageBooks = new TabPage();
            lblSynopsis = new Label();
            lblCopies = new Label();
            lblYear = new Label();
            lblPublisher = new Label();
            lblGenre = new Label();
            lblAuthor = new Label();
            lblTitle = new Label();
            txtSynopsis = new RichTextBox();
            lblMode = new Label();
            nudCopies = new NumericUpDown();
            btnSaveBook = new Button();
            btnNewBook = new Button();
            txtYear = new TextBox();
            txtPublisher = new TextBox();
            txtGenre = new TextBox();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            dgvCatalog = new DataGridView();
            tabReturnDesk = new TabPage();
            btnMarkReturned = new Button();
            dgvReturns = new DataGridView();
            tabLoanRequest = new TabPage();
            btnRefreshData = new Button();
            btnCancelRequest = new Button();
            btnAcceptRequest = new Button();
            dgvLoanRequest = new DataGridView();
            tabControlStaff = new TabControl();
            tabBorrowingHistory = new TabPage();
            cbFilterBy = new ComboBox();
            dgvTransactionHistory = new DataGridView();
            tabAccounts = new TabPage();
            label1 = new Label();
            txtLastName = new TextBox();
            cbAccountRole = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblAccountMode = new Label();
            btnSaveAccount = new Button();
            txtMiddleName = new TextBox();
            txtFirstName = new TextBox();
            txtAccountPassword = new TextBox();
            txtLoginId = new TextBox();
            dgvAccounts = new DataGridView();
            tabReports = new TabPage();
            btnNewAccount = new Button();
            tabManageBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCopies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            tabReturnDesk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReturns).BeginInit();
            tabLoanRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoanRequest).BeginInit();
            tabControlStaff.SuspendLayout();
            tabBorrowingHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactionHistory).BeginInit();
            tabAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            SuspendLayout();
            // 
            // tabManageBooks
            // 
            tabManageBooks.AccessibleName = "";
            tabManageBooks.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabManageBooks.Controls.Add(lblSynopsis);
            tabManageBooks.Controls.Add(lblCopies);
            tabManageBooks.Controls.Add(lblYear);
            tabManageBooks.Controls.Add(lblPublisher);
            tabManageBooks.Controls.Add(lblGenre);
            tabManageBooks.Controls.Add(lblAuthor);
            tabManageBooks.Controls.Add(lblTitle);
            tabManageBooks.Controls.Add(txtSynopsis);
            tabManageBooks.Controls.Add(lblMode);
            tabManageBooks.Controls.Add(nudCopies);
            tabManageBooks.Controls.Add(btnSaveBook);
            tabManageBooks.Controls.Add(btnNewBook);
            tabManageBooks.Controls.Add(txtYear);
            tabManageBooks.Controls.Add(txtPublisher);
            tabManageBooks.Controls.Add(txtGenre);
            tabManageBooks.Controls.Add(txtAuthor);
            tabManageBooks.Controls.Add(txtTitle);
            tabManageBooks.Controls.Add(dgvCatalog);
            tabManageBooks.Location = new Point(4, 24);
            tabManageBooks.Name = "tabManageBooks";
            tabManageBooks.Size = new Size(975, 384);
            tabManageBooks.TabIndex = 2;
            tabManageBooks.Text = "Manage Books";
            tabManageBooks.UseVisualStyleBackColor = true;
            // 
            // lblSynopsis
            // 
            lblSynopsis.AutoSize = true;
            lblSynopsis.Location = new Point(544, 214);
            lblSynopsis.Name = "lblSynopsis";
            lblSynopsis.Size = new Size(53, 15);
            lblSynopsis.TabIndex = 22;
            lblSynopsis.Text = "Synopsis";
            // 
            // lblCopies
            // 
            lblCopies.AutoSize = true;
            lblCopies.Location = new Point(739, 158);
            lblCopies.Name = "lblCopies";
            lblCopies.Size = new Size(43, 15);
            lblCopies.TabIndex = 21;
            lblCopies.Text = "Copies";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(544, 159);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(29, 15);
            lblYear.TabIndex = 20;
            lblYear.Text = "Year";
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Location = new Point(739, 112);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(56, 15);
            lblPublisher.TabIndex = 19;
            lblPublisher.Text = "Publisher";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(544, 112);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(38, 15);
            lblGenre.TabIndex = 18;
            lblGenre.Text = "Genre";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(739, 63);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(44, 15);
            lblAuthor.TabIndex = 17;
            lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(544, 63);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(30, 15);
            lblTitle.TabIndex = 16;
            lblTitle.Text = "Title";
            // 
            // txtSynopsis
            // 
            txtSynopsis.Location = new Point(544, 232);
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.Size = new Size(290, 96);
            txtSynopsis.TabIndex = 15;
            txtSynopsis.Text = "";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(544, 34);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(38, 15);
            lblMode.TabIndex = 14;
            lblMode.Text = "label1";
            // 
            // nudCopies
            // 
            nudCopies.Location = new Point(739, 177);
            nudCopies.Name = "nudCopies";
            nudCopies.Size = new Size(120, 23);
            nudCopies.TabIndex = 13;
            // 
            // btnSaveBook
            // 
            btnSaveBook.Location = new Point(863, 305);
            btnSaveBook.Name = "btnSaveBook";
            btnSaveBook.Size = new Size(75, 23);
            btnSaveBook.TabIndex = 12;
            btnSaveBook.Text = "Save Book";
            btnSaveBook.UseVisualStyleBackColor = true;
            btnSaveBook.Click += btnSaveBook_Click;
            // 
            // btnNewBook
            // 
            btnNewBook.Location = new Point(863, 246);
            btnNewBook.Name = "btnNewBook";
            btnNewBook.Size = new Size(75, 23);
            btnNewBook.TabIndex = 11;
            btnNewBook.Text = "New Book";
            btnNewBook.UseVisualStyleBackColor = true;
            btnNewBook.Click += btnNewBook_Click;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(544, 177);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(166, 23);
            txtYear.TabIndex = 10;
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(739, 129);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(166, 23);
            txtPublisher.TabIndex = 5;
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(544, 129);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(166, 23);
            txtGenre.TabIndex = 4;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(739, 81);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(166, 23);
            txtAuthor.TabIndex = 3;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(544, 81);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(166, 23);
            txtTitle.TabIndex = 2;
            // 
            // dgvCatalog
            // 
            dgvCatalog.BackgroundColor = Color.LightYellow;
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalog.Location = new Point(42, 53);
            dgvCatalog.Name = "dgvCatalog";
            dgvCatalog.Size = new Size(481, 293);
            dgvCatalog.TabIndex = 1;
            // 
            // tabReturnDesk
            // 
            tabReturnDesk.AccessibleName = "";
            tabReturnDesk.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabReturnDesk.BackgroundImageLayout = ImageLayout.Stretch;
            tabReturnDesk.Controls.Add(btnMarkReturned);
            tabReturnDesk.Controls.Add(dgvReturns);
            tabReturnDesk.Location = new Point(4, 24);
            tabReturnDesk.Name = "tabReturnDesk";
            tabReturnDesk.Padding = new Padding(3);
            tabReturnDesk.Size = new Size(975, 384);
            tabReturnDesk.TabIndex = 1;
            tabReturnDesk.Text = "Return Desk";
            tabReturnDesk.UseVisualStyleBackColor = true;
            // 
            // btnMarkReturned
            // 
            btnMarkReturned.Location = new Point(812, 289);
            btnMarkReturned.Name = "btnMarkReturned";
            btnMarkReturned.Size = new Size(107, 23);
            btnMarkReturned.TabIndex = 2;
            btnMarkReturned.Text = "Mark Returned";
            btnMarkReturned.UseVisualStyleBackColor = true;
            btnMarkReturned.Click += btnMarkReturned_Click;
            // 
            // dgvReturns
            // 
            dgvReturns.BackgroundColor = Color.LightYellow;
            dgvReturns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReturns.Location = new Point(42, 53);
            dgvReturns.Name = "dgvReturns";
            dgvReturns.Size = new Size(713, 293);
            dgvReturns.TabIndex = 1;
            // 
            // tabLoanRequest
            // 
            tabLoanRequest.AccessibleName = "";
            tabLoanRequest.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabLoanRequest.BackgroundImageLayout = ImageLayout.Stretch;
            tabLoanRequest.Controls.Add(btnRefreshData);
            tabLoanRequest.Controls.Add(btnCancelRequest);
            tabLoanRequest.Controls.Add(btnAcceptRequest);
            tabLoanRequest.Controls.Add(dgvLoanRequest);
            tabLoanRequest.Location = new Point(4, 24);
            tabLoanRequest.Name = "tabLoanRequest";
            tabLoanRequest.Padding = new Padding(3);
            tabLoanRequest.Size = new Size(975, 384);
            tabLoanRequest.TabIndex = 0;
            tabLoanRequest.Text = "Loan Requests";
            tabLoanRequest.UseVisualStyleBackColor = true;
            // 
            // btnRefreshData
            // 
            btnRefreshData.Location = new Point(837, 248);
            btnRefreshData.Name = "btnRefreshData";
            btnRefreshData.Size = new Size(75, 23);
            btnRefreshData.TabIndex = 3;
            btnRefreshData.Text = "refresh";
            btnRefreshData.UseVisualStyleBackColor = true;
            btnRefreshData.Click += btnRefreshData_Click;
            // 
            // btnCancelRequest
            // 
            btnCancelRequest.Location = new Point(822, 277);
            btnCancelRequest.Name = "btnCancelRequest";
            btnCancelRequest.Size = new Size(107, 23);
            btnCancelRequest.TabIndex = 2;
            btnCancelRequest.Text = "Cancel Request";
            btnCancelRequest.UseVisualStyleBackColor = true;
            btnCancelRequest.Click += btnCancelRequest_Click;
            // 
            // btnAcceptRequest
            // 
            btnAcceptRequest.Location = new Point(822, 306);
            btnAcceptRequest.Name = "btnAcceptRequest";
            btnAcceptRequest.Size = new Size(107, 23);
            btnAcceptRequest.TabIndex = 1;
            btnAcceptRequest.Text = "Accept Request";
            btnAcceptRequest.UseVisualStyleBackColor = true;
            btnAcceptRequest.Click += btnAcceptRequest_Click;
            // 
            // dgvLoanRequest
            // 
            dgvLoanRequest.BackgroundColor = Color.LightYellow;
            dgvLoanRequest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoanRequest.Location = new Point(42, 53);
            dgvLoanRequest.Name = "dgvLoanRequest";
            dgvLoanRequest.Size = new Size(713, 293);
            dgvLoanRequest.TabIndex = 0;
            // 
            // tabControlStaff
            // 
            tabControlStaff.Controls.Add(tabLoanRequest);
            tabControlStaff.Controls.Add(tabReturnDesk);
            tabControlStaff.Controls.Add(tabManageBooks);
            tabControlStaff.Controls.Add(tabBorrowingHistory);
            tabControlStaff.Controls.Add(tabAccounts);
            tabControlStaff.Controls.Add(tabReports);
            tabControlStaff.Location = new Point(11, 137);
            tabControlStaff.Name = "tabControlStaff";
            tabControlStaff.SelectedIndex = 0;
            tabControlStaff.Size = new Size(983, 412);
            tabControlStaff.TabIndex = 0;
            // 
            // tabBorrowingHistory
            // 
            tabBorrowingHistory.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabBorrowingHistory.BackgroundImageLayout = ImageLayout.Stretch;
            tabBorrowingHistory.Controls.Add(cbFilterBy);
            tabBorrowingHistory.Controls.Add(dgvTransactionHistory);
            tabBorrowingHistory.Location = new Point(4, 24);
            tabBorrowingHistory.Name = "tabBorrowingHistory";
            tabBorrowingHistory.Padding = new Padding(3);
            tabBorrowingHistory.Size = new Size(975, 384);
            tabBorrowingHistory.TabIndex = 3;
            tabBorrowingHistory.Text = "Borrowing History";
            tabBorrowingHistory.UseVisualStyleBackColor = true;
            // 
            // cbFilterBy
            // 
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Location = new Point(820, 103);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(121, 23);
            cbFilterBy.TabIndex = 5;
            // 
            // dgvTransactionHistory
            // 
            dgvTransactionHistory.BackgroundColor = Color.LightYellow;
            dgvTransactionHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactionHistory.Location = new Point(42, 53);
            dgvTransactionHistory.Name = "dgvTransactionHistory";
            dgvTransactionHistory.Size = new Size(713, 293);
            dgvTransactionHistory.TabIndex = 1;
            // 
            // tabAccounts
            // 
            tabAccounts.Controls.Add(btnNewAccount);
            tabAccounts.Controls.Add(label1);
            tabAccounts.Controls.Add(txtLastName);
            tabAccounts.Controls.Add(cbAccountRole);
            tabAccounts.Controls.Add(label2);
            tabAccounts.Controls.Add(label3);
            tabAccounts.Controls.Add(label5);
            tabAccounts.Controls.Add(label6);
            tabAccounts.Controls.Add(label7);
            tabAccounts.Controls.Add(lblAccountMode);
            tabAccounts.Controls.Add(btnSaveAccount);
            tabAccounts.Controls.Add(txtMiddleName);
            tabAccounts.Controls.Add(txtFirstName);
            tabAccounts.Controls.Add(txtAccountPassword);
            tabAccounts.Controls.Add(txtLoginId);
            tabAccounts.Controls.Add(dgvAccounts);
            tabAccounts.Location = new Point(4, 24);
            tabAccounts.Name = "tabAccounts";
            tabAccounts.Padding = new Padding(3);
            tabAccounts.Size = new Size(975, 384);
            tabAccounts.TabIndex = 4;
            tabAccounts.Text = "Accounts";
            tabAccounts.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(541, 214);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 43;
            label1.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(541, 232);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(166, 23);
            txtLastName.TabIndex = 42;
            // 
            // cbAccountRole
            // 
            cbAccountRole.FormattingEnabled = true;
            cbAccountRole.Location = new Point(736, 131);
            cbAccountRole.Name = "cbAccountRole";
            cbAccountRole.Size = new Size(121, 23);
            cbAccountRole.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(736, 114);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 39;
            label2.Text = "Role";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(541, 161);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 38;
            label3.Text = "Middle Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(541, 114);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 36;
            label5.Text = "First Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(736, 65);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 35;
            label6.Text = "Password";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(541, 65);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 34;
            label7.Text = "Login Id";
            // 
            // lblAccountMode
            // 
            lblAccountMode.AutoSize = true;
            lblAccountMode.Location = new Point(541, 36);
            lblAccountMode.Name = "lblAccountMode";
            lblAccountMode.Size = new Size(38, 15);
            lblAccountMode.TabIndex = 32;
            lblAccountMode.Text = "label1";
            // 
            // btnSaveAccount
            // 
            btnSaveAccount.Location = new Point(541, 325);
            btnSaveAccount.Name = "btnSaveAccount";
            btnSaveAccount.Size = new Size(97, 23);
            btnSaveAccount.TabIndex = 30;
            btnSaveAccount.Text = "Save Account";
            btnSaveAccount.UseVisualStyleBackColor = true;
            btnSaveAccount.Click += btnSaveAccount_Click;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(541, 179);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(166, 23);
            txtMiddleName.TabIndex = 28;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(541, 131);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(166, 23);
            txtFirstName.TabIndex = 26;
            // 
            // txtAccountPassword
            // 
            txtAccountPassword.Location = new Point(736, 83);
            txtAccountPassword.Name = "txtAccountPassword";
            txtAccountPassword.Size = new Size(166, 23);
            txtAccountPassword.TabIndex = 25;
            // 
            // txtLoginId
            // 
            txtLoginId.Location = new Point(541, 83);
            txtLoginId.Name = "txtLoginId";
            txtLoginId.Size = new Size(166, 23);
            txtLoginId.TabIndex = 24;
            // 
            // dgvAccounts
            // 
            dgvAccounts.BackgroundColor = Color.LightYellow;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(39, 55);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.Size = new Size(481, 293);
            dgvAccounts.TabIndex = 23;
            // 
            // tabReports
            // 
            tabReports.Location = new Point(4, 24);
            tabReports.Name = "tabReports";
            tabReports.Padding = new Padding(3);
            tabReports.Size = new Size(975, 384);
            tabReports.TabIndex = 5;
            tabReports.Text = "Reports";
            tabReports.UseVisualStyleBackColor = true;
            // 
            // btnNewAccount
            // 
            btnNewAccount.Location = new Point(657, 325);
            btnNewAccount.Name = "btnNewAccount";
            btnNewAccount.Size = new Size(97, 23);
            btnNewAccount.TabIndex = 44;
            btnNewAccount.Text = "New Account";
            btnNewAccount.UseVisualStyleBackColor = true;
            btnNewAccount.Click += btnNewAccount_Click;
            // 
            // StaffDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianDashboard__1556__980_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1006, 616);
            Controls.Add(tabControlStaff);
            Name = "StaffDashboard";
            Text = "JILCF - ARK";
            Load += btnRefreshData_Click;
            tabManageBooks.ResumeLayout(false);
            tabManageBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCopies).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            tabReturnDesk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReturns).EndInit();
            tabLoanRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoanRequest).EndInit();
            tabControlStaff.ResumeLayout(false);
            tabBorrowingHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactionHistory).EndInit();
            tabAccounts.ResumeLayout(false);
            tabAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabManageBooks;
        private TabPage tabReturnDesk;
        private TabPage tabLoanRequest;
        private TabControl tabControlStaff;
        private DataGridView dgvLoanRequest;
        private Button btnAcceptRequest;
        private DataGridView dgvReturns;
        private Button btnMarkReturned;
        private Button btnCancelRequest;
        private Button btnRefreshData;
        private TabPage tabBorrowingHistory;
        private DataGridView dgvCatalog;
        private TextBox txtGenre;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private TextBox txtYear;
        private TextBox txtPublisher;
        private Button btnSaveBook;
        private Button btnNewBook;
        private NumericUpDown nudCopies;
        private Label lblMode;
        private Label lblAuthor;
        private Label lblTitle;
        private RichTextBox txtSynopsis;
        private Label lblSynopsis;
        private Label lblCopies;
        private Label lblYear;
        private Label lblPublisher;
        private Label lblGenre;
        private DataGridView dgvTransactionHistory;
        private ComboBox cbFilterBy;
        private TabPage tabAccounts;
        private TabPage tabReports;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblAccountMode;
        private Button btnSaveAccount;
        private TextBox txtMiddleName;
        private TextBox txtFirstName;
        private TextBox txtAccountPassword;
        private TextBox txtLoginId;
        private DataGridView dgvAccounts;
        private ComboBox cbAccountRole;
        private Label label1;
        private TextBox txtLastName;
        private Button btnNewAccount;
    }
}