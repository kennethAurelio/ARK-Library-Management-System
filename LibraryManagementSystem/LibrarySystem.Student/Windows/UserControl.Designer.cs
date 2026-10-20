namespace LibrarySystem.Student {
    partial class UserControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl));
            btnViewHistory = new Button();
            btnChangePassword = new Button();
            btnLogout = new Button();
            rtbUserInformation = new RichTextBox();
            SuspendLayout();
            // 
            // btnViewHistory
            // 
            btnViewHistory.Location = new Point(40, 485);
            btnViewHistory.Margin = new Padding(4);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(148, 29);
            btnViewHistory.TabIndex = 6;
            btnViewHistory.Text = "View History";
            btnViewHistory.UseVisualStyleBackColor = true;
            btnViewHistory.Click += btnViewHistory_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(17, 522);
            btnChangePassword.Margin = new Padding(4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(192, 29);
            btnChangePassword.TabIndex = 7;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.None;
            btnLogout.BackgroundImage = Properties.Resources.images;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.Location = new Point(286, 517);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(46, 42);
            btnLogout.TabIndex = 11;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // rtbUserInformation
            // 
            rtbUserInformation.BorderStyle = BorderStyle.None;
            rtbUserInformation.Location = new Point(17, 27);
            rtbUserInformation.Margin = new Padding(4);
            rtbUserInformation.Name = "rtbUserInformation";
            rtbUserInformation.Size = new Size(324, 286);
            rtbUserInformation.TabIndex = 12;
            rtbUserInformation.Text = "";
            // 
            // UserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 575);
            Controls.Add(rtbUserInformation);
            Controls.Add(btnLogout);
            Controls.Add(btnChangePassword);
            Controls.Add(btnViewHistory);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "UserControl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Account";
            ResumeLayout(false);
        }

        #endregion
        private Button btnViewHistory;
        private Button btnChangePassword;
        private Button btnLogout;
        private RichTextBox rtbUserInformation;
    }
}