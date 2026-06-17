namespace ShiftSystem.Controls
{
    partial class ScheduleControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblEmp = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnToggleView = new System.Windows.Forms.Button();
            this.calendarPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlTop.Controls.Add(this.lblEmp);
            this.pnlTop.Controls.Add(this.cmbEmployee);
            this.pnlTop.Controls.Add(this.lblShift);
            this.pnlTop.Controls.Add(this.cmbShift);
            this.pnlTop.Controls.Add(this.lblDate);
            this.pnlTop.Controls.Add(this.dtpDate);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.lblYear);
            this.pnlTop.Controls.Add(this.nudYear);
            this.pnlTop.Controls.Add(this.lblMonth);
            this.pnlTop.Controls.Add(this.cmbMonth);
            this.pnlTop.Controls.Add(this.btnDelete);
            this.pnlTop.Controls.Add(this.btnExport);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 115;
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);

            // 第一排：新增排班
            this.lblEmp.AutoSize = true;
            this.lblEmp.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblEmp.Location = new System.Drawing.Point(10, 12);
            this.lblEmp.Text = "員工";

            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.cmbEmployee.Location = new System.Drawing.Point(10, 30);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(140, 25);

            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblShift.Location = new System.Drawing.Point(165, 12);
            this.lblShift.Text = "班別";

            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.cmbShift.Location = new System.Drawing.Point(165, 30);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(170, 25);

            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblDate.Location = new System.Drawing.Point(350, 12);
            this.lblDate.Text = "日期";

            this.dtpDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(350, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 23);

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(515, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 35);
            this.btnAdd.Text = "➕ 新增排班";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 第二排：篩選 + 操作
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblYear.Location = new System.Drawing.Point(10, 78);
            this.lblYear.Text = "年份";

            this.nudYear.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.nudYear.Location = new System.Drawing.Point(45, 75);
            this.nudYear.Maximum = 2100;
            this.nudYear.Minimum = 2020;
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(70, 23);
            this.nudYear.Value = System.DateTime.Now.Year;
            this.nudYear.ValueChanged += new System.EventHandler(this.nudYear_ValueChanged);

            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblMonth.Location = new System.Drawing.Point(130, 78);
            this.lblMonth.Text = "月份";

            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.cmbMonth.Location = new System.Drawing.Point(165, 75);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(80, 25);
            for (int m = 1; m <= 12; m++) this.cmbMonth.Items.Add(m + " 月");
            this.cmbMonth.SelectedIndex = System.DateTime.Now.Month - 1;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);

            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 80, 80);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(260, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.Text = "🗑️ 刪除選取";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnExport.BackColor = System.Drawing.Color.FromArgb(100, 160, 100);
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(385, 70);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 35);
            this.btnExport.Text = "📤 匯出 CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.btnToggleView.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnToggleView.Location = new System.Drawing.Point(515, 67);
            this.btnToggleView.Name = "btnToggleView";
            this.btnToggleView.Size = new System.Drawing.Size(130, 35);
            this.btnToggleView.Text = "🗓️ 切換月曆檢視";
            this.btnToggleView.Click += new System.EventHandler(this.btnToggleView_Click);
            this.pnlTop.Controls.Add(this.btnToggleView);

            // calendarPanel
            this.calendarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Visible = false;
            this.calendarPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.calendarPanel.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);

            // dgvSchedule
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.dgvSchedule.MultiSelect = false;
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowTemplate.Height = 28;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // ScheduleControl
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.calendarPanel);
            this.Controls.Add(this.pnlTop);
            this.Name = "ScheduleControl";
            this.Size = new System.Drawing.Size(880, 580);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblEmp, lblShift, lblDate, lblYear, lblMonth;
        private System.Windows.Forms.ComboBox cmbEmployee, cmbShift, cmbMonth;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Button btnAdd, btnDelete, btnExport, btnToggleView;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.TableLayoutPanel calendarPanel;
    }
}
