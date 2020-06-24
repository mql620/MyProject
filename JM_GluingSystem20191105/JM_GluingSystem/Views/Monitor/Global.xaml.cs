using JM_GluingSystem.DB;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JM_GluingSystem.Views.Monitor
{
    /// <summary>
    /// Global.xaml 的交互逻辑
    /// </summary>
    public partial class Global : UserControl
    {
        public System.Timers.Timer Timer1;
        public Global()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(HeartBeatLamp);
            timer.Interval = new TimeSpan(0,0,2);
            timer.Start();
            TimeStart();

            DataContext = this;
        }
        private void TimeStart()
        {
            Timer1 = new System.Timers.Timer(50);
            Timer1.Elapsed += new ElapsedEventHandler(ShowResult);
            Timer1.AutoReset = true;
            Timer1.Start();
        }
        private void ShowResult(object sender, ElapsedEventArgs e)
        {
            GateInfo();
        }
        private void GateInfo()
        {
            txt_NGNumber.Dispatcher.BeginInvoke(new Action(() =>
            {
                txt_NGNumber.Text = MainWindow.ProductNumber.UnqualifiedNumber.ToString();
            }));
            if (MainWindow.PLCReadInfo.LoadInput == 1)
            {
                txt_LoadID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_LoadID.Text = MainWindow.DoorInfoInput.DoorID;//id
                }));

                txt_LoadType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_LoadType.Text = MainWindow.DoorInfoInput.DoorMold;
                }));
                txt_LoadParametric1.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_LoadParametric1.Text = "长" + MainWindow.DoorInfoInput.ThinPlateLength + "宽" + MainWindow.DoorInfoInput.ThinPlateWidth + "厚" + MainWindow.DoorInfoInput.Thickness;//参1长宽厚
                }));
                txt_LoadParametric2.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_LoadParametric2.Text = MainWindow.DoorInfoInput.OpenDirection;//参2开合方向
                }));
            }
            if (MainWindow.PLCReadInfo.LoadOutput == 1)
            {
                txt_LoadID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_LoadID.Text = "";
                }));
                txt_LoadType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_LoadType.Text = "";
                }));
                txt_LoadParametric1.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_LoadParametric1.Text = "";
                }));
                txt_LoadParametric2.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_LoadParametric2.Text = "";
                }));
            }
            if (MainWindow.PLCReadInfo.FilmMulchInput == 1)
            {
                switch (MainWindow.PLCReadInfo.MulchDoorType)
                {
                    case 1:
                        txt_MulchType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_MulchType.Text = "防火门";
                        }));
                        break;
                    case 2:
                        txt_MulchType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_MulchType.Text = "防盗门";
                        }));
                        break;
                }
                txt_MulchID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_MulchID.Text = MainWindow.PLCReadInfo.MulchDoorID;
                }));
            }
            if (MainWindow.PLCReadInfo.FilmMulchOutput == 1)
            {
                txt_MulchID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_MulchID.Text = "";
                }));
                txt_MulchType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_MulchType.Text = "";
                }));
            }
            if (MainWindow.PLCReadInfo.GluingInput == 1)
            {
                txt_GluingID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_GluingID.Text = MainWindow.PLCReadInfo.GluingDoorID;
                }));
                switch (MainWindow.PLCReadInfo.GluingDoorType)
                {
                    case 1:
                        txt_GluingType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_GluingType.Text = "防火门";
                        }));
                        break;
                    case 2:
                        txt_GluingType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_GluingType.Text = "防盗门";
                        }));
                        break;
                }
            }
            if (MainWindow.PLCReadInfo.GluingOutput == 1)
            {
                txt_GluingID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_GluingID.Text = "";
                }));
                txt_GluingType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_GluingType.Text = "";
                }));
            }
            if (MainWindow.PLCReadInfo.FillInput == 1)
            {
                txt_FillID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_FillID.Text = MainWindow.PLCReadInfo.FillDoorID;//id
                }));
                switch (MainWindow.PLCReadInfo.FillDoorType)
                {
                    case 1:
                        txt_FillType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_FillType.Text = "防火门";
                        }));
                        break;
                    case 2:
                        txt_FillType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_FillType.Text = "防盗门";
                        }));
                        break;
                }
            }
            if (MainWindow.PLCReadInfo.FillOutput == 1)
            {
                txt_FillID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_FillID.Text = "";
                }));
                txt_FillType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_FillType.Text = "";
                }));
            }
            if (MainWindow.PLCReadInfo.PolishInput == 1)
            {
                txt_PolishID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_PolishID.Text = MainWindow.PLCReadInfo.PolishDoorID;
                }));
                switch (MainWindow.PLCReadInfo.PolishDoorType)
                {
                    case 1:
                        txt_PolishType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_PolishType.Text = "防火门";
                        }));
                        break;
                    case 2:
                        txt_PolishType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_PolishType.Text = "防盗门";
                        }));
                        break;
                }
            }
            if (MainWindow.PLCReadInfo.PolishOutput == 1)
            {
                txt_PolishID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_PolishID.Text = "";
                }));
                txt_PolishType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_PolishType.Text = "";
                }));
            }
            if (MainWindow.PLCReadInfo.WeldingInput == 1)
            {
                txt_WeldingID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_WeldingID.Text = MainWindow.PLCReadInfo.WeldingDoorID;
                }));
                switch (MainWindow.PLCReadInfo.WeldingDoorType)
                {
                    case 1:
                        txt_WeldingType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_WeldingType.Text = "防火门";
                        }));
                        break;
                    case 2:
                        txt_WeldingType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_WeldingType.Text = "防盗门";
                        }));
                        break;
                }
            }
            if (MainWindow.PLCReadInfo.WeldingOutput == 1)
            {
                txt_WeldingID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_WeldingID.Text = "";
                }));
                txt_WeldingType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_WeldingType.Text = "";
                }));
            }
            if (MainWindow.PLCReadInfo.RemoveSmokeTrainInput == 1)
            {
                txt_RemoveSmokeTrainID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_RemoveSmokeTrainID.Text = MainWindow.PLCReadInfo.RemoveSmokeTrainDoorID;
                }));
                switch (MainWindow.PLCReadInfo.RemoveSmokeTrainDoorType)
                {
                    case 1:
                        txt_RemoveSmokeTrainType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_RemoveSmokeTrainType.Text = "防火门";
                        }));
                        break;
                    case 2:
                        txt_RemoveSmokeTrainType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_RemoveSmokeTrainType.Text = "防盗门";
                        }));
                        break;
                }
            }
            if (MainWindow.PLCReadInfo.RemoveSmokeTrainOutput == 1)
            {
                txt_RemoveSmokeTrainID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_RemoveSmokeTrainID.Text = "";
                }));
                txt_RemoveSmokeTrainType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_RemoveSmokeTrainType.Text = "";
                }));
            }
            if (MainWindow.PLCReadInfo.CheckInput == 1)
            {
                txt_CheckID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_CheckID.Text = MainWindow.PLCReadInfo.CheckDoorID;
                }));
                switch (MainWindow.PLCReadInfo.CheckDoorType)
                {
                    case 1:
                        txt_CheckType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_CheckType.Text = "防火门";
                        }));
                        break;
                    case 2:
                        txt_CheckType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_CheckType.Text = "防盗门";
                        }));
                        break;
                }
            }
            if (MainWindow.PLCReadInfo.CheckStep >= 200 && MainWindow.PLCReadInfo.CheckStep <= 210)//检测结果
            {
                switch (MainWindow.PLCReadInfo.CheckResult)
                {
                    case 1:
                        txt_CheckResult.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_CheckResult.Text = "OK";
                        }));
                        break;
                    case 2:
                        txt_CheckResult.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_CheckResult.Text = "NG";
                        }));
                        break;
                }
            }
            if (MainWindow.PLCReadInfo.CheckOutput == 1)
            {
                txt_CheckID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_CheckID.Text = "";
                }));
                txt_CheckType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_CheckType.Text = "";
                }));
                txt_CheckResult.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_CheckResult.Text = "";
                }));
                CheckPicture.Dispatcher.BeginInvoke(new Action(() =>
                {
                    CheckPicture.Source = null;
                }));
            }
            if (MainWindow.PLCReadInfo.UnloadInput == 1)
            {
                txt_UnloadID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_UnloadID.Text = MainWindow.PLCReadInfo.UnloadDoorID;
                }));
                switch (MainWindow.PLCReadInfo.UnloadDoorType)
                {
                    case 1:
                        txt_UnloadType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_UnloadType.Text = "防火门";
                        }));
                        break;
                    case 2:
                        txt_UnloadType.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            txt_UnloadType.Text = "防盗门";
                        }));
                        break;
                }
            }
            if (MainWindow.PLCReadInfo.UnloadOutput == 1)
            {
                txt_UnloadID.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_UnloadID.Text = "";
                }));
                txt_UnloadType.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txt_UnloadType.Text = "";
                }));
            }
        }

        private void HeartBeatLamp(object sender, EventArgs e)
        {
            Ellipse ellipse = (Ellipse)_btn.Template.FindName("ButtonEllipse", _btn);
            if (ellipse.Fill == Brushes.Red)
                ellipse.Fill = Brushes.Green;
            else
                ellipse.Fill = Brushes.Red;
            //if (_btn.Visibility == Visibility.Hidden || _btn.Visibility == Visibility.Collapsed)
            //{
            //    _btn.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    _btn.Visibility = Visibility.Hidden;
            //}
        }
    }
}
