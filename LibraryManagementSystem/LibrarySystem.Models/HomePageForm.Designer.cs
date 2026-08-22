namespace LibrarySystem.Models
{
    partial class HomePageForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lblText1 = new Label();
            txtSeachBox = new TextBox();
            btnSearch = new Button();
            lblText2 = new Label();
            btnOpenLogin = new Button();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            Panel1 = new Panel();
            pictureBox4 = new PictureBox();
            lblText3 = new Label();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // lblText1
            // 
            lblText1.Anchor = AnchorStyles.Top;
            lblText1.AutoSize = true;
            lblText1.BackColor = SystemColors.Control;
            lblText1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText1.ForeColor = Color.Navy;
            lblText1.Location = new Point(456, 31);
            lblText1.Name = "lblText1";
            lblText1.Size = new Size(133, 23);
            lblText1.TabIndex = 0;
            lblText1.Text = "Welcome to ARK";
            // 
            // txtSeachBox
            // 
            txtSeachBox.Anchor = AnchorStyles.Top;
            txtSeachBox.Location = new Point(354, 113);
            txtSeachBox.Margin = new Padding(3, 2, 3, 2);
            txtSeachBox.Name = "txtSeachBox";
            txtSeachBox.Size = new Size(291, 23);
            txtSeachBox.TabIndex = 1;
            txtSeachBox.Text = "Search..";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top;
            btnSearch.BackgroundImage = Properties.Resources.jkhadkhuial;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(652, 112);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(36, 23);
            btnSearch.TabIndex = 2;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblText2
            // 
            lblText2.AutoSize = true;
            lblText2.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText2.Location = new Point(68, 239);
            lblText2.Name = "lblText2";
            lblText2.Size = new Size(97, 17);
            lblText2.TabIndex = 6;
            lblText2.Text = "New to Library:";
            // 
            // btnOpenLogin
            // 
            btnOpenLogin.Anchor = AnchorStyles.Right;
            btnOpenLogin.BackgroundImage = Properties.Resources.profile_icon_login_head_icon_vector;
            btnOpenLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnOpenLogin.Location = new Point(943, 11);
            btnOpenLogin.Margin = new Padding(3, 2, 3, 2);
            btnOpenLogin.Name = "btnOpenLogin";
            btnOpenLogin.Size = new Size(36, 33);
            btnOpenLogin.TabIndex = 7;
            btnOpenLogin.UseVisualStyleBackColor = true;
            btnOpenLogin.Click += btnOpenLogin_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.book3;
            pictureBox3.Location = new Point(426, 10);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(117, 172);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.book2;
            pictureBox2.Location = new Point(255, 10);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(117, 172);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.book1;
            pictureBox1.Location = new Point(83, 10);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.Gainsboro;
            Panel1.Controls.Add(pictureBox4);
            Panel1.Controls.Add(pictureBox1);
            Panel1.Controls.Add(pictureBox2);
            Panel1.Controls.Add(pictureBox3);
            Panel1.Location = new Point(82, 269);
            Panel1.Margin = new Padding(3, 2, 3, 2);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(807, 191);
            Panel1.TabIndex = 8;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.ikigai_7;
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(590, 10);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(117, 172);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // lblText3
            // 
            lblText3.AutoSize = true;
            lblText3.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText3.ForeColor = Color.Navy;
            lblText3.Location = new Point(428, 54);
            lblText3.Name = "lblText3";
            lblText3.Size = new Size(196, 17);
            lblText3.TabIndex = 9;
            lblText3.Text = "Your Archive and Resource Keeper";
            // 
            // btnLogout
            // 
            btnLogout.BackgroundImage = Properties.Resources.images;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.Location = new Point(943, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(36, 33);
            btnLogout.TabIndex = 10;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Visible = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // HomePageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 588);
            Controls.Add(btnLogout);
            Controls.Add(lblText3);
            Controls.Add(Panel1);
            Controls.Add(btnOpenLogin);
            Controls.Add(lblText2);
            Controls.Add(btnSearch);
            Controls.Add(txtSeachBox);
            Controls.Add(lblText1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HomePageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home Page";
            Load += HomePageForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblText1;
        private TextBox txtSeachBox;
        private Button btnSearch;
        private Label lblText2;
        private Button btnOpenLogin;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel Panel1;
        private PictureBox pictureBox4;
        private Label lblText3;
        private Button btnLogout;
    }
}
