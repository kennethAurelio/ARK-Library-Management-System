namespace LibrarySystem.Models {
    partial class ChangePasswordForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            lblStudentName = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            chkShowPassword_current = new CheckBox();
            chkShowPassword_new = new CheckBox();
            chkShowPassword_confirm = new CheckBox();
            btnChangePassword = new Button();
            SuspendLayout();
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.BackColor = Color.Transparent;
            lblStudentName.Font = new Font("Times New Roman", 10.8F);
            lblStudentName.Location = new Point(86, 53);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(115, 17);
            lblStudentName.TabIndex = 1;
            lblStudentName.Text = "Change Password";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(28, 118);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(192, 23);
            txtCurrentPassword.TabIndex = 2;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(29, 185);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(191, 23);
            txtNewPassword.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(29, 247);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(191, 23);
            txtConfirmPassword.TabIndex = 4;
            // 
            // chkShowPassword_current
            // 
            chkShowPassword_current.AutoSize = true;
            chkShowPassword_current.Location = new Point(226, 122);
            chkShowPassword_current.Name = "chkShowPassword_current";
            chkShowPassword_current.Size = new Size(51, 19);
            chkShowPassword_current.TabIndex = 5;
            chkShowPassword_current.Text = "View";
            chkShowPassword_current.UseVisualStyleBackColor = true;
            chkShowPassword_current.Visible = false;
            // 
            // chkShowPassword_new
            // 
            chkShowPassword_new.AutoSize = true;
            chkShowPassword_new.Location = new Point(226, 187);
            chkShowPassword_new.Name = "chkShowPassword_new";
            chkShowPassword_new.Size = new Size(51, 19);
            chkShowPassword_new.TabIndex = 6;
            chkShowPassword_new.Text = "View";
            chkShowPassword_new.UseVisualStyleBackColor = true;
            chkShowPassword_new.Visible = false;
            // 
            // chkShowPassword_confirm
            // 
            chkShowPassword_confirm.AutoSize = true;
            chkShowPassword_confirm.Location = new Point(226, 247);
            chkShowPassword_confirm.Name = "chkShowPassword_confirm";
            chkShowPassword_confirm.Size = new Size(51, 19);
            chkShowPassword_confirm.TabIndex = 7;
            chkShowPassword_confirm.Text = "View";
            chkShowPassword_confirm.UseVisualStyleBackColor = true;
            chkShowPassword_confirm.Visible = false;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Enabled = false;
            btnChangePassword.Location = new Point(67, 398);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(145, 23);
            btnChangePassword.TabIndex = 8;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 452);
            Controls.Add(btnChangePassword);
            Controls.Add(chkShowPassword_confirm);
            Controls.Add(chkShowPassword_new);
            Controls.Add(chkShowPassword_current);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblStudentName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Password Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudentName;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private CheckBox chkShowPassword_current;
        private CheckBox chkShowPassword_new;
        private CheckBox chkShowPassword_confirm;
        private Button btnChangePassword;
    }
}