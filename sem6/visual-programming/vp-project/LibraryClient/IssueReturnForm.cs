using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Models;
using LibraryClient.Services;

namespace LibraryClient
{
    public class IssueReturnForm : Form
    {
        private TabControl tabControl;
        private TabPage tabIssue;
        private TabPage tabReturn;

        // Issue Tab Controls
        private ComboBox cmbMembers;
        private ComboBox cmbBooks;
        private Label lblDueDate;
        private Button btnIssue;

        // Return Tab Controls
        private DataGridView gridTransactions;
        private Button btnReturn;

        public IssueReturnForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Issue / Return Book";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            tabControl = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(tabControl);

            tabIssue = new TabPage("Issue Book") { Padding = new Padding(20) };
            tabReturn = new TabPage("Return Book") { Padding = new Padding(10) };

            tabControl.TabPages.Add(tabIssue);
            tabControl.TabPages.Add(tabReturn);

            // --- ISSUE TAB SETUP ---
            int y = 40;
            tabIssue.Controls.Add(new Label { Text = "Select Member:", Location = new Point(40, y), Width = 150 });
            cmbMembers = new ComboBox { Location = new Point(200, y), Width = 400, DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Name", ValueMember = "Id" };
            tabIssue.Controls.Add(cmbMembers);
            y += 60;

            tabIssue.Controls.Add(new Label { Text = "Select Book:", Location = new Point(40, y), Width = 150 });
            cmbBooks = new ComboBox { Location = new Point(200, y), Width = 400, DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "DisplayTitle", ValueMember = "Id" };
            tabIssue.Controls.Add(cmbBooks);
            y += 60;

            tabIssue.Controls.Add(new Label { Text = "Due Date:", Location = new Point(40, y), Width = 150 });
            lblDueDate = new Label { Text = DateTime.Now.AddDays(14).ToString("d"), Location = new Point(200, y), Width = 300, Font = new Font(this.Font, FontStyle.Bold) };
            tabIssue.Controls.Add(lblDueDate);
            y += 80;

            btnIssue = new Button { Text = "Issue Book", Location = new Point(200, y), Width = 150, Height = 40, BackColor = Color.LightGreen };
            btnIssue.Click += BtnIssue_Click;
            tabIssue.Controls.Add(btnIssue);

            // --- RETURN TAB SETUP ---
            var topPanelReturn = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(10) };
            tabReturn.Controls.Add(topPanelReturn);

            btnReturn = new Button { Text = "Return Selected", Width = 150, Location = new Point(10, 15), BackColor = Color.LightSkyBlue };
            btnReturn.Click += BtnReturn_Click;
            topPanelReturn.Controls.Add(btnReturn);

            gridTransactions = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray }
            };
            gridTransactions.CellFormatting += GridTransactions_CellFormatting;
            tabReturn.Controls.Add(gridTransactions);
            gridTransactions.BringToFront(); 

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
            {
                await LoadIssueTabDataAsync();
            }
            else if (tabControl.SelectedTab == tabReturn)
            {
                await LoadReturnTabDataAsync();
            }
        }

        private async Task LoadIssueTabDataAsync()
        {
            var membersTask = ApiService.GetAsync<Member>("members");
            var booksTask = ApiService.GetAsync<Book>("books");

            await Task.WhenAll(membersTask, booksTask);

            if (membersTask.Result != null)
            {
                cmbMembers.DataSource = membersTask.Result;
            }

            if (booksTask.Result != null)
            {
                // Only books with AvailableStock > 0
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

                // Hide unnecessary columns
                string[] visibleCols = { "Id", "BookTitle", "MemberName", "IssuedOn", "DueDate", "Status" };
                foreach (DataGridViewColumn col in gridTransactions.Columns)
                {
                    if (!visibleCols.Contains(col.Name))
                    {
                        col.Visible = false;
                    }
                }
            }
        }

        private void GridTransactions_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && gridTransactions.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString() ?? "";
                if (status == "OVERDUE")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    if (e.CellStyle.Font == null)
                    {
                         e.CellStyle.Font = new Font(gridTransactions.Font, FontStyle.Bold);
                    }
                    else
                    {
                         e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                }
            }
        }

        public class IssueRequest
        {
            public int BookId { get; set; }
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
                BookId = (int)cmbBooks.SelectedValue
            };

            btnIssue.Enabled = false;

            var transaction = await ApiService.PostAsync<Transaction>("transactions/issue", request);

            if (transaction != null)
            {
                var selectedBook = (Book)cmbBooks.SelectedItem;
                MessageBox.Show($"Successfully issued '{selectedBook.Title}'!\nDue Date: {transaction.DueDate:d}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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

            var selectedTransaction = (Transaction)gridTransactions.SelectedRows[0].DataBoundItem;
            
            var result = await ApiService.PostAsync<Transaction>($"transactions/return/{selectedTransaction.Id}", new { });

            if (result != null)
            {
                MessageBox.Show("Book successfully returned!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadReturnTabDataAsync();
            }
        }
    }
}
