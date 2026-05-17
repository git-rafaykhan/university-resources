using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryClient.Models;
using LibraryClient.Services;

namespace LibraryClient
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();

            gridOverdue.CellFormatting += GridOverdue_CellFormatting;
            gridStock.CellFormatting   += GridStock_CellFormatting;

            btnExportOverdue.Click += (s, e) => ExportToCsv(gridOverdue, "OverdueBooksReport.csv");
            btnExportHistory.Click += (s, e) => ExportToCsv(gridHistory, "TransactionHistoryReport.csv");
            btnExportStock.Click   += (s, e) => ExportToCsv(gridStock,   "StockSummaryReport.csv");

            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            this.Load += ReportsForm_Load;
        }

        private async void ReportsForm_Load(object? sender, EventArgs e)
        {
            await LoadOverdueAsync();
        }

        private async void TabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if      (tabControl.SelectedTab == tabOverdue) await LoadOverdueAsync();
            else if (tabControl.SelectedTab == tabHistory) await LoadHistoryAsync();
            else if (tabControl.SelectedTab == tabStock)   await LoadStockAsync();
        }

        private async Task LoadOverdueAsync()
        {
            var overdue = await ApiService.GetAsync<Transaction>("transactions/overdue");
            if (overdue != null)
            {
                gridOverdue.DataSource = overdue;
                FilterGridColumns(gridOverdue, new[] { "MemberName", "BookTitle", "IssuedOn", "DueDate", "DaysOverdue" });
            }
        }

        private async Task LoadHistoryAsync()
        {
            var history = await ApiService.GetAsync<Transaction>("transactions/history");
            if (history != null)
            {
                gridHistory.DataSource = history;
                FilterGridColumns(gridHistory, new[] { "BookTitle", "MemberName", "IssuedOn", "DueDate", "ReturnedOn", "Status" });
            }
        }

        private async Task LoadStockAsync()
        {
            var books = await ApiService.GetAsync<Book>("books");
            if (books != null)
            {
                gridStock.DataSource = books;
                FilterGridColumns(gridStock, new[] { "Title", "Author", "CategoryName", "TotalStock", "AvailableStock", "Issued" });
                if (gridStock.Columns.Contains("CategoryName"))   gridStock.Columns["CategoryName"].HeaderText   = "Category";
                if (gridStock.Columns.Contains("AvailableStock")) gridStock.Columns["AvailableStock"].HeaderText = "Available";
            }
        }

        private void FilterGridColumns(DataGridView grid, string[] visibleCols)
        {
            foreach (DataGridViewColumn col in grid.Columns)
                col.Visible = visibleCols.Contains(col.Name);

            for (int i = 0; i < visibleCols.Length; i++)
                if (grid.Columns.Contains(visibleCols[i]))
                    grid.Columns[visibleCols[i]].DisplayIndex = i;
        }

        private void GridOverdue_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0
                && gridOverdue.Columns[e.ColumnIndex].Name == "DaysOverdue"
                && e.Value != null
                && int.TryParse(e.Value.ToString(), out int days)
                && days > 7)
            {
                gridOverdue.Rows[e.RowIndex].DefaultCellStyle.BackColor          = Color.LightCoral;
                gridOverdue.Rows[e.RowIndex].DefaultCellStyle.ForeColor          = Color.White;
                gridOverdue.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                gridOverdue.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private void GridStock_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0
                && gridStock.Columns[e.ColumnIndex].Name == "AvailableStock"
                && e.Value != null
                && int.TryParse(e.Value.ToString(), out int available)
                && available == 0)
            {
                gridStock.Rows[e.RowIndex].DefaultCellStyle.BackColor          = Color.MistyRose;
                gridStock.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.LightCoral;
            }
        }

        private void ExportToCsv(DataGridView grid, string defaultFileName)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog { Filter = "CSV Files|*.csv", FileName = defaultFileName })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var visibleColumns = grid.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .OrderBy(c => c.DisplayIndex)
                        .ToList();

                    using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine(string.Join(",",
                            visibleColumns.Select(c => "\"" + c.HeaderText.Replace("\"", "\"\"") + "\"")));

                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            var cells = visibleColumns.Select(c =>
                            {
                                var val  = row.Cells[c.Name].Value;
                                var text = val == null ? "" : val.ToString() ?? "";
                                return "\"" + text.Replace("\"", "\"\"") + "\"";
                            });
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }

                    MessageBox.Show("Data exported successfully!", "Export",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
