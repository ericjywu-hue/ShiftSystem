using System;
using System.Windows.Forms;
using ShiftSystem.Database;

namespace ShiftSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            DatabaseHelper.Initialize();
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 切換分頁時刷新資料
            if (tabControl1.SelectedTab == tabSchedule)
                scheduleControl1.RefreshData();
            else if (tabControl1.SelectedTab == tabStats)
                statsControl1.RefreshData();
        }
    }
}