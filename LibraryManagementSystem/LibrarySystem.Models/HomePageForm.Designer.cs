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
            pbBookDisplay1 = new PictureBox();
            pbBookDisplay2 = new PictureBox();
            pbBookDisplay3 = new PictureBox();
            pbBookDisplay4 = new PictureBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbBookDisplay1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBookDisplay2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBookDisplay3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBookDisplay4).BeginInit();
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
            // pbBookDisplay1
            // 
            pbBookDisplay1.Location = new Point(106, 300);
            pbBookDisplay1.Name = "pbBookDisplay1";
            pbBookDisplay1.Size = new Size(109, 169);
            pbBookDisplay1.TabIndex = 11;
            pbBookDisplay1.TabStop = false;
            // 
            // pbBookDisplay2
            // 
            pbBookDisplay2.Location = new Point(262, 300);
            pbBookDisplay2.Name = "pbBookDisplay2";
            pbBookDisplay2.Size = new Size(109, 169);
            pbBookDisplay2.TabIndex = 12;
            pbBookDisplay2.TabStop = false;
            // 
            // pbBookDisplay3
            // 
            pbBookDisplay3.Location = new Point(415, 300);
            pbBookDisplay3.Name = "pbBookDisplay3";
            pbBookDisplay3.Size = new Size(109, 169);
            pbBookDisplay3.TabIndex = 13;
            pbBookDisplay3.TabStop = false;
            // 
            // pbBookDisplay4
            // 
            pbBookDisplay4.Location = new Point(570, 300);
            pbBookDisplay4.Name = "pbBookDisplay4";
            pbBookDisplay4.Size = new Size(109, 169);
            pbBookDisplay4.TabIndex = 14;
            pbBookDisplay4.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(91, 264);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 15;
            label3.Text = "Newest to Library:";
            // 
            // HomePageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 588);
            Controls.Add(label3);
            Controls.Add(pbBookDisplay4);
            Controls.Add(pbBookDisplay3);
            Controls.Add(pbBookDisplay2);
            Controls.Add(pbBookDisplay1);
            Controls.Add(btnLogout);
            Controls.Add(btnOpenLogin);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HomePageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home Page";
            Load += HomePageForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbBookDisplay1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBookDisplay2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBookDisplay3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBookDisplay4).EndInit();
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
        private PictureBox pbBookDisplay1;
        private PictureBox pbBookDisplay2;
        private PictureBox pbBookDisplay3;
        private PictureBox pbBookDisplay4;
        private Label label3;
    }
}
