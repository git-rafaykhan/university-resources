namespace LibraryClient
{
    partial class ReportsForm
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
            this.tabOverdue       = new System.Windows.Forms.TabPage();
            this.tabHistory       = new System.Windows.Forms.TabPage();
            this.tabStock         = new System.Windows.Forms.TabPage();
            this.topPanelOverdue  = new System.Windows.Forms.Panel();
            this.btnExportOverdue = new System.Windows.Forms.Button();
            this.gridOverdue      = new System.Windows.Forms.DataGridView();
            this.topPanelHistory  = new System.Windows.Forms.Panel();
            this.btnExportHistory = new System.Windows.Forms.Button();
            this.gridHistory      = new System.Windows.Forms.DataGridView();
            this.topPanelStock    = new System.Windows.Forms.Panel();
            this.btnExportStock   = new System.Windows.Forms.Button();
            this.gridStock        = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabOverdue.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.tabStock.SuspendLayout();
            this.topPanelOverdue.SuspendLayout();
            this.topPanelHistory.SuspendLayout();
            this.topPanelStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverdue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            this.SuspendLayout();
            // tabControl
            this.tabControl.Controls.Add(this.tabOverdue);
            this.tabControl.Controls.Add(this.tabHistory);
            this.tabControl.Controls.Add(this.tabStock);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 700);
            this.tabControl.TabIndex = 0;
            // tabOverdue
            this.tabOverdue.Controls.Add(this.gridOverdue);
            this.tabOverdue.Controls.Add(this.topPanelOverdue);
            this.tabOverdue.Location = new System.Drawing.Point(4, 29);
            this.tabOverdue.Name = "tabOverdue";
            this.tabOverdue.Padding = new System.Windows.Forms.Padding(10);
            this.tabOverdue.Size = new System.Drawing.Size(992, 667);
            this.tabOverdue.TabIndex = 0;
            this.tabOverdue.Text = "Overdue Books";
            // topPanelOverdue
            this.topPanelOverdue.Controls.Add(this.btnExportOverdue);
            this.topPanelOverdue.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanelOverdue.Location = new System.Drawing.Point(10, 10);
            this.topPanelOverdue.Name = "topPanelOverdue";
            this.topPanelOverdue.Size = new System.Drawing.Size(972, 60);
            this.topPanelOverdue.TabIndex = 0;
            // btnExportOverdue
            this.btnExportOverdue.BackColor = System.Drawing.Color.LightGray;
            this.btnExportOverdue.Location = new System.Drawing.Point(10, 10);
            this.btnExportOverdue.Name = "btnExportOverdue";
            this.btnExportOverdue.Size = new System.Drawing.Size(150, 40);
            this.btnExportOverdue.TabIndex = 0;
            this.btnExportOverdue.Text = "Export to CSV";
            // gridOverdue
            this.gridOverdue.AllowUserToAddRows = false;
            this.gridOverdue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridOverdue.BackgroundColor = System.Drawing.Color.White;
            this.gridOverdue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOverdue.Location = new System.Drawing.Point(10, 70);
            this.gridOverdue.Name = "gridOverdue";
            this.gridOverdue.ReadOnly = true;
            this.gridOverdue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOverdue.Size = new System.Drawing.Size(972, 587);
            this.gridOverdue.TabIndex = 1;
            // tabHistory
            this.tabHistory.Controls.Add(this.gridHistory);
            this.tabHistory.Controls.Add(this.topPanelHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 29);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(10);
            this.tabHistory.Size = new System.Drawing.Size(992, 667);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "Transaction History";
            // topPanelHistory
            this.topPanelHistory.Controls.Add(this.btnExportHistory);
            this.topPanelHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanelHistory.Location = new System.Drawing.Point(10, 10);
            this.topPanelHistory.Name = "topPanelHistory";
            this.topPanelHistory.Size = new System.Drawing.Size(972, 60);
            this.topPanelHistory.TabIndex = 0;
            // btnExportHistory
            this.btnExportHistory.BackColor = System.Drawing.Color.LightGray;
            this.btnExportHistory.Location = new System.Drawing.Point(10, 10);
            this.btnExportHistory.Name = "btnExportHistory";
            this.btnExportHistory.Size = new System.Drawing.Size(150, 40);
            this.btnExportHistory.TabIndex = 0;
            this.btnExportHistory.Text = "Export to CSV";
            // gridHistory
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHistory.BackgroundColor = System.Drawing.Color.White;
            this.gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHistory.Location = new System.Drawing.Point(10, 70);
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.ReadOnly = true;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(972, 587);
            this.gridHistory.TabIndex = 1;
            // tabStock
            this.tabStock.Controls.Add(this.gridStock);
            this.tabStock.Controls.Add(this.topPanelStock);
            this.tabStock.Location = new System.Drawing.Point(4, 29);
            this.tabStock.Name = "tabStock";
            this.tabStock.Padding = new System.Windows.Forms.Padding(10);
            this.tabStock.Size = new System.Drawing.Size(992, 667);
            this.tabStock.TabIndex = 2;
            this.tabStock.Text = "Stock Summary";
            // topPanelStock
            this.topPanelStock.Controls.Add(this.btnExportStock);
            this.topPanelStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanelStock.Location = new System.Drawing.Point(10, 10);
            this.topPanelStock.Name = "topPanelStock";
            this.topPanelStock.Size = new System.Drawing.Size(972, 60);
            this.topPanelStock.TabIndex = 0;
            // btnExportStock
            this.btnExportStock.BackColor = System.Drawing.Color.LightGray;
            this.btnExportStock.Location = new System.Drawing.Point(10, 10);
            this.btnExportStock.Name = "btnExportStock";
            this.btnExportStock.Size = new System.Drawing.Size(150, 40);
            this.btnExportStock.TabIndex = 0;
            this.btnExportStock.Text = "Export to CSV";
            // gridStock
            this.gridStock.AllowUserToAddRows = false;
            this.gridStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStock.BackgroundColor = System.Drawing.Color.White;
            this.gridStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStock.Location = new System.Drawing.Point(10, 70);
            this.gridStock.Name = "gridStock";
            this.gridStock.ReadOnly = true;
            this.gridStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStock.Size = new System.Drawing.Size(972, 587);
            this.gridStock.TabIndex = 1;
            // ReportsForm
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.tabControl);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Reports";
            this.tabControl.ResumeLayout(false);
            this.tabOverdue.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            this.tabStock.ResumeLayout(false);
            this.topPanelOverdue.ResumeLayout(false);
            this.topPanelHistory.ResumeLayout(false);
            this.topPanelStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOverdue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl   tabControl;
        private System.Windows.Forms.TabPage      tabOverdue;
        private System.Windows.Forms.TabPage      tabHistory;
        private System.Windows.Forms.TabPage      tabStock;
        private System.Windows.Forms.Panel        topPanelOverdue;
        private System.Windows.Forms.Button       btnExportOverdue;
        private System.Windows.Forms.DataGridView gridOverdue;
        private System.Windows.Forms.Panel        topPanelHistory;
        private System.Windows.Forms.Button       btnExportHistory;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.Panel        topPanelStock;
        private System.Windows.Forms.Button       btnExportStock;
        private System.Windows.Forms.DataGridView gridStock;
    }
}
