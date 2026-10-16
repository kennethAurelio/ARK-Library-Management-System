using LibrarySystem.Core;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Staff {
    public partial class StaffDashboard {

        private int? _editingBookId = null;   // null = adding a new book

        private const string CatalogQuery = @"
            SELECT book_id, title, author, genre, publisher, year_published,
                   copies_available, book_status, synopsis
            FROM books
            ORDER BY title";

        private void LoadCatalog() {
            GridHelper.Bind(dgvCatalog, LoadTable(CatalogQuery));
            dgvCatalog.Columns["synopsis"].Visible = false;   // too long for a grid cell
            StartNewBook();
        }

        // Selecting a row fills the fields and switches to edit mode.
        private void dgvCatalog_SelectionChanged(object? sender, EventArgs e) {
            if (dgvCatalog.SelectedRows.Count == 0) return;

            var cells = dgvCatalog.SelectedRows[0].Cells;
            _editingBookId = Convert.ToInt32(cells["book_id"].Value);

            txtTitle.Text = cells["title"].Value?.ToString();
            txtAuthor.Text = cells["author"].Value?.ToString();
            txtGenre.Text = cells["genre"].Value?.ToString();
            txtPublisher.Text = cells["publisher"].Value?.ToString();
            txtYear.Text = cells["year_published"].Value?.ToString();
            txtSynopsis.Text = cells["synopsis"].Value?.ToString();

            int copies = int.TryParse(cells["copies_available"].Value?.ToString(), out int c) ? c : 0;
            nudCopies.Value = Math.Clamp(copies, (int)nudCopies.Minimum, (int)nudCopies.Maximum);

            lblMode.Text = $"Editing: {txtTitle.Text}";
            btnSaveBook.Text = "Save Changes";
        }

        // Clears everything and switches to add mode.
        private void StartNewBook() {
            _editingBookId = null;
            dgvCatalog.ClearSelection();

            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtPublisher.Clear();
            txtYear.Clear();
            txtSynopsis.Clear();
            nudCopies.Value = 3;

            lblMode.Text = "Adding a new book";
            btnSaveBook.Text = "Add Book";
            txtTitle.Focus();
        }

        private void btnNewBook_Click(object sender, EventArgs e) {
            StartNewBook();
        }

        private void btnSaveBook_Click(object sender, EventArgs e) {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();

            if (title == "" || author == "") {
                MessageBox.Show("Title and author are required.", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object year = DBNull.Value;
            if (txtYear.Text.Trim() != "") {
                if (!int.TryParse(txtYear.Text.Trim(), out int y)) {
                    MessageBox.Show("Year must be a number.", "Invalid Year",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                year = y;
            }

            int copies = (int)nudCopies.Value;
            string status = copies > 0 ? "Available" : "Unavailable";

            string sql = _editingBookId == null
                ? @"INSERT INTO books (title, author, genre, publisher, year_published, synopsis,
                                       copies_available, book_status, date_added)
                    VALUES (@title, @author, @genre, @publisher, @year, @synopsis, @copies, @status, NOW())"
                : @"UPDATE books
                    SET title = @title, author = @author, genre = @genre, publisher = @publisher,
                        year_published = @year, synopsis = @synopsis,
                        copies_available = @copies, book_status = @status
                    WHERE book_id = @bookId";

            bool wasAdding = _editingBookId == null;

            try {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySqlCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@genre", txtGenre.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher", txtPublisher.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@synopsis", txtSynopsis.Text.Trim());
                    cmd.Parameters.AddWithValue("@copies", copies);
                    cmd.Parameters.AddWithValue("@status", status);
                    if (_editingBookId != null)
                        cmd.Parameters.AddWithValue("@bookId", _editingBookId.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            } catch (MySqlException ex) {
                MessageBox.Show("Could not save the book.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(wasAdding ? "Book added." : "Book updated.", "Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadCatalog();        // refresh the grid and reset the form to add mode
            LoadLoanRequests();   // keep "Copies Left" in the requests grid current
        }
    }

}
