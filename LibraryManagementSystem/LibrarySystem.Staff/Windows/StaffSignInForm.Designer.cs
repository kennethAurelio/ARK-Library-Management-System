namespace LibrarySystem.Staff {
    partial class StaffSignInForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            txtLogInField = new TextBox();
            txtPasswordField = new TextBox();
            btnSignIn = new Button();
            chkShowPassword = new CheckBox();
            SuspendLayout();
            // 
            // txtLogInField
            // 
            txtLogInField.Location = new Point(578, 242);
            txtLogInField.Margin = new Padding(3, 2, 3, 2);
            txtLogInField.Name = "txtLogInField";
            txtLogInField.Size = new Size(354, 23);
            txtLogInField.TabIndex = 3;
            // 
            // txtPasswordField
            // 
            txtPasswordField.Location = new Point(578, 323);
            txtPasswordField.Margin = new Padding(3, 2, 3, 2);
            txtPasswordField.Name = "txtPasswordField";
            txtPasswordField.PasswordChar = '*';
            txtPasswordField.Size = new Size(354, 23);
            txtPasswordField.TabIndex = 4;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(704, 411);
            btnSignIn.Margin = new Padding(3, 2, 3, 2);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(82, 22);
            btnSignIn.TabIndex = 10;
            btnSignIn.Text = "Sign in";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.BackColor = Color.Transparent;
            chkShowPassword.Font = new Font("Times New Roman", 9F);
            chkShowPassword.Location = new Point(578, 362);
            chkShowPassword.Margin = new Padding(3, 2, 3, 2);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(103, 19);
            chkShowPassword.TabIndex = 9;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = false;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // StaffSignInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LibrarySystem_Staff___Background_Login__1556__980_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 588);
            Controls.Add(btnSignIn);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPasswordField);
            Controls.Add(txtLogInField);
            Margin = new Padding(3, 2, 3, 2);
            Name = "StaffSignInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "s";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLogInField;
        private TextBox txtPasswordField;
        private Button btnSignIn;
        private CheckBox chkShowPassword;
    }
}
