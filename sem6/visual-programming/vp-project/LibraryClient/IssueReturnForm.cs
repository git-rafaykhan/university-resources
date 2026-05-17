using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Models;
using LibraryClient.Services;

namespace LibraryClient
{
    public partial class IssueReturnForm : Form
    {
        public IssueReturnForm()
        {
            InitializeComponent();

            btnIssue.Click  += BtnIssue_Click;
            btnReturn.Click += BtnReturn_Click;
            gridTransactions.CellFormatting += GridTransactions_CellFormatting;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            this.Load += IssueReturnForm_Load;
        }

        private async void IssueReturnForm_Load(object? sender, EventArgs e)
        {
            await LoadIssueTabDataAsync();
        }

        private async void TabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabIssue)
                await LoadIssueTabDataAsync();
            else if (tabControl.SelectedTab == tabReturn)
                await LoadReturnTabDataAsync();
        }

        private async Task LoadIssueTabDataAsync()
        {
            var membersTask = ApiService.GetAsync<Member>("members");
            var booksTask   = ApiService.GetAsync<Book>("books");

            await Task.WhenAll(membersTask, booksTask);

            if (membersTask.Result != null)
                cmbMembers.DataSource = membersTask.Result;

            if (booksTask.Result != null)
            {
                var availableBooks = booksTask.Result.Where(b => b.AvailableStock > 0).ToList();
                cmbBooks.DataSource = availableBooks;
            }

            lblDueDate.Text = DateTime.Now.AddDays(14).ToString("d");
        }

        private async Task LoadReturnTabDataAsync()
        {
            var activeTransactions = await ApiService.GetAsync<Transaction>("transactions/active");
            if (activeTransactions != null)
            {
                gridTransactions.DataSource = activeTransactions;

                string[] visibleCols = { "Id", "BookTitle", "MemberName", "IssuedOn", "DueDate", "Status" };
                foreach (DataGridViewColumn col in gridTransactions.Columns)
                    col.Visible = visibleCols.Contains(col.Name);
            }
        }

        private void GridTransactions_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0
                && gridTransactions.Columns[e.ColumnIndex].Name == "Status"
                && e.Value != null
                && e.CellStyle != null)
            {
                if ((e.Value.ToString() ?? "") == "OVERDUE")
                {
                    e.CellStyle.ForeColor          = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Font = e.CellStyle.Font == null
                        ? new Font(gridTransactions.Font, FontStyle.Bold)
                        : new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
        }

        // Nested DTO used by the issue endpoint
        public class IssueRequest
        {
            public int BookId   { get; set; }
            public int MemberId { get; set; }
        }

        private async void BtnIssue_Click(object? sender, EventArgs e)
        {
            if (cmbMembers.SelectedValue == null || cmbBooks.SelectedValue == null)
            {
                MessageBox.Show("Please select both a Member and a Book.");
                return;
            }

            var request = new IssueRequest
            {
                MemberId = (int)cmbMembers.SelectedValue,
                BookId   = (int)cmbBooks.SelectedValue
            };

            btnIssue.Enabled = false;

            var transaction = await ApiService.PostAsync<Transaction>("transactions/issue", request);

            if (transaction != null)
            {
                if (cmbBooks.SelectedItem is Book selectedBook)
                {
                    MessageBox.Show(
                        $"Successfully issued '{selectedBook.Title}'!\nDue Date: {transaction.DueDate:d}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadIssueTabDataAsync();
            }

            btnIssue.Enabled = true;
        }

        private async void BtnReturn_Click(object? sender, EventArgs e)
        {
            if (gridTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to return.");
                return;
            }

            var selected = (Transaction)gridTransactions.SelectedRows[0].DataBoundItem;
            var result   = await ApiService.PostAsync<Transaction>($"transactions/return/{selected.Id}", new { });

            if (result != null)
            {
                MessageBox.Show("Book successfully returned!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadReturnTabDataAsync();
            }
        }
    }
}
