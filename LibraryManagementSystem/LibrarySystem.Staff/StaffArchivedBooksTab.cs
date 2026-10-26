using LibrarySystem.Core;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Staff {
    public partial class StaffDashboard {

        private const string ArchivedBooksQuery = @"
            SELECT b.book_id,
                   b.title,
                   b.author,
                   COALESCE(g.genre, 'Unknown') AS genre,
                   b.publisher,
                   b.copies_available
            FROM books b
            LEFT JOIN genre g ON g.genre_id = b.genre
            WHERE b.is_active = 0
            ORDER BY b.title";

        private void InitArchivedBooksTab() {
            GridHelper.Style(dgvArchivedBooks);
            LoadArchivedBooks();
        }

        private void LoadArchivedBooks() {
            GridHelper.Bind(dgvArchivedBooks, LoadTable(ArchivedBooksQuery));

            // Hide the internal id, but keep it for the restore button
            if (dgvArchivedBooks.Columns.Contains("book_id"))
                dgvArchivedBooks.Columns["book_id"].Visible = false;

            // SetHeader(...) is already defined in your archived users file, so reuse it here
            SetHeader(dgvArchivedBooks, "title", "Title");
            SetHeader(dgvArchivedBooks, "author", "Author");
            SetHeader(dgvArchivedBooks, "genre", "Genre");
            SetHeader(dgvArchivedBooks, "publisher", "Publisher");
            SetHeader(dgvArchivedBooks, "copies_available", "Copies");
        }

        private void btnRestoreBook_Click(object sender, EventArgs e) {
            if (dgvArchivedBooks.CurrentRow == null) {
                MessageBox.Show("Select an archived book first.", "No selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int bookId = Convert.ToInt32(dgvArchivedBooks.CurrentRow.Cells["book_id"].Value);
            string title = dgvArchivedBooks.CurrentRow.Cells["title"].Value?.ToString() ?? "this book";

            if (MessageBox.Show($"Restore \"{title}\" to the catalog?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try {
                using (var conn = DatabaseHelper.GetConnection())
                using (var cmd = new MySqlCommand(
                    "UPDATE books SET is_active = 1 " +
                    "WHERE book_id = @id AND is_active = 0", conn)) {
                    cmd.Parameters.AddWithValue("@id", bookId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            } catch (MySqlException ex) {
                MessageBox.Show("Could not restore the book.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadArchivedBooks();
            LoadCatalog();   // the restored book reappears in the Catalog grid
        }

    }
}
