namespace LibrarySystem.Models {
    partial class RulesForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            lblTitle = new Label();
            btnConfirm = new Button();
            chkAgree = new CheckBox();
            txtRules = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(34, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(175, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Borrowing Rules and Condition:";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(154, 509);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // chkAgree
            // 
            chkAgree.AutoSize = true;
            chkAgree.Location = new Point(34, 443);
            chkAgree.Name = "chkAgree";
            chkAgree.Size = new Size(203, 19);
            chkAgree.TabIndex = 2;
            chkAgree.Text = "I have read and agree to the rules.";
            chkAgree.UseVisualStyleBackColor = true;
            // 
            // txtRules
            // 
            txtRules.BackColor = SystemColors.Control;
            txtRules.BorderStyle = BorderStyle.None;
            txtRules.Location = new Point(34, 68);
            txtRules.Multiline = true;
            txtRules.Name = "txtRules";
            txtRules.ReadOnly = true;
            txtRules.ScrollBars = ScrollBars.Vertical;
            txtRules.Size = new Size(313, 369);
            txtRules.TabIndex = 3;
            // 
            // RulesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 593);
            Controls.Add(txtRules);
            Controls.Add(chkAgree);
            Controls.Add(btnConfirm);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RulesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rules Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnConfirm;
        private CheckBox chkAgree;
        private TextBox txtRules;
    }
}