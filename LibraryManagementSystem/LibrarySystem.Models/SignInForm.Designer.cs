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
            btnSignUp = new Button();
            chkShowPassword = new CheckBox();
            btnSignIn = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(538, 57);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // txtMemberID
            // 
            txtMemberID.Location = new Point(670, 392);
            txtMemberID.Name = "txtMemberID";
            txtMemberID.Size = new Size(383, 27);
            txtMemberID.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(669, 503);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(383, 27);
            txtPassword.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(667, 354);
            label3.Name = "label3";
            label3.Size = new Size(78, 17);
            label3.TabIndex = 4;
            label3.Text = "Member ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Times New Roman", 9F);
            label4.Location = new Point(667, 466);
            label4.Name = "label4";
            label4.Size = new Size(66, 17);
            label4.TabIndex = 5;
            label4.Text = "Password";
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(893, 743);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(128, 29);
            btnSignUp.TabIndex = 6;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignIn_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.BackColor = Color.Transparent;
            chkShowPassword.Font = new Font("Times New Roman", 9F);
            chkShowPassword.Location = new Point(670, 547);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(125, 21);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = false;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(814, 612);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(94, 29);
            btnSignIn.TabIndex = 8;
            btnSignIn.Text = "Sign in";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnLogin_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1027, 743);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ARK___Sign_In;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1133, 784);
            Controls.Add(button1);
            Controls.Add(btnSignIn);
            Controls.Add(chkShowPassword);
            Controls.Add(btnSignUp);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(txtMemberID);
            Controls.Add(label1);
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
        private Button btnSignUp;
        private CheckBox chkShowPassword;
        private Button btnSignIn;
        private Button button1;
    }
}