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
            pbCover = new PictureBox();
            lblTitle = new Label();
            lblSynopsisHeader = new Label();
            txtSynopsis = new TextBox();
            txtAuthor = new TextBox();
            button1 = new Button();
            lblAuthor = new Label();
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
            txtSynopsis.BorderStyle = BorderStyle.None;
            txtSynopsis.Location = new Point(443, 192);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.ReadOnly = true;
            txtSynopsis.ScrollBars = ScrollBars.Vertical;
            txtSynopsis.Size = new Size(350, 200);
            txtSynopsis.TabIndex = 5;
            // 
            // txtAuthor
            // 
            txtAuthor.BorderStyle = BorderStyle.None;
            txtAuthor.Location = new Point(274, 192);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.ReadOnly = true;
            txtAuthor.Size = new Size(150, 44);
            txtAuthor.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(101, 474);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Loan Book";
            button1.UseVisualStyleBackColor = true;
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
            // LoanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ARK___Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 588);
            Controls.Add(lblAuthor);
            Controls.Add(button1);
            Controls.Add(txtAuthor);
            Controls.Add(txtSynopsis);
            Controls.Add(lblSynopsisHeader);
            Controls.Add(lblTitle);
            Controls.Add(pbCover);
            Name = "LoanForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loan Form";
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
        private Button button1;
        private Label lblAuthor;
    }
}