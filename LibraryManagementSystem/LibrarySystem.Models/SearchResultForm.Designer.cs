namespace LibrarySystem.Models {
    partial class SearchResultForm {
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
            dgvResults = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.AllowUserToResizeColumns = false;
            dgvResults.AllowUserToResizeRows = false;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(79, 95);
            dgvResults.Margin = new Padding(3, 2, 3, 2);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(594, 263);
            dgvResults.TabIndex = 0;
            dgvResults.CellDoubleClick += dgvResults_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(79, 67);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Search Result:";
            // 
            // SearchResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 588);
            Controls.Add(label1);
            Controls.Add(dgvResults);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SearchResultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search Result";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvResults;
        private Label label1;
    }
}