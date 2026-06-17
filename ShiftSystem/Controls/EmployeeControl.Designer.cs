namespace ShiftSystem.Controls
{
    partial class EmployeeControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblList = new System.Windows.Forms.Label();
            this.lblSearchHint = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();

            // dgvEmployee
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToDeleteRows = false;
            this.dgvEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;
            this.dgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployee.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colName, this.colPhone, this.colPosition });
            this.dgvEmployee.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.dgvEmployee.Location = new System.Drawing.Point(10, 75);
            this.dgvEmployee.MultiSelect = false;
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ReadOnly = true;
            this.dgvEmployee.RowTemplate.Height = 28;
            this.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.Size = new System.Drawing.Size(560, 480);
            this.dgvEmployee.TabIndex = 2;
            this.dgvEmployee.SelectionChanged += new System.EventHandler(this.dgvEmployee_SelectionChanged);

            // colId
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Width = 40;
            this.colId.FillWeight = 20;

            // colName
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";

            // colPhone
            this.colPhone.HeaderText = "電話";
            this.colPhone.Name = "colPhone";

            // colPosition
            this.colPosition.HeaderText = "職位";
            this.colPosition.Name = "colPosition";

            // lblList
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.lblList.Location = new System.Drawing.Point(10, 10);
            this.lblList.Name = "lblList";
            this.lblList.Text = "員工列表";

            // lblSearchHint
            this.lblSearchHint.AutoSize = true;
            this.lblSearchHint.Font = new System.Drawing.Font("Microsoft JhengHei", 8.5F);
            this.lblSearchHint.ForeColor = System.Drawing.Color.Gray;
            this.lblSearchHint.Location = new System.Drawing.Point(270, 44);
            this.lblSearchHint.Name = "lblSearchHint";
            this.lblSearchHint.Text = "🔍 輸入姓名搜尋";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(10, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // btnImport
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(100, 160, 100);
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(390, 38);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 27);
            this.btnImport.Text = "📥 匯入CSV";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);

            // btnTemplate
            this.btnTemplate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btnTemplate.Location = new System.Drawing.Point(490, 38);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(80, 27);
            this.btnTemplate.Text = "下載範本";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);

            // pnlLeft
            this.pnlLeft.Controls.Add(this.dgvEmployee);
            this.pnlLeft.Controls.Add(this.txtSearch);
            this.pnlLeft.Controls.Add(this.lblSearchHint);
            this.pnlLeft.Controls.Add(this.btnImport);
            this.pnlLeft.Controls.Add(this.btnTemplate);
            this.pnlLeft.Controls.Add(this.lblList);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.TabIndex = 0;

            // pnlRight
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlRight.Controls.Add(this.lblFormTitle);
            this.pnlRight.Controls.Add(this.lblName);
            this.pnlRight.Controls.Add(this.txtName);
            this.pnlRight.Controls.Add(this.lblPhone);
            this.pnlRight.Controls.Add(this.txtPhone);
            this.pnlRight.Controls.Add(this.lblPosition);
            this.pnlRight.Controls.Add(this.txtPosition);
            this.pnlRight.Controls.Add(this.btnAdd);
            this.pnlRight.Controls.Add(this.btnUpdate);
            this.pnlRight.Controls.Add(this.btnDelete);
            this.pnlRight.Controls.Add(this.btnClear);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Width = 280;
            this.pnlRight.TabIndex = 1;

            // lblFormTitle
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Location = new System.Drawing.Point(10, 15);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Text = "員工資料";

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblName.Location = new System.Drawing.Point(10, 55);
            this.lblName.Name = "lblName";
            this.lblName.Text = "姓名 *";

            // txtName
            this.txtName.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.txtName.Location = new System.Drawing.Point(10, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 23);
            this.txtName.TabIndex = 1;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblPhone.Location = new System.Drawing.Point(10, 110);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "電話";

            // txtPhone
            this.txtPhone.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.txtPhone.Location = new System.Drawing.Point(10, 130);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 23);
            this.txtPhone.TabIndex = 2;

            // lblPosition
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.lblPosition.Location = new System.Drawing.Point(10, 165);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Text = "職位";

            // txtPosition
            this.txtPosition.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.txtPosition.Location = new System.Drawing.Point(10, 185);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(250, 23);
            this.txtPosition.TabIndex = 3;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(10, 230);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(250, 36);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "➕ 新增員工";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(100, 160, 100);
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(10, 275);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(250, 36);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "✏️ 更新選取";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 80, 80);
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(10, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(250, 36);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "🗑️ 刪除選取";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.Font = new System.Drawing.Font("Microsoft JhengHei", 9.5F);
            this.btnClear.Location = new System.Drawing.Point(10, 370);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(250, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清除輸入";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // EmployeeControl
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(880, 580);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Label lblSearchHint;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnTemplate;
    }
}
