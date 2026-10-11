namespace LibrarySystem.Staff {
    partial class LibrarianDashboard {
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
            tabReturnDesk = new TabPage();
            btnMarkReturned = new Button();
            dgvReturns = new DataGridView();
            tabLoanRequest = new TabPage();
            btnRefreshData = new Button();
            btnCancelRequest = new Button();
            btnAcceptRequest = new Button();
            dgvLoanRequest = new DataGridView();
            tabControl = new TabControl();
            tabBorrowingHistory = new TabPage();
            tabReturnDesk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReturns).BeginInit();
            tabLoanRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoanRequest).BeginInit();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabManageBooks
            // 
            tabManageBooks.AccessibleName = "";
            tabManageBooks.Location = new Point(4, 24);
            tabManageBooks.Name = "tabManageBooks";
            tabManageBooks.Size = new Size(975, 384);
            tabManageBooks.TabIndex = 2;
            tabManageBooks.Text = "Manage Books";
            tabManageBooks.UseVisualStyleBackColor = true;
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
            tabLoanRequest.Text = "Loan Request";
            tabLoanRequest.UseVisualStyleBackColor = true;
            // 
            // btnRefreshData
            // 
            btnRefreshData.Location = new Point(822, 192);
            btnRefreshData.Name = "btnRefreshData";
            btnRefreshData.Size = new Size(75, 23);
            btnRefreshData.TabIndex = 3;
            btnRefreshData.Text = "refresh";
            btnRefreshData.UseVisualStyleBackColor = true;
            // 
            // btnCancelRequest
            // 
            btnCancelRequest.Location = new Point(822, 238);
            btnCancelRequest.Name = "btnCancelRequest";
            btnCancelRequest.Size = new Size(107, 23);
            btnCancelRequest.TabIndex = 2;
            btnCancelRequest.Text = "Cancel Request";
            btnCancelRequest.UseVisualStyleBackColor = true;
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
            // tabControl
            // 
            tabControl.Controls.Add(tabLoanRequest);
            tabControl.Controls.Add(tabReturnDesk);
            tabControl.Controls.Add(tabManageBooks);
            tabControl.Controls.Add(tabBorrowingHistory);
            tabControl.Location = new Point(11, 137);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(983, 412);
            tabControl.TabIndex = 0;
            // 
            // tabBorrowingHistory
            // 
            tabBorrowingHistory.Location = new Point(4, 24);
            tabBorrowingHistory.Name = "tabBorrowingHistory";
            tabBorrowingHistory.Padding = new Padding(3);
            tabBorrowingHistory.Size = new Size(975, 384);
            tabBorrowingHistory.TabIndex = 3;
            tabBorrowingHistory.Text = "Borrowing History";
            tabBorrowingHistory.UseVisualStyleBackColor = true;
            // 
            // LibrarianDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.LibrarySystem_Staff___LibrarianDashboard__1556__980_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1006, 616);
            Controls.Add(tabControl);
            Name = "LibrarianDashboard";
            Text = "JILCF - ARK";
            Load += BtnRefreshData;
            tabReturnDesk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReturns).EndInit();
            tabLoanRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoanRequest).EndInit();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabManageBooks;
        private TabPage tabReturnDesk;
        private TabPage tabLoanRequest;
        private TabControl tabControl;
        private DataGridView dgvLoanRequest;
        private Button btnAcceptRequest;
        private DataGridView dgvReturns;
        private Button btnMarkReturned;
        private Button btnCancelRequest;
        private Button btnRefreshData;
        private TabPage tabBorrowingHistory;
    }
}