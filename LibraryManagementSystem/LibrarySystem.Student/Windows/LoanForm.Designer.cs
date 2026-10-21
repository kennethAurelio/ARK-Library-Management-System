namespace LibrarySystem.Student {
    partial class LoanForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanForm));
            pbCover = new PictureBox();
            lblTitle = new Label();
            lblSynopsisHeader = new Label();
            txtSynopsis = new TextBox();
            txtAuthor = new TextBox();
            btnLoanBook = new Button();
            lblAuthor = new Label();
            lblAvailableCopies = new Label();
            lblBookStatus = new Label();
            lblGenre = new Label();
            txtGenre = new TextBox();
            lblPublished = new Label();
            lblPublisher = new Label();
            ((System.ComponentModel.ISupportInitialize)pbCover).BeginInit();
            SuspendLayout();
            // 
            // pbCover
            // 
            pbCover.BackColor = SystemColors.ControlLightLight;
            pbCover.BackgroundImageLayout = ImageLayout.Stretch;
            pbCover.BorderStyle = BorderStyle.FixedSingle;
            pbCover.Location = new Point(147, 194);
            pbCover.Name = "pbCover";
            pbCover.Size = new Size(189, 278);
            pbCover.TabIndex = 0;
            pbCover.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(342, 194);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(40, 19);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title";
            // 
            // lblSynopsisHeader
            // 
            lblSynopsisHeader.AutoSize = true;
            lblSynopsisHeader.BackColor = Color.Transparent;
            lblSynopsisHeader.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSynopsisHeader.Location = new Point(579, 222);
            lblSynopsisHeader.Name = "lblSynopsisHeader";
            lblSynopsisHeader.Size = new Size(55, 15);
            lblSynopsisHeader.TabIndex = 0;
            lblSynopsisHeader.Text = "Synopsis:";
            // 
            // txtSynopsis
            // 
            txtSynopsis.BackColor = Color.White;
            txtSynopsis.BorderStyle = BorderStyle.None;
            txtSynopsis.Font = new Font("Times New Roman", 11F);
            txtSynopsis.Location = new Point(579, 241);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.ReadOnly = true;
            txtSynopsis.ScrollBars = ScrollBars.Vertical;
            txtSynopsis.Size = new Size(315, 231);
            txtSynopsis.TabIndex = 5;
            // 
            // txtAuthor
            // 
            txtAuthor.BackColor = Color.White;
            txtAuthor.BorderStyle = BorderStyle.None;
            txtAuthor.Font = new Font("Times New Roman", 11F);
            txtAuthor.Location = new Point(342, 240);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.ReadOnly = true;
            txtAuthor.ScrollBars = ScrollBars.Vertical;
            txtAuthor.Size = new Size(150, 72);
            txtAuthor.TabIndex = 6;
            // 
            // btnLoanBook
            // 
            btnLoanBook.Location = new Point(147, 585);
            btnLoanBook.Name = "btnLoanBook";
            btnLoanBook.Size = new Size(75, 23);
            btnLoanBook.TabIndex = 7;
            btnLoanBook.Text = "Loan Book";
            btnLoanBook.UseVisualStyleBackColor = true;
            btnLoanBook.Click += btnLoanBook_Click;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.BackColor = Color.Transparent;
            lblAuthor.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.Location = new Point(342, 222);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(42, 15);
            lblAuthor.TabIndex = 8;
            lblAuthor.Text = "Author";
            // 
            // lblAvailableCopies
            // 
            lblAvailableCopies.AutoSize = true;
            lblAvailableCopies.BackColor = Color.Transparent;
            lblAvailableCopies.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvailableCopies.Location = new Point(147, 485);
            lblAvailableCopies.Name = "lblAvailableCopies";
            lblAvailableCopies.Size = new Size(114, 19);
            lblAvailableCopies.TabIndex = 9;
            lblAvailableCopies.Text = "Available Copies:";
            // 
            // lblBookStatus
            // 
            lblBookStatus.AutoSize = true;
            lblBookStatus.BackColor = Color.Transparent;
            lblBookStatus.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookStatus.Location = new Point(147, 510);
            lblBookStatus.Name = "lblBookStatus";
            lblBookStatus.Size = new Size(49, 19);
            lblBookStatus.TabIndex = 12;
            lblBookStatus.Text = "Status:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.BackColor = Color.Transparent;
            lblGenre.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGenre.Location = new Point(344, 401);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(39, 15);
            lblGenre.TabIndex = 13;
            lblGenre.Text = "Genre:";
            // 
            // txtGenre
            // 
            txtGenre.BackColor = Color.White;
            txtGenre.BorderStyle = BorderStyle.None;
            txtGenre.Font = new Font("Times New Roman", 11F);
            txtGenre.Location = new Point(344, 419);
            txtGenre.Multiline = true;
            txtGenre.Name = "txtGenre";
            txtGenre.ReadOnly = true;
            txtGenre.Size = new Size(113, 27);
            txtGenre.TabIndex = 14;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.BackColor = Color.Transparent;
            lblPublished.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPublished.Location = new Point(344, 371);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(57, 15);
            lblPublished.TabIndex = 15;
            lblPublished.Text = "Published:";
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.BackColor = Color.Transparent;
            lblPublisher.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPublisher.Location = new Point(344, 342);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(55, 15);
            lblPublisher.TabIndex = 16;
            lblPublisher.Text = "Publisher:";
            // 
            // LoanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ARK___Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1084, 741);
            Controls.Add(lblPublisher);
            Controls.Add(lblPublished);
            Controls.Add(txtGenre);
            Controls.Add(lblGenre);
            Controls.Add(lblBookStatus);
            Controls.Add(lblAvailableCopies);
            Controls.Add(lblAuthor);
            Controls.Add(btnLoanBook);
            Controls.Add(txtAuthor);
            Controls.Add(txtSynopsis);
            Controls.Add(lblSynopsisHeader);
            Controls.Add(lblTitle);
            Controls.Add(pbCover);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoanForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JILCF - ARK";
            ((System.ComponentModel.ISupportInitialize)pbCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbCover;
        private Label lblTitle;
        private Label lblSynopsisHeader;
        private TextBox txtSynopsis;
        private TextBox txtAuthor;
        private Button btnLoanBook;
        private Label lblAuthor;
        private Label lblAvailableCopies;
        private Label lblBookStatus;
        private Label lblGenre;
        private TextBox txtGenre;
        private Label lblPublished;
        private Label lblPublisher;
    }
}