using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ShiftSystem.Database;

namespace ShiftSystem.Controls
{
    public partial class StatsControl : UserControl
    {
        public StatsControl()
        {
            InitializeComponent();
            StyleGrid();
            StyleChart();
            LoadStats();
        }

        public void RefreshData() => LoadStats();

        private void StyleGrid()
        {
            dgvStats.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            dgvStats.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStats.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft JhengHei", 10f, FontStyle.Bold);
            dgvStats.EnableHeadersVisualStyles = false;
            dgvStats.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
        }

        private void StyleChart()
        {
            chartHours.ChartAreas.Clear();
            var area = new ChartArea("MainArea")
            {
                BackColor = Color.White
            };
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            area.AxisX.LabelStyle.Font = new Font("Microsoft JhengHei", 9f);
            area.AxisY.LabelStyle.Font = new Font("Microsoft JhengHei", 9f);
            area.AxisY.Title = "工時 (小時)";
            area.AxisY.TitleFont = new Font("Microsoft JhengHei", 9f);
            chartHours.ChartAreas.Add(area);

            chartHours.Series.Clear();
            var series = new Series("工時")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(70, 130, 180),
                IsValueShownAsLabel = true,
                Font = new Font("Microsoft JhengHei", 8.5f),
                LabelForeColor = Color.FromArgb(60, 60, 60)
            };
            chartHours.Series.Add(series);
            chartHours.Legends.Clear();
        }

        private void LoadStats()
        {
            if (cmbMonth.SelectedIndex < 0) return;
            int year = (int)nudYear.Value;
            int month = cmbMonth.SelectedIndex + 1;
            var dt = DatabaseHelper.GetMonthlyHours(year, month);
            dgvStats.DataSource = dt;

            // 更新長條圖
            var series = chartHours.Series["工時"];
            series.Points.Clear();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string name = row["員工"].ToString();
                int hours = Convert.ToInt32(row["工時"]);
                series.Points.AddXY(name, hours);
            }

            int totalShifts = 0, totalHours = 0;
            foreach (System.Data.DataRow row in dt.Rows)
            {
                totalShifts += Convert.ToInt32(row["班次"]);
                totalHours += Convert.ToInt32(row["工時"]);
            }
            lblSummary.Text = $"本月合計：{dt.Rows.Count} 位員工 ／ {totalShifts} 班次 ／ {totalHours} 工時";
        }

        private void nudYear_ValueChanged(object sender, EventArgs e) => LoadStats();
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e) => LoadStats();
        private void btnRefresh_Click(object sender, EventArgs e) => LoadStats();
    }
}

