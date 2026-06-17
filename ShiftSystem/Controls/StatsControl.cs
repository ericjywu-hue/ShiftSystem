using System;
using System.Drawing;
using System.Windows.Forms;
using ShiftSystem.Database;

namespace ShiftSystem.Controls
{
    public partial class StatsControl : UserControl
    {
        public StatsControl()
        {
            InitializeComponent();
            StyleGrid();
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

        private void LoadStats()
        {
            if (cmbMonth.SelectedIndex < 0) return;
            int year  = (int)nudYear.Value;
            int month = cmbMonth.SelectedIndex + 1;
            var dt = DatabaseHelper.GetMonthlyHours(year, month);
            dgvStats.DataSource = dt;

            int totalShifts = 0, totalHours = 0;
            foreach (System.Data.DataRow row in dt.Rows)
            {
                totalShifts += Convert.ToInt32(row["班次"]);
                totalHours  += Convert.ToInt32(row["工時"]);
            }
            lblSummary.Text = $"本月合計：{dt.Rows.Count} 位員工 ／ {totalShifts} 班次 ／ {totalHours} 工時";
        }

        private void nudYear_ValueChanged(object sender, EventArgs e) => LoadStats();
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e) => LoadStats();
        private void btnRefresh_Click(object sender, EventArgs e) => LoadStats();
    }
}
