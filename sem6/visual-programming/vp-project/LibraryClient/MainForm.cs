using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Services;
using LibraryClient.Models;

namespace LibraryClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            btnManageBooks.Click   += (s, e) => { using (var f = new BooksForm())       f.ShowDialog(); };
            btnManageMembers.Click += (s, e) => { using (var f = new MembersForm())     f.ShowDialog(); };
            btnIssueReturn.Click   += (s, e) => { using (var f = new IssueReturnForm()) f.ShowDialog(); };
            btnViewReports.Click   += (s, e) => { using (var f = new ReportsForm())     f.ShowDialog(); };
            btnRefresh.Click       += async (s, e) => await LoadStatsAsync();

            this.Load += MainForm_Load;
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

            var active = await ApiService.GetAsync<Transaction>("transactions/active");
            if (active != null) lblBooksIssued.Text = active.Count.ToString();

            var overdue = await ApiService.GetAsync<Transaction>("transactions/overdue");
            if (overdue != null) lblOverdueBooks.Text = overdue.Count.ToString();
        }
    }
}
