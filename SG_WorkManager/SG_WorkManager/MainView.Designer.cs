namespace SG_WorkManager
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            panel5 = new Panel();
            panel6 = new Panel();
            panel8 = new Panel();
            panel7 = new Panel();
            lblWindowSize = new Label();
            btnSaveWindowSize = new Button();
            panel2 = new Panel();
            panel4 = new Panel();
            btnShowMemoViewControl = new Button();
            btnShowVacationViewControl = new Button();
            btnShowDocumentViewControl = new Button();
            btnShowWeekReportViewControl = new Button();
            btnShowDailyReportViewControl = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            프로그램보이기ToolStripMenuItem = new ToolStripMenuItem();
            프로그램종료ToolStripMenuItem = new ToolStripMenuItem();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(20, 10, 20, 10);
            panel5.Size = new Size(1481, 51);
            panel5.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(20, 10);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(3);
            panel6.Size = new Size(1441, 31);
            panel6.TabIndex = 6;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel7);
            panel8.Controls.Add(btnSaveWindowSize);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(1153, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(285, 25);
            panel8.TabIndex = 3;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblWindowSize);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(3);
            panel7.Size = new Size(217, 25);
            panel7.TabIndex = 4;
            // 
            // lblWindowSize
            // 
            lblWindowSize.AutoSize = true;
            lblWindowSize.Dock = DockStyle.Right;
            lblWindowSize.Location = new Point(53, 3);
            lblWindowSize.Margin = new Padding(0);
            lblWindowSize.Name = "lblWindowSize";
            lblWindowSize.Size = new Size(161, 15);
            lblWindowSize.TabIndex = 5;
            lblWindowSize.Text = "Window Size : 1,920 x 1080";
            lblWindowSize.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSaveWindowSize
            // 
            btnSaveWindowSize.Dock = DockStyle.Right;
            btnSaveWindowSize.Location = new Point(217, 0);
            btnSaveWindowSize.Name = "btnSaveWindowSize";
            btnSaveWindowSize.Size = new Size(68, 25);
            btnSaveWindowSize.TabIndex = 3;
            btnSaveWindowSize.Text = "Save Size";
            btnSaveWindowSize.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 51);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20, 10, 20, 10);
            panel2.Size = new Size(1481, 97);
            panel2.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnShowMemoViewControl);
            panel4.Controls.Add(btnShowVacationViewControl);
            panel4.Controls.Add(btnShowDocumentViewControl);
            panel4.Controls.Add(btnShowWeekReportViewControl);
            panel4.Controls.Add(btnShowDailyReportViewControl);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(20, 10);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(1441, 77);
            panel4.TabIndex = 0;
            // 
            // btnShowMemoViewControl
            // 
            btnShowMemoViewControl.BackColor = SystemColors.Control;
            btnShowMemoViewControl.Dock = DockStyle.Left;
            btnShowMemoViewControl.FlatAppearance.BorderSize = 0;
            btnShowMemoViewControl.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowMemoViewControl.Location = new Point(605, 5);
            btnShowMemoViewControl.Name = "btnShowMemoViewControl";
            btnShowMemoViewControl.Size = new Size(150, 67);
            btnShowMemoViewControl.TabIndex = 4;
            btnShowMemoViewControl.Text = "메모";
            btnShowMemoViewControl.UseVisualStyleBackColor = false;
            btnShowMemoViewControl.Visible = false;
            // 
            // btnShowVacationViewControl
            // 
            btnShowVacationViewControl.BackColor = SystemColors.Control;
            btnShowVacationViewControl.Dock = DockStyle.Left;
            btnShowVacationViewControl.FlatAppearance.BorderSize = 0;
            btnShowVacationViewControl.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowVacationViewControl.Location = new Point(455, 5);
            btnShowVacationViewControl.Name = "btnShowVacationViewControl";
            btnShowVacationViewControl.Size = new Size(150, 67);
            btnShowVacationViewControl.TabIndex = 3;
            btnShowVacationViewControl.Text = "연차";
            btnShowVacationViewControl.UseVisualStyleBackColor = false;
            // 
            // btnShowDocumentViewControl
            // 
            btnShowDocumentViewControl.BackColor = SystemColors.Control;
            btnShowDocumentViewControl.Dock = DockStyle.Left;
            btnShowDocumentViewControl.FlatAppearance.BorderSize = 0;
            btnShowDocumentViewControl.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowDocumentViewControl.Location = new Point(305, 5);
            btnShowDocumentViewControl.Name = "btnShowDocumentViewControl";
            btnShowDocumentViewControl.Size = new Size(150, 67);
            btnShowDocumentViewControl.TabIndex = 2;
            btnShowDocumentViewControl.Text = "산출물";
            btnShowDocumentViewControl.UseVisualStyleBackColor = false;
            // 
            // btnShowWeekReportViewControl
            // 
            btnShowWeekReportViewControl.BackColor = SystemColors.Control;
            btnShowWeekReportViewControl.Dock = DockStyle.Left;
            btnShowWeekReportViewControl.FlatAppearance.BorderSize = 0;
            btnShowWeekReportViewControl.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowWeekReportViewControl.Location = new Point(155, 5);
            btnShowWeekReportViewControl.Name = "btnShowWeekReportViewControl";
            btnShowWeekReportViewControl.Size = new Size(150, 67);
            btnShowWeekReportViewControl.TabIndex = 1;
            btnShowWeekReportViewControl.Text = "주간 보고";
            btnShowWeekReportViewControl.UseVisualStyleBackColor = false;
            // 
            // btnShowDailyReportViewControl
            // 
            btnShowDailyReportViewControl.BackColor = SystemColors.Control;
            btnShowDailyReportViewControl.Dock = DockStyle.Left;
            btnShowDailyReportViewControl.FlatAppearance.BorderSize = 0;
            btnShowDailyReportViewControl.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnShowDailyReportViewControl.Location = new Point(5, 5);
            btnShowDailyReportViewControl.Name = "btnShowDailyReportViewControl";
            btnShowDailyReportViewControl.Size = new Size(150, 67);
            btnShowDailyReportViewControl.TabIndex = 0;
            btnShowDailyReportViewControl.Text = "일일 리포트";
            btnShowDailyReportViewControl.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 148);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(1481, 706);
            panel1.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(20, 20);
            panel3.Name = "panel3";
            panel3.Size = new Size(1439, 664);
            panel3.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "SG_WorkReport";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 프로그램보이기ToolStripMenuItem, 프로그램종료ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(163, 48);
            contextMenuStrip1.Tag = "";
            // 
            // 프로그램보이기ToolStripMenuItem
            // 
            프로그램보이기ToolStripMenuItem.Name = "프로그램보이기ToolStripMenuItem";
            프로그램보이기ToolStripMenuItem.Size = new Size(162, 22);
            프로그램보이기ToolStripMenuItem.Tag = "DIC";
            프로그램보이기ToolStripMenuItem.Text = "프로그램 보이기";
            // 
            // 프로그램종료ToolStripMenuItem
            // 
            프로그램종료ToolStripMenuItem.Name = "프로그램종료ToolStripMenuItem";
            프로그램종료ToolStripMenuItem.Size = new Size(162, 22);
            프로그램종료ToolStripMenuItem.Tag = "EXIT";
            프로그램종료ToolStripMenuItem.Text = "프로그램 종료";
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 854);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel5);
            Name = "MainView";
            Text = "MainView";
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel5;
        private Panel panel6;
        private Panel panel2;
        private Panel panel4;
        private Button btnShowDocumentViewControl;
        private Button btnShowWeekReportViewControl;
        private Button btnShowDailyReportViewControl;
        private Panel panel1;
        private Panel panel3;
        private Panel panel8;
        private Panel panel7;
        private Button btnSaveWindowSize;
        private Label lblWindowSize;
        private Button btnShowVacationViewControl;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 프로그램보이기ToolStripMenuItem;
        private ToolStripMenuItem 프로그램종료ToolStripMenuItem;
        private Button btnShowMemoViewControl;
    }
}