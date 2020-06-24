using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JM_GluingSystem.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoubleAnimation c_daListAnimation;
        public bool c_bState = true;
        //全局界面列表
        public ObservableCollection<PojInfo> MonitorList { get; set; }
        //报表管理列表
        public ObservableCollection<PojInfo> ReportList { get; set; }
        //报警管理列表
        public ObservableCollection<PojInfo> AlarmList { get; set; }
        //工单管理列表
        public ObservableCollection<PojInfo> WorkSheetList { get; set; }
        //基础信息列表
        public ObservableCollection<PojInfo> BasicInfoList { get; set; }
        public string LitName { get; set; }
        public string BtnTag { get; set; }
        private DispatcherTimer ShowTimer;
        public MainWindow()
        {
            InitializeComponent();
            ShowTimer = new DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
            ListAdd();
            this.DataContext = this;
        }
        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            // 全屏显示
            //this.WindowState = WindowState.Normal;
            //this.WindowStyle = WindowStyle.None;
            //this.ResizeMode = ResizeMode.NoResize;
            //this.Topmost = true;

            //this.Left = 0.0;
            //this.Top = 0.0;
            //this.Width = SystemParameters.PrimaryScreenWidth;
            //this.Height = SystemParameters.PrimaryScreenHeight;
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Convert.ToInt32(DeskWidth * 0.8);
            this.Height = Convert.ToInt32(DeskHeight * 0.9);
            this.userName.Text = Login.userInfo.UserName;
            ////添加元素加载完成事件——自动开始播放
            //Media.Loaded += new RoutedEventHandler(media_loaded);
            ////添加媒体播放结束事件——重新播放
            //Media.MediaEnded += new RoutedEventHandler(media_MediaEnded);
            //Media.Unloaded += new RoutedEventHandler(media_Unloaded);
            //string str = Directory.GetCurrentDirectory();
            ////Directory.SetCurrentDirectory(Directory.GetParent(str).FullName);
            ////str = Directory.GetCurrentDirectory();
            ////Directory.SetCurrentDirectory(Directory.GetParent(str).FullName);
            ////str = Directory.GetCurrentDirectory();
            //string path = str + "\\Resources\\Video\\WL_jiance0000.mp4";
            //Media.Source = new Uri(path);
            //Media.Play();
            //c_daListAnimation = new DoubleAnimation();
        }
        private void No_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (c_bState)
            {
                c_bState = false;
                c_daListAnimation.From = 0;
                c_daListAnimation.To = -205;
                cd.Width = new GridLength(0);
                MainPanel.Width = 1695;
            }
            else
            {
                c_bState = true;
                c_daListAnimation.From = -205;
                c_daListAnimation.To = 0;
                cd.Width = new GridLength(205);
                MainPanel.Width = 1490;
            }
        }
        public void ShowCurTimer(object sender, EventArgs args)
        {
            this.tbTimeText.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            this.tbTimeText.Text += " ";
            this.tbTimeText.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        public void ListAdd()
        {
            MonitorList = new ObservableCollection<PojInfo>
            {
                new PojInfo { Name = "全局监控"}
            };
            ReportList = new ObservableCollection<PojInfo>
            {
                new PojInfo { Name = "检测统计"},
                new PojInfo { Name = "生产统计"}
            };
            AlarmList = new ObservableCollection<PojInfo>
            {
                new PojInfo { Name = "历史报警"}
            };
            WorkSheetList = new ObservableCollection<PojInfo>
            {
                //new PojInfo { Name = "工单作成"},
                new PojInfo { Name = "工单排产"}
            };
            BasicInfoList = new ObservableCollection<PojInfo>
            {
                new PojInfo { Name = "用户管理"}
                //new PojInfo { Name = "权限管理"}
            };
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            string btnInfo = btn.Tag.ToString();
            foreach (TabItem tab in MainPanel.Items)
            {
                string str = tab.Header.ToString() + tab.Name.ToString();
                if (btnInfo.Equals(str))
                {
                    MainPanel.Items.Remove(tab);
                    break;
                }
            }
        }
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.ListBox listBox = sender as System.Windows.Controls.ListBox;
            PojInfo selected = listBox.SelectedItem as PojInfo;
            string manageName = listBox.Name;
            string header = selected.Name;
            foreach (TabItem tab in MainPanel.Items)
            {
                if (tab.Header.Equals(header) && tab.Name.Equals(manageName))
                {
                    MainPanel.SelectedItem = tab;
                    return;
                }
            }
            TabItem temptb = new TabItem();
            temptb.Header = header;
            temptb.Name = manageName;
            BtnTag = temptb.Header + temptb.Name;
            foreach (PojInfo p in MonitorList)
            {
                if (p.Name == header)
                {
                    Global_2 uc = new Global_2();
                    LitName = header;
                    temptb.Content = uc;
                }
            }
            foreach (PojInfo p in ReportList)
            {
                if (p.Name == header)
                {
                    if (header == "检测统计")
                    {
                        Check uc = new Check();
                        LitName = header;
                        temptb.Content = uc;
                    }
                    else if (header == "生产统计")
                    {
                        Product uc = new Product();
                        LitName = header;
                        temptb.Content = uc;
                    }
                }
            }
            foreach (PojInfo p in AlarmList)
            {
                if (p.Name == header)
                {
                    HistoryAlarm uc = new HistoryAlarm();
                    LitName = header;
                    temptb.Content = uc;
                }
            }
            foreach (PojInfo p in WorkSheetList)
            {
                if (p.Name == header)
                {
                    WorkSchedule uc = new WorkSchedule();
                    LitName = header;
                    temptb.Content = uc;
                    //if (header == "工单作成")
                    //{
                    //    WorkDone uc = new WorkDone();
                    //    LitName = header;
                    //    temptb.Content = uc;
                    //}
                    //else if (header == "工单排产")
                    //{
                    //    WorkSchedule uc = new WorkSchedule();
                    //    LitName = header;
                    //    temptb.Content = uc;
                    //}
                }
            }
            foreach (PojInfo p in BasicInfoList)
            {
                if (p.Name == header)
                {
                    BasicInfoList uc = new BasicInfoList();
                    LitName = header;
                    temptb.Content = uc;
                }
            }
            this.MainPanel.Items.Add(temptb);
            MainPanel.SelectedIndex = MainPanel.Items.Count - 1;
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        public class PojInfo
        {
            public string Name { get; set; }
        }
    }
}
