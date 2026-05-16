using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Services;
using LibraryClient.Models;

namespace LibraryClient
{
    public class BooksForm : Form
    {
        private TextBox txtSearch;
        private DataGridView gridBooks;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private System.Windows.Forms.Timer searchTimer;

        public BooksForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Manage Books";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // Top Panel for Search and Buttons
            var topPanel = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(10) };
            this.Controls.Add(topPanel);

            txtSearch = new TextBox { Width = 300, Location = new Point(10, 20), PlaceholderText = "Search by Title or Author..." };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            topPanel.Controls.Add(txtSearch);

            btnDelete = new Button { Text = "Delete Book", Width = 100, Location = new Point(this.Width - 140, 15), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnEdit = new Button { Text = "Edit Book", Width = 100, Location = new Point(this.Width - 250, 15), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnAdd = new Button { Text = "Add Book", Width = 100, Location = new Point(this.Width - 360, 15), Anchor = AnchorStyles.Top | AnchorStyles.Right };

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;

            topPanel.Controls.Add(btnDelete);
            topPanel.Controls.Add(btnEdit);
            topPanel.Controls.Add(btnAdd);

            // DataGridView
            gridBooks = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray }
            };
            this.Controls.Add(gridBooks);

            searchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            searchTimer.Tick += SearchTimer_Tick;

            this.Load += BooksForm_Load;
        }

        private async void BooksForm_Load(object? sender, EventArgs e)
        {
            await LoadBooksAsync();
        }

        private async Task LoadBooksAsync(string query = "")
        {
            string endpoint = string.IsNullOrWhiteSpace(query) ? "books" : $"books/search?query={Uri.EscapeDataString(query)}";
            var books = await ApiService.GetAsync<Book>(endpoint);
            
            if (books != null)
            {
                gridBooks.DataSource = books;
                
                // Hide unnecessary columns
                if (gridBooks.Columns["Category"] != null) gridBooks.Columns["Category"].Visible = false;
                if (gridBooks.Columns["CategoryId"] != null) gridBooks.Columns["CategoryId"].Visible = false;
            }
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private async void SearchTimer_Tick(object? sender, EventArgs e)
        {
            searchTimer.Stop();
            await LoadBooksAsync(txtSearch.Text);
        }

        private async void BtnAdd_Click(object? sender, EventArgs e)
        {
            using (var form = new AddEditBookForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadBooksAsync(txtSearch.Text);
                }
            }
        }

        private async void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (gridBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to edit.");
                return;
            }

            var selectedBook = (Book)gridBooks.SelectedRows[0].DataBoundItem;
            using (var form = new AddEditBookForm(selectedBook))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadBooksAsync(txtSearch.Text);
                }
            }
        }

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (gridBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to delete.");
                return;
            }

            var selectedBook = (Book)gridBooks.SelectedRows[0].DataBoundItem;
            var confirmResult = MessageBox.Show($"Are you sure you want to delete '{selectedBook.Title}'?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                bool success = await ApiService.DeleteAsync($"books/{selectedBook.Id}");
                if (success)
                {
                    await LoadBooksAsync(txtSearch.Text);
                }
            }
        }
    }
}
