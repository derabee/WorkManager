using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using SG_WorkManager.ViewControl.ViewInterface;
using SG_WorkManager;
using SG_WorkManager.Item;
using SG_WorkManager.ViewControl.ViewInterface;

namespace SG_WorkManager
{

    public partial class DailyReportViewControl : UserControl, IViewControl
    {

        private Dictionary<string, DailyReportItem> dicWorkReport = new Dictionary<string, DailyReportItem>();

        private Dictionary<string, SplitContainer> _dictSplit = new Dictionary<string, SplitContainer>();
        private Dictionary<string, int> _dictSplitDistance = new Dictionary<string, int>();
        //private List<int> _dictSplitDistance = new List<int>();

        private string selectedDate;
        private DateTime lastUpdatedDT;
        private int UPDATE_CYCLE_SECOND;
        private bool isLoading;
        private bool isIniting;
        public bool IsSaved { get; set; } = true;
        public string ControlName { get; set; }
        public string DisplayText { get; set; }
        public int PageNumber { get; set; }


        public DailyReportViewControl()
        {
            InitializeComponent();
            isIniting = true;
            DefaultInit();
            RefreshView();
            isIniting = false;
        }

        private void DefaultInit()
        {
            AddSplit(splitContainer1);
            AddSplit(splitContainer2);
            InitEvents();
        }

        private void RefreshView()
        {
            InitVars();
            InitControls();
            InitLoadDatas();
            UpdateSelectedDate(DateTime.Now);
        }

        private void InitVars()
        {
            UPDATE_CYCLE_SECOND = 10;
            lastUpdatedDT = DateTime.Now.AddSeconds(-(UPDATE_CYCLE_SECOND + 1));
            isLoading = false;
        }
        private void AddSplit(SplitContainer splitContainer)
        {
            _dictSplit.Add(splitContainer.Name, splitContainer);
        }

        private void InitControls()
        {
            txbBody.AcceptsTab = true;
            var grid = dataGridView1;
            grid.Columns.Clear();
            var col0Idx = grid.Columns.Add("colDate", "Date");
            var col1Idx = grid.Columns.Add("colDayOfWeeks", "");
            var col2Idx = grid.Columns.Add("ColTitle", "Title");
            var col0 = grid.Columns[col0Idx];
            var col1 = grid.Columns[col1Idx];
            var col2 = grid.Columns[col2Idx];
            col0.Width = 80;
            col1.Width = 35;
            col2.Width = 310;
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UpdateTabControl(tabControl1);
        }

        private void InitEvents()
        {
            //btnDisplay.Click += delegate { DisplayData(selectedDate); };
            btnSave.Click += delegate {
                this.Save();
            };
            btnToday.Click += delegate { 

                UpdateSelectedDate(DateTime.Now);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[0].Selected = true;
            };
            monthCalendar1.DateSelected += delegate { UpdateSelectedDate(monthCalendar1.SelectionEnd); };
            txbTitle.TextChanged += delegate { DisplaySaved(false); };
            txbBody.TextChanged += delegate { DisplaySaved(false); };
            txbNote.TextChanged += delegate { DisplaySaved(false); };
            ckbIsHoliday.CheckedChanged += delegate { DisplaySaved(false); };
            ckbIsVacation.CheckedChanged += delegate { DisplaySaved(false); };
            dataGridView1.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;
                var dt = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                UpdateSelectedDate(Convert.ToDateTime(dt));
            };

            tabControl1.SelectedIndexChanged += (sender, e) =>
            {
                UpdateTabControl(sender as TabControl);
            };

            ckbIsVacation.Click += delegate
            {
                txbTitle.Text = ckbIsVacation.Checked ? "휴가" : "";

            };

