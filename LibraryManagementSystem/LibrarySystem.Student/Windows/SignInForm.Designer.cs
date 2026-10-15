namespace LibrarySystem.Student
{
    partial class SignInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            label1 = new Label();
            txtLogInField = new TextBox();
            txtPasswordField = new TextBox();
            chkShowPassword = new CheckBox();
            btnSignIn = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(471, 43);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // txtLogInField
            // 
            txtLogInField.Location = new Point(586, 294);
            txtLogInField.Margin = new Padding(3, 2, 3, 2);
            txtLogInField.Name = "txtLogInField";
            txtLogInField.Size = new Size(336, 23);
            txtLogInField.TabIndex = 2;
            // 
            // txtPasswordField
            // 
            txtPasswordField.Location = new Point(585, 377);
            txtPasswordField.Margin = new Padding(3, 2, 3, 2);
            txtPasswordField.Name = "txtPasswordField";
            txtPasswordField.PasswordChar = '*';
            txtPasswordField.Size = new Size(336, 23);
            txtPasswordField.TabIndex = 3;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.BackColor = Color.Transparent;
            chkShowPassword.Font = new Font("Times New Roman", 9F);
            chkShowPassword.Location = new Point(586, 410);
            chkShowPassword.Margin = new Padding(3, 2, 3, 2);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(103, 19);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = false;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(712, 459);
            btnSignIn.Margin = new Padding(3, 2, 3, 2);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(82, 22);
            btnSignIn.TabIndex = 8;
            btnSignIn.Text = "Sign in";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(899, 557);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ARK___Sign_In;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 588);
            Controls.Add(button1);
            Controls.Add(btnSignIn);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPasswordField);
            Controls.Add(txtLogInField);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "SignInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign in";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtLogInField;
        private TextBox txtPasswordField;
        private CheckBox chkShowPassword;
        private Button btnSignIn;
        private Button button1;
    }
}