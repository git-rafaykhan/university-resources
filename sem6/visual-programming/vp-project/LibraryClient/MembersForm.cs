using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Services;
using LibraryClient.Models;
using System.Linq;

namespace LibraryClient
{
    public class MembersForm : Form
    {
        private TextBox txtSearch;
        private DataGridView gridMembers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private System.Windows.Forms.Timer searchTimer;

        public MembersForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Manage Members";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // Top Panel for Search and Buttons
            var topPanel = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(10) };
            this.Controls.Add(topPanel);

            txtSearch = new TextBox { Width = 300, Location = new Point(10, 20), PlaceholderText = "Search by Name or Email..." };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            topPanel.Controls.Add(txtSearch);

            btnDelete = new Button { Text = "Delete Member", Width = 110, Location = new Point(this.Width - 150, 15), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnEdit = new Button { Text = "Edit Member", Width = 110, Location = new Point(this.Width - 270, 15), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnAdd = new Button { Text = "Add Member", Width = 110, Location = new Point(this.Width - 390, 15), Anchor = AnchorStyles.Top | AnchorStyles.Right };

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;

            topPanel.Controls.Add(btnDelete);
            topPanel.Controls.Add(btnEdit);
            topPanel.Controls.Add(btnAdd);

            // DataGridView
            gridMembers = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray }
            };
            this.Controls.Add(gridMembers);
            gridMembers.BringToFront();

            searchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            searchTimer.Tick += SearchTimer_Tick;

            this.Load += MembersForm_Load;
        }

        private async void MembersForm_Load(object? sender, EventArgs e)
        {
            await LoadMembersAsync();
        }

        private async Task LoadMembersAsync(string query = "")
        {
            var members = await ApiService.GetAsync<Member>("members");
            
            if (members != null)
            {
                if (!string.IsNullOrWhiteSpace(query))
                {
                    query = query.ToLower();
                    members = members.Where(m => 
                        (m.Name != null && m.Name.ToLower().Contains(query)) || 
                        (m.Email != null && m.Email.ToLower().Contains(query))
                    ).ToList();
                }

                gridMembers.DataSource = members;
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
            await LoadMembersAsync(txtSearch.Text);
        }

        private async void BtnAdd_Click(object? sender, EventArgs e)
        {
            using (var form = new AddEditMemberForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadMembersAsync(txtSearch.Text);
                }
            }
        }

        private async void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (gridMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a member to edit.");
                return;
            }

            var selectedMember = (Member)gridMembers.SelectedRows[0].DataBoundItem;
            using (var form = new AddEditMemberForm(selectedMember))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadMembersAsync(txtSearch.Text);
                }
            }
        }

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (gridMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a member to delete.");
                return;
            }

            var selectedMember = (Member)gridMembers.SelectedRows[0].DataBoundItem;
            var confirmResult = MessageBox.Show($"Are you sure you want to delete member '{selectedMember.Name}'?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                bool success = await ApiService.DeleteAsync($"members/{selectedMember.Id}");
                if (success)
                {
                    await LoadMembersAsync(txtSearch.Text);
                }
            }
        }
    }
}
