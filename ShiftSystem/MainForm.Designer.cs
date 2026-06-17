namespace ShiftSystem
{
    partial class MainForm
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
            this.tabControl1    = new System.Windows.Forms.TabControl();
            this.tabEmployee    = new System.Windows.Forms.TabPage();
            this.tabSchedule    = new System.Windows.Forms.TabPage();
            this.tabStats       = new System.Windows.Forms.TabPage();
            this.employeeControl1 = new ShiftSystem.Controls.EmployeeControl();
            this.scheduleControl1 = new ShiftSystem.Controls.ScheduleControl();
            this.statsControl1    = new ShiftSystem.Controls.StatsControl();

            this.tabControl1.SuspendLayout();
            this.tabEmployee.SuspendLayout();
            this.tabSchedule.SuspendLayout();
            this.tabStats.SuspendLayout();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabEmployee);
            this.tabControl1.Controls.Add(this.tabSchedule);
            this.tabControl1.Controls.Add(this.tabStats);
            this.tabControl1.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font     = new System.Drawing.Font("Microsoft JhengHei", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name     = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size     = new System.Drawing.Size(900, 620);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);

            // tabEmployee
            this.tabEmployee.Controls.Add(this.employeeControl1);
            this.tabEmployee.Location = new System.Drawing.Point(4, 26);
            this.tabEmployee.Name     = "tabEmployee";
            this.tabEmployee.Padding  = new System.Windows.Forms.Padding(3);
            this.tabEmployee.Size     = new System.Drawing.Size(892, 590);
            this.tabEmployee.TabIndex = 0;
            this.tabEmployee.Text     = "👤 員工管理";
            this.tabEmployee.UseVisualStyleBackColor = true;

            // tabSchedule
            this.tabSchedule.Controls.Add(this.scheduleControl1);
            this.tabSchedule.Location = new System.Drawing.Point(4, 26);
            this.tabSchedule.Name     = "tabSchedule";
            this.tabSchedule.Padding  = new System.Windows.Forms.Padding(3);
            this.tabSchedule.Size     = new System.Drawing.Size(892, 590);
            this.tabSchedule.TabIndex = 1;
            this.tabSchedule.Text     = "📅 排班管理";
            this.tabSchedule.UseVisualStyleBackColor = true;

            // tabStats
            this.tabStats.Controls.Add(this.statsControl1);
            this.tabStats.Location = new System.Drawing.Point(4, 26);
            this.tabStats.Name     = "tabStats";
            this.tabStats.Padding  = new System.Windows.Forms.Padding(3);
            this.tabStats.Size     = new System.Drawing.Size(892, 590);
            this.tabStats.TabIndex = 2;
            this.tabStats.Text     = "📊 統計報表";
            this.tabStats.UseVisualStyleBackColor = true;

            // employeeControl1
            this.employeeControl1.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.employeeControl1.Location = new System.Drawing.Point(3, 3);
            this.employeeControl1.Name     = "employeeControl1";
            this.employeeControl1.Size     = new System.Drawing.Size(886, 584);
            this.employeeControl1.TabIndex = 0;

            // scheduleControl1
            this.scheduleControl1.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.scheduleControl1.Location = new System.Drawing.Point(3, 3);
            this.scheduleControl1.Name     = "scheduleControl1";
            this.scheduleControl1.Size     = new System.Drawing.Size(886, 584);
            this.scheduleControl1.TabIndex = 0;

            // statsControl1
            this.statsControl1.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.statsControl1.Location = new System.Drawing.Point(3, 3);
            this.statsControl1.Name     = "statsControl1";
            this.statsControl1.Size     = new System.Drawing.Size(886, 584);
            this.statsControl1.TabIndex = 0;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.tabControl1);
            this.Font            = new System.Drawing.Font("Microsoft JhengHei", 9.75F);
            this.MinimumSize     = new System.Drawing.Size(800, 550);
            this.Name            = "MainForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "超商排班系統";

            this.tabControl1.ResumeLayout(false);
            this.tabEmployee.ResumeLayout(false);
            this.tabSchedule.ResumeLayout(false);
            this.tabStats.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEmployee;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.TabPage tabStats;
        private ShiftSystem.Controls.EmployeeControl employeeControl1;
        private ShiftSystem.Controls.ScheduleControl scheduleControl1;
        private ShiftSystem.Controls.StatsControl    statsControl1;
    }
}
