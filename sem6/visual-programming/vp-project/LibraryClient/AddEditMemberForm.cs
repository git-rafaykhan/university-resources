using System;
using System.Windows.Forms;
using LibraryClient.Models;
using LibraryClient.Services;

namespace LibraryClient
{
    public partial class AddEditMemberForm : Form
    {
        private Member? _currentMember;
        private bool _isEditMode;
        private bool _isSaving = false;

        public AddEditMemberForm(Member? member = null)
        {
            _currentMember = member;
            _isEditMode = member != null;

            InitializeComponent();

            // Set title after edit-mode is known
            this.Text = _isEditMode ? "Edit Member" : "Add Member";

            // Pre-populate fields in edit mode
            if (_isEditMode && _currentMember != null)
            {
                txtName.Text = _currentMember.Name;
                txtEmail.Text = _currentMember.Email;
                txtPhone.Text = _currentMember.Phone;
            }

            // NOTE: btnSave.Click is already wired in Designer.cs — do NOT add it here again.
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private async void BtnSave_Click(object? sender, EventArgs e)
        {
            // Guard against double submission (rapid clicks or duplicate event wiring)
            if (_isSaving) return;
            _isSaving = true;
            btnSave.Enabled = false;

            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Name and Email are required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
