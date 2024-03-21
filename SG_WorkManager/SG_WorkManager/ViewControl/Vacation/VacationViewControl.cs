using SG_WorkManager.ViewControl.Vacation;
using SG_WorkManager;
using SG_WorkManager.Item;
using SG_WorkManager.ViewControl.ViewInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_WorkManager.ViewControl
{
    public partial class VacationViewControl : UserControl, IViewControl
    {
        private const int MIN_YEAR = 2000;
        private string selectedYear = DateTime.Now.Year.ToString();
        private VacationUseItem selectedVacationUseItem;
        private bool gridRowAllChecked = false;

        private int vacationMaxCount = 16;

        private VacationUseEditViewForm vacationUseEditViewForm = VacationUseEditViewForm.GetInstance();

        private Dictionary<string, List<VacationUseItem>> dictVacationUse = new Dictionary<string, List<VacationUseItem>>();

        private Dictionary<string, int> dictVacationMaxCount = new Dictionary<string, int>();

        public VacationViewControl()
        {
            InitializeComponent();
            InitEvents();
            InitControls();
            CreateDefaultFolder();
            LoadVacationUseCount();
            LoadVacationMaxCount();
        }

        private void InitControls()
        {
            var grid = dataGridView1;
            grid.ReadOnly = false;
            grid.Columns.Clear();
            var colCheckBox = new DataGridViewCheckBoxColumn();
            colCheckBox.HeaderText = "";
            var col0Idx = grid.Columns.Add(colCheckBox);
            var col1Idx = grid.Columns.Add("ColCount", "Count");
            var col2Idx = grid.Columns.Add("ColVacationDate", "Date");
            var col3Idx = grid.Columns.Add("ColDayOfWeek", "");
            var col4Idx = grid.Columns.Add("ColNote", "Note");
            var col0 = grid.Columns[col0Idx];
            var col1 = grid.Columns[col1Idx];
            var col2 = grid.Columns[col2Idx];
            var col3 = grid.Columns[col3Idx];
            var col4 = grid.Columns[col4Idx];

            var checkBox = new CheckBox();
            checkBox.Name = "ckbAllChecked";
         

            for (int i = 0, count = grid.Columns.Count; i < count; i++)
            {
                grid.Columns[i].ReadOnly = true;
            }
            col0.ReadOnly = false;
            col0.Width = 30;
            col1.Width = 80;
            col2.Width = 80;
            col3.Width = 40;
            col4.Width = 340;
            col0.ValueType = typeof(bool);
            cbbYear.Items.Clear();

            var nowYear = DateTime.Now.Year;
            while (nowYear >= MIN_YEAR)
            {
                cbbYear.Items.Add(nowYear);
                nowYear--;
            }
            cbbYear.SelectedIndex = 0;
  
        }

        private string GetVacationCountText(VacationUseItem item)
        {
            return $"{item.Index.ToString("00")}/{vacationMaxCount}";
        }

        private void AddRow(VacationUseItem item)
        {
            dataGridView1.Rows.Add(false, GetVacationCountText(item), item.VacationDate.ToShortDateString(), GetDayOfWeek(item.VacationDate), item.Note);
        }

        private void EditRow(int idx, VacationUseItem item)
        {
            dataGridView1.Rows[idx].SetValues(false, GetVacationCountText(item), item.VacationDate.ToShortDateString(), GetDayOfWeek(item.VacationDate), item.Note);

        }

        private void InitEvents()
        {
            var now = DateTime.Now;
            
            btnAddVacationUse.Click += delegate
            {
                var year = Convert.ToInt32(selectedYear);
                var list = GetCurrentList();
                var item = new VacationUseItem()
                {
                    Year = year,
                    Index = list.Count + 1,
                    VacationDate = new DateTime(year, now.Month, now.Day),
                    IsNotRegularVacation = false,
                    Note = ""
                };
                list.Add(item);
                AddRow(item);
                ShowEditViewForm(item, true);
            };
            btnApplyVacationMaxCount.Click += delegate
            {
                var maxCount = 16;
                var preVacationMaxCount = vacationMaxCount;
                try
                {
                    maxCount = Convert.ToInt32(txbVacationMaxCount.Text);
                    
                }
                catch
                {
                }

                vacationMaxCount = maxCount;

                if (dictVacationMaxCount.TryGetValue(selectedYear, out var count))
                {
                    dictVacationMaxCount[selectedYear] = maxCount;
                }
                else
                {
                    dictVacationMaxCount.Add(selectedYear, maxCount);
                }

                if (preVacationMaxCount != vacationMaxCount)
                {
                    UpdateEditGrid();
                }

                SaveVacationMaxCount();
            };

            vacationUseEditViewForm.SaveEvent += new EventHandler(delegate
            {
                var item = vacationUseEditViewForm.newVacationUseItem;
                EditRow(item.Index - 1, item);
                var list = GetCurrentList();
                list[item.Index - 1] = item;
                SaveModelAsFile();
            });

            btnDelete.Click += delegate 
            {
                var reuslt = MessageBox.Show("삭제하시겠습니까?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reuslt == DialogResult.No)
                {
                    return;
                }

                var list = GetCurrentList();
                var gridRows = dataGridView1.Rows;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(gridRows[i].Cells[0].Value) == true)
                    {
                        var item = list[i];
                        list.RemoveAt(i);
                        gridRows.RemoveAt(i);
                    }
                }

                for(int i = 0,count = list.Count; i < count; i++)
                {
                    var item2 = list[i];
                    item2.Index = i + 1;
                    gridRows[i].Cells[1].Value = GetVacationCountText(item2);
                }              
                SaveModelAsFile();
            };

            dataGridView1.CellDoubleClick += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;

                var list = GetCurrentList();
                ShowEditViewForm(list[e.RowIndex], false);
            };

            cbbYear.SelectedIndexChanged += delegate
            {
                UpdateVacationUseList(cbbYear.SelectedItem.ToString());
            };

            btnNextYear.Click += delegate
            {
                var selectedIndex = cbbYear.SelectedIndex;
                if (0 <= selectedIndex - 1)
                {
                    cbbYear.SelectedIndex = selectedIndex - 1;
                }
            };

            btnPreYear.Click += delegate
            {
                var selectedIndex = cbbYear.SelectedIndex;
                if (cbbYear.Items.Count + 1 > selectedIndex + 1)
                {
                    cbbYear.SelectedIndex = selectedIndex + 1;
                }
            };

            dataGridView1.CellClick += (sender, e) =>
            {
                if (e.RowIndex != -1 && e.ColumnIndex == 0)
                {
                    var row = dataGridView1.Rows[e.RowIndex];
                    row.Cells[1].Selected = true;
                    var value = Convert.ToBoolean(row.Cells[0].Value);
                    row.Cells[0].Value = !value;
                }
            };


            dataGridView1.CellPainting += (sender, e) =>
            {
                if (e.ColumnIndex == 0 && e.RowIndex == -1)
                {
                    e.PaintBackground(e.ClipBounds, false);
                    Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell
                    int nChkBoxWidth = 15; int nChkBoxHeight = 15; int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2; int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;
                    pt.X += offsetx; pt.Y += offsety;
                    CheckBox cb = new CheckBox(); cb.Size = new Size(nChkBoxWidth, nChkBoxHeight); cb.Location = pt; cb.CheckedChanged += (sender, e) =>
                    { 
                        foreach (DataGridViewRow r in dataGridView1.Rows) 
                        { 
                            r.Cells[0].Value = ((CheckBox)sender).Checked; 
                        }; 
                    };
                    ((DataGridView)sender).Controls.Add(cb);
                    e.Handled = true;
                }
            };

            txbVacationMaxCount.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            };

            /*dataGridView1.CellClick += (sender, e) =>
            {
                if (e.RowIndex != -1 || e.ColumnIndex != 0)
                    return;

                dataGridView1.Select();
                gridRowAllChecked = !gridRowAllChecked;
                var rows = dataGridView1.Rows;
                for(int i = 0,count = rows.Count; i < count; i++)
                {
                    rows[i].Cells[0].Value = gridRowAllChecked;
                }
            };*/
        }

        private string GetDayOfWeek(DateTime dt)
        {
            return dt.DayOfWeek.ToString().Substring(0, 3);
        }

        private List<VacationUseItem> GetCurrentList()
        {
            List<VacationUseItem> list;
            if (!dictVacationUse.TryGetValue(selectedYear, out list))
            {
                list = new List<VacationUseItem>();
                dictVacationUse.Add(selectedYear, list);
            }
            return list;
        }

        private void UpdateEditGrid()
        {
            UpdateVacationUseList(selectedYear);
        }

        private void UpdateVacationUseList(string yearStr)
        {
            selectedYear = yearStr;
            if (cbbYear.SelectedIndex == 0)
            {
                btnNextYear.Enabled = false;
                btnPreYear.Enabled = true;
            }
            else if (cbbYear.SelectedIndex == cbbYear.Items.Count - 1)
            {
                btnNextYear.Enabled = true;
                btnPreYear.Enabled = false;
            }
            else
            {
                btnNextYear.Enabled = true;
                btnPreYear.Enabled = true;
            }

            DisplayVacationMaxCount(yearStr);
            DisplayVacationUseList(yearStr);
        }

        private string GetDefaultPath()
        {
            return $@"{Settings.DEFAULT_PATH}\{Settings.VACATION_PATH}\{Settings.VACATION_USE_FILE_NAME}";
        }

        private void CreateDefaultFolder()
        {
            var defaultPath = GetDefaultPath();
            if (Directory.Exists(defaultPath) == false)
            {
                Directory.CreateDirectory(defaultPath);
            }
        }

        private async void LoadVacationUseCount()
        {
            List<VacationUseItem> list;
            for (int i = 0; i < cbbYear.Items.Count; i++)
            {
                var yearStr = cbbYear.Items[i].ToString();
                var fileName = GetVacationUseFileName(yearStr);
                if (File.Exists(fileName))
                {
                    using FileStream openStream = File.OpenRead(fileName);
                    list = JsonSerializer.DeserializeAsync<List<VacationUseItem>>(openStream).Result;
                }
                else
                {
                    list = new List<VacationUseItem>();
                }
                dictVacationUse.Add(yearStr, list);
            }
            DisplayVacationUseList(selectedYear);
        }
        
        private async void LoadVacationMaxCount()
        {
            var fileName = GetVacationMaxCountFileName();
            if (File.Exists(fileName))
            {
                using FileStream openStream = File.OpenRead(fileName);
                dictVacationMaxCount = JsonSerializer.DeserializeAsync<Dictionary<string,int>>(openStream).Result;
            }
        }

        private async void SaveModelAsFile()
        {
            var yearStr = selectedYear;
            var fileName = GetVacationUseFileName(yearStr);
            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, dictVacationUse[yearStr]);
        }

        private async void SaveVacationMaxCount()
        {
            var fileName = GetVacationMaxCountFileName();
            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, dictVacationMaxCount);
        }

        private void DisplayVacationUseList(string yearStr)
        {
            var grid = dataGridView1;
            grid.Rows.Clear();
            List<VacationUseItem> list;
            if (!dictVacationUse.TryGetValue(yearStr, out list))
            {
                list = new List<VacationUseItem>();
            }
            
            for(int i= 0; i<list.Count; i++)
            {
                var item = list[i];
                AddRow(item);
            }
        }

        private int GetVacationMaxCount(string yearStr)
        {
            const int DEFAULT_VACATION_MAX_COUNT = 16;
            if(dictVacationMaxCount.TryGetValue(yearStr, out var count))
            {
                return count;
            }
            else
            {
                return DEFAULT_VACATION_MAX_COUNT;
            }
        }

        private void DisplayVacationMaxCount(string yearStr)
        {
            vacationMaxCount = GetVacationMaxCount(yearStr);
            txbVacationMaxCount.Text = vacationMaxCount.ToString();
        }

        private void ShowEditViewForm(VacationUseItem vacationUseItem, bool IsAddMode)
        {
            
            //vacationUseEditViewForm.Left = this.Left + ((this.Width - vacationUseEditViewForm.Width) / 2);
            //vacationUseEditViewForm.Top = this.Top + ((this.Top - vacationUseEditViewForm.Height) / 2);
            vacationUseEditViewForm.SetVacationUseItem(vacationUseItem, IsAddMode);
            vacationUseEditViewForm.Visible = true;
        }

        private string GetVacationUseDefaultPath()
        {
            return $@"{Settings.DEFAULT_PATH}\{Settings.VACATION_PATH}";
        }

        private string GetVacationUseFileName(string yearStr)
        {
            const string FILE_EXTENTION = "json";
            var fileName = $@"{GetVacationUseDefaultPath()}\{Settings.VACATION_USE_FILE_NAME}\{yearStr}.{FILE_EXTENTION}";
            return fileName;
        }

        private string GetVacationMaxCountFileName()
        {
            const string FILE_EXTENTION = "json";
            var fileName = $@"{GetVacationUseDefaultPath()}\{Settings.VACATION_USE_FILE_NAME}\MaxCount.{FILE_EXTENTION}";
            return fileName;
        }

        public bool Save()
        {
            SaveModelAsFile();
            return true;
        }

        public bool CanProcess()
        {
            return true;
        }

        #region Property
        public string ControlName { get; set; }
        public string DisplayText { get; set; }
        public bool IsSaved { get; set; }
        public int PageNumber { get; set; }
        #endregion

        #region Instance

        private static VacationViewControl s_instance;

        public static VacationViewControl GetInstance()
        {
            if (s_instance == null || s_instance.IsDisposed)
                s_instance = new VacationViewControl();

            return s_instance;
        }
        #endregion

    }
}
