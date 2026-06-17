namespace ShiftSystem.Controls
{
    partial class StatsControl
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
            this.lblYear = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.chartHours = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvStats = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlTop.Controls.Add(this.lblYear);
            this.pnlTop.Controls.Add(this.nudYear);
            this.pnlTop.Controls.Add(this.lblMonth);
            this.pnlTop.Controls.Add(this.cmbMonth);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.lblSummary);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);

            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblYear.Location = new System.Drawing.Point(10, 18);
            this.lblYear.Text = "年份";

            this.nudYear.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.nudYear.Location = new System.Drawing.Point(45, 15);
            this.nudYear.Maximum = 2100;
            this.nudYear.Minimum = 2020;
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(70, 23);
            this.nudYear.Value = System.DateTime.Now.Year;
            this.nudYear.ValueChanged += new System.EventHandler(this.nudYear_ValueChanged);

            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblMonth.Location = new System.Drawing.Point(130, 18);
            this.lblMonth.Text = "月份";

            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.cmbMonth.Location = new System.Drawing.Point(165, 15);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(80, 25);
            for (int m = 1; m <= 12; m++) this.cmbMonth.Items.Add(m + " 月");
            this.cmbMonth.SelectedIndex = System.DateTime.Now.Month - 1;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);

            this.btnRefresh.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnRefresh.Location = new System.Drawing.Point(260, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 35);
            this.btnRefresh.Text = "🔄 重新整理";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.lblSummary.Location = new System.Drawing.Point(390, 18);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Text = "";

            // splitMain (上：圖表 / 下：表格)
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1.Controls.Add(this.chartHours);
            this.splitMain.Panel2.Controls.Add(this.dgvStats);
            this.splitMain.SplitterDistance = 320;
            this.splitMain.SplitterWidth = 6;

            // chartHours
            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea");
            this.chartHours.ChartAreas.Add(chartArea);
            this.chartHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartHours.Name = "chartHours";
            this.chartHours.BackColor = System.Drawing.Color.White;
            this.chartHours.Padding = new System.Windows.Forms.Padding(10);

            var chartTitle = new System.Windows.Forms.DataVisualization.Charting.Title(
                "員工工時統計圖")
            {
                Font = new System.Drawing.Font("Microsoft JhengHei", 11f, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(60, 60, 60)
            };
            this.chartHours.Titles.Add(chartTitle);

            // dgvStats
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AllowUserToDeleteRows = false;
            this.dgvStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStats.BackgroundColor = System.Drawing.Color.White;
            this.dgvStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStats.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.ReadOnly = true;
            this.dgvStats.RowTemplate.Height = 32;

            // StatsControl
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "StatsControl";
            this.Size = new System.Drawing.Size(880, 580);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblYear, lblMonth, lblSummary;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHours;
        private System.Windows.Forms.DataGridView dgvStats;
    }
}
