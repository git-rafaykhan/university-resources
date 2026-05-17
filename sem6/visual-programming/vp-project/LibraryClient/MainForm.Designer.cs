namespace LibraryClient
{
    partial class MainForm
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
            this.topPanel            = new System.Windows.Forms.Panel();
            this.lblTitle            = new System.Windows.Forms.Label();
            this.leftPanel           = new System.Windows.Forms.Panel();
            this.btnManageBooks      = new System.Windows.Forms.Button();
            this.btnManageMembers    = new System.Windows.Forms.Button();
            this.btnIssueReturn      = new System.Windows.Forms.Button();
            this.btnViewReports      = new System.Windows.Forms.Button();
            this.rightPanel          = new System.Windows.Forms.Panel();
            this.lblDashboard        = new System.Windows.Forms.Label();
            this.pnlTotalBooks       = new System.Windows.Forms.Panel();
            this.lblTotalBooksTitle  = new System.Windows.Forms.Label();
            this.lblTotalBooks       = new System.Windows.Forms.Label();
            this.pnlTotalMembers     = new System.Windows.Forms.Panel();
            this.lblTotalMembersTitle = new System.Windows.Forms.Label();
            this.lblTotalMembers     = new System.Windows.Forms.Label();
            this.pnlBooksIssued      = new System.Windows.Forms.Panel();
            this.lblBooksIssuedTitle = new System.Windows.Forms.Label();
            this.lblBooksIssued      = new System.Windows.Forms.Label();
            this.pnlOverdueBooks     = new System.Windows.Forms.Panel();
            this.lblOverdueBooksTitle = new System.Windows.Forms.Label();
            this.lblOverdueBooks     = new System.Windows.Forms.Label();
            this.btnRefresh          = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.pnlTotalBooks.SuspendLayout();
            this.pnlTotalMembers.SuspendLayout();
            this.pnlBooksIssued.SuspendLayout();
            this.pnlOverdueBooks.SuspendLayout();
            this.SuspendLayout();
            // topPanel
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(26, 35, 126);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 70);
            this.topPanel.TabIndex = 0;
            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Library Management System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // leftPanel
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.leftPanel.Controls.Add(this.btnViewReports);
            this.leftPanel.Controls.Add(this.btnIssueReturn);
            this.leftPanel.Controls.Add(this.btnManageMembers);
            this.leftPanel.Controls.Add(this.btnManageBooks);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 70);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 480);
            this.leftPanel.TabIndex = 1;
            // btnManageBooks
            this.btnManageBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageBooks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnManageBooks.Location = new System.Drawing.Point(0, 0);
            this.btnManageBooks.Name = "btnManageBooks";
            this.btnManageBooks.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageBooks.Size = new System.Drawing.Size(200, 60);
            this.btnManageBooks.TabIndex = 0;
            this.btnManageBooks.Text = "Manage Books";
            this.btnManageBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageBooks.FlatAppearance.BorderSize = 0;
            // btnManageMembers
            this.btnManageMembers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMembers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnManageMembers.Location = new System.Drawing.Point(0, 60);
            this.btnManageMembers.Name = "btnManageMembers";
            this.btnManageMembers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageMembers.Size = new System.Drawing.Size(200, 60);
            this.btnManageMembers.TabIndex = 1;
            this.btnManageMembers.Text = "Manage Members";
            this.btnManageMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageMembers.FlatAppearance.BorderSize = 0;
            // btnIssueReturn
            this.btnIssueReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssueReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueReturn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnIssueReturn.Location = new System.Drawing.Point(0, 120);
            this.btnIssueReturn.Name = "btnIssueReturn";
            this.btnIssueReturn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnIssueReturn.Size = new System.Drawing.Size(200, 60);
            this.btnIssueReturn.TabIndex = 2;
            this.btnIssueReturn.Text = "Issue / Return Book";
            this.btnIssueReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReturn.FlatAppearance.BorderSize = 0;
            // btnViewReports
            this.btnViewReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReports.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnViewReports.Location = new System.Drawing.Point(0, 180);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnViewReports.Size = new System.Drawing.Size(200, 60);
            this.btnViewReports.TabIndex = 3;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewReports.FlatAppearance.BorderSize = 0;
            // rightPanel
            this.rightPanel.BackColor = System.Drawing.Color.White;
            this.rightPanel.Controls.Add(this.btnRefresh);
            this.rightPanel.Controls.Add(this.pnlOverdueBooks);
            this.rightPanel.Controls.Add(this.pnlBooksIssued);
            this.rightPanel.Controls.Add(this.pnlTotalMembers);
            this.rightPanel.Controls.Add(this.pnlTotalBooks);
            this.rightPanel.Controls.Add(this.lblDashboard);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(200, 70);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(700, 480);
            this.rightPanel.TabIndex = 2;
            // lblDashboard
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDashboard.Location = new System.Drawing.Point(30, 20);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Dashboard";
            // pnlTotalBooks
            this.pnlTotalBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalBooks.Controls.Add(this.lblTotalBooksTitle);
            this.pnlTotalBooks.Controls.Add(this.lblTotalBooks);
            this.pnlTotalBooks.Location = new System.Drawing.Point(30, 70);
            this.pnlTotalBooks.Name = "pnlTotalBooks";
            this.pnlTotalBooks.Size = new System.Drawing.Size(270, 120);
            this.pnlTotalBooks.TabIndex = 1;
            // lblTotalBooksTitle
            this.lblTotalBooksTitle.AutoSize = true;
            this.lblTotalBooksTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalBooksTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalBooksTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalBooksTitle.Name = "lblTotalBooksTitle";
            this.lblTotalBooksTitle.TabIndex = 0;
            this.lblTotalBooksTitle.Text = "TOTAL BOOKS";
            // lblTotalBooks
            this.lblTotalBooks.AutoSize = true;
            this.lblTotalBooks.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalBooks.Location = new System.Drawing.Point(16, 50);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.TabIndex = 1;
            this.lblTotalBooks.Text = "-";
            // pnlTotalMembers
            this.pnlTotalMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalMembers.Controls.Add(this.lblTotalMembersTitle);
            this.pnlTotalMembers.Controls.Add(this.lblTotalMembers);
            this.pnlTotalMembers.Location = new System.Drawing.Point(330, 70);
            this.pnlTotalMembers.Name = "pnlTotalMembers";
            this.pnlTotalMembers.Size = new System.Drawing.Size(270, 120);
            this.pnlTotalMembers.TabIndex = 2;
            // lblTotalMembersTitle
            this.lblTotalMembersTitle.AutoSize = true;
            this.lblTotalMembersTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalMembersTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalMembersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalMembersTitle.Name = "lblTotalMembersTitle";
            this.lblTotalMembersTitle.TabIndex = 0;
            this.lblTotalMembersTitle.Text = "TOTAL MEMBERS";
            // lblTotalMembers
            this.lblTotalMembers.AutoSize = true;
            this.lblTotalMembers.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalMembers.Location = new System.Drawing.Point(16, 50);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.TabIndex = 1;
            this.lblTotalMembers.Text = "-";
            // pnlBooksIssued
            this.pnlBooksIssued.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBooksIssued.Controls.Add(this.lblBooksIssuedTitle);
            this.pnlBooksIssued.Controls.Add(this.lblBooksIssued);
            this.pnlBooksIssued.Location = new System.Drawing.Point(30, 220);
            this.pnlBooksIssued.Name = "pnlBooksIssued";
            this.pnlBooksIssued.Size = new System.Drawing.Size(270, 120);
            this.pnlBooksIssued.TabIndex = 3;
            // lblBooksIssuedTitle
            this.lblBooksIssuedTitle.AutoSize = true;
            this.lblBooksIssuedTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBooksIssuedTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblBooksIssuedTitle.Location = new System.Drawing.Point(20, 20);
            this.lblBooksIssuedTitle.Name = "lblBooksIssuedTitle";
            this.lblBooksIssuedTitle.TabIndex = 0;
            this.lblBooksIssuedTitle.Text = "BOOKS ISSUED";
            // lblBooksIssued
            this.lblBooksIssued.AutoSize = true;
            this.lblBooksIssued.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblBooksIssued.Location = new System.Drawing.Point(16, 50);
            this.lblBooksIssued.Name = "lblBooksIssued";
            this.lblBooksIssued.TabIndex = 1;
            this.lblBooksIssued.Text = "-";
            // pnlOverdueBooks
            this.pnlOverdueBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOverdueBooks.Controls.Add(this.lblOverdueBooksTitle);
            this.pnlOverdueBooks.Controls.Add(this.lblOverdueBooks);
            this.pnlOverdueBooks.Location = new System.Drawing.Point(330, 220);
            this.pnlOverdueBooks.Name = "pnlOverdueBooks";
            this.pnlOverdueBooks.Size = new System.Drawing.Size(270, 120);
            this.pnlOverdueBooks.TabIndex = 4;
            // lblOverdueBooksTitle
            this.lblOverdueBooksTitle.AutoSize = true;
            this.lblOverdueBooksTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOverdueBooksTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblOverdueBooksTitle.Location = new System.Drawing.Point(20, 20);
            this.lblOverdueBooksTitle.Name = "lblOverdueBooksTitle";
            this.lblOverdueBooksTitle.TabIndex = 0;
            this.lblOverdueBooksTitle.Text = "OVERDUE BOOKS";
            // lblOverdueBooks
            this.lblOverdueBooks.AutoSize = true;
            this.lblOverdueBooks.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblOverdueBooks.Location = new System.Drawing.Point(16, 50);
            this.lblOverdueBooks.Name = "lblOverdueBooks";
            this.lblOverdueBooks.TabIndex = 1;
            this.lblOverdueBooks.Text = "-";
            // btnRefresh
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.Location = new System.Drawing.Point(570, 390);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            // MainForm
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System - Dashboard";
            this.topPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.pnlTotalBooks.ResumeLayout(false);
            this.pnlTotalBooks.PerformLayout();
            this.pnlTotalMembers.ResumeLayout(false);
            this.pnlTotalMembers.PerformLayout();
            this.pnlBooksIssued.ResumeLayout(false);
            this.pnlBooksIssued.PerformLayout();
            this.pnlOverdueBooks.ResumeLayout(false);
            this.pnlOverdueBooks.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel   topPanel;
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Panel   leftPanel;
        private System.Windows.Forms.Button  btnManageBooks;
        private System.Windows.Forms.Button  btnManageMembers;
        private System.Windows.Forms.Button  btnIssueReturn;
        private System.Windows.Forms.Button  btnViewReports;
        private System.Windows.Forms.Panel   rightPanel;
        private System.Windows.Forms.Label   lblDashboard;
        private System.Windows.Forms.Panel   pnlTotalBooks;
        private System.Windows.Forms.Label   lblTotalBooksTitle;
        private System.Windows.Forms.Label   lblTotalBooks;
        private System.Windows.Forms.Panel   pnlTotalMembers;
        private System.Windows.Forms.Label   lblTotalMembersTitle;
        private System.Windows.Forms.Label   lblTotalMembers;
        private System.Windows.Forms.Panel   pnlBooksIssued;
        private System.Windows.Forms.Label   lblBooksIssuedTitle;
        private System.Windows.Forms.Label   lblBooksIssued;
        private System.Windows.Forms.Panel   pnlOverdueBooks;
        private System.Windows.Forms.Label   lblOverdueBooksTitle;
        private System.Windows.Forms.Label   lblOverdueBooks;
        private System.Windows.Forms.Button  btnRefresh;
    }
}
