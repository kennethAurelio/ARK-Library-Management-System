namespace LibrarySystem.Models {
    partial class AccountForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            lblStudentName = new Label();
            lblStudentId = new Label();
            lblYearLevel = new Label();
            lblStrandAndSection = new Label();
            lblPrivilege = new Label();
            btnViewHistory = new Button();
            btnChangePassword = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.BackColor = Color.Transparent;
            lblStudentName.Font = new Font("Times New Roman", 10.8F);
            lblStudentName.Location = new Point(12, 32);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(95, 17);
            lblStudentName.TabIndex = 0;
            lblStudentName.Text = "Student Name:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.BackColor = Color.Transparent;
            lblStudentId.Font = new Font("Times New Roman", 10.8F);
            lblStudentId.Location = new Point(12, 56);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(108, 17);
            lblStudentId.TabIndex = 1;
            lblStudentId.Text = "Student/Login Id:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.BackColor = Color.Transparent;
            lblYearLevel.Font = new Font("Times New Roman", 10.8F);
            lblYearLevel.Location = new Point(12, 101);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(76, 17);
            lblYearLevel.TabIndex = 3;
            lblYearLevel.Text = "Year Level:";
            // 
            // lblStrandAndSection
            // 
            lblStrandAndSection.AutoSize = true;
            lblStrandAndSection.BackColor = Color.Transparent;
            lblStrandAndSection.Font = new Font("Times New Roman", 10.8F);
            lblStrandAndSection.Location = new Point(12, 79);
            lblStrandAndSection.Name = "lblStrandAndSection";
            lblStrandAndSection.Size = new Size(121, 17);
            lblStrandAndSection.TabIndex = 4;
            lblStrandAndSection.Text = "Strand and Section:";
            // 
            // lblPrivilege
            // 
            lblPrivilege.AutoSize = true;
            lblPrivilege.BackColor = Color.Transparent;
            lblPrivilege.Font = new Font("Times New Roman", 10.8F);
            lblPrivilege.Location = new Point(12, 146);
            lblPrivilege.Name = "lblPrivilege";
            lblPrivilege.Size = new Size(62, 17);
            lblPrivilege.TabIndex = 5;
            lblPrivilege.Text = "Privilege:";
            // 
            // btnViewHistory
            // 
            btnViewHistory.Location = new Point(31, 383);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(115, 23);
            btnViewHistory.TabIndex = 6;
            btnViewHistory.Text = "View History";
            btnViewHistory.UseVisualStyleBackColor = true;
            btnViewHistory.Click += btnViewHistory_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(13, 412);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(149, 23);
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
            btnLogout.Location = new Point(241, 407);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(36, 33);
            btnLogout.TabIndex = 11;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 452);
            Controls.Add(btnLogout);
            Controls.Add(btnChangePassword);
            Controls.Add(btnViewHistory);
            Controls.Add(lblPrivilege);
            Controls.Add(lblStrandAndSection);
            Controls.Add(lblYearLevel);
            Controls.Add(lblStudentId);
            Controls.Add(lblStudentName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudentName;
        private Label lblStudentId;
        private Label lblYearLevel;
        private Label lblStrandAndSection;
        private Label lblPrivilege;
        private Button btnViewHistory;
        private Button btnChangePassword;
        private Button btnLogout;
    }
}