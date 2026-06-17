using System;
using System.Drawing;
using System.Windows.Forms;
using ShiftSystem.Database;
using ShiftSystem.Models;

namespace ShiftSystem.Controls
{
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();
            StyleGrid();
            LoadData();
        }

        private void StyleGrid()
        {
            dgvEmployee.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            dgvEmployee.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft JhengHei", 9.5f, FontStyle.Bold);
            dgvEmployee.EnableHeadersVisualStyles = false;
            dgvEmployee.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
        }

        private void LoadData(string keyword = "")
        {
            dgvEmployee.Rows.Clear();
            foreach (var e in DatabaseHelper.GetAllEmployees())
                if (string.IsNullOrEmpty(keyword) || e.Name.Contains(keyword))
                    dgvEmployee.Rows.Add(e.Id, e.Name, e.Phone, e.Position);
        }

        private void ClearFields()
        {
            txtName.Text = txtPhone.Text = txtPosition.Text = "";
            dgvEmployee.ClearSelection();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count == 0) return;
            var row = dgvEmployee.SelectedRows[0];
            txtName.Text = row.Cells["colName"].Value?.ToString();
            txtPhone.Text = row.Cells["colPhone"].Value?.ToString();
            txtPosition.Text = row.Cells["colPosition"].Value?.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("請填寫姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            DatabaseHelper.AddEmployee(new Employee
            {
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Position = txtPosition.Text.Trim()
            });
            ClearFields();
            LoadData();
            MessageBox.Show("員工新增成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells["colId"].Value);
            DatabaseHelper.UpdateEmployee(new Employee
            {
                Id = id,
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Position = txtPosition.Text.Trim()
            });
            LoadData();
            MessageBox.Show("更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count == 0) return;
            string name = dgvEmployee.SelectedRows[0].Cells["colName"].Value?.ToString();
            if (MessageBox.Show($"確定刪除員工「{name}」？\n相關排班也會一併刪除。",
                "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            int id = Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells["colId"].Value);
            DatabaseHelper.DeleteEmployee(id);
            ClearFields();
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        private void btnImport_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Title = "選擇員工 CSV 檔案",
                Filter = "CSV 檔案|*.csv|所有檔案|*.*"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                int count = DatabaseHelper.ImportEmployeesFromCsv(ofd.FileName);
                LoadData();
                MessageBox.Show($"匯入完成！共新增 {count} 位員工。", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"匯入失敗：{ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Title = "儲存 CSV 範本",
                Filter = "CSV 檔案|*.csv",
                FileName = "員工範本.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            string[] sample =
            {
                "姓名,電話,職位",
                "王小明,0912345678,店長",
                "李小美,0922334455,正職",
                "陳大山,0933445566,兼職"
            };
            System.IO.File.WriteAllLines(sfd.FileName, sample, System.Text.Encoding.UTF8);
            MessageBox.Show($"範本已儲存：\n{sfd.FileName}\n\n請依格式填入員工資料後再用「匯入CSV」匯入。",
                "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
