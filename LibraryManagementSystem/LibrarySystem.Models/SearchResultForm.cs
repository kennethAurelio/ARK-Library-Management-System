using System.Data;

namespace LibrarySystem.Models {
    public partial class SearchResultForm : Form {
        public SearchResultForm(DataTable results) {
            InitializeComponent();
            dataGridViewResults.DataSource = results;
        }

        // remove
        private void SearchResultForm_Load(object sender, EventArgs e) {

        }
    }
}
