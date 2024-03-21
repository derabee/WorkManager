using SG_WorkManager.Item;
using SG_WorkManager.Manager;
using SG_WorkManager.ViewControl;
using SG_WorkManager.ViewControl.ViewInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_WorkManager
{
    public partial class MainView : Form
    {
        private ViewControlManager viewControlManager = new ViewControlManager();
        private Dictionary<string, Size> dictWindowSize = new Dictionary<string, Size>();
        //private Dictionary<string, int> dictSplitDistance = new Dictionary<string, int>();
        private string DEFAULT_FILE_EXTENTION = "json";
        private bool _systemShutdown = false;
        public MainView()
        {
            InitializeComponent();
            InitMapping();
            CreateDefaultFolder();
            InitSetting();
            InitEvents();
            UpdateViewControl(btnShowDailyReportViewControl);
        }

        private void InitMapping()
        {
            viewControlManager.AddViewControl(btnShowDailyReportViewControl, DailyReportViewControl.GetInstance());
            viewControlManager.AddViewControl(btnShowWeekReportViewControl, WeekReportViewControl.GetInstance());
            viewControlManager.AddViewControl(btnShowDocumentViewControl, DocumentViewControl.GetInstance());
            viewControlManager.AddViewControl(btnShowVacationViewControl, VacationViewControl.GetInstance());
        }

        private string GetDefaultPath()
        {
            return $@"{Settings.DEFAULT_PATH}\{Settings.WINSETTING_PATH}";
        }
        private void CreateDefaultFolder()
        {
            if (Directory.Exists(GetDefaultPath()) == false)
            {
                Directory.CreateDirectory(GetDefaultPath());
            }
        }

        private string GetWindowSizeFilePath()
        {
            return $@"{GetDefaultPath()}\{Settings.WINDOW_FILE_NAME}.{DEFAULT_FILE_EXTENTION}";
        }

        private void InitSetting()
        {
            const int DEFUALT_WINDOW_SIZE_W = 1500;
            const int DEFUALT_WINDOW_SIZE_H = 1200;
            var filePath = GetWindowSizeFilePath();
            if (File.Exists(filePath))
            {
                using FileStream openStream = File.OpenRead(filePath);
                dictWindowSize = JsonSerializer.DeserializeAsync<Dictionary<string, Size>>(openStream).Result;
            }
            else
            {
                var size = new Size(DEFUALT_WINDOW_SIZE_W, DEFUALT_WINDOW_SIZE_H);
                foreach (var button in viewControlManager.Keys)
                {
                    dictWindowSize.Add(button.Name, size);
                }
            }
            /*var filePath2 = GetSplitDistanceFilePath();
            if (File.Exists(filePath2))
            {
                using FileStream openStream = File.OpenRead(filePath2);
                dictSplitDistance = JsonSerializer.DeserializeAsync<Dictionary<string, int>>(openStream).Result;
            }*/
        }

        private void InitEvents()
        {
            foreach (var button in viewControlManager.Keys)
            {
                button.Click += (sender, e) => { UpdateViewControl(button); };
            }

            this.SizeChanged += delegate
            {
                lblWindowSize.Text = $"Window Size : {this.Width.ToString("#,##0")} x {this.Height.ToString("#,##0")}";
            };

            this.FormClosing += async (sender, e) =>
            {
                if (_systemShutdown)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    this.Visible = false;
                }
            };
            btnSaveWindowSize.Click += delegate
            {
                //
                var keyControl = viewControlManager.LastViewControlKey.Name;
                //
                SaveWindowSize(keyControl);
                //SaveSplitDistance(keyControl);
            };
            contextMenuStrip1.ItemClicked += contextMenuTray_ItemClicked;
            notifyIcon1.DoubleClick += delegate
            {
                this.Visible = true;
            };
        }

        private void contextMenuTray_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag != null && e.ClickedItem.Tag.ToString().Equals("EXIT"))
            {
                this.Close();
                this.Dispose();
                Application.Exit();
            }
            else if (e.ClickedItem.Tag != null && e.ClickedItem.Tag.ToString().Equals("DIC"))
            {
                this.Visible = true;
            }
        }

        private void UpdateViewControl(Button button)
        {
            var lastViewControl = viewControlManager.LastViewControl;
            var viewControl = viewControlManager.GetViewControl(button);
            // 동일한 페이지 반복 이동 차단
            if (lastViewControl == viewControl)
            {
                return;
            }
            // 페이지 이동 전 저장 여부 확인
            if (lastViewControl != null)
            {
                if (!lastViewControl.CanProcess())
                {
                    return;
                }
            }
            // 페이지 이동 및 창 크기 조정
            this.panel3.Controls.Clear();
            var control = viewControl as Control;
            control.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(control);
            viewControlManager.UpdateLastViewControl(button, viewControl);

            if (dictWindowSize.TryGetValue(button.Name, out var size))
            {
                this.Size = size;
            }
        }

        private async void SaveWindowSize(string key)
        {
            if (dictWindowSize.ContainsKey(key))
            {
                dictWindowSize[key] = this.Size;
            }
            else
            {
                dictWindowSize.Add(key, this.Size);
            }
            //
            var filePath = GetWindowSizeFilePath();
            await using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, dictWindowSize);
        }
        /*
        private async void SaveSplitDistance(string key)
        {
            var splitDistance = GetSplitDistance(viewControlManager.LastViewControl);
            if (dictSplitDistance.ContainsKey(key))
            {
                dictSplitDistance[key] = splitDistance;
            }
            else
            {
                if (splitDistance != 0)
                    dictSplitDistance.Add(key, splitDistance);
            }
            //
            var filePath = GetSplitDistanceFilePath();
            await using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, dictSplitDistance);
        }

        private int GetSplitDistance(IViewControl lastViewControl)
        {
            return (lastViewControl as IViewSplitable)?.SplitDistance ?? 0;
        }
        */


    }
}
