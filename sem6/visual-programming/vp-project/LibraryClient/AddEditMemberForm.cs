using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryClient.Models;
using LibraryClient.Services;

namespace LibraryClient
{
    public class AddEditMemberForm : Form
    {
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Button btnSave;
        private Button btnCancel;

        private Member? _currentMember;
        private bool _isEditMode;

        public AddEditMemberForm(Member? member = null)
        {
            _currentMember = member;
            _isEditMode = member != null;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = _isEditMode ? "Edit Member" : "Add Member";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int y = 20;

            this.Controls.Add(new Label { Text = "Name:", Location = new Point(20, y), Width = 100 });
            txtName = new TextBox { Location = new Point(130, y), Width = 230 };
            if (_isEditMode && _currentMember != null) txtName.Text = _currentMember.Name;
            this.Controls.Add(txtName);
            y += 40;

            this.Controls.Add(new Label { Text = "Email:", Location = new Point(20, y), Width = 100 });
            txtEmail = new TextBox { Location = new Point(130, y), Width = 230 };
            if (_isEditMode && _currentMember != null) txtEmail.Text = _currentMember.Email;
            this.Controls.Add(txtEmail);
            y += 40;

            this.Controls.Add(new Label { Text = "Phone:", Location = new Point(20, y), Width = 100 });
            txtPhone = new TextBox { Location = new Point(130, y), Width = 230 };
            if (_isEditMode && _currentMember != null) txtPhone.Text = _currentMember.Phone;
            this.Controls.Add(txtPhone);
            y += 60;

            btnSave = new Button { Text = "Save", Location = new Point(130, y), Width = 100 };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button { Text = "Cancel", Location = new Point(260, y), Width = 100 };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);
        }

        private async void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Name and Email are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSave.Enabled = false;

            var memberData = new Member
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            bool success;

            if (_isEditMode && _currentMember != null)
            {
                memberData.Id = _currentMember.Id;
                memberData.RegisteredOn = _currentMember.RegisteredOn; 
                success = await ApiService.PutAsync($"members/{_currentMember.Id}", memberData);
            }
            else
            {
                memberData.RegisteredOn = DateTime.Now; 
                var created = await ApiService.PostAsync<Member>("members", memberData);
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
