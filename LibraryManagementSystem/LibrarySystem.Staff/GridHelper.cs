using System.Data;

namespace LibrarySystem.Staff {
    internal static class GridHelper {

        // One map of header text for ALL grids. Columns a grid doesn't have are simply skipped.
        private static readonly Dictionary<string, string> Headers = new() {
            ["student_id"] = "Student ID",
            ["student_name"] = "Student Name",
            ["title"] = "Title",
            ["author"] = "Author",
            ["genre"] = "Genre",
            ["publisher"] = "Publisher",
            ["year_published"] = "Year",
            ["synopsis"] = "Synopsis",
            ["copies_available"] = "Copies Left",
            ["book_status"] = "Book Status",
            ["requested_on"] = "Requested On",
            ["loan_date"] = "Borrowed On",
            ["due_date"] = "Due Date",
            ["return_date"] = "Returned On",
            ["status"] = "Status",
            ["login_id"] = "Login ID",
            ["first_name"] = "First Name",
            ["middle_name"] = "Middle Name",
            ["last_name"] = "Last Name",
            ["role"] = "Role",
            ["education_level"] = "Education Level",
            ["grade_level"] = "Year Level",
            ["strand_code"] = "Strand",
            ["section"] = "Section"
        };

        // Columns the librarian never needs to see (but the code still reads).
        private static readonly HashSet<string> Hidden = new() {
            "loan_id", "book_id", "user_id", "book_cover"
        };

        // Call ONCE per grid, in the constructor.
        public static void Style(DataGridView dgv) {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.CellFormatting += StatusColor;
        }

        // Call EVERY TIME you load data, instead of setting DataSource yourself.
        public static void Bind(DataGridView dgv, DataTable dt) {
            dgv.DataSource = dt;

            foreach (DataGridViewColumn col in dgv.Columns) {
                if (Hidden.Contains(col.Name))
                    col.Visible = false;
                else if (Headers.TryGetValue(col.Name, out string? text))
                    col.HeaderText = text;
            }

            // give long-text columns more room
            foreach (string name in new[] { "title", "author", "student_name", "synopsis" })
                if (dgv.Columns.Contains(name))
                    dgv.Columns[name].FillWeight = 150;
        }

        // Optional: call once on a grid that has a due_date column (Returns).
        // Optional: call once on a grid that has a due_date column (Returns).
        // Red     = past the due date AND time
        // Orange  = still on time, but due within DueSoonWindow
        public static void HighlightOverdue(DataGridView dgv) {
            TimeSpan DueSoonWindow = TimeSpan.FromHours(24);   // change this to taste

            dgv.RowPrePaint += (s, e) => {
                if (e.RowIndex < 0 || !dgv.Columns.Contains("due_date")) return;

                var row = dgv.Rows[e.RowIndex];
                var v = row.Cells["due_date"].Value;

                if (v == null || v == DBNull.Value) return;

                DateTime due = Convert.ToDateTime(v);      // keeps the time, no .Date
                TimeSpan left = due - DateTime.Now;

                if (left < TimeSpan.Zero)
                    row.DefaultCellStyle.ForeColor = Color.Red;
                else if (left <= DueSoonWindow)
                    row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                else
                    row.DefaultCellStyle.ForeColor = dgv.DefaultCellStyle.ForeColor;   // reset
            };

            // Colors are only recalculated when the grid repaints, so repaint once a minute.
            var timer = new System.Windows.Forms.Timer { Interval = 60_000 };
            timer.Tick += (s, e) => dgv.Invalidate();
            timer.Start();
            dgv.Disposed += (s, e) => timer.Dispose();
        }

        // Colors a "status" column if the grid has one (history, catalog later).
        private static void StatusColor(object? sender, DataGridViewCellFormattingEventArgs e) {
            if (sender is not DataGridView dgv || e.RowIndex < 0 || e.Value == null) return;
            if (dgv.Columns[e.ColumnIndex].Name != "status") return;

            switch (e.Value.ToString()?.ToLower()) {
                case "pending": e.CellStyle.ForeColor = Color.DarkGoldenrod; break;
                case "borrowed": e.CellStyle.ForeColor = Color.RoyalBlue; break;
                case "returned": e.CellStyle.ForeColor = Color.Gray; break;
                case "lost": e.CellStyle.ForeColor = Color.Red; break;
                case "cancelled": e.CellStyle.ForeColor = Color.DarkGray; break;
            }
        }

    }
}