            dataGridView1.CellFormatting += (sender, e) =>
            {

                
                switch (e.ColumnIndex)
                {
                    case 0:
                        var dt = Convert.ToDateTime(e.Value);
                        if (dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Saturday || dicWorkReport[e.Value.ToString()].IsHoliday)
                        {
                            var row = dataGridView1.Rows[e.RowIndex];
                            row.Cells[0].Style.ForeColor = Color.Red;
                            row.Cells[1].Style.ForeColor = Color.Red;
                            row.Cells[2].Style.ForeColor = Color.Red;
                        }
                        else if (dicWorkReport[e.Value.ToString()].IsVacation)
                        {
                            var row = dataGridView1.Rows[e.RowIndex];
                            row.Cells[0].Style.ForeColor = Color.Blue;
                            row.Cells[1].Style.ForeColor = Color.Blue;
                            row.Cells[2].Style.ForeColor = Color.Blue;
                        }
                        break;
    
                }
                
            };

            txbBody.KeyDown += txbBody_KeyDown;
            txbBody.TextChanged += txbBody_TextChanged;

            foreach(var split in _dictSplit.Values)
            {
                split.SplitterMoved += delegate {
                    if (!isIniting)
                    {
                        UpdateLayout(split);
                        SaveLayout();
                    }
                };
            }
        }

        private void UpdateSelectedDate(DateTime dt)
        {
            if (!this.CanProcess())
            {
                return;
            }
            var dtDate = dt.ToShortDateString();
            selectedDate = dtDate;
            label2.Text = $"{dtDate} {dt.DayOfWeek.ToString().Substring(0, 3)}";
            DisplayData(dtDate);
            DisplaySaved(true);
        }

        private async void InitLoadDatas()
        {
            CreateDefaultFolder();
            var dtNow = DateTime.Now;
            await LoadDataFromFile(dtNow.AddDays(-30), dtNow);
            UpdateSelectedDate(dtNow);
            await LoadLayout();
        }

        private string GetDefaultPath()
        {
            return $@"{Settings.DEFAULT_PATH}\{Settings.DAILY_PATH}";
        }

        private void CreateDefaultFolder()
        {
            var defaultPath = GetDefaultPath();
            if (Directory.Exists(defaultPath) == false)
            {
                Directory.CreateDirectory(defaultPath);
            }
        }

        private string GetFileName(string dt)
        {
            const string FILE_EXTENTION = "json";
            var fileName = $@"{GetDefaultPath()}\{dt}.{FILE_EXTENTION}";
            return fileName;
        }

        private string GetLayoutFileName()
        {
            const string FILE_EXTENTION = "json";
            var fileName = $@"{GetDefaultPath()}\{Settings.SPLIT_DISTANCE_FILE_NAME}.{FILE_EXTENTION}";
            return fileName;
        }

        private async Task LoadDataFromFile(DateTime startPeriod, DateTime endPeriod)
        {
            var dtNow = DateTime.Now;
            if (dtNow < lastUpdatedDT.AddSeconds(UPDATE_CYCLE_SECOND) || isLoading)
            {
                return;
            }
            isLoading = true;
            lastUpdatedDT = dtNow;
            var grid = dataGridView1;
            grid.Rows.Clear();
            dicWorkReport.Clear();
            var dt = endPeriod;
            while (dt >= startPeriod)
            {
                var dtStr = dt.ToShortDateString();
                var fileName = GetFileName(dtStr);
                DailyReportItem workReportItem;
                var title = string.Empty;
                if (File.Exists(fileName))
                {
                    using FileStream openStream = File.OpenRead(fileName);
                    workReportItem = JsonSerializer.DeserializeAsync<DailyReportItem>(openStream).Result;
                    title = workReportItem.Title ?? string.Empty;
                }
                else
                {
                    workReportItem = new DailyReportItem();
                    title = "-";
                }

                dicWorkReport.Add(dtStr, workReportItem);
                grid.Rows.Add(dtStr, dt.DayOfWeek.ToString().Substring(0, 3), title);
                dt = dt.AddDays(-1);
            }
            isLoading = false;
        }

