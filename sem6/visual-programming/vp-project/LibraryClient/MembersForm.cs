using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Services;
using LibraryClient.Models;

namespace LibraryClient
{
    public partial class MembersForm : Form
    {
        public MembersForm()
        {
            InitializeComponent();

            txtSearch.TextChanged += TxtSearch_TextChanged;
            searchTimer.Tick      += SearchTimer_Tick;
            btnAdd.Click          += BtnAdd_Click;
            btnEdit.Click         += BtnEdit_Click;
            btnDelete.Click       += BtnDelete_Click;

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
                    var q = query.ToLower();
                    members = members.Where(m =>
                        (m.Name  != null && m.Name.ToLower().Contains(q)) ||
                        (m.Email != null && m.Email.ToLower().Contains(q))
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
                    await LoadMembersAsync(txtSearch.Text);
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
                    await LoadMembersAsync(txtSearch.Text);
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
            var confirm = MessageBox.Show(
                $"Are you sure you want to delete member '{selectedMember.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool success = await ApiService.DeleteAsync($"members/{selectedMember.Id}");
                if (success) await LoadMembersAsync(txtSearch.Text);
            }
        }
    }
}
