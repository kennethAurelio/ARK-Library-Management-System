namespace LibrarySystem.Models
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
            label1 = new Label();
            txtMemberID = new TextBox();
            txtPassword = new TextBox();
            label3 = new Label();
            label4 = new Label();
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
            // txtMemberID
            // 
            txtMemberID.Location = new Point(586, 294);
            txtMemberID.Margin = new Padding(3, 2, 3, 2);
            txtMemberID.Name = "txtMemberID";
            txtMemberID.Size = new Size(336, 23);
            txtMemberID.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(585, 377);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(336, 23);
            txtPassword.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(584, 266);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 4;
            label3.Text = "Login ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Times New Roman", 9F);
            label4.Location = new Point(584, 350);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 5;
            label4.Text = "Password";
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
            btnSignIn.Click += btnLogin_Click;
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
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(txtMemberID);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SignInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign in";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMemberID;
        private TextBox txtPassword;
        private Label label3;
        private Label label4;
        private CheckBox chkShowPassword;
        private Button btnSignIn;
        private Button button1;
    }
}