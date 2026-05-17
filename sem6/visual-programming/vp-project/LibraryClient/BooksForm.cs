using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Services;
using LibraryClient.Models;

namespace LibraryClient
{
    public partial class BooksForm : Form
    {
        public BooksForm()
        {
            InitializeComponent();

            txtSearch.TextChanged += TxtSearch_TextChanged;
            searchTimer.Tick      += SearchTimer_Tick;
            btnAdd.Click          += BtnAdd_Click;
            btnEdit.Click         += BtnEdit_Click;
            btnDelete.Click       += BtnDelete_Click;

            this.Load += BooksForm_Load;
        }

        private async void BooksForm_Load(object? sender, EventArgs e)
        {
            await LoadBooksAsync();
        }

        private async Task LoadBooksAsync(string query = "")
        {
            string endpoint = string.IsNullOrWhiteSpace(query)
                ? "books"
                : $"books/search?query={Uri.EscapeDataString(query)}";

            var books = await ApiService.GetAsync<Book>(endpoint);
            if (books != null)
            {
                gridBooks.DataSource = books;
                if (gridBooks.Columns["Category"]   != null) gridBooks.Columns["Category"].Visible   = false;
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
                    await LoadBooksAsync(txtSearch.Text);
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
                    await LoadBooksAsync(txtSearch.Text);
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
            var confirm = MessageBox.Show(
                $"Are you sure you want to delete '{selectedBook.Title}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool success = await ApiService.DeleteAsync($"books/{selectedBook.Id}");
                if (success) await LoadBooksAsync(txtSearch.Text);
            }
        }
    }
}
