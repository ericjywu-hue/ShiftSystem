using System;
using System.Drawing;
using System.Windows.Forms;
using ShiftSystem.Database;

namespace ShiftSystem.Controls
{
    public partial class ScheduleControl : UserControl
    {
        public ScheduleControl()
        {
            InitializeComponent();
            StyleGrid();
            LoadComboBoxes();
            LoadSchedule();
        }

        public void RefreshData()
        {
            LoadComboBoxes();
            LoadSchedule();
        }

        private void StyleGrid()
        {
            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft JhengHei", 9.5f, FontStyle.Bold);
            dgvSchedule.EnableHeadersVisualStyles = false;
            dgvSchedule.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
        }

        private void LoadComboBoxes()
        {
            cmbEmployee.DataSource    = null;
            cmbEmployee.DataSource    = DatabaseHelper.GetAllEmployees();
            cmbEmployee.DisplayMember = "Name";
            cmbEmployee.ValueMember   = "Id";

            cmbShift.DataSource    = null;
            cmbShift.DataSource    = DatabaseHelper.GetAllShifts();
            cmbShift.DisplayMember = "ToString";
            cmbShift.ValueMember   = "Id";
        }

        private void LoadSchedule()
        {
            if (cmbMonth.SelectedIndex < 0) return;
            int year  = (int)nudYear.Value;
            int month = cmbMonth.SelectedIndex + 1;
            var dt = DatabaseHelper.GetScheduleByMonth(year, month);
            dgvSchedule.DataSource = dt;
            if (dgvSchedule.Columns.Count > 0)
                dgvSchedule.Columns[0].Visible = false;
        }

        private void nudYear_ValueChanged(object sender, EventArgs e) => LoadSchedule();
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e) => LoadSchedule();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedItem == null || cmbShift.SelectedItem == null)
            { MessageBox.Show("請選擇員工和班別！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int    empId  = (int)cmbEmployee.SelectedValue;
            int    shiftId = (int)cmbShift.SelectedValue;
            string date   = dtpDate.Value.ToString("yyyy-MM-dd");
            string name   = cmbEmployee.Text;

            if (DatabaseHelper.HasConflict(empId, date))
            {
                MessageBox.Show($"⚠️ 衝突警告！\n「{name}」在 {date} 已有排班，\n請更換員工或日期。",
                    "排班衝突", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseHelper.AddSchedule(empId, shiftId, date);
            LoadSchedule();
            MessageBox.Show("排班新增成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count == 0)
            { MessageBox.Show("請先選擇要刪除的排班！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var row  = dgvSchedule.SelectedRows[0];
            string info = $"{row.Cells["員工"].Value} / {row.Cells["班別"].Value} / {row.Cells["日期"].Value}";
            if (MessageBox.Show($"確定刪除此排班？\n{info}",
                "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int scheduleId = Convert.ToInt32(row.Cells[0].Value);
            DatabaseHelper.DeleteSchedule(scheduleId);
            LoadSchedule();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int year  = (int)nudYear.Value;
            int month = cmbMonth.SelectedIndex + 1;
            var sfd = new SaveFileDialog
            {
                Title    = "匯出班表",
                Filter   = "CSV 檔案|*.csv",
                FileName = $"班表_{year}_{month:D2}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            DatabaseHelper.ExportToCsv(year, month, sfd.FileName);
            MessageBox.Show($"匯出成功！\n{sfd.FileName}", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
