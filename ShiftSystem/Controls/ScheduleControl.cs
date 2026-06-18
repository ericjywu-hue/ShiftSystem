using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ShiftSystem.Database;

namespace ShiftSystem.Controls
{
    public partial class ScheduleControl : UserControl
    {
        private bool isCalendarView = false;

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

        private System.Collections.Generic.List<Models.Employee> employeeList;

        private void LoadComboBoxes()
        {
            employeeList = DatabaseHelper.GetAllEmployees();

            cmbEmployee.DataSource = null;
            cmbEmployee.Items.Clear();
            cmbEmployee.DataSource = employeeList;
            cmbEmployee.DisplayMember = "Name";
            cmbEmployee.ValueMember = "Id";

            var nameSource = new AutoCompleteStringCollection();
            nameSource.AddRange(employeeList.Select(emp => emp.Name).ToArray());
            cmbEmployee.AutoCompleteCustomSource = nameSource;
            cmbEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;

            cmbShift.DataSource = null;
            cmbShift.DataSource = DatabaseHelper.GetAllShifts();
            cmbShift.DisplayMember = "ToString";
            cmbShift.ValueMember = "Id";
        }

        // 依目前輸入文字找出對應的員工（支援可輸入篩選的 ComboBox）
        private Models.Employee FindSelectedEmployee()
        {
            if (employeeList == null) return null;
            string text = cmbEmployee.Text.Trim();
            return employeeList.FirstOrDefault(emp => emp.Name == text);
        }

        private void LoadSchedule()
        {
            if (cmbMonth.SelectedIndex < 0) return;
            int year = (int)nudYear.Value;
            int month = cmbMonth.SelectedIndex + 1;
            var dt = DatabaseHelper.GetScheduleByMonth(year, month);

            dgvSchedule.DataSource = dt;
            if (dgvSchedule.Columns.Count > 0)
                dgvSchedule.Columns[0].Visible = false;

            if (isCalendarView)
                BuildCalendar(year, month, dt);
        }

        private void BuildCalendar(int year, int month, DataTable dt)
        {
            calendarPanel.Controls.Clear();
            calendarPanel.RowStyles.Clear();
            calendarPanel.ColumnStyles.Clear();
            calendarPanel.ColumnCount = 7;
            calendarPanel.RowCount = 1;

            for (int c = 0; c < 7; c++)
                calendarPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));

            string[] weekDays = { "日", "一", "二", "三", "四", "五", "六" };
            calendarPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            for (int c = 0; c < 7; c++)
            {
                var lbl = new Label
                {
                    Text = weekDays[c],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft JhengHei", 9.5f, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(70, 130, 180)
                };
                calendarPanel.Controls.Add(lbl, c, 0);
            }

            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startWeekday = (int)firstDay.DayOfWeek; // 0=Sun
            int totalCells = startWeekday + daysInMonth;
            int totalRows = (int)Math.Ceiling(totalCells / 7.0);

            calendarPanel.RowCount = totalRows + 1;
            for (int r = 0; r < totalRows; r++)
                calendarPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / totalRows));

            // 依日期分組班表資料
            var groupedByDate = dt.AsEnumerable()
                .GroupBy(row => row["日期"].ToString())
                .ToDictionary(g => g.Key, g => g.ToList());

            int day = 1;
            for (int r = 0; r < totalRows; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    int cellIndex = r * 7 + c;
                    if (cellIndex < startWeekday || day > daysInMonth)
                    {
                        var blank = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(248, 248, 248) };
                        calendarPanel.Controls.Add(blank, c, r + 1);
                        continue;
                    }

                    string dateStr = $"{year:D4}-{month:D2}-{day:D2}";
                    var dayPanel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.White,
                        Padding = new Padding(3),
                        Margin = new Padding(1)
                    };

                    var lblDay = new Label
                    {
                        Text = day.ToString(),
                        Dock = DockStyle.Top,
                        Height = 18,
                        Font = new Font("Microsoft JhengHei", 8.5f, FontStyle.Bold),
                        ForeColor = Color.FromArgb(90, 90, 90)
                    };
                    dayPanel.Controls.Add(lblDay);

                    if (groupedByDate.TryGetValue(dateStr, out var shifts))
                    {
                        int yOffset = 20;
                        foreach (var row in shifts.Take(3))
                        {
                            var lblShift = new Label
                            {
                                Text = $"{row["員工"]} ({row["班別"]})",
                                Font = new Font("Microsoft JhengHei", 7.5f),
                                AutoSize = false,
                                Location = new Point(2, yOffset),
                                Size = new Size(dayPanel.Width - 6, 16),
                                BackColor = Color.FromArgb(225, 238, 250),
                                ForeColor = Color.FromArgb(40, 90, 140)
                            };
                            dayPanel.Controls.Add(lblShift);
                            yOffset += 17;
                        }
                        if (shifts.Count > 3)
                        {
                            var lblMore = new Label
                            {
                                Text = $"+{shifts.Count - 3} 更多",
                                Font = new Font("Microsoft JhengHei", 7f),
                                ForeColor = Color.Gray,
                                Location = new Point(2, yOffset),
                                AutoSize = true
                            };
                            dayPanel.Controls.Add(lblMore);
                        }
                    }

                    calendarPanel.Controls.Add(dayPanel, c, r + 1);
                    day++;
                }
            }
        }

        private void nudYear_ValueChanged(object sender, EventArgs e) => LoadSchedule();
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e) => LoadSchedule();

        private void btnToggleView_Click(object sender, EventArgs e)
        {
            isCalendarView = !isCalendarView;
            if (isCalendarView)
            {
                dgvSchedule.Visible = false;
                calendarPanel.Visible = true;
                btnToggleView.Text = "📋 切換列表檢視";
                LoadSchedule();
            }
            else
            {
                dgvSchedule.Visible = true;
                calendarPanel.Visible = false;
                btnToggleView.Text = "🗓️ 切換月曆檢視";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var employee = FindSelectedEmployee();
            if (employee == null || cmbShift.SelectedItem == null)
            {
                MessageBox.Show("請從清單中選擇有效的員工和班別！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int empId = employee.Id;
            int shiftId = (int)cmbShift.SelectedValue;
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string name = employee.Name;

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

            var row = dgvSchedule.SelectedRows[0];
            string info = $"{row.Cells["員工"].Value} / {row.Cells["班別"].Value} / {row.Cells["日期"].Value}";
            if (MessageBox.Show($"確定刪除此排班？\n{info}",
                "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int scheduleId = Convert.ToInt32(row.Cells[0].Value);
            DatabaseHelper.DeleteSchedule(scheduleId);
            LoadSchedule();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int year = (int)nudYear.Value;
            int month = cmbMonth.SelectedIndex + 1;
            var sfd = new SaveFileDialog
            {
                Title = "匯出班表",
                Filter = "CSV 檔案|*.csv",
                FileName = $"班表_{year}_{month:D2}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            DatabaseHelper.ExportToCsv(year, month, sfd.FileName);
            MessageBox.Show($"匯出成功！\n{sfd.FileName}", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
