using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Forms;
using SG_WorkManager.ViewControl.ViewInterface;
using Microsoft.VisualBasic;
using SG_WorkManager;
using SG_WorkManager.Item;
using SG_WorkManager.ViewControl.ViewInterface;

namespace SG_WorkManager
{

    public partial class WeekReportViewControl : UserControl, IViewControl
    {
        private Dictionary<string, WeekReportItem> dicWorkReport = new Dictionary<string, WeekReportItem>();
        private Dictionary<string, SplitContainer> _dictSplit = new Dictionary<string, SplitContainer>();
        private Dictionary<string, int> _dictSplitDistance = new Dictionary<string, int>();
        private DateTime selectedWeekStartDate;
        private DateTime lastUpdatedDT;
        private int UPDATE_CYCLE_SECOND;
        private bool isLoading;

        private bool isIniting;
        public bool IsSaved { get; set; } = true;
        public string ControlName { get; set; }
        public string DisplayText { get; set; }
        public int PageNumber { get; set; }

        public WeekReportViewControl()
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
            InitEvents();
            InitControls();
            InitVars();
        }

        private void RefreshView()
        {     
            InitLoadDatas();
            UpdateSelectedWeek(DateTime.Now);
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
            var col0Idx = grid.Columns.Add("colWeekIdx", "Week");
            var col1Idx = grid.Columns.Add("colSummary", "Summary");
            var col0 = grid.Columns[col0Idx];
            var col1 = grid.Columns[col1Idx];
            col0.Width = 120;
            col1.Width = 875;
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitEvents()
        {
            //btnDisplay.Click += delegate { DisplayData(selectedDate); };
            btnSave.Click += delegate
            {
                this.Save();
            };
            btnToday.Click += delegate
            {

                UpdateSelectedWeek(DateTime.Now);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[0].Selected = true;
            };

            dataGridView1.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;
                var weekString = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var item = dicWorkReport[weekString];
                UpdateSelectedWeek(item.ReportWeekStartDate);
            };

            txbTitle.TextChanged += delegate { DisplaySaved(false); };
            txbBody.TextChanged += delegate { DisplaySaved(false); };
            txbSummary.TextChanged += delegate { DisplaySaved(false); };

            txbBody.KeyDown += txbBody_KeyDown;
            txbBody.TextChanged += txbBody_TextChanged;

            foreach (var split in _dictSplit.Values)
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

        private void DisplaySaved(bool isSaved)
        {
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
            this.IsSaved = isSaved;
        }

        private void UpdateSelectedWeek(DateTime dt)
        {
            if (!this.CanProcess())
            {
                return;
            }
            var weekStr = GetWeekString(dt);
            label2.Text = weekStr;
            DisplayData(weekStr);
            selectedWeekStartDate = dt;
            DisplaySaved(true);
        }

        private async void InitLoadDatas()
        {
            CreateDefaultFolder();
            var dtNow = DateTime.Now;
            await LoadDataFromFile(dtNow.AddDays(-30), dtNow);
            UpdateSelectedWeek(dtNow);
            await LoadLayout();
        }
        private string GetDefaultPath()
        {
            return $@"{Settings.DEFAULT_PATH}\{Settings.WEEKLY_PATH}";
        }
        private void CreateDefaultFolder()
        {
            var defaultPath = GetDefaultPath();
            if (Directory.Exists(defaultPath) == false)
            {
                Directory.CreateDirectory(defaultPath);
            }
        }

        private string GetWeekReportFilePath(string fileName)
        {
            const string FILE_EXTENTION = "json";
            var filePath = $@"{GetDefaultPath()}\{fileName}.{FILE_EXTENTION}";
            return filePath;
        }

        private string GetWeekString(DateTime dt)
        {
            var dt2 = dt.AddDays(2);
            int year = dt.Year;
            int month = dt.Month;
            int weekIdx = (dt.Day / 7) + 1;
            if (dt.Month != dt2.Month)
            {
                year = dt2.Year;
                month = dt2.Month;
                weekIdx = (dt2.Day / 7) + 1;
            }
            return $"{year}-{month.ToString("0#")} {weekIdx}주차";
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
                if (dt.DayOfWeek != DayOfWeek.Monday)
                {
                    dt = dt.AddDays(-1);
                    continue;
                }

                var fileName = GetWeekString(dt);
                var filePath = GetWeekReportFilePath(fileName);
                WeekReportItem weekReportItem;
                var summary = string.Empty;
                if (File.Exists(filePath))
                {
                    using FileStream openStream = File.OpenRead(filePath);
                    weekReportItem = JsonSerializer.DeserializeAsync<WeekReportItem>(openStream).Result;
                    summary = weekReportItem.Summary ?? string.Empty;
                }
                else
                {
                    weekReportItem = new WeekReportItem()
                    {
                        ReportWeekStartDate = dt
                    };
                    summary = "-";
                }

                var key = fileName;
                dicWorkReport.Add(key, weekReportItem);
                grid.Rows.Add(key, summary);
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

                foreach (var key in _dictSplitDistance.Keys)
                {
                    _dictSplit[key].SplitterDistance = _dictSplitDistance[key];
                }
            }
        }

        private async void SaveDataAsFile(DateTime dt, WeekReportItem item)
        {
            var key = GetWeekString(dt);
            if (dicWorkReport.TryGetValue(key, out var workReport))
            {
                dicWorkReport[key] = item;
            }
            else
            {
                dicWorkReport.Add(key, item);
            }

            var grid = dataGridView1;
            for (int i = 0, count = grid.Rows.Count; i < count; i++)
            {
                if (grid.Rows[i].Cells[0].Value.ToString() == key)
                {
                    grid.Rows[i].Cells[1].Value = item.Summary;
                    break;
                }
            }

            var filePath = GetWeekReportFilePath(key);
            await using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, item);
            DisplaySaved(true);
        }

        private void DisplayData(string selectedDate)
        {
            WeekReportItem item;
            dicWorkReport.TryGetValue(selectedDate, out item);
            if (item == null)
            {
                item = new();
            }
            txbSummary.Text = item.Summary;
            txbTitle.Text = item.Title;
            txbBody.Text = item.Body;
        }



        private static WeekReportViewControl s_instance;
        public static WeekReportViewControl GetInstance()
        {
            if (s_instance == null || s_instance.IsDisposed)
                s_instance = new WeekReportViewControl();
            s_instance.RefreshView();
            return s_instance;
        }

        public bool Save()
        {
            SaveDataAsFile(selectedWeekStartDate, new WeekReportItem
            {
                ReportWeekStartDate = selectedWeekStartDate,
                Summary = txbSummary.Text,
                Title = txbTitle.Text,
                Body = txbBody.Text
            });
            return true;
        }
        public bool CanProcess()
        {
            if (this.IsSaved)
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
