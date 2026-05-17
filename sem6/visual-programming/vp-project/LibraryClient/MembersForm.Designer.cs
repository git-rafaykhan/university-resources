namespace LibraryClient
{
    partial class MembersForm
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
            this.topPanel     = new System.Windows.Forms.Panel();
            this.txtSearch    = new System.Windows.Forms.TextBox();
            this.btnAdd       = new System.Windows.Forms.Button();
            this.btnEdit      = new System.Windows.Forms.Button();
            this.btnDelete    = new System.Windows.Forms.Button();
            this.gridMembers  = new System.Windows.Forms.DataGridView();
            this.searchTimer  = new System.Windows.Forms.Timer();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMembers)).BeginInit();
            this.SuspendLayout();
            // topPanel
            this.topPanel.Controls.Add(this.btnDelete);
            this.topPanel.Controls.Add(this.btnEdit);
            this.topPanel.Controls.Add(this.btnAdd);
            this.topPanel.Controls.Add(this.txtSearch);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10);
            this.topPanel.Size = new System.Drawing.Size(1000, 60);
            this.topPanel.TabIndex = 0;
            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(10, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search by Name or Email...";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 0;
            // btnAdd
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Location = new System.Drawing.Point(530, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Member";
            // btnEdit
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnEdit.Location = new System.Drawing.Point(650, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit Member";
            // btnDelete
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(770, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Member";
            // gridMembers
            this.gridMembers.AllowUserToAddRows = false;
            this.gridMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMembers.Location = new System.Drawing.Point(0, 60);
            this.gridMembers.Name = "gridMembers";
            this.gridMembers.ReadOnly = true;
            this.gridMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMembers.Size = new System.Drawing.Size(1000, 540);
            this.gridMembers.TabIndex = 1;
            // searchTimer
            this.searchTimer.Interval = 300;
            // MembersForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.gridMembers);
            this.Controls.Add(this.topPanel);
            this.Name = "MembersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Members";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMembers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel        topPanel;
        private System.Windows.Forms.TextBox      txtSearch;
        private System.Windows.Forms.Button       btnAdd;
        private System.Windows.Forms.Button       btnEdit;
        private System.Windows.Forms.Button       btnDelete;
        private System.Windows.Forms.DataGridView gridMembers;
        private System.Windows.Forms.Timer        searchTimer;
    }
}
