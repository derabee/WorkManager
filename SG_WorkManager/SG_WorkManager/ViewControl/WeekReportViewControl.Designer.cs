namespace SG_WorkManager
{
    partial class WeekReportViewControl
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
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            col01_DT = new DataGridViewTextBoxColumn();
            col02_Exist = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            panel5 = new Panel();
            panel8 = new Panel();
            txbBody = new TextBox();
            panel7 = new Panel();
            txbTitle = new TextBox();
            panel6 = new Panel();
            txbSummary = new TextBox();
            panel4 = new Panel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            btnSave = new Button();
            lblIsSaved = new Label();
            label1 = new Label();
            btnToday = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1223, 896);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 33;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1223, 300);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 25;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1215, 272);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "목록";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { col01_DT, col02_Exist });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1209, 266);
            dataGridView1.TabIndex = 4;
            // 
            // col01_DT
            // 
            col01_DT.Frozen = true;
            col01_DT.HeaderText = "주차";
            col01_DT.Name = "col01_DT";
            col01_DT.ReadOnly = true;
            col01_DT.Width = 130;
            // 
            // col02_Exist
            // 
            col02_Exist.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            col02_Exist.Frozen = true;
            col02_Exist.HeaderText = "요약";
            col02_Exist.Name = "col02_Exist";
            col02_Exist.ReadOnly = true;
            col02_Exist.Width = 56;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1223, 592);
            panel1.TabIndex = 33;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel8);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(93, 54);
            panel5.Name = "panel5";
            panel5.Size = new Size(1130, 538);
            panel5.TabIndex = 34;
            // 
            // panel8
            // 
            panel8.Controls.Add(txbBody);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 66);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(5);
            panel8.Size = new Size(1130, 472);
            panel8.TabIndex = 34;
            // 
            // txbBody
            // 
            txbBody.Dock = DockStyle.Fill;
            txbBody.Location = new Point(5, 5);
            txbBody.Multiline = true;
            txbBody.Name = "txbBody";
            txbBody.ScrollBars = ScrollBars.Vertical;
            txbBody.Size = new Size(1120, 462);
            txbBody.TabIndex = 32;
            // 
            // panel7
            // 
            panel7.Controls.Add(txbTitle);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 33);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(5);
            panel7.Size = new Size(1130, 33);
            panel7.TabIndex = 31;
            // 
            // txbTitle
            // 
            txbTitle.Dock = DockStyle.Fill;
            txbTitle.Location = new Point(5, 5);
            txbTitle.Name = "txbTitle";
            txbTitle.Size = new Size(1120, 23);
            txbTitle.TabIndex = 25;
            // 
            // panel6
            // 
            panel6.Controls.Add(txbSummary);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(1130, 33);
            panel6.TabIndex = 30;
            // 
            // txbSummary
            // 
            txbSummary.Dock = DockStyle.Fill;
            txbSummary.Location = new Point(5, 5);
            txbSummary.Name = "txbSummary";
            txbSummary.Size = new Size(1120, 23);
            txbSummary.TabIndex = 29;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 54);
            panel4.Name = "panel4";
            panel4.Size = new Size(93, 538);
            panel4.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 41);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 27;
            label3.Text = "Title";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 74);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 28;
            label4.Text = "Body";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 8);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 30;
            label5.Text = "Summary";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnToday);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1223, 54);
            panel2.TabIndex = 32;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSave);
            panel3.Controls.Add(lblIsSaved);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1023, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 54);
            panel3.TabIndex = 32;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(97, 9);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(84, 32);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // lblIsSaved
            // 
            lblIsSaved.AutoSize = true;
            lblIsSaved.ForeColor = Color.Red;
            lblIsSaved.Location = new Point(18, 18);
            lblIsSaved.Name = "lblIsSaved";
            lblIsSaved.Size = new Size(63, 15);
            lblIsSaved.TabIndex = 31;
            lblIsSaved.Text = "Not Saved";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 18);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 22;
            label1.Text = "선택된 주차 :";
            // 
            // btnToday
            // 
            btnToday.Location = new Point(482, 9);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(84, 32);
            btnToday.TabIndex = 26;
            btnToday.Text = "Today";
            btnToday.UseVisualStyleBackColor = true;
            btnToday.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 18);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 23;
            label2.Text = "2024-01 1주차";
            // 
            // WeekReportViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "WeekReportViewControl";
            Size = new Size(1223, 896);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn col01_DT;
        private DataGridViewTextBoxColumn col02_Exist;
        private Panel panel1;
        private Panel panel5;
        private Panel panel8;
        private TextBox txbBody;
        private Panel panel7;
        private TextBox txbTitle;
        private Panel panel6;
        private TextBox txbSummary;
        private Panel panel4;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel2;
        private Panel panel3;
        private Button btnSave;
        private Label lblIsSaved;
        private Label label1;
        private Button btnToday;
        private Label label2;
    }
}
