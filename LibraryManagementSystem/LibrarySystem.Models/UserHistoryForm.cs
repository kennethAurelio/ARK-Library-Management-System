using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibrarySystem.Models {
    public partial class UserHistoryForm : Form {
        public UserHistoryForm() {
            InitializeComponent();
            SetupGrid();
            SetupFilter();
        }

        // Fills the ComboBox once (NOT inside LoadHistory).
        private void SetupFilter() {
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new object[] {
                "All", "Currently Borrowing", "Pending", "Returned", "Lost", "Cancelled"
            });

            // wire the event in code (the -= first prevents double subscription)
            cbFilterBy.SelectedIndexChanged -= cbFilterBy_SelectedIndexChanged;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;

            cbFilterBy.SelectedIndex = 0;   // starts on "All" and loads the grid
        }

        private void cbFilterBy_SelectedIndexChanged(object? sender, EventArgs e) {
            LoadHistory();
        }

        // One-time grid look: read-only, list-style.
        private void SetupGrid() {
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.MultiSelect = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistory.CellFormatting += dgvHistory_CellFormatting;
        }

        private void LoadHistory() {
            string choice = cbFilterBy.SelectedItem?.ToString() ?? "All";

            // Map what the user sees to the value stored in the database.
            object status = choice switch {
                "All" => DBNull.Value,
                "Currently Borrowing" => "Borrowed",
                _ => choice    // Pending, Returned, Lost, Cancelled
            };

            var historyTable = new DataTable();

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT b.title, b.author, l.loan_date, l.due_date, l.status
                FROM book_loans l
                JOIN books b ON b.book_id = l.book_id
                WHERE l.user_id = @userId
                  AND (@status IS NULL OR l.status = @status)
                ORDER BY FIELD(l.status, 'Borrowed', 'Pending', 'Returned', 'Lost', 'Cancelled'),
                         l.loan_date DESC", conn)) {
                cmd.Parameters.AddWithValue("@userId", LoggedInUser.UserId);
                cmd.Parameters.AddWithValue("@status", status);
                conn.Open();

                using (var reader = cmd.ExecuteReader()) {
                    historyTable.Load(reader);
                }
            }

            dgvHistory.DataSource = historyTable;

            // Headers and formats
            dgvHistory.Columns["title"].HeaderText = "Title";
            dgvHistory.Columns["author"].HeaderText = "Author";
            dgvHistory.Columns["loan_date"].HeaderText = "Loan Date";
            dgvHistory.Columns["due_date"].HeaderText = "Due Date";
            dgvHistory.Columns["status"].HeaderText = "Status";

            dgvHistory.Columns["loan_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dgvHistory.Columns["due_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dgvHistory.Columns["due_date"].DefaultCellStyle.NullValue = "—";   // pending/cancelled have no due date

            // Status is only useful when rows are mixed ("All")
            dgvHistory.Columns["status"].Visible = (choice == "All");
        }

        // Colors the Status text per value.
        private void dgvHistory_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvHistory.Columns[e.ColumnIndex].Name != "status") return;

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
