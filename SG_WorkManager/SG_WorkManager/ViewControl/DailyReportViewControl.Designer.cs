namespace SG_WorkManager
{
    partial class DailyReportViewControl
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
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            btnToday = new Button();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            col01_DT = new DataGridViewTextBoxColumn();
            col02_Exist = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            tabPage1 = new TabPage();
            monthCalendar1 = new MonthCalendar();
            panel4 = new Panel();
            panel3 = new Panel();
            panel6 = new Panel();
            splitContainer2 = new SplitContainer();
            panel7 = new Panel();
            panel9 = new Panel();
            txbBody = new TextBox();
            panel8 = new Panel();
            label4 = new Label();
            panel12 = new Panel();
            panel16 = new Panel();
            txbTitle = new TextBox();
            panel15 = new Panel();
            label3 = new Label();
            panel5 = new Panel();
            panel14 = new Panel();
            lblIsSaved = new Label();
            btnSave = new Button();
            ckbIsVacation = new CheckBox();
            ckbIsHoliday = new CheckBox();
            panel10 = new Panel();
            panel11 = new Panel();
            txbNote = new TextBox();
            panel13 = new Panel();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel12.SuspendLayout();
            panel16.SuspendLayout();
            panel15.SuspendLayout();
            panel5.SuspendLayout();
            panel14.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel13.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Panel2.Padding = new Padding(10);
            splitContainer1.Size = new Size(1366, 837);
            splitContainer1.SplitterDistance = 455;
            splitContainer1.TabIndex = 26;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(455, 837);
            panel1.TabIndex = 26;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnToday);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 779);
            panel2.Name = "panel2";
            panel2.Size = new Size(455, 58);
            panel2.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 13;
            label1.Text = "선택된 날짜 :";
            // 
            // btnToday
            // 
            btnToday.Location = new Point(209, 16);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(84, 32);
            btnToday.TabIndex = 17;
            btnToday.Text = "Today";
            btnToday.UseVisualStyleBackColor = true;
            btnToday.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 22);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 14;
            label2.Text = "2024-01-08";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(455, 837);
            tabControl1.TabIndex = 15;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(447, 809);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { col01_DT, col02_Exist, Column1 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(441, 803);
            dataGridView1.TabIndex = 4;
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
            // tabPage1
            // 
            tabPage1.Controls.Add(monthCalendar1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(447, 809);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "달력";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(2, 5);
            monthCalendar1.Dock = DockStyle.Fill;
            monthCalendar1.Location = new Point(3, 3);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 3;
            monthCalendar1.TodayDate = new DateTime(2024, 1, 10, 0, 0, 0, 0);
            // 
            // panel4
            // 
            panel4.Controls.Add(panel3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(10, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(887, 817);
            panel4.TabIndex = 28;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(887, 817);
            panel3.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(splitContainer2);
            panel6.Controls.Add(panel12);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 46);
            panel6.Name = "panel6";
            panel6.Size = new Size(887, 771);
            panel6.TabIndex = 30;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Location = new Point(0, 33);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(panel7);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panel10);
            splitContainer2.Size = new Size(887, 738);
            splitContainer2.SplitterDistance = 300;
            splitContainer2.TabIndex = 34;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(panel8);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(887, 300);
            panel7.TabIndex = 28;
            // 
            // panel9
            // 
            panel9.Controls.Add(txbBody);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(64, 0);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(5);
            panel9.Size = new Size(823, 300);
            panel9.TabIndex = 21;
            // 
            // txbBody
            // 
            txbBody.Dock = DockStyle.Fill;
            txbBody.Location = new Point(5, 5);
            txbBody.Multiline = true;
            txbBody.Name = "txbBody";
            txbBody.ScrollBars = ScrollBars.Vertical;
            txbBody.Size = new Size(813, 290);
            txbBody.TabIndex = 11;
            // 
            // panel8
            // 
            panel8.Controls.Add(label4);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(64, 300);
            panel8.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 8);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 19;
            label4.Text = "Body";
            // 
            // panel12
            // 
            panel12.Controls.Add(panel16);
            panel12.Controls.Add(panel15);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(887, 33);
            panel12.TabIndex = 33;
            // 
            // panel16
            // 
            panel16.Controls.Add(txbTitle);
            panel16.Dock = DockStyle.Fill;
            panel16.Location = new Point(64, 0);
            panel16.Name = "panel16";
            panel16.Padding = new Padding(5);
            panel16.Size = new Size(823, 33);
            panel16.TabIndex = 20;
            // 
            // txbTitle
            // 
            txbTitle.Dock = DockStyle.Fill;
            txbTitle.Location = new Point(5, 5);
            txbTitle.Name = "txbTitle";
            txbTitle.Size = new Size(813, 23);
            txbTitle.TabIndex = 16;
            // 
            // panel15
            // 
            panel15.Controls.Add(label3);
            panel15.Dock = DockStyle.Left;
            panel15.Location = new Point(0, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(64, 33);
            panel15.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 8);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 18;
            label3.Text = "Title";
            // 
            // panel5
            // 
            panel5.Controls.Add(panel14);
            panel5.Controls.Add(ckbIsVacation);
            panel5.Controls.Add(ckbIsHoliday);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(887, 46);
            panel5.TabIndex = 29;
            // 
            // panel14
            // 
            panel14.Controls.Add(lblIsSaved);
            panel14.Controls.Add(btnSave);
            panel14.Dock = DockStyle.Right;
            panel14.Location = new Point(678, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(209, 46);
            panel14.TabIndex = 23;
            // 
            // lblIsSaved
            // 
            lblIsSaved.AutoSize = true;
            lblIsSaved.ForeColor = Color.Red;
            lblIsSaved.Location = new Point(30, 17);
            lblIsSaved.Name = "lblIsSaved";
            lblIsSaved.Size = new Size(63, 15);
            lblIsSaved.TabIndex = 22;
            lblIsSaved.Text = "Not Saved";
            lblIsSaved.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(115, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(84, 32);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // ckbIsVacation
            // 
            ckbIsVacation.AutoSize = true;
            ckbIsVacation.Location = new Point(16, 16);
            ckbIsVacation.Name = "ckbIsVacation";
            ckbIsVacation.Size = new Size(91, 19);
            ckbIsVacation.TabIndex = 21;
            ckbIsVacation.Text = "Is Vacation?";
            ckbIsVacation.UseVisualStyleBackColor = true;
            // 
            // ckbIsHoliday
            // 
            ckbIsHoliday.AutoSize = true;
            ckbIsHoliday.Location = new Point(117, 16);
            ckbIsHoliday.Name = "ckbIsHoliday";
            ckbIsHoliday.Size = new Size(85, 19);
            ckbIsHoliday.TabIndex = 20;
            ckbIsHoliday.Text = "Is Holiday?";
            ckbIsHoliday.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(panel13);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(887, 434);
            panel10.TabIndex = 29;
            // 
            // panel11
            // 
            panel11.Controls.Add(txbNote);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(64, 0);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(5);
            panel11.Size = new Size(823, 434);
            panel11.TabIndex = 26;
            // 
            // txbNote
            // 
            txbNote.Dock = DockStyle.Fill;
            txbNote.Location = new Point(5, 5);
            txbNote.Multiline = true;
            txbNote.Name = "txbNote";
            txbNote.ScrollBars = ScrollBars.Vertical;
            txbNote.Size = new Size(813, 424);
            txbNote.TabIndex = 23;
            // 
            // panel13
            // 
            panel13.Controls.Add(label5);
            panel13.Dock = DockStyle.Left;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(64, 434);
            panel13.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 8);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 24;
            label5.Text = "Note";
            // 
            // DailyReportViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "DailyReportViewControl";
            Size = new Size(1366, 837);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel12.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Button btnToday;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn col01_DT;
        private DataGridViewTextBoxColumn col02_Exist;
        private DataGridViewTextBoxColumn Column1;
        private TabPage tabPage1;
        private MonthCalendar monthCalendar1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel6;
        private SplitContainer splitContainer2;
        private Panel panel7;
        private Panel panel9;
        private TextBox txbBody;
        private Panel panel8;
        private Label label4;
        private Panel panel12;
        private TextBox txbTitle;
        private Label label3;
        private Panel panel5;
        private Panel panel14;
        private Label lblIsSaved;
        private Button btnSave;
        private CheckBox ckbIsVacation;
        private CheckBox ckbIsHoliday;
        private Panel panel16;
        private Panel panel15;
        private Panel panel10;
        private Panel panel11;
        private TextBox txbNote;
        private Panel panel13;
        private Label label5;
    }
}