        private async Task LoadLayout()
        {
            var fileName = GetLayoutFileName();
            if (File.Exists(fileName))
            {
                using FileStream openStream = File.OpenRead(fileName);
                _dictSplitDistance = JsonSerializer.DeserializeAsync<Dictionary<string, int>>(openStream).Result;

                foreach(var key in _dictSplitDistance.Keys)
                {
                    _dictSplit[key].SplitterDistance = _dictSplitDistance[key];
                }
            }
        }

        private async void SaveDataAsFile(string dt, DailyReportItem item)
        {
            if (dicWorkReport.TryGetValue(dt, out var workReport))
            {
                dicWorkReport[dt] = item;
            }
            else
            {
                dicWorkReport.Add(dt, item);
            }

            var grid = dataGridView1;
            for (int i = 0, count = grid.Rows.Count; i < count; i++)
            {
                if (grid.Rows[i].Cells[0].Value.ToString() == dt)
                {
                    grid.Rows[i].Cells[2].Value = item.Title;
                    break;
                }
            }

            var fileName = GetFileName(dt);
            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, item);
            DisplaySaved(true);
        }
        
        private void DisplaySaved(bool isSaved)
        {
            this.IsSaved = isSaved;
            if (isSaved && lblIsSaved.Text != "Saved")
            {
                lblIsSaved.Text = "Saved";
                lblIsSaved.ForeColor = Color.Green;
            }
            else if (!isSaved && lblIsSaved.Text != "Not Saved")
            {
                lblIsSaved.Text = "Not Saved";
                lblIsSaved.ForeColor = Color.Red;
            }
        }

        private void DisplayData(string selectedDate)
        {
            DailyReportItem item;
            dicWorkReport.TryGetValue(selectedDate, out item);
            if (item == null)
            {
                item = new();
            }
            txbTitle.Text = item.Title;
            txbBody.Text = item.Body;
            txbNote.Text = item.Note;
            ckbIsHoliday.Checked = item.IsHoliday;
            ckbIsVacation.Checked = item.IsVacation;
        }

        private void UpdateTabControl(TabControl control)
        {
            switch (control.SelectedIndex)
            {
                case 0:
                    tabControl1.Width = 500;
                    InitLoadDatas(); break;
                case 1:
                    tabControl1.Width = 237; break;
            }
        }

        public bool Save()
        {
            SaveDataAsFile(selectedDate, new DailyReportItem
            {
                Title = txbTitle.Text,
                Body = txbBody.Text,
                Note = txbNote.Text,
                IsHoliday = ckbIsHoliday.Checked,
                IsVacation = ckbIsVacation.Checked
            });
            return true;
        }


        private static DailyReportViewControl s_instance;
        public static DailyReportViewControl GetInstance()
        {
            if (s_instance == null || s_instance.IsDisposed)
                s_instance = new DailyReportViewControl();

            s_instance.RefreshView();
            return s_instance;
        }

        public bool CanProcess()
        {
            if(this.IsSaved)
            {
                return true; 
            }

            var result = MessageBox.Show("저장하지 않은 내용이 있습니다.\r\n저장하시겠습니까?", "주의", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes: this.Save(); return false;
                case DialogResult.No: return true;
                case DialogResult.Cancel: return false;
                default: return false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == (Keys.ControlKey | Keys.Control | Keys.S)))
            {
                this.Save();
                //Do custom stuff
                //true if key was processed by control, false otherwise
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void txbBody_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txbBody.SelectedText = "    ";
                e.Handled = true;
            }
        }

        private void txbBody_TextChanged(object sender, EventArgs e)
        {
            var selectionStart = txbBody.SelectionStart;
            txbBody.Text = txbBody.Text.Replace("\t", "");
            txbBody.SelectionStart = selectionStart;
        }

        private void UpdateLayout(SplitContainer split)
        {
            if (_dictSplitDistance.ContainsKey(split.Name))
            {
                _dictSplitDistance[split.Name] = split.SplitterDistance;
            }
            else
            {
                _dictSplitDistance.Add(split.Name, split.SplitterDistance);
            }
        }

        private async void SaveLayout()
        {
            var fileName = GetLayoutFileName();
            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, _dictSplitDistance);
        }
    }
}
