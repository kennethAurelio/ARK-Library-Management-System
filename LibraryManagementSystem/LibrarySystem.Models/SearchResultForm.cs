using System.Data;

namespace LibrarySystem.Models {
    public partial class SearchResultForm : Form {
        public SearchResultForm(DataTable results) {
            InitializeComponent();
            dataGridViewResults.DataSource = results;

            // Enable text wrapping and let rows auto-size to fit wrapped content
            dataGridViewResults.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // Ensure each column also allows wrapping and is read-only
            foreach (DataGridViewColumn col in dataGridViewResults.Columns) {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                col.ReadOnly = true;
            }

            // Make the whole grid non-editable and adjust behavior for read-only display
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

    }
}
