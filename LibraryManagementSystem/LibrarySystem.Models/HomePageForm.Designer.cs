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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageForm));
            txtSearchBox = new TextBox();
            btnSearch = new Button();
            btnOpenLogin = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // txtSearchBox
            // 
            txtSearchBox.Anchor = AnchorStyles.Top;
            txtSearchBox.Location = new Point(160, 210);
            txtSearchBox.Margin = new Padding(3, 2, 3, 2);
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new Size(421, 23);
            txtSearchBox.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top;
            btnSearch.BackgroundImage = Properties.Resources.jkhadkhuial;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(586, 208);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(36, 23);
            btnSearch.TabIndex = 2;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnOpenLogin
            // 
            btnOpenLogin.Anchor = AnchorStyles.Right;
            btnOpenLogin.BackgroundImage = Properties.Resources.profile_icon_login_head_icon_vector;
            btnOpenLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnOpenLogin.Location = new Point(933, 26);
            btnOpenLogin.Margin = new Padding(3, 2, 3, 2);
            btnOpenLogin.Name = "btnOpenLogin";
            btnOpenLogin.Size = new Size(36, 33);
            btnOpenLogin.TabIndex = 7;
            btnOpenLogin.UseVisualStyleBackColor = true;
            btnOpenLogin.Click += btnOpenLogin_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackgroundImage = Properties.Resources.images;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.Location = new Point(933, 26);
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
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 588);
            Controls.Add(btnLogout);
            Controls.Add(btnOpenLogin);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HomePageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home Page";
            Load += HomePageForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtSearchBox;
        private Button btnSearch;
        private Label lblText2;
        private Button btnOpenLogin;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel Panel1;
        private PictureBox pictureBox4;
        private Button btnLogout;
    }
}
