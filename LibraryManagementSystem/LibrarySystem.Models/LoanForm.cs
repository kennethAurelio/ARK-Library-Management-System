using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Models {
    public partial class LoanForm : Form {
        private int _bookId;
        private int _userId;
        public LoanForm(int bookId, int userId) {
            InitializeComponent();
            _bookId = bookId;
            _userId = userId;
            LoadBook();
            txtSynopsis.TabStop = false;
            txtAuthor.TabStop = false;
        }

        private void LoadBook() {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT title, author, synopsis, book_cover FROM books WHERE book_id = @id", conn)) {
                cmd.Parameters.AddWithValue("@id", _bookId);
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    if (!reader.Read()) return;

                    lblTitle.Text = reader["title"]?.ToString() ?? "Unknown Title";
                    txtAuthor.Text = reader["author"]?.ToString() ?? "Unknown Author";
                    txtSynopsis.Text = reader["synopsis"]?.ToString() ?? "Synopsis Missing";

                    if (reader["book_cover"] != DBNull.Value) {
                        byte[] data = (byte[])reader["book_cover"];
                        using (var stream = new MemoryStream(data))
                        using (var img = Image.FromStream(stream)) {
                            pbCover.BackgroundImage = new Bitmap(img);
                        }
                    } else {
                        pbCover.BackgroundImage = Properties.Resources.no_cover;
                    }
                }
            }
        }

    }
}
