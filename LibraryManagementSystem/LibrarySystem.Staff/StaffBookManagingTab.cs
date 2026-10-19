using LibrarySystem.Core;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Staff {
    public partial class StaffDashboard {

        private int? _editingBookId = null;   // null = adding a new book

        private const string CatalogQuery = @"
            SELECT 
	            b.book_id AS book_id,
                b.title AS title,
                b.author as author,
                g.genre AS genre,
                b.publisher AS publisher,
                b.year_published AS year_published,
                b.copies_available AS copies_available,
                b.book_status AS book_status,
                b.synopsis AS synopsis
            FROM books b
            INNER JOIN genre g ON b.genre = g.genre_id
            ORDER BY title;";

        private void LoadCatalog() {
            LoadGenres();
            GridHelper.Bind(dgvCatalog, LoadTable(CatalogQuery));
            dgvCatalog.Columns["synopsis"].Visible = false;   // too long for a grid cell
            StartNewBook();
        }

        // Fills a ComboBox from a query: shows one column, stores another as the value.
        private void BindCombo(ComboBox cb, string sql, string display, string value) {
            cb.DisplayMember = display;
            cb.ValueMember = value;
            cb.DataSource = LoadTable(sql);
            cb.SelectedIndex = -1;
        }

        private void LoadGenres() {
            BindCombo(cbGenre, "SELECT genre_id, genre FROM genre ORDER BY genre", "genre", "genre_id");
            cbGenre.DropDownStyle = ComboBoxStyle.DropDown;   // allow typing new genres
        }

        // Selecting a row fills the fields and switches to edit mode.
        private void dgvCatalog_SelectionChanged(object? sender, EventArgs e) {
            if (dgvCatalog.SelectedRows.Count == 0) return;

            var cells = dgvCatalog.SelectedRows[0].Cells;
            _editingBookId = Convert.ToInt32(cells["book_id"].Value);

            txtTitle.Text = cells["title"].Value?.ToString();
            txtAuthor.Text = cells["author"].Value?.ToString();
            cbGenre.Text = cells["genre"].Value?.ToString();
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
            cbGenre.SelectedIndex = -1;
            cbGenre.Text = "";
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
                using (var conn = DatabaseHelper.GetConnection()) {
                    conn.Open();

                    // Determine genre id. If user typed a new genre, insert it and use the new id.
                    object genreParam = DBNull.Value;
                    string genreText = cbGenre.Text.Trim();
                    if (!string.IsNullOrEmpty(genreText)) {
                        using (var findCmd = new MySqlCommand("SELECT genre_id FROM genre WHERE genre = @g LIMIT 1", conn)) {
                            findCmd.Parameters.AddWithValue("@g", genreText);
                            var existing = findCmd.ExecuteScalar();
                            if (existing != null) {
                                genreParam = Convert.ToInt32(existing);
                            } else {
                                using (var insCmd = new MySqlCommand("INSERT INTO genre (genre) VALUES (@g); SELECT LAST_INSERT_ID();", conn)) {
                                    insCmd.Parameters.AddWithValue("@g", genreText);
                                    genreParam = Convert.ToInt32(insCmd.ExecuteScalar());
                                }
                            }
                        }
                    }

                    using (var cmd = new MySqlCommand(sql, conn)) {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@author", author);
                        cmd.Parameters.AddWithValue("@genre", genreParam);
                        cmd.Parameters.AddWithValue("@publisher", txtPublisher.Text.Trim());
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@synopsis", txtSynopsis.Text.Trim());
                        cmd.Parameters.AddWithValue("@copies", copies);
                        cmd.Parameters.AddWithValue("@status", status);
                        if (_editingBookId != null)
                            cmd.Parameters.AddWithValue("@bookId", _editingBookId.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            } catch (MySqlException ex) {
                MessageBox.Show("Could not save the book.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(wasAdding ? "Book added." : "Book updated.", "Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadCatalog();        // refresh the grid and reset the form to add mode (LoadCatalog calls LoadGenres)
            LoadLoanRequests();   // keep "Copies Left" in the requests grid current
        }
    }

}
