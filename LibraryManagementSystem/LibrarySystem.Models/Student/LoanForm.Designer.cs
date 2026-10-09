namespace LibrarySystem.Models {
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
            label1 = new Label();
            txtBookCopies = new TextBox();
            lblBookStatus = new Label();
            lblGenre = new Label();
            ((System.ComponentModel.ISupportInitialize)pbCover).BeginInit();
            SuspendLayout();
            // 
            // pbCover
            // 
            pbCover.BackColor = SystemColors.ControlLightLight;
            pbCover.BackgroundImageLayout = ImageLayout.Stretch;
            pbCover.Location = new Point(101, 146);
            pbCover.Name = "pbCover";
            pbCover.Size = new Size(158, 230);
            pbCover.TabIndex = 0;
            pbCover.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(274, 146);
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
            lblSynopsisHeader.Location = new Point(443, 174);
            lblSynopsisHeader.Name = "lblSynopsisHeader";
            lblSynopsisHeader.Size = new Size(55, 15);
            lblSynopsisHeader.TabIndex = 0;
            lblSynopsisHeader.Text = "Synopsis:";
            // 
            // txtSynopsis
            // 
            txtSynopsis.BackColor = Color.White;
            txtSynopsis.BorderStyle = BorderStyle.None;
            txtSynopsis.Location = new Point(443, 193);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.ReadOnly = true;
            txtSynopsis.ScrollBars = ScrollBars.Vertical;
            txtSynopsis.Size = new Size(350, 200);
            txtSynopsis.TabIndex = 5;
            // 
            // txtAuthor
            // 
            txtAuthor.BackColor = Color.White;
            txtAuthor.BorderStyle = BorderStyle.None;
            txtAuthor.Location = new Point(274, 192);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.ReadOnly = true;
            txtAuthor.Size = new Size(150, 44);
            txtAuthor.TabIndex = 6;
            // 
            // btnLoanBook
            // 
            btnLoanBook.Location = new Point(101, 474);
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
            lblAuthor.Location = new Point(274, 174);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(42, 15);
            lblAuthor.TabIndex = 8;
            lblAuthor.Text = "Author";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(274, 255);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 9;
            label1.Text = "Available Copies:";
            // 
            // txtBookCopies
            // 
            txtBookCopies.BackColor = Color.White;
            txtBookCopies.BorderStyle = BorderStyle.None;
            txtBookCopies.Location = new Point(371, 253);
            txtBookCopies.Multiline = true;
            txtBookCopies.Name = "txtBookCopies";
            txtBookCopies.ReadOnly = true;
            txtBookCopies.Size = new Size(52, 12);
            txtBookCopies.TabIndex = 10;
            // 
            // lblBookStatus
            // 
            lblBookStatus.AutoSize = true;
            lblBookStatus.BackColor = Color.Transparent;
            lblBookStatus.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookStatus.Location = new Point(274, 281);
            lblBookStatus.Name = "lblBookStatus";
            lblBookStatus.Size = new Size(40, 15);
            lblBookStatus.TabIndex = 12;
            lblBookStatus.Text = "Status:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.BackColor = Color.Transparent;
            lblGenre.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGenre.Location = new Point(274, 306);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(39, 15);
            lblGenre.TabIndex = 13;
            lblGenre.Text = "Genre:";
            // 
            // LoanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ARK___Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 588);
            Controls.Add(lblGenre);
            Controls.Add(lblBookStatus);
            Controls.Add(txtBookCopies);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox txtBookCopies;
        private Label lblBookStatus;
        private Label lblGenre;
    }
}