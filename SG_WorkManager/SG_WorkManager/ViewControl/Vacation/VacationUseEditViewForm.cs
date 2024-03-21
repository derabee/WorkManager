using SG_WorkManager.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_WorkManager.ViewControl.Vacation
{
    public partial class VacationUseEditViewForm : Form
    {

        public event EventHandler SaveEvent;
        //public event EventHandler DeleteEvent;
        public bool IsSaved { get; set; } = true;
        public VacationUseItem newVacationUseItem;

        public VacationUseEditViewForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            btnSave.Click += (sender, e) =>
            {
                Save();
            };

            this.FormClosing += (sender, e) =>
            {
                this.Visible = false;
                e.Cancel = true;
            };

            /*btnExit.Click += delegate
            {
                this.Visible = false;
            };*/

            /*btnDelete.Click += (sender, e) =>
            {
                DeleteEvent?.Invoke(sender, e);
                this.Visible = false;
            };*/

            txbNote.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Save();
                }
            };
        }

        private void Save()
        {
            UpdateVacationUseItem();
            SaveEvent?.Invoke(null, EventArgs.Empty);
            this.Visible = false;
        }

        public void SetVacationUseItem(VacationUseItem vacationUseItem, bool isAddMode)
        {
            if (isAddMode)
            {
                label2.Text = "추가";
            }
            else
            {
                label2.Text = "편집";
            }
            newVacationUseItem = vacationUseItem;
            dateTimePicker1.Value = newVacationUseItem.VacationDate;
            ckbIsNotRegularVacation.Checked = newVacationUseItem.IsNotRegularVacation;
            txbNote.Text = newVacationUseItem.Note;
        }

        private void UpdateVacationUseItem()
        {
            newVacationUseItem.VacationDate = dateTimePicker1.Value;
            newVacationUseItem.IsNotRegularVacation = ckbIsNotRegularVacation.Checked;
            newVacationUseItem.Note = txbNote.Text;
        }


        private static VacationUseEditViewForm s_instance;
        public static VacationUseEditViewForm GetInstance()
        {
            if (s_instance == null || s_instance.IsDisposed)
                s_instance = new VacationUseEditViewForm();
            return s_instance;
        }
    }
}
