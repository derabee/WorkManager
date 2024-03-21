namespace SG_WorkManager.ViewControl.Vacation
{
    partial class VacationUseEditViewForm
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
            ckbIsNotRegularVacation = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnSave = new Button();
            txbNote = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ckbIsNotRegularVacation
            // 
            ckbIsNotRegularVacation.AutoSize = true;
            ckbIsNotRegularVacation.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckbIsNotRegularVacation.Location = new Point(604, 156);
            ckbIsNotRegularVacation.Name = "ckbIsNotRegularVacation";
            ckbIsNotRegularVacation.Size = new Size(212, 25);
            ckbIsNotRegularVacation.TabIndex = 53;
            ckbIsNotRegularVacation.Text = "Is Not Regular Vacation?";
            ckbIsNotRegularVacation.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Location = new Point(21, 120);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(224, 29);
            dateTimePicker1.TabIndex = 52;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 48);
            panel1.TabIndex = 51;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(146, 9);
            label2.Name = "label2";
            label2.Size = new Size(55, 30);
            label2.TabIndex = 42;
            label2.Text = "추가";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 9);
            label1.Name = "label1";
            label1.Size = new Size(153, 30);
            label1.TabIndex = 41;
            label1.Text = "연차 사용 내역";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(21, 165);
            label4.Name = "label4";
            label4.Size = new Size(47, 21);
            label4.TabIndex = 49;
            label4.Text = "Note";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(21, 99);
            label3.Name = "label3";
            label3.Size = new Size(44, 21);
            label3.TabIndex = 48;
            label3.Text = "Date";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(732, 227);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(84, 54);
            btnSave.TabIndex = 47;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txbNote
            // 
            txbNote.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNote.Location = new Point(21, 187);
            txbNote.Name = "txbNote";
            txbNote.ScrollBars = ScrollBars.Vertical;
            txbNote.Size = new Size(795, 29);
            txbNote.TabIndex = 46;
            // 
            // VacationUseEditViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 325);
            Controls.Add(ckbIsNotRegularVacation);
            Controls.Add(dateTimePicker1);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnSave);
            Controls.Add(txbNote);
            Name = "VacationUseEditViewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VacationUseEditViewForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox ckbIsNotRegularVacation;
        private DateTimePicker dateTimePicker1;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Button btnSave;
        private TextBox txbNote;
    }
}