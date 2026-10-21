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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffDashboard));
            tabManageBooks = new TabPage();
            cbGenre = new ComboBox();
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
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            dgvCatalog = new DataGridView();
            tabReturnDesk = new TabPage();
            btnMarkLostOrDamage = new Button();
            btnMarkReturned = new Button();
            dgvReturns = new DataGridView();
            tabLoanRequest = new TabPage();
            btnRefreshData = new Button();
            btnCancelRequest = new Button();
            btnAcceptRequest = new Button();
            dgvLoanRequest = new DataGridView();
            tabControlStaff = new TabControl();
            tabTransactionHistory = new TabPage();
            cbFilterBy = new ComboBox();
            dgvTransactionHistory = new DataGridView();
            tabInformationAndAccountManagement = new TabPage();
            lblSection = new Label();
            lblStrand = new Label();
            lblGradeLevel = new Label();
            lblEducationLevel = new Label();
            txtEducationLevel = new TextBox();
            cbSection = new ComboBox();
            cbStrand = new ComboBox();
            cbGradeLevel = new ComboBox();
            btnNewAccount = new Button();
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
            tableLayoutPanel2 = new TableLayoutPanel();
            tlpReportsHeader = new TableLayoutPanel();
            lblReportsTitle = new Label();
            button1 = new Button();
            tlpReportCards = new TableLayoutPanel();
            grpPending = new GroupBox();
            lblPendingCount = new Label();
            grpBorrowed = new GroupBox();
            lblBorrowedCount = new Label();
            grpOverdue = new GroupBox();
            lblOverdueCount = new Label();
            grpReturned = new GroupBox();
            lblReturnedCount = new Label();
            grpLostOrDamage = new GroupBox();
            lblLostCount = new Label();
            tlpReportPanels = new TableLayoutPanel();
            grpLoansPerMonth = new GroupBox();
            dgvMonthlyLoans = new DataGridView();
            grpOverdueLoans = new GroupBox();
            dgvOverdue = new DataGridView();
            grpLostBooks = new GroupBox();
            dgvLostBooks = new DataGridView();
            grpTopBooks = new GroupBox();
            dgvTopBooks = new DataGridView();
            grpLoansByGenre = new GroupBox();
            dgvGenreLoans = new DataGridView();
            tabManageBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCopies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            tabReturnDesk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReturns).BeginInit();
            tabLoanRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoanRequest).BeginInit();
            tabControlStaff.SuspendLayout();
            tabTransactionHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactionHistory).BeginInit();
            tabInformationAndAccountManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            tabReports.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tlpReportsHeader.SuspendLayout();
            tlpReportCards.SuspendLayout();
            grpPending.SuspendLayout();
            grpBorrowed.SuspendLayout();
            grpOverdue.SuspendLayout();
            grpReturned.SuspendLayout();
            grpLostOrDamage.SuspendLayout();
            tlpReportPanels.SuspendLayout();
            grpLoansPerMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonthlyLoans).BeginInit();
            grpOverdueLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).BeginInit();
            grpLostBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLostBooks).BeginInit();
            grpTopBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopBooks).BeginInit();
            grpLoansByGenre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGenreLoans).BeginInit();
            SuspendLayout();
            // 
            // tabManageBooks
            // 
            tabManageBooks.AccessibleName = "";
            tabManageBooks.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabManageBooks.Controls.Add(cbGenre);
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
            tabManageBooks.Controls.Add(txtAuthor);
            tabManageBooks.Controls.Add(txtTitle);
            tabManageBooks.Controls.Add(dgvCatalog);
            tabManageBooks.Location = new Point(4, 24);
            tabManageBooks.Name = "tabManageBooks";
            tabManageBooks.Size = new Size(1530, 595);
            tabManageBooks.TabIndex = 2;
            tabManageBooks.Text = "Manage Books";
            tabManageBooks.UseVisualStyleBackColor = true;
            // 
            // cbGenre
            // 
            cbGenre.FormattingEnabled = true;
            cbGenre.Location = new Point(1061, 181);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(121, 23);
            cbGenre.TabIndex = 23;
            // 
            // lblSynopsis
            // 
            lblSynopsis.AutoSize = true;
            lblSynopsis.Location = new Point(1061, 265);
            lblSynopsis.Name = "lblSynopsis";
            lblSynopsis.Size = new Size(53, 15);
            lblSynopsis.TabIndex = 22;
            lblSynopsis.Text = "Synopsis";
            // 
            // lblCopies
            // 
            lblCopies.AutoSize = true;
            lblCopies.Location = new Point(1300, 209);
            lblCopies.Name = "lblCopies";
            lblCopies.Size = new Size(43, 15);
            lblCopies.TabIndex = 21;
            lblCopies.Text = "Copies";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(1061, 210);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(29, 15);
            lblYear.TabIndex = 20;
            lblYear.Text = "Year";
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Location = new Point(1300, 163);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(56, 15);
            lblPublisher.TabIndex = 19;
            lblPublisher.Text = "Publisher";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(1061, 163);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(38, 15);
            lblGenre.TabIndex = 18;
            lblGenre.Text = "Genre";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(1300, 114);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(44, 15);
            lblAuthor.TabIndex = 17;
            lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(1061, 114);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(30, 15);
            lblTitle.TabIndex = 16;
            lblTitle.Text = "Title";
            // 
            // txtSynopsis
            // 
            txtSynopsis.Location = new Point(1061, 283);
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.Size = new Size(361, 242);
            txtSynopsis.TabIndex = 15;
            txtSynopsis.Text = "";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(1061, 73);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(38, 15);
            lblMode.TabIndex = 14;
            lblMode.Text = "label1";
            // 
            // nudCopies
            // 
            nudCopies.Location = new Point(1300, 228);
            nudCopies.Name = "nudCopies";
            nudCopies.Size = new Size(122, 23);
            nudCopies.TabIndex = 13;
            // 
            // btnSaveBook
            // 
            btnSaveBook.Location = new Point(1413, 569);
            btnSaveBook.Name = "btnSaveBook";
            btnSaveBook.Size = new Size(97, 23);
            btnSaveBook.TabIndex = 12;
            btnSaveBook.Text = "Save Book";
            btnSaveBook.UseVisualStyleBackColor = true;
            btnSaveBook.Click += btnSaveBook_Click;
            // 
            // btnNewBook
            // 
            btnNewBook.Location = new Point(1061, 569);
            btnNewBook.Name = "btnNewBook";
            btnNewBook.Size = new Size(119, 23);
            btnNewBook.TabIndex = 11;
            btnNewBook.Text = "Add New Book";
            btnNewBook.UseVisualStyleBackColor = true;
            btnNewBook.Click += btnNewBook_Click;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(1061, 228);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(199, 23);
            txtYear.TabIndex = 10;
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(1300, 180);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(199, 23);
            txtPublisher.TabIndex = 5;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(1300, 132);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(199, 23);
            txtAuthor.TabIndex = 3;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(1061, 132);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(199, 23);
            txtTitle.TabIndex = 2;
            // 
            // dgvCatalog
            // 
            dgvCatalog.BackgroundColor = Color.LightYellow;
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalog.Location = new Point(36, 73);
            dgvCatalog.Name = "dgvCatalog";
            dgvCatalog.Size = new Size(1008, 522);
            dgvCatalog.TabIndex = 1;
            // 
            // tabReturnDesk
            // 
            tabReturnDesk.AccessibleName = "";
            tabReturnDesk.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabReturnDesk.BackgroundImageLayout = ImageLayout.Stretch;
            tabReturnDesk.Controls.Add(btnMarkLostOrDamage);
            tabReturnDesk.Controls.Add(btnMarkReturned);
            tabReturnDesk.Controls.Add(dgvReturns);
            tabReturnDesk.Location = new Point(4, 24);
            tabReturnDesk.Name = "tabReturnDesk";
            tabReturnDesk.Padding = new Padding(3);
            tabReturnDesk.Size = new Size(1530, 595);
            tabReturnDesk.TabIndex = 1;
            tabReturnDesk.Text = "Return Desk";
            tabReturnDesk.UseVisualStyleBackColor = true;
            // 
            // btnMarkLostOrDamage
            // 
            btnMarkLostOrDamage.Location = new Point(1232, 572);
            btnMarkLostOrDamage.Name = "btnMarkLostOrDamage";
            btnMarkLostOrDamage.Size = new Size(116, 23);
            btnMarkLostOrDamage.TabIndex = 3;
            btnMarkLostOrDamage.Text = "Mark Lost/Damage";
            btnMarkLostOrDamage.UseVisualStyleBackColor = true;
            btnMarkLostOrDamage.Click += btnMarkLostOrDamage_click;
            // 
            // btnMarkReturned
            // 
            btnMarkReturned.Location = new Point(1101, 572);
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
            dgvReturns.Location = new Point(36, 73);
            dgvReturns.Name = "dgvReturns";
            dgvReturns.Size = new Size(1008, 522);
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
            tabLoanRequest.Size = new Size(1530, 595);
            tabLoanRequest.TabIndex = 0;
            tabLoanRequest.Text = "Loan Requests";
            tabLoanRequest.UseVisualStyleBackColor = true;
            // 
            // btnRefreshData
            // 
            btnRefreshData.BackgroundImage = Properties.Resources.refresh;
            btnRefreshData.BackgroundImageLayout = ImageLayout.Stretch;
            btnRefreshData.Location = new Point(1489, 6);
            btnRefreshData.Name = "btnRefreshData";
            btnRefreshData.Size = new Size(35, 28);
            btnRefreshData.TabIndex = 3;
            btnRefreshData.UseVisualStyleBackColor = true;
            btnRefreshData.Click += btnRefreshData_Click;
            // 
            // btnCancelRequest
            // 
            btnCancelRequest.Location = new Point(1222, 572);
            btnCancelRequest.Name = "btnCancelRequest";
            btnCancelRequest.Size = new Size(107, 23);
            btnCancelRequest.TabIndex = 2;
            btnCancelRequest.Text = "Cancel Request";
            btnCancelRequest.UseVisualStyleBackColor = true;
            btnCancelRequest.Click += btnCancelRequest_Click;
            // 
            // btnAcceptRequest
            // 
            btnAcceptRequest.Location = new Point(1089, 572);
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
            dgvLoanRequest.Location = new Point(36, 73);
            dgvLoanRequest.Name = "dgvLoanRequest";
            dgvLoanRequest.Size = new Size(1008, 522);
            dgvLoanRequest.TabIndex = 0;
            // 
            // tabControlStaff
            // 
            tabControlStaff.Controls.Add(tabLoanRequest);
            tabControlStaff.Controls.Add(tabReturnDesk);
            tabControlStaff.Controls.Add(tabManageBooks);
            tabControlStaff.Controls.Add(tabTransactionHistory);
            tabControlStaff.Controls.Add(tabInformationAndAccountManagement);
            tabControlStaff.Controls.Add(tabReports);
            tabControlStaff.Location = new Point(2, 184);
            tabControlStaff.Name = "tabControlStaff";
            tabControlStaff.SelectedIndex = 0;
            tabControlStaff.Size = new Size(1538, 623);
            tabControlStaff.TabIndex = 0;
            // 
            // tabTransactionHistory
            // 
            tabTransactionHistory.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabTransactionHistory.BackgroundImageLayout = ImageLayout.Stretch;
            tabTransactionHistory.Controls.Add(cbFilterBy);
            tabTransactionHistory.Controls.Add(dgvTransactionHistory);
            tabTransactionHistory.Location = new Point(4, 24);
            tabTransactionHistory.Name = "tabTransactionHistory";
            tabTransactionHistory.Padding = new Padding(3);
            tabTransactionHistory.Size = new Size(1530, 595);
            tabTransactionHistory.TabIndex = 3;
            tabTransactionHistory.Text = "Transaction History";
            tabTransactionHistory.UseVisualStyleBackColor = true;
            // 
            // cbFilterBy
            // 
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Location = new Point(1096, 73);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(121, 23);
            cbFilterBy.TabIndex = 5;
            // 
            // dgvTransactionHistory
            // 
            dgvTransactionHistory.BackgroundColor = Color.LightYellow;
            dgvTransactionHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactionHistory.Location = new Point(36, 73);
            dgvTransactionHistory.Name = "dgvTransactionHistory";
            dgvTransactionHistory.Size = new Size(1008, 522);
            dgvTransactionHistory.TabIndex = 1;
            // 
            // tabInformationAndAccountManagement
            // 
            tabInformationAndAccountManagement.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabInformationAndAccountManagement.Controls.Add(lblSection);
            tabInformationAndAccountManagement.Controls.Add(lblStrand);
            tabInformationAndAccountManagement.Controls.Add(lblGradeLevel);
            tabInformationAndAccountManagement.Controls.Add(lblEducationLevel);
            tabInformationAndAccountManagement.Controls.Add(txtEducationLevel);
            tabInformationAndAccountManagement.Controls.Add(cbSection);
            tabInformationAndAccountManagement.Controls.Add(cbStrand);
            tabInformationAndAccountManagement.Controls.Add(cbGradeLevel);
            tabInformationAndAccountManagement.Controls.Add(btnNewAccount);
            tabInformationAndAccountManagement.Controls.Add(label1);
            tabInformationAndAccountManagement.Controls.Add(txtLastName);
            tabInformationAndAccountManagement.Controls.Add(cbAccountRole);
            tabInformationAndAccountManagement.Controls.Add(label2);
            tabInformationAndAccountManagement.Controls.Add(label3);
            tabInformationAndAccountManagement.Controls.Add(label5);
            tabInformationAndAccountManagement.Controls.Add(label6);
            tabInformationAndAccountManagement.Controls.Add(label7);
            tabInformationAndAccountManagement.Controls.Add(lblAccountMode);
            tabInformationAndAccountManagement.Controls.Add(btnSaveAccount);
            tabInformationAndAccountManagement.Controls.Add(txtMiddleName);
            tabInformationAndAccountManagement.Controls.Add(txtFirstName);
            tabInformationAndAccountManagement.Controls.Add(txtAccountPassword);
            tabInformationAndAccountManagement.Controls.Add(txtLoginId);
            tabInformationAndAccountManagement.Controls.Add(dgvAccounts);
            tabInformationAndAccountManagement.Location = new Point(4, 24);
            tabInformationAndAccountManagement.Name = "tabInformationAndAccountManagement";
            tabInformationAndAccountManagement.Padding = new Padding(3);
            tabInformationAndAccountManagement.Size = new Size(1530, 595);
            tabInformationAndAccountManagement.TabIndex = 4;
            tabInformationAndAccountManagement.Text = "Info and Account Management";
            tabInformationAndAccountManagement.UseVisualStyleBackColor = true;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(1060, 460);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(49, 15);
            lblSection.TabIndex = 53;
            lblSection.Text = "Section:";
            lblSection.Visible = false;
            // 
            // lblStrand
            // 
            lblStrand.AutoSize = true;
            lblStrand.Location = new Point(1060, 411);
            lblStrand.Name = "lblStrand";
            lblStrand.Size = new Size(44, 15);
            lblStrand.TabIndex = 52;
            lblStrand.Text = "Strand:";
            lblStrand.Visible = false;
            // 
            // lblGradeLevel
            // 
            lblGradeLevel.AutoSize = true;
            lblGradeLevel.Location = new Point(1060, 361);
            lblGradeLevel.Name = "lblGradeLevel";
            lblGradeLevel.Size = new Size(71, 15);
            lblGradeLevel.TabIndex = 51;
            lblGradeLevel.Text = "Grade Level:";
            lblGradeLevel.Visible = false;
            // 
            // lblEducationLevel
            // 
            lblEducationLevel.AutoSize = true;
            lblEducationLevel.Location = new Point(1060, 312);
            lblEducationLevel.Name = "lblEducationLevel";
            lblEducationLevel.Size = new Size(93, 15);
            lblEducationLevel.TabIndex = 50;
            lblEducationLevel.Text = "Education Level:";
            lblEducationLevel.Visible = false;
            // 
            // txtEducationLevel
            // 
            txtEducationLevel.Enabled = false;
            txtEducationLevel.Location = new Point(1060, 330);
            txtEducationLevel.Name = "txtEducationLevel";
            txtEducationLevel.PlaceholderText = "Senior High";
            txtEducationLevel.Size = new Size(166, 23);
            txtEducationLevel.TabIndex = 49;
            txtEducationLevel.TabStop = false;
            txtEducationLevel.Visible = false;
            // 
            // cbSection
            // 
            cbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSection.FormattingEnabled = true;
            cbSection.Location = new Point(1060, 478);
            cbSection.Name = "cbSection";
            cbSection.Size = new Size(121, 23);
            cbSection.TabIndex = 48;
            cbSection.TabStop = false;
            cbSection.Visible = false;
            // 
            // cbStrand
            // 
            cbStrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStrand.FormattingEnabled = true;
            cbStrand.Location = new Point(1060, 429);
            cbStrand.Name = "cbStrand";
            cbStrand.Size = new Size(121, 23);
            cbStrand.TabIndex = 47;
            cbStrand.TabStop = false;
            cbStrand.Visible = false;
            // 
            // cbGradeLevel
            // 
            cbGradeLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGradeLevel.FormattingEnabled = true;
            cbGradeLevel.Location = new Point(1060, 379);
            cbGradeLevel.Name = "cbGradeLevel";
            cbGradeLevel.Size = new Size(121, 23);
            cbGradeLevel.TabIndex = 46;
            cbGradeLevel.TabStop = false;
            cbGradeLevel.Visible = false;
            // 
            // btnNewAccount
            // 
            btnNewAccount.Location = new Point(1196, 572);
            btnNewAccount.Name = "btnNewAccount";
            btnNewAccount.Size = new Size(97, 23);
            btnNewAccount.TabIndex = 44;
            btnNewAccount.Text = "New Account";
            btnNewAccount.UseVisualStyleBackColor = true;
            btnNewAccount.Click += btnNewAccount_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1060, 257);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 43;
            label1.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(1060, 275);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(166, 23);
            txtLastName.TabIndex = 42;
            // 
            // cbAccountRole
            // 
            cbAccountRole.FormattingEnabled = true;
            cbAccountRole.Location = new Point(1250, 174);
            cbAccountRole.Name = "cbAccountRole";
            cbAccountRole.Size = new Size(121, 23);
            cbAccountRole.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1250, 157);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 39;
            label2.Text = "Role";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1060, 204);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 38;
            label3.Text = "Middle Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1060, 157);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 36;
            label5.Text = "First Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1250, 108);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 35;
            label6.Text = "Password";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1060, 108);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 34;
            label7.Text = "Login Id";
            // 
            // lblAccountMode
            // 
            lblAccountMode.AutoSize = true;
            lblAccountMode.Location = new Point(1060, 73);
            lblAccountMode.Name = "lblAccountMode";
            lblAccountMode.Size = new Size(38, 15);
            lblAccountMode.TabIndex = 32;
            lblAccountMode.Text = "label1";
            // 
            // btnSaveAccount
            // 
            btnSaveAccount.Location = new Point(1060, 572);
            btnSaveAccount.Name = "btnSaveAccount";
            btnSaveAccount.Size = new Size(97, 23);
            btnSaveAccount.TabIndex = 30;
            btnSaveAccount.Text = "Save Account";
            btnSaveAccount.UseVisualStyleBackColor = true;
            btnSaveAccount.Click += btnSaveAccount_Click;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(1060, 222);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(166, 23);
            txtMiddleName.TabIndex = 28;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(1060, 174);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(166, 23);
            txtFirstName.TabIndex = 26;
            // 
            // txtAccountPassword
            // 
            txtAccountPassword.Location = new Point(1250, 126);
            txtAccountPassword.Name = "txtAccountPassword";
            txtAccountPassword.Size = new Size(166, 23);
            txtAccountPassword.TabIndex = 25;
            // 
            // txtLoginId
            // 
            txtLoginId.Location = new Point(1060, 126);
            txtLoginId.Name = "txtLoginId";
            txtLoginId.Size = new Size(166, 23);
            txtLoginId.TabIndex = 24;
            // 
            // dgvAccounts
            // 
            dgvAccounts.BackgroundColor = Color.LightYellow;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(36, 73);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.Size = new Size(1008, 522);
            dgvAccounts.TabIndex = 23;
            // 
            // tabReports
            // 
            tabReports.BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianTabControl__1556__980_;
            tabReports.Controls.Add(tableLayoutPanel2);
            tabReports.Location = new Point(4, 24);
            tabReports.Name = "tabReports";
            tabReports.Padding = new Padding(3);
            tabReports.Size = new Size(1530, 595);
            tabReports.TabIndex = 5;
            tabReports.Text = "Reports";
            tabReports.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tlpReportsHeader, 0, 0);
            tableLayoutPanel2.Controls.Add(tlpReportCards, 0, 1);
            tableLayoutPanel2.Controls.Add(tlpReportPanels, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1524, 589);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tlpReportsHeader
            // 
            tlpReportsHeader.ColumnCount = 2;
            tlpReportsHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpReportsHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpReportsHeader.Controls.Add(lblReportsTitle, 0, 0);
            tlpReportsHeader.Controls.Add(button1, 1, 0);
            tlpReportsHeader.Dock = DockStyle.Fill;
            tlpReportsHeader.Location = new Point(3, 3);
            tlpReportsHeader.Name = "tlpReportsHeader";
            tlpReportsHeader.RowCount = 1;
            tlpReportsHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpReportsHeader.Size = new Size(1518, 34);
            tlpReportsHeader.TabIndex = 0;
            // 
            // lblReportsTitle
            // 
            lblReportsTitle.AutoSize = true;
            lblReportsTitle.Dock = DockStyle.Fill;
            lblReportsTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReportsTitle.Location = new Point(3, 0);
            lblReportsTitle.Name = "lblReportsTitle";
            lblReportsTitle.Size = new Size(1412, 34);
            lblReportsTitle.TabIndex = 2;
            lblReportsTitle.Text = "Report";
            lblReportsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.refresh;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(1421, 3);
            button1.Name = "button1";
            button1.Size = new Size(35, 28);
            button1.TabIndex = 4;
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnRefreshData_Click;
            // 
            // tlpReportCards
            // 
            tlpReportCards.ColumnCount = 5;
            tlpReportCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpReportCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpReportCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpReportCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpReportCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpReportCards.Controls.Add(grpPending, 0, 0);
            tlpReportCards.Controls.Add(grpBorrowed, 1, 0);
            tlpReportCards.Controls.Add(grpOverdue, 2, 0);
            tlpReportCards.Controls.Add(grpReturned, 3, 0);
            tlpReportCards.Controls.Add(grpLostOrDamage, 4, 0);
            tlpReportCards.Dock = DockStyle.Fill;
            tlpReportCards.Location = new Point(3, 43);
            tlpReportCards.Name = "tlpReportCards";
            tlpReportCards.RowCount = 1;
            tlpReportCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpReportCards.Size = new Size(1518, 94);
            tlpReportCards.TabIndex = 1;
            // 
            // grpPending
            // 
            grpPending.Controls.Add(lblPendingCount);
            grpPending.Dock = DockStyle.Fill;
            grpPending.Location = new Point(3, 3);
            grpPending.Name = "grpPending";
            grpPending.Size = new Size(297, 88);
            grpPending.TabIndex = 0;
            grpPending.TabStop = false;
            grpPending.Text = "Pending";
            // 
            // lblPendingCount
            // 
            lblPendingCount.Dock = DockStyle.Fill;
            lblPendingCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblPendingCount.Location = new Point(3, 19);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(291, 66);
            lblPendingCount.TabIndex = 0;
            lblPendingCount.Text = "0";
            lblPendingCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpBorrowed
            // 
            grpBorrowed.Controls.Add(lblBorrowedCount);
            grpBorrowed.Dock = DockStyle.Fill;
            grpBorrowed.Location = new Point(306, 3);
            grpBorrowed.Name = "grpBorrowed";
            grpBorrowed.Size = new Size(297, 88);
            grpBorrowed.TabIndex = 1;
            grpBorrowed.TabStop = false;
            grpBorrowed.Text = "Borrowed";
            // 
            // lblBorrowedCount
            // 
            lblBorrowedCount.Dock = DockStyle.Fill;
            lblBorrowedCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblBorrowedCount.Location = new Point(3, 19);
            lblBorrowedCount.Name = "lblBorrowedCount";
            lblBorrowedCount.Size = new Size(291, 66);
            lblBorrowedCount.TabIndex = 0;
            lblBorrowedCount.Text = "0";
            lblBorrowedCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpOverdue
            // 
            grpOverdue.Controls.Add(lblOverdueCount);
            grpOverdue.Dock = DockStyle.Fill;
            grpOverdue.Location = new Point(609, 3);
            grpOverdue.Name = "grpOverdue";
            grpOverdue.Size = new Size(297, 88);
            grpOverdue.TabIndex = 2;
            grpOverdue.TabStop = false;
            grpOverdue.Text = "Overdue";
            // 
            // lblOverdueCount
            // 
            lblOverdueCount.Dock = DockStyle.Fill;
            lblOverdueCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblOverdueCount.ForeColor = Color.Firebrick;
            lblOverdueCount.Location = new Point(3, 19);
            lblOverdueCount.Name = "lblOverdueCount";
            lblOverdueCount.Size = new Size(291, 66);
            lblOverdueCount.TabIndex = 2;
            lblOverdueCount.Text = "0";
            lblOverdueCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpReturned
            // 
            grpReturned.Controls.Add(lblReturnedCount);
            grpReturned.Dock = DockStyle.Fill;
            grpReturned.Location = new Point(912, 3);
            grpReturned.Name = "grpReturned";
            grpReturned.Size = new Size(297, 88);
            grpReturned.TabIndex = 3;
            grpReturned.TabStop = false;
            grpReturned.Text = "Returned";
            // 
            // lblReturnedCount
            // 
            lblReturnedCount.Dock = DockStyle.Fill;
            lblReturnedCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblReturnedCount.Location = new Point(3, 19);
            lblReturnedCount.Name = "lblReturnedCount";
            lblReturnedCount.Size = new Size(291, 66);
            lblReturnedCount.TabIndex = 0;
            lblReturnedCount.Text = "0";
            lblReturnedCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpLostOrDamage
            // 
            grpLostOrDamage.Controls.Add(lblLostCount);
            grpLostOrDamage.Dock = DockStyle.Fill;
            grpLostOrDamage.Location = new Point(1215, 3);
            grpLostOrDamage.Name = "grpLostOrDamage";
            grpLostOrDamage.Size = new Size(300, 88);
            grpLostOrDamage.TabIndex = 4;
            grpLostOrDamage.TabStop = false;
            grpLostOrDamage.Text = "Lost/Damage";
            // 
            // lblLostCount
            // 
            lblLostCount.Dock = DockStyle.Fill;
            lblLostCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblLostCount.Location = new Point(3, 19);
            lblLostCount.Name = "lblLostCount";
            lblLostCount.Size = new Size(294, 66);
            lblLostCount.TabIndex = 0;
            lblLostCount.Text = "0";
            lblLostCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpReportPanels
            // 
            tlpReportPanels.ColumnCount = 3;
            tlpReportPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpReportPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpReportPanels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpReportPanels.Controls.Add(grpLoansPerMonth, 1, 1);
            tlpReportPanels.Controls.Add(grpOverdueLoans, 0, 0);
            tlpReportPanels.Controls.Add(grpLostBooks, 1, 0);
            tlpReportPanels.Controls.Add(grpTopBooks, 2, 0);
            tlpReportPanels.Controls.Add(grpLoansByGenre, 0, 1);
            tlpReportPanels.Dock = DockStyle.Fill;
            tlpReportPanels.Location = new Point(3, 143);
            tlpReportPanels.Name = "tlpReportPanels";
            tlpReportPanels.RowCount = 2;
            tlpReportPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpReportPanels.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpReportPanels.Size = new Size(1518, 443);
            tlpReportPanels.TabIndex = 2;
            // 
            // grpLoansPerMonth
            // 
            grpLoansPerMonth.Controls.Add(dgvMonthlyLoans);
            grpLoansPerMonth.Dock = DockStyle.Fill;
            grpLoansPerMonth.Location = new Point(509, 224);
            grpLoansPerMonth.Name = "grpLoansPerMonth";
            grpLoansPerMonth.Size = new Size(500, 216);
            grpLoansPerMonth.TabIndex = 0;
            grpLoansPerMonth.TabStop = false;
            grpLoansPerMonth.Text = "Loans per Month";
            // 
            // dgvMonthlyLoans
            // 
            dgvMonthlyLoans.AllowUserToAddRows = false;
            dgvMonthlyLoans.AllowUserToDeleteRows = false;
            dgvMonthlyLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonthlyLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonthlyLoans.Dock = DockStyle.Fill;
            dgvMonthlyLoans.Location = new Point(3, 19);
            dgvMonthlyLoans.MultiSelect = false;
            dgvMonthlyLoans.Name = "dgvMonthlyLoans";
            dgvMonthlyLoans.ReadOnly = true;
            dgvMonthlyLoans.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvMonthlyLoans.Size = new Size(494, 194);
            dgvMonthlyLoans.TabIndex = 0;
            // 
            // grpOverdueLoans
            // 
            grpOverdueLoans.Controls.Add(dgvOverdue);
            grpOverdueLoans.Dock = DockStyle.Fill;
            grpOverdueLoans.Location = new Point(3, 3);
            grpOverdueLoans.Name = "grpOverdueLoans";
            grpOverdueLoans.Size = new Size(500, 215);
            grpOverdueLoans.TabIndex = 0;
            grpOverdueLoans.TabStop = false;
            grpOverdueLoans.Text = "Overdue Loans";
            // 
            // dgvOverdue
            // 
            dgvOverdue.AllowUserToAddRows = false;
            dgvOverdue.AllowUserToDeleteRows = false;
            dgvOverdue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOverdue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOverdue.Dock = DockStyle.Fill;
            dgvOverdue.Location = new Point(3, 19);
            dgvOverdue.MultiSelect = false;
            dgvOverdue.Name = "dgvOverdue";
            dgvOverdue.ReadOnly = true;
            dgvOverdue.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvOverdue.Size = new Size(494, 193);
            dgvOverdue.TabIndex = 0;
            // 
            // grpLostBooks
            // 
            grpLostBooks.Controls.Add(dgvLostBooks);
            grpLostBooks.Dock = DockStyle.Fill;
            grpLostBooks.Location = new Point(509, 3);
            grpLostBooks.Name = "grpLostBooks";
            grpLostBooks.Size = new Size(500, 215);
            grpLostBooks.TabIndex = 1;
            grpLostBooks.TabStop = false;
            grpLostBooks.Text = "Lost or Damage Books";
            // 
            // dgvLostBooks
            // 
            dgvLostBooks.AllowUserToAddRows = false;
            dgvLostBooks.AllowUserToDeleteRows = false;
            dgvLostBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLostBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLostBooks.Dock = DockStyle.Fill;
            dgvLostBooks.Location = new Point(3, 19);
            dgvLostBooks.MultiSelect = false;
            dgvLostBooks.Name = "dgvLostBooks";
            dgvLostBooks.ReadOnly = true;
            dgvLostBooks.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvLostBooks.Size = new Size(494, 193);
            dgvLostBooks.TabIndex = 0;
            // 
            // grpTopBooks
            // 
            grpTopBooks.Controls.Add(dgvTopBooks);
            grpTopBooks.Dock = DockStyle.Fill;
            grpTopBooks.Location = new Point(1015, 3);
            grpTopBooks.Name = "grpTopBooks";
            grpTopBooks.Size = new Size(500, 215);
            grpTopBooks.TabIndex = 2;
            grpTopBooks.TabStop = false;
            grpTopBooks.Text = "Top Books";
            // 
            // dgvTopBooks
            // 
            dgvTopBooks.AllowUserToAddRows = false;
            dgvTopBooks.AllowUserToDeleteRows = false;
            dgvTopBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopBooks.Dock = DockStyle.Fill;
            dgvTopBooks.Location = new Point(3, 19);
            dgvTopBooks.MultiSelect = false;
            dgvTopBooks.Name = "dgvTopBooks";
            dgvTopBooks.ReadOnly = true;
            dgvTopBooks.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvTopBooks.Size = new Size(494, 193);
            dgvTopBooks.TabIndex = 0;
            // 
            // grpLoansByGenre
            // 
            grpLoansByGenre.Controls.Add(dgvGenreLoans);
            grpLoansByGenre.Dock = DockStyle.Fill;
            grpLoansByGenre.Location = new Point(3, 224);
            grpLoansByGenre.Name = "grpLoansByGenre";
            grpLoansByGenre.Size = new Size(500, 216);
            grpLoansByGenre.TabIndex = 4;
            grpLoansByGenre.TabStop = false;
            grpLoansByGenre.Text = "Loans by Genre";
            // 
            // dgvGenreLoans
            // 
            dgvGenreLoans.AllowUserToAddRows = false;
            dgvGenreLoans.AllowUserToDeleteRows = false;
            dgvGenreLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGenreLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGenreLoans.Dock = DockStyle.Fill;
            dgvGenreLoans.Location = new Point(3, 19);
            dgvGenreLoans.MultiSelect = false;
            dgvGenreLoans.Name = "dgvGenreLoans";
            dgvGenreLoans.ReadOnly = true;
            dgvGenreLoans.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvGenreLoans.Size = new Size(494, 194);
            dgvGenreLoans.TabIndex = 1;
            // 
            // StaffDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianDashboard__1556__980_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1540, 941);
            Controls.Add(tabControlStaff);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StaffDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JILCF - ARK_STAFF";
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
            tabTransactionHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactionHistory).EndInit();
            tabInformationAndAccountManagement.ResumeLayout(false);
            tabInformationAndAccountManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            tabReports.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tlpReportsHeader.ResumeLayout(false);
            tlpReportsHeader.PerformLayout();
            tlpReportCards.ResumeLayout(false);
            grpPending.ResumeLayout(false);
            grpBorrowed.ResumeLayout(false);
            grpOverdue.ResumeLayout(false);
            grpReturned.ResumeLayout(false);
            grpLostOrDamage.ResumeLayout(false);
            tlpReportPanels.ResumeLayout(false);
            grpLoansPerMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMonthlyLoans).EndInit();
            grpOverdueLoans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).EndInit();
            grpLostBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLostBooks).EndInit();
            grpTopBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopBooks).EndInit();
            grpLoansByGenre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGenreLoans).EndInit();
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
        private TabPage tabTransactionHistory;
        private DataGridView dgvCatalog;
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
        private TabPage tabReports;
        private ComboBox cbGenre;
        private TabPage tabInformationAndAccountManagement;
        private ComboBox cbSection;
        private ComboBox cbStrand;
        private ComboBox cbGradeLevel;
        private Button btnNewAccount;
        private Label label1;
        private TextBox txtLastName;
        private ComboBox cbAccountRole;
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
        private Label lblSection;
        private Label lblStrand;
        private Label lblGradeLevel;
        private Label lblEducationLevel;
        private TextBox txtEducationLevel;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tlpReportsHeader;
        private TableLayoutPanel tlpReportCards;
        private TableLayoutPanel tlpReportPanels;
        private Label lblReportsTitle;
        private GroupBox grpPending;
        private GroupBox grpBorrowed;
        private GroupBox grpOverdue;
        private GroupBox grpReturned;
        private GroupBox grpLostOrDamage;
        private Label lblPendingCount;
        private Label lblBorrowedCount;
        private Label lblOverdueCount;
        private Label lblReturnedCount;
        private Label lblLostCount;
        private GroupBox grpLoansPerMonth;
        private GroupBox grpOverdueLoans;
        private GroupBox grpLostBooks;
        private GroupBox grpTopBooks;
        private GroupBox grpLoansByGenre;
        private DataGridView dgvOverdue;
        private DataGridView dgvLostBooks;
        private DataGridView dgvGenreLoans;
        private DataGridView dgvTopBooks;
        private DataGridView dgvMonthlyLoans;
        private Button button1;
        private Button btnMarkLostOrDamage;
    }
}