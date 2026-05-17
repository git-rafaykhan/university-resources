using System;
using System.Windows.Forms;
using LibraryClient.Models;
using LibraryClient.Services;

namespace LibraryClient
{
    public partial class AddEditBookForm : Form
    {
        private Book? _currentBook;
        private bool  _isEditMode;
        private bool  _isSaving = false;

        public AddEditBookForm(Book? book = null)
        {
            _currentBook = book;
            _isEditMode  = book != null;

            InitializeComponent();

            // Set title after edit-mode is known
            this.Text = _isEditMode ? "Edit Book" : "Add Book";

            // Pre-populate fields in edit mode
            if (_isEditMode && _currentBook != null)
            {
                txtTitle.Text       = _currentBook.Title;
                txtAuthor.Text      = _currentBook.Author;
                numTotalStock.Value = _currentBook.TotalStock;
            }

            // NOTE: btnSave.Click is already wired in Designer.cs — do NOT add it here again.
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Load += AddEditBookForm_Load;
        }

        private async void AddEditBookForm_Load(object? sender, EventArgs e)
        {
            var categories = await ApiService.GetAsync<Category>("categories");
            if (categories != null)
            {
                cmbCategory.DataSource = categories;
                if (_isEditMode && _currentBook != null)
                    cmbCategory.SelectedValue = _currentBook.CategoryId;
            }
        }

        private async void BtnSave_Click(object? sender, EventArgs e)
        {
            // Guard against double submission (rapid clicks or duplicate event wiring)
            if (_isSaving) return;
            _isSaving = true;
            btnSave.Enabled = false;

            try
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text))
                {
                    MessageBox.Show("Title and Author are required.");
                    return;
                }

                if (cmbCategory.SelectedValue == null)
                {
                    MessageBox.Show("Please select a valid category.");
                    return;
                }

                var bookData = new Book
                {
                    Title       = txtTitle.Text,
                    Author      = txtAuthor.Text,
                    TotalStock  = (int)numTotalStock.Value,
                    CategoryId  = (int)cmbCategory.SelectedValue
                };

                bool success;

                if (_isEditMode && _currentBook != null)
                {
                    bookData.Id = _currentBook.Id;
                    success = await ApiService.PutAsync($"books/{_currentBook.Id}", bookData);
                }
                else
                {
                    var created = await ApiService.PostAsync<Book>("books", bookData);
                    success = created != null;
                }

                if (success)
                    this.DialogResult = DialogResult.OK;
            }
            finally
            {
                _isSaving = false;
                btnSave.Enabled = true;
            }
        }
    }
}
