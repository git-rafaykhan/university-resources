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
    public class ReportsForm : Form
    {
        private TabControl tabControl;
        private TabPage tabOverdue;
        private TabPage tabHistory;
        private TabPage tabStock;

        // Overdue Tab
        private DataGridView gridOverdue;
        private Button btnExportOverdue;

        // History Tab
        private DataGridView gridHistory;
        private Button btnExportHistory;

        // Stock Tab
        private DataGridView gridStock;
        private Button btnExportStock;

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "View Reports";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;

            tabControl = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10) };
            this.Controls.Add(tabControl);

            tabOverdue = new TabPage("Overdue Books") { Padding = new Padding(10) };
            tabHistory = new TabPage("Transaction History") { Padding = new Padding(10) };
            tabStock = new TabPage("Stock Summary") { Padding = new Padding(10) };

            tabControl.TabPages.Add(tabOverdue);
            tabControl.TabPages.Add(tabHistory);
            tabControl.TabPages.Add(tabStock);

            // --- OVERDUE TAB ---
            var topPanelOverdue = new Panel { Dock = DockStyle.Top, Height = 60 };
            tabOverdue.Controls.Add(topPanelOverdue);

            btnExportOverdue = new Button { Text = "Export to CSV", Location = new Point(10, 10), Width = 150, Height = 40, BackColor = Color.LightGray };
            btnExportOverdue.Click += (s, e) => ExportToCsv(gridOverdue, "OverdueBooksReport.csv");
            topPanelOverdue.Controls.Add(btnExportOverdue);

            gridOverdue = CreateGrid();
            gridOverdue.CellFormatting += GridOverdue_CellFormatting;
            tabOverdue.Controls.Add(gridOverdue);
            gridOverdue.BringToFront();

            // --- HISTORY TAB ---
            var topPanelHistory = new Panel { Dock = DockStyle.Top, Height = 60 };
            tabHistory.Controls.Add(topPanelHistory);

            btnExportHistory = new Button { Text = "Export to CSV", Location = new Point(10, 10), Width = 150, Height = 40, BackColor = Color.LightGray };
            btnExportHistory.Click += (s, e) => ExportToCsv(gridHistory, "TransactionHistoryReport.csv");
            topPanelHistory.Controls.Add(btnExportHistory);

            gridHistory = CreateGrid();
            tabHistory.Controls.Add(gridHistory);
            gridHistory.BringToFront();

            // --- STOCK TAB ---
            var topPanelStock = new Panel { Dock = DockStyle.Top, Height = 60 };
            tabStock.Controls.Add(topPanelStock);

            btnExportStock = new Button { Text = "Export to CSV", Location = new Point(10, 10), Width = 150, Height = 40, BackColor = Color.LightGray };
            btnExportStock.Click += (s, e) => ExportToCsv(gridStock, "StockSummaryReport.csv");
            topPanelStock.Controls.Add(btnExportStock);

            gridStock = CreateGrid();
            gridStock.CellFormatting += GridStock_CellFormatting;
            tabStock.Controls.Add(gridStock);
            gridStock.BringToFront();

            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            this.Load += ReportsForm_Load;
        }

        private DataGridView CreateGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.WhiteSmoke },
                BackgroundColor = Color.White
            };
        }

        private async void ReportsForm_Load(object? sender, EventArgs e)
        {
            await LoadOverdueAsync();
        }

        private async void TabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabOverdue) await LoadOverdueAsync();
            else if (tabControl.SelectedTab == tabHistory) await LoadHistoryAsync();
            else if (tabControl.SelectedTab == tabStock) await LoadStockAsync();
        }

        private async Task LoadOverdueAsync()
        {
            var overdue = await ApiService.GetAsync<Transaction>("transactions/overdue");
            if (overdue != null)
            {
                gridOverdue.DataSource = overdue;
                string[] visibleCols = { "MemberName", "BookTitle", "IssuedOn", "DueDate", "DaysOverdue" };
                FilterGridColumns(gridOverdue, visibleCols);
            }
        }

        private async Task LoadHistoryAsync()
        {
            var history = await ApiService.GetAsync<Transaction>("transactions/history");
            if (history != null)
            {
                gridHistory.DataSource = history;
                string[] visibleCols = { "BookTitle", "MemberName", "IssuedOn", "DueDate", "ReturnedOn", "Status" };
                FilterGridColumns(gridHistory, visibleCols);
            }
        }

        private async Task LoadStockAsync()
        {
            var books = await ApiService.GetAsync<Book>("books");
            if (books != null)
            {
                gridStock.DataSource = books;
                string[] visibleCols = { "Title", "Author", "CategoryName", "TotalStock", "AvailableStock", "Issued" };
                FilterGridColumns(gridStock, visibleCols);
                if (gridStock.Columns.Contains("CategoryName")) gridStock.Columns["CategoryName"].HeaderText = "Category";
                if (gridStock.Columns.Contains("AvailableStock")) gridStock.Columns["AvailableStock"].HeaderText = "Available";
            }
        }

        private void FilterGridColumns(DataGridView grid, string[] visibleCols)
        {
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.Visible = visibleCols.Contains(col.Name);
            }

            // Set precise order
            for (int i = 0; i < visibleCols.Length; i++)
            {
                if (grid.Columns.Contains(visibleCols[i]))
                {
                    grid.Columns[visibleCols[i]].DisplayIndex = i;
                }
            }
        }

        private void GridOverdue_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && gridOverdue.Columns[e.ColumnIndex].Name == "DaysOverdue" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int days) && days > 7)
                {
                    gridOverdue.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    gridOverdue.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    gridOverdue.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                    gridOverdue.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private void GridStock_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && gridStock.Columns[e.ColumnIndex].Name == "AvailableStock" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int available) && available == 0)
                {
                    gridStock.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    gridStock.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.LightCoral;
                }
            }
        }

        private void ExportToCsv(DataGridView grid, string defaultFileName)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV Files|*.csv", FileName = defaultFileName })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var visibleColumns = grid.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).OrderBy(c => c.DisplayIndex).ToList();

                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            // Write headers
                            var headers = visibleColumns.Select(c => "\"" + c.HeaderText.Replace("\"", "\"\"") + "\"");
                            sw.WriteLine(string.Join(",", headers));

                            // Write rows
                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                var cells = visibleColumns.Select(c =>
                                {
                                    var val = row.Cells[c.Name].Value;
                                    string text = val == null ? "" : val.ToString() ?? "";
                                    return "\"" + text.Replace("\"", "\"\"") + "\"";
                                });
                                sw.WriteLine(string.Join(",", cells));
                            }
                        }

                        MessageBox.Show("Data exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
