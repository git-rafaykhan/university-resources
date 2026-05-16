using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryClient.Models;
using LibraryClient.Services;

namespace LibraryClient
{
    public class AddEditBookForm : Form
    {
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private NumericUpDown numTotalStock;
        private ComboBox cmbCategory;
        private Button btnSave;
        private Button btnCancel;

        private Book? _currentBook;
        private bool _isEditMode;

        public AddEditBookForm(Book? book = null)
        {
            _currentBook = book;
            _isEditMode = book != null;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = _isEditMode ? "Edit Book" : "Add Book";
            this.Size = new Size(400, 310);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int y = 20;

            this.Controls.Add(new Label { Text = "Title:", Location = new Point(20, y), Width = 100 });
            txtTitle = new TextBox { Location = new Point(130, y), Width = 230 };
            if (_isEditMode && _currentBook != null) txtTitle.Text = _currentBook.Title;
            this.Controls.Add(txtTitle);
            y += 40;

            this.Controls.Add(new Label { Text = "Author:", Location = new Point(20, y), Width = 100 });
            txtAuthor = new TextBox { Location = new Point(130, y), Width = 230 };
            if (_isEditMode && _currentBook != null) txtAuthor.Text = _currentBook.Author;
            this.Controls.Add(txtAuthor);
            y += 40;

            this.Controls.Add(new Label { Text = "Total Stock:", Location = new Point(20, y), Width = 100 });
            numTotalStock = new NumericUpDown { Location = new Point(130, y), Width = 230, Maximum = 10000 };
            if (_isEditMode && _currentBook != null) numTotalStock.Value = _currentBook.TotalStock;
            this.Controls.Add(numTotalStock);
            y += 40;

            this.Controls.Add(new Label { Text = "Category:", Location = new Point(20, y), Width = 100 });
            cmbCategory = new ComboBox { Location = new Point(130, y), Width = 230, DisplayMember = "Name", ValueMember = "Id", DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(cmbCategory);
            y += 60;

            btnSave = new Button { Text = "Save", Location = new Point(130, y), Width = 100 };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button { Text = "Cancel", Location = new Point(260, y), Width = 100 };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);

            this.Load += AddEditBookForm_Load;
        }

        private async void AddEditBookForm_Load(object? sender, EventArgs e)
        {
            var categories = await ApiService.GetAsync<Category>("categories");
            if (categories != null)
            {
                cmbCategory.DataSource = categories;
                if (_isEditMode && _currentBook != null)
                {
                    cmbCategory.SelectedValue = _currentBook.CategoryId;
                }
            }
        }

        private async void BtnSave_Click(object? sender, EventArgs e)
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

            btnSave.Enabled = false;

            var bookData = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                ISBN = "",
                TotalStock = (int)numTotalStock.Value,
                CategoryId = (int)cmbCategory.SelectedValue
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
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
    }
}
