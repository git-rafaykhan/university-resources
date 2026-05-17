namespace LibraryClient
{
    partial class AddEditMemberForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblPhone = new System.Windows.Forms.Label();
            txtPhone = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            //
            // lblName
            //
            lblName.Location = new System.Drawing.Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            //
            // txtName
            //
            txtName.Location = new System.Drawing.Point(130, 20);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(230, 27);
            txtName.TabIndex = 1;
            //
            // lblEmail
            //
            lblEmail.Location = new System.Drawing.Point(20, 60);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(100, 23);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.Location = new System.Drawing.Point(130, 60);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(230, 27);
            txtEmail.TabIndex = 3;
            //
            // lblPhone
            //
            lblPhone.Location = new System.Drawing.Point(20, 100);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new System.Drawing.Size(100, 23);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone:";
            //
            // txtPhone
            //
            txtPhone.Location = new System.Drawing.Point(130, 100);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new System.Drawing.Size(230, 27);
            txtPhone.TabIndex = 5;
            //
            // btnSave — wired HERE in Designer.cs only (NOT in constructor)
            //
            btnSave.Location = new System.Drawing.Point(130, 160);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(100, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            //
            // btnCancel
            //
            btnCancel.Location = new System.Drawing.Point(260, 160);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            //
            // AddEditMemberForm
            //
            ClientSize = new System.Drawing.Size(400, 210);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddEditMemberForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Member";
            // NOTE: No Load event wired here — the empty AddEditMemberForm_Load stub has been removed.
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label   lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label   lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button  btnSave;
        private System.Windows.Forms.Button  btnCancel;
    }
}
