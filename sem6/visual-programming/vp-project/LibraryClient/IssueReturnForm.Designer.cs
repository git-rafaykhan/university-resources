namespace LibraryClient
{
    partial class IssueReturnForm
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
            this.tabControl       = new System.Windows.Forms.TabControl();
            this.tabIssue         = new System.Windows.Forms.TabPage();
            this.tabReturn        = new System.Windows.Forms.TabPage();
            this.lblMemberLabel   = new System.Windows.Forms.Label();
            this.cmbMembers       = new System.Windows.Forms.ComboBox();
            this.lblBookLabel     = new System.Windows.Forms.Label();
            this.cmbBooks         = new System.Windows.Forms.ComboBox();
            this.lblDueDateLabel  = new System.Windows.Forms.Label();
            this.lblDueDate       = new System.Windows.Forms.Label();
            this.btnIssue         = new System.Windows.Forms.Button();
            this.topPanelReturn   = new System.Windows.Forms.Panel();
            this.btnReturn        = new System.Windows.Forms.Button();
            this.gridTransactions = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabIssue.SuspendLayout();
            this.tabReturn.SuspendLayout();
            this.topPanelReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).BeginInit();
            this.SuspendLayout();
            // tabControl
            this.tabControl.Controls.Add(this.tabIssue);
            this.tabControl.Controls.Add(this.tabReturn);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 600);
            this.tabControl.TabIndex = 0;
            // tabIssue
            this.tabIssue.Controls.Add(this.btnIssue);
            this.tabIssue.Controls.Add(this.lblDueDate);
            this.tabIssue.Controls.Add(this.lblDueDateLabel);
            this.tabIssue.Controls.Add(this.cmbBooks);
            this.tabIssue.Controls.Add(this.lblBookLabel);
            this.tabIssue.Controls.Add(this.cmbMembers);
            this.tabIssue.Controls.Add(this.lblMemberLabel);
            this.tabIssue.Location = new System.Drawing.Point(4, 29);
            this.tabIssue.Name = "tabIssue";
            this.tabIssue.Padding = new System.Windows.Forms.Padding(20);
            this.tabIssue.Size = new System.Drawing.Size(892, 567);
            this.tabIssue.TabIndex = 0;
            this.tabIssue.Text = "Issue Book";
            // tabReturn
            this.tabReturn.Controls.Add(this.gridTransactions);
            this.tabReturn.Controls.Add(this.topPanelReturn);
            this.tabReturn.Location = new System.Drawing.Point(4, 29);
            this.tabReturn.Name = "tabReturn";
            this.tabReturn.Padding = new System.Windows.Forms.Padding(10);
            this.tabReturn.Size = new System.Drawing.Size(892, 567);
            this.tabReturn.TabIndex = 1;
            this.tabReturn.Text = "Return Book";
            // lblMemberLabel
            this.lblMemberLabel.Location = new System.Drawing.Point(40, 40);
            this.lblMemberLabel.Name = "lblMemberLabel";
            this.lblMemberLabel.Size = new System.Drawing.Size(150, 23);
            this.lblMemberLabel.TabIndex = 0;
            this.lblMemberLabel.Text = "Select Member:";
            // cmbMembers
            this.cmbMembers.DisplayMember = "Name";
            this.cmbMembers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMembers.Location = new System.Drawing.Point(200, 40);
            this.cmbMembers.Name = "cmbMembers";
            this.cmbMembers.Size = new System.Drawing.Size(400, 25);
            this.cmbMembers.TabIndex = 1;
            this.cmbMembers.ValueMember = "Id";
            // lblBookLabel
            this.lblBookLabel.Location = new System.Drawing.Point(40, 100);
            this.lblBookLabel.Name = "lblBookLabel";
            this.lblBookLabel.Size = new System.Drawing.Size(150, 23);
            this.lblBookLabel.TabIndex = 2;
            this.lblBookLabel.Text = "Select Book:";
            // cmbBooks
            this.cmbBooks.DisplayMember = "DisplayTitle";
            this.cmbBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooks.Location = new System.Drawing.Point(200, 100);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(400, 25);
            this.cmbBooks.TabIndex = 3;
            this.cmbBooks.ValueMember = "Id";
            // lblDueDateLabel
            this.lblDueDateLabel.Location = new System.Drawing.Point(40, 160);
            this.lblDueDateLabel.Name = "lblDueDateLabel";
            this.lblDueDateLabel.Size = new System.Drawing.Size(150, 23);
            this.lblDueDateLabel.TabIndex = 4;
            this.lblDueDateLabel.Text = "Due Date:";
            // lblDueDate
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDueDate.Location = new System.Drawing.Point(200, 160);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(300, 23);
            this.lblDueDate.TabIndex = 5;
            this.lblDueDate.Text = "";
            // btnIssue
            this.btnIssue.BackColor = System.Drawing.Color.LightGreen;
            this.btnIssue.Location = new System.Drawing.Point(200, 240);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(150, 40);
            this.btnIssue.TabIndex = 6;
            this.btnIssue.Text = "Issue Book";
            // topPanelReturn
            this.topPanelReturn.Controls.Add(this.btnReturn);
            this.topPanelReturn.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanelReturn.Location = new System.Drawing.Point(10, 10);
            this.topPanelReturn.Name = "topPanelReturn";
            this.topPanelReturn.Padding = new System.Windows.Forms.Padding(10);
            this.topPanelReturn.Size = new System.Drawing.Size(872, 60);
            this.topPanelReturn.TabIndex = 0;
            // btnReturn
            this.btnReturn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnReturn.Location = new System.Drawing.Point(10, 15);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(150, 30);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Return Selected";
            // gridTransactions
            this.gridTransactions.AllowUserToAddRows = false;
            this.gridTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTransactions.Location = new System.Drawing.Point(10, 70);
            this.gridTransactions.Name = "gridTransactions";
            this.gridTransactions.ReadOnly = true;
            this.gridTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTransactions.Size = new System.Drawing.Size(872, 487);
            this.gridTransactions.TabIndex = 1;
            // IssueReturnForm
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "IssueReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue / Return Book";
            this.tabControl.ResumeLayout(false);
            this.tabIssue.ResumeLayout(false);
            this.tabReturn.ResumeLayout(false);
            this.topPanelReturn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl   tabControl;
        private System.Windows.Forms.TabPage      tabIssue;
        private System.Windows.Forms.TabPage      tabReturn;
        private System.Windows.Forms.Label        lblMemberLabel;
        private System.Windows.Forms.ComboBox     cmbMembers;
        private System.Windows.Forms.Label        lblBookLabel;
        private System.Windows.Forms.ComboBox     cmbBooks;
        private System.Windows.Forms.Label        lblDueDateLabel;
        private System.Windows.Forms.Label        lblDueDate;
        private System.Windows.Forms.Button       btnIssue;
        private System.Windows.Forms.Panel        topPanelReturn;
        private System.Windows.Forms.Button       btnReturn;
        private System.Windows.Forms.DataGridView gridTransactions;
    }
}
