namespace SG_WorkManager.ViewControl
{
    partial class VacationViewControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel4 = new Panel();
            panel1 = new Panel();
            btnDelete = new Button();
            btnAddVacationUse = new Button();
            dataGridView1 = new DataGridView();
            Column2 = new DataGridViewCheckBoxColumn();
            카운트 = new DataGridViewTextBoxColumn();
            col01_DT = new DataGridViewTextBoxColumn();
            col02_Exist = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            cbbYear = new ComboBox();
            btnPreYear = new Button();
            btnNextYear = new Button();
            label1 = new Label();
            txbVacationMaxCount = new TextBox();
            label2 = new Label();
            btnApplyVacationMaxCount = new Button();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.Controls.Add(panel1);
            panel4.Controls.Add(dataGridView1);
            panel4.Location = new Point(12, 79);
            panel4.Name = "panel4";
            panel4.Size = new Size(612, 442);
            panel4.TabIndex = 36;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnAddVacationUse);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 397);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(612, 45);
            panel1.TabIndex = 38;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(5, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(84, 35);
            btnDelete.TabIndex = 36;
            btnDelete.Text = "삭제";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAddVacationUse
            // 
            btnAddVacationUse.Dock = DockStyle.Right;
            btnAddVacationUse.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddVacationUse.Location = new Point(523, 5);
            btnAddVacationUse.Name = "btnAddVacationUse";
            btnAddVacationUse.Size = new Size(84, 35);
            btnAddVacationUse.TabIndex = 35;
            btnAddVacationUse.Text = "추가";
            btnAddVacationUse.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column2, 카운트, col01_DT, col02_Exist, Column1 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(612, 442);
            dataGridView1.TabIndex = 37;
            // 
            // Column2
            // 
            Column2.FalseValue = "";
            Column2.Frozen = true;
            Column2.HeaderText = " ";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.TrueValue = "";
            Column2.Width = 30;
            // 
            // 카운트
            // 
            카운트.Frozen = true;
            카운트.HeaderText = "카운트";
            카운트.Name = "카운트";
            카운트.ReadOnly = true;
            // 
            // col01_DT
            // 
            col01_DT.Frozen = true;
            col01_DT.HeaderText = "날짜";
            col01_DT.Name = "col01_DT";
            col01_DT.ReadOnly = true;
            col01_DT.Width = 80;
            // 
            // col02_Exist
            // 
            col02_Exist.Frozen = true;
            col02_Exist.HeaderText = "요일";
            col02_Exist.Name = "col02_Exist";
            col02_Exist.ReadOnly = true;
            col02_Exist.Width = 80;
            // 
            // Column1
            // 
            Column1.HeaderText = "제목";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // cbbYear
            // 
            cbbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbYear.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbYear.FormattingEnabled = true;
            cbbYear.Location = new Point(198, 25);
            cbbYear.Name = "cbbYear";
            cbbYear.Size = new Size(87, 29);
            cbbYear.TabIndex = 37;
            // 
            // btnPreYear
            // 
            btnPreYear.Location = new Point(85, 10);
            btnPreYear.Name = "btnPreYear";
            btnPreYear.Size = new Size(82, 50);
            btnPreYear.TabIndex = 38;
            btnPreYear.Text = "<";
            btnPreYear.UseVisualStyleBackColor = true;
            // 
            // btnNextYear
            // 
            btnNextYear.Location = new Point(319, 10);
            btnNextYear.Name = "btnNextYear";
            btnNextYear.Size = new Size(82, 50);
            btnNextYear.TabIndex = 39;
            btnNextYear.Text = ">";
            btnNextYear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(55, 30);
            label1.TabIndex = 40;
            label1.Text = "연도";
            // 
            // txbVacationMaxCount
            // 
            txbVacationMaxCount.Location = new Point(549, 50);
            txbVacationMaxCount.Name = "txbVacationMaxCount";
            txbVacationMaxCount.Size = new Size(30, 23);
            txbVacationMaxCount.TabIndex = 41;
            txbVacationMaxCount.Text = "16";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(468, 53);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 42;
            label2.Text = "연차 총 개수";
            // 
            // btnApplyVacationMaxCount
            // 
            btnApplyVacationMaxCount.Location = new Point(585, 50);
            btnApplyVacationMaxCount.Name = "btnApplyVacationMaxCount";
            btnApplyVacationMaxCount.Size = new Size(39, 23);
            btnApplyVacationMaxCount.TabIndex = 43;
            btnApplyVacationMaxCount.Text = "적용";
            btnApplyVacationMaxCount.UseVisualStyleBackColor = true;
            // 
            // VacationViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnApplyVacationMaxCount);
            Controls.Add(label2);
            Controls.Add(txbVacationMaxCount);
            Controls.Add(label1);
            Controls.Add(btnNextYear);
            Controls.Add(btnPreYear);
            Controls.Add(cbbYear);
            Controls.Add(panel4);
            Name = "VacationViewControl";
            Size = new Size(723, 539);
            panel4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel4;
        private Panel panel1;
        private Button btnAddVacationUse;
        private DataGridView dataGridView1;
        private ComboBox cbbYear;
        private Button btnPreYear;
        private Button btnNextYear;
        private Label label1;
        private Button btnDelete;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewTextBoxColumn 카운트;
        private DataGridViewTextBoxColumn col01_DT;
        private DataGridViewTextBoxColumn col02_Exist;
        private DataGridViewTextBoxColumn Column1;
        private TextBox txbVacationMaxCount;
        private Label label2;
        private Button btnApplyVacationMaxCount;
    }
}
