using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Services;
using LibraryClient.Models;

namespace LibraryClient
{
    public class MainForm : Form
    {
        private Label lblTitle;
        private Panel leftPanel;
        private Panel rightPanel;

        private Button btnManageBooks;
        private Button btnManageMembers;
        private Button btnIssueReturn;
        private Button btnViewReports;

        private Label lblTotalBooks;
        private Label lblTotalMembers;
        private Label lblBooksIssued;
        private Label lblOverdueBooks;
        private Button btnRefresh;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Library Management System - Dashboard";
            this.Size = new Size(900, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // TOP AREA
            var topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = ColorTranslator.FromHtml("#1a237e")
            };
            
            lblTitle = new Label
            {
                Text = "Library Management System",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            topPanel.Controls.Add(lblTitle);

            // LEFT PANEL
            leftPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = ColorTranslator.FromHtml("#f5f5f5")
            };

            btnManageBooks = CreateNavButton("Manage Books", 0);
            btnManageMembers = CreateNavButton("Manage Members", 60);
            btnIssueReturn = CreateNavButton("Issue / Return Book", 120);
            btnViewReports = CreateNavButton("View Reports", 180);

            leftPanel.Controls.Add(btnManageBooks);
            leftPanel.Controls.Add(btnManageMembers);
            leftPanel.Controls.Add(btnIssueReturn);
            leftPanel.Controls.Add(btnViewReports);

            // RIGHT PANEL
            rightPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            var lblDashboard = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true
            };
            rightPanel.Controls.Add(lblDashboard);

            // Stat cards
            var card1 = CreateStatCard("Total Books", out lblTotalBooks, 30, 70);
            var card2 = CreateStatCard("Total Members", out lblTotalMembers, 330, 70);
            var card3 = CreateStatCard("Books Issued", out lblBooksIssued, 30, 220);
            var card4 = CreateStatCard("Overdue Books", out lblOverdueBooks, 330, 220);

            rightPanel.Controls.Add(card1);
            rightPanel.Controls.Add(card2);
            rightPanel.Controls.Add(card3);
            rightPanel.Controls.Add(card4);

            // Refresh Button
            btnRefresh = new Button
            {
                Text = "Refresh",
                Font = new Font("Segoe UI", 10),
                Size = new Size(100, 40),
                Location = new Point(570, 390),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = ColorTranslator.FromHtml("#e0e0e0"),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += async (s, e) => await LoadStatsAsync();
            rightPanel.Controls.Add(btnRefresh);

            // The order in which controls are added affects Docking priority in WinForms.
            // Controls added FIRST are given the remaining space (Dock Fill).
            // Controls added LAST are placed at the edges first.
            this.Controls.Add(rightPanel); // Fill space left by others
            this.Controls.Add(leftPanel);  // Takes Left
            this.Controls.Add(topPanel);   // Takes Top

            // Setup Navigation Events
            btnManageBooks.Click += (s, e) => { using (var f = new BooksForm()) f.ShowDialog(); };
            btnManageMembers.Click += (s, e) => { using (var f = new MembersForm()) f.ShowDialog(); };
            btnIssueReturn.Click += (s, e) => { using (var f = new IssueReturnForm()) f.ShowDialog(); };
            btnViewReports.Click += (s, e) => { using (var f = new ReportsForm()) f.ShowDialog(); };

            this.Load += MainForm_Load;
        }

        private Button CreateNavButton(string text, int top)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 11),
                Location = new Point(0, top),
                Width = 200,
                Height = 60,
                BackColor = ColorTranslator.FromHtml("#f5f5f5"),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private Panel CreateStatCard(string title, out Label valueLabel, int x, int y)
        {
            var pnl = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(270, 120),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTitle = new Label
            {
                Text = title.ToUpper(),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(20, 20),
                AutoSize = true
            };

            valueLabel = new Label
            {
                Text = "-",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(16, 50),
                AutoSize = true
            };

            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(valueLabel);

            return pnl;
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            await LoadStatsAsync();
        }

        private async Task LoadStatsAsync()
        {
            var books = await ApiService.GetAsync<Book>("books");
            if (books != null) lblTotalBooks.Text = books.Count.ToString();

            var members = await ApiService.GetAsync<Member>("members");
            if (members != null) lblTotalMembers.Text = members.Count.ToString();

            var activeTransactions = await ApiService.GetAsync<Transaction>("transactions/active");
            if (activeTransactions != null) lblBooksIssued.Text = activeTransactions.Count.ToString();

            var overdueTransactions = await ApiService.GetAsync<Transaction>("transactions/overdue");
            if (overdueTransactions != null) lblOverdueBooks.Text = overdueTransactions.Count.ToString();
        }
    }
}
