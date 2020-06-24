using JM.SiemensS7;
using JM_GluingSystem.Common;
using JM_GluingSystem.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        private DispatcherTimer ShowTimer;
        public bool c_bState = true;
        private DoubleAnimation c_daListAnimation;
        private static S7 Client;
        private static bool connectDone = false;//plc连接标志
        //private int alarmBegin_Flag = 0;//报警开始标志
        //private int alarmHandle_Flag = 0;//报警处理状态标志
        private int writeDone_Flag = 0;//数据发送完成标志
        private int load_Flag = 0;//上料站报警处理状态标志
        private int filmMulch_Flag=0;//覆膜站报警处理状态标志
        private int gluing_Flag = 0;//涂胶站报警处理状态标志
        private int fill_Flag = 0;//填充站报警处理状态标志
        private int polish_Flag = 0;//打磨站报警处理状态标志
        private int welding_Flag = 0;//焊接站报警处理状态标志
        private int removeSmokeTrain_Flag = 0;//除烟痕站报警处理状态标志
        private int check_Flag = 0;//检测站报警处理状态标志
        private int unload_Flag = 0;//下料站报警处理状态标志
        private int loadInbound_Flag = 0;//上料入站标志位
        private int loadOutbound_Flag = 0;//上料出站标志
        private int filmMulchInbound_Flag = 0;//覆膜入站标志
        private int filmMulchOutbound_Flag = 0;//覆膜出站标志
        private int gluingInbound_Flag = 0;//涂胶入站标志
        private int gluingOutbound_Flag = 0;//涂胶出站标志
        private int fillInbound_Flag = 0;//珍珠岩填充入站标志
        private int fillOutbound_Flag = 0;//珍珠岩填充出站标志
        private int polishInbound_Flag = 0;//打磨入站标志
        private int polishOutbound_Flag = 0;//打磨出站标志
        private int weldingInbound_Flag = 0;//焊接入站标志
        private int weldingOutbound_Flag = 0;//焊接出站标志
        private int removeSmokeTrainInbound_Flag = 0;//除烟痕入站标志
        private int removeSmokeTrainOutbound_Flag = 0;//除烟痕出站标志
        private int checkInbound_Flag = 0;//检测入站标志
        private int checkOutbound_Flag = 0;//检测出站标志
        private int unloadInbound_Flag = 0;//下料入站标志
        private int unloadOutbound_Flag = 0;//下料出站标志
        public static PLCReadInfo PLCReadInfo = new PLCReadInfo();
        public static DoorInfoInput DoorInfoInput = new DoorInfoInput();
        public static ProductNumber ProductNumber = new ProductNumber();
        public static SecondDoorInfo SecondDoorInfo = new SecondDoorInfo();
        private int output;
        private int qualified;
        //全局界面列表
        public ObservableCollection<PojInfo> MonitorList { get; set; }
        //报表管理列表
        public ObservableCollection<PojInfo> ReportList { get; set; }
        //报警管理列表
        public ObservableCollection<PojInfo> AlarmList { get; set; }
        //工单管理列表
        //public ObservableCollection<PojInfo> WorkSheetList { get; set; }
        //基础信息列表
        public ObservableCollection<PojInfo> BasicInfoList { get; set; }
        //public string LitName { get; set; }
        public string BtnTag { get; set; }
        public System.Timers.Timer aTimer;
        public MainWindow()
        {
            InitializeComponent();
            ShowTimer = new DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
            ListAdd();            
            this.DataContext = this;
            ReadPLCThread();
            TimeStart();
        }
        /// <summary>
        /// PLC读取线程
        /// </summary>
        private void ReadPLCThread()
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                Client = new S7();
                while (true)
                {
                    if (connectDone)
                    {
                        Read();
                        if (PLCReadInfo.HeartBeat == 1)
                        {
                            Client.WriteDBBit(17, 0, 0, 1);
                        }
                        else if (PLCReadInfo.HeartBeat == 0)
                        {
                            Client.WriteDBBit(17, 0, 0, 0);
                        }
                        if (PLCReadInfo.LoadFault_Flag == 1 && load_Flag == 0)
                        {
                            LoadAlarm();
                            InsertLoadAlarm();
                            load_Flag = 1;
                        }
                        else if (PLCReadInfo.LoadFault_Flag == 0 && load_Flag == 1)
                        {
                            LoadAlarm();
                            UpdateLoadAlarm();
                            load_Flag = 0;
                        }
                        if (PLCReadInfo.FillFault_Flag == 1 && fill_Flag == 0)
                        {
                            FillAlarm();
                            InsertFillAlarm();
                            fill_Flag = 1;
                        }
                        else if (PLCReadInfo.FillFault_Flag == 0 && fill_Flag == 1)
                        {
                            FillAlarm();
                            UpdateFillAlarm();
                            fill_Flag = 0;
                        }
                        if (PLCReadInfo.CheckFault_Flag == 1 && check_Flag == 0)
                        {
                            CheckAlarm();
                            InsertCheckAlarm();
                            check_Flag = 1;
                        }
                        else if (PLCReadInfo.CheckFault_Flag == 0 && check_Flag == 1)
                        {
                            CheckAlarm();
                            UpdateCheckAlarm();
                            check_Flag = 0;
                        }
                        if (PLCReadInfo.LayingOffFault_Flag == 1 && unload_Flag == 0)
                        {
                            UnloadALarm();
                            InsertUnloadAlarm();
                            unload_Flag = 1;
                        }
                        else if (PLCReadInfo.LayingOffFault_Flag == 0 && unload_Flag == 1)
                        {
                            UnloadALarm();
                            UpdateUnloadAlarm();
                            unload_Flag = 0;
                        }
                        if (PLCReadInfo.LoadRequest_Flag == 1 && Client.ReadDBBit(17, 0, 7) == 0)
                        {
                            SqlDataReader dr = DBHelper.ExecuteReader1("searchdoorInfo", null);
                            if (dr.HasRows)
                            {
                                while (dr.Read())//遍历出各个字段
                                {
                                    DoorInfoInput.LoadBatchID = dr[0].ToString();
                                    DoorInfoInput.OrderNum = dr[1].ToString();
                                    DoorInfoInput.OrderQuantity = Convert.ToInt32(dr[2]);
                                    DoorInfoInput.DoorMold = dr[3].ToString();
                                    DoorInfoInput.PlacementMode = dr[4].ToString();
                                    DoorInfoInput.ThicknessDistinguish = dr[5].ToString();
                                    DoorInfoInput.OpenDirection = dr[6].ToString();
                                    DoorInfoInput.StackPosition = dr[7].ToString();
                                    DoorInfoInput.PerlitePosition = dr[8].ToString();
                                    DoorInfoInput.ThinPlateLength = Convert.ToInt32(dr[9]);
                                    DoorInfoInput.ThinPlateWidth = Convert.ToInt32(dr[10]);
                                    DoorInfoInput.ThickPlateLength = Convert.ToInt32(dr[11]);
                                    DoorInfoInput.ThickPlateWidth = Convert.ToInt32(dr[12]);
                                    DoorInfoInput.Thickness = Convert.ToInt32(dr[13]);
                                    DoorInfoInput.ThinPlateKeyholeX = Convert.ToInt32(dr[14]);
                                    DoorInfoInput.ThinPlateKeyholeY = Convert.ToInt32(dr[15]);
                                    DoorInfoInput.ThickPlateKeyholeX = Convert.ToInt32(dr[16]);
                                    DoorInfoInput.ThickPlateKeyholeY = Convert.ToInt32(dr[17]);
                                    DoorInfoInput.WeldSpacingUpDownStr = dr[18].ToString();
                                    DoorInfoInput.WeldSpacingUpDown = DBHelper.ToIntArray(DoorInfoInput.WeldSpacingUpDownStr);
                                    DoorInfoInput.WeldSpacingHingeStr = dr[19].ToString();
                                    DoorInfoInput.WeldSpacingHinge = DBHelper.ToIntArray(DoorInfoInput.WeldSpacingHingeStr);
                                    DoorInfoInput.WeldSpacingKeyholeStr = dr[20].ToString();
                                    DoorInfoInput.WeldSpacingKeyhole = DBHelper.ToIntArray(DoorInfoInput.WeldSpacingKeyholeStr);
                                    DoorInfoInput.WeldNumUpDown = Convert.ToInt32(dr[21]);
                                    DoorInfoInput.WeldNumHinge = Convert.ToInt32(dr[22]);
                                    DoorInfoInput.WeldNumKeyhole = Convert.ToInt32(dr[23]);
                                    DoorInfoInput.PerliteLength = Convert.ToInt32(dr[24]);
                                    DoorInfoInput.PerliteWidth = Convert.ToInt32(dr[25]);
                                    DoorInfoInput.PerliteThickness = Convert.ToInt32(dr[26]);
                                    DoorInfoInput.ThinPlateViewerX = Convert.ToInt32(dr[27]);
                                    DoorInfoInput.ThinPlateViewerY = Convert.ToInt32(dr[28]);
                                    DoorInfoInput.ThickPlateViewerX = Convert.ToInt32(dr[29]);
                                    DoorInfoInput.ThickPlateViewerY = Convert.ToInt32(dr[30]);
                                    DoorInfoInput.LockWidth = Convert.ToInt32(dr[31]);
                                    DoorInfoInput.LockLength = Convert.ToInt32(dr[32]);
                                    DoorInfoInput.LaminationDosage = Convert.ToInt32(dr[33]);
                                    DoorInfoInput.Status = Convert.ToInt32(dr[34]);
                                    DoorInfoInput.LoadNum = Convert.ToInt32(dr[35]);
                                    DoorInfoInput.SentNum = Convert.ToInt32(dr[36]);
                                }
                                if (DoorInfoInput.SentNum < DoorInfoInput.LoadNum)//已发送数小于上料数
                                {
                                    string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    DoorInfoInput.DoorID = time;
                                    Client.WriteDBString(17, 2, DoorInfoInput.OrderNum, 15); //DB17，偏移2.0订单编号
                                    Client.WriteDBString(17, 20, DoorInfoInput.DoorID, 15); //DB17,偏移20.0门ID
                                    switch (DoorInfoInput.DoorMold)
                                    {
                                        case "防盗门":
                                            Client.WriteDBBit(17, 38, 0, 0);
                                            Client.WriteDBBit(17, 38, 1, 1);
                                            break;
                                        case "防火门":
                                            Client.WriteDBBit(17, 38, 0, 1);
                                            Client.WriteDBBit(17, 38, 1, 0);
                                            break;
                                    }
                                    switch (DoorInfoInput.PlacementMode)
                                    {
                                        case "平放":
                                            Client.WriteDBBit(17, 38, 2, 1);
                                            Client.WriteDBBit(17, 38, 3, 0);
                                            break;
                                        case "斜放":
                                            Client.WriteDBBit(17, 38, 2, 0);
                                            Client.WriteDBBit(17, 38, 3, 1);
                                            break;
                                    }
                                    switch (DoorInfoInput.OpenDirection)
                                    {
                                        case "外右":
                                            Client.WriteDBBit(17, 38, 4, 1);
                                            Client.WriteDBBit(17, 38, 5, 0);
                                            break;
                                        case "外左":
                                            Client.WriteDBBit(17, 38, 4, 0);
                                            Client.WriteDBBit(17, 38, 5, 1);
                                            break;
                                    }
                                    switch (DoorInfoInput.ThicknessDistinguish)
                                    {
                                        case "厚板":
                                            Client.WriteDBBit(17, 38, 6, 1);
                                            Client.WriteDBBit(17, 20, 7, 0);
                                            break;
                                        case "薄板":
                                            Client.WriteDBBit(17, 38, 6, 0);
                                            Client.WriteDBBit(17, 38, 7, 1);
                                            break;
                                    }
                                    switch (DoorInfoInput.StackPosition)
                                    {
                                        case "A垛":
                                            Client.WriteDBBit(17, 39, 0, 1);
                                            Client.WriteDBBit(17, 39, 1, 0);
                                            break;
                                        case "B垛":
                                            Client.WriteDBBit(17, 39, 0, 0);
                                            Client.WriteDBBit(17, 39, 1, 1);
                                            break;
                                    }
                                    switch (DoorInfoInput.PerlitePosition)
                                    {
                                        case "A垛":
                                            Client.WriteDBBit(17, 39, 2, 1);//珍珠岩a垛
                                            Client.WriteDBBit(17, 39, 3, 0);//珍珠岩b垛
                                            break;
                                        case "B垛":
                                            Client.WriteDBBit(17, 39, 2, 0);//珍珠岩a垛
                                            Client.WriteDBBit(17, 39, 3, 1);//珍珠岩b垛
                                            break;
                                    }
                                    Client.WriteDBWord(17, 50, DoorInfoInput.ThickPlateLength);//厚板长
                                    Client.WriteDBWord(17, 52, DoorInfoInput.ThickPlateWidth);//厚板宽
                                    Client.WriteDBWord(17, 54, 70);//厚板厚，固定值
                                    Client.WriteDBWord(17, 56, DoorInfoInput.ThinPlateLength);//薄板长
                                    Client.WriteDBWord(17, 58, DoorInfoInput.ThinPlateWidth);//薄板宽
                                    Client.WriteDBWord(17, 60, 20);//薄板厚，固定值
                                    Client.WriteDBWord(17, 62, DoorInfoInput.PerliteLength);//珍珠岩长
                                    Client.WriteDBWord(17, 64, DoorInfoInput.PerliteWidth);//珍珠岩宽
                                    Client.WriteDBWord(17, 66, DoorInfoInput.PerliteThickness);//珍珠岩厚
                                    Client.WriteDBWord(17, 68, DoorInfoInput.Thickness);//门厚
                                    Client.WriteDBWord(17, 70, DoorInfoInput.ThickPlateKeyholeX);//厚板锁孔X
                                    Client.WriteDBWord(17, 72, DoorInfoInput.ThickPlateKeyholeY);//厚板锁孔Y
                                    Client.WriteDBWord(17, 74, DoorInfoInput.ThinPlateKeyholeX);//薄板锁孔X
                                    Client.WriteDBWord(17, 76, DoorInfoInput.ThinPlateKeyholeY);//薄板锁孔Y
                                    Client.WriteDBWord(17, 78, DoorInfoInput.ThickPlateViewerX);//厚板猫眼X
                                    Client.WriteDBWord(17, 80, DoorInfoInput.ThickPlateViewerY);//厚板猫眼Y
                                    Client.WriteDBWord(17, 82, DoorInfoInput.ThinPlateViewerX);//薄板猫眼X
                                    Client.WriteDBWord(17, 84, DoorInfoInput.ThinPlateViewerY);//薄板猫眼Y
                                    Client.WriteDBWord(17, 86, DoorInfoInput.LockWidth);//锁具宽
                                    Client.WriteDBWord(17, 88, DoorInfoInput.LockLength);//锁具长
                                    //Client.WriteDBWord(17, 86, DoorInfoInput.WeldNumKeyhole);//锁边焊点数
                                    //Client.WriteDBWord(17, 128, DoorInfoInput.WeldNumHinge);//铰链边焊点数
                                    //Client.WriteDBWord(17, 170, DoorInfoInput.WeldNumUpDown);//上下边焊点数
                                    //if (DoorInfoInput.WeldNumKeyhole <= 20 && DoorInfoInput.WeldNumHinge <= 20 && DoorInfoInput.WeldNumUpDown <= 10)
                                    //{
                                    //    for (int i = 0; i < DoorInfoInput.WeldNumKeyhole; i++)//锁边焊点间距
                                    //    {
                                    //        Client.WriteDBWord(17, 2 * i + 88, DoorInfoInput.WeldSpacingKeyhole[i]);
                                    //    }
                                    //    for (int i = 0; i < DoorInfoInput.WeldNumHinge; i++)//链边焊点间距
                                    //    {
                                    //        Client.WriteDBWord(17, 2 * i + 130, DoorInfoInput.WeldSpacingHinge[i]);
                                    //    }
                                    //    for (int i = 0; i < DoorInfoInput.WeldNumUpDown; i++)//上下边焊点间距
                                    //    {
                                    //        Client.WriteDBWord(17, 2 * i + 172, DoorInfoInput.WeldSpacingUpDown[i]);
                                    //    }
                                    //    Client.WriteDBWord(17, 228, 20);//PLC用来判断数据发送完成,写入数据随意
                                    //    Client.WriteDBBit(17, 0, 7, 1);//发送完成信号写入PLC
                                    //    writeDone_Flag = 1;//发送完成标志位置1
                                    //}
                                    //else//报警，焊点个数超出范围
                                    //{
                                    //    Log.WriteLog("焊点个数超出范围");
                                    //    System.Windows.MessageBox.Show("焊点个数超出范围");
                                    //}
                                    Client.WriteDBWord(17, 228, 20);//PLC用来判断数据发送完成,写入数据随意
                                    Client.WriteDBBit(17, 0, 7, 1);//发送完成信号写入PLC
                                    writeDone_Flag = 1;//发送完成标志位置1
                                }
                                else
                                {
                                    DoorInfoInput.Status = 2;
                                    int query = DBHelper.ExecuteNonQueryProc("UpdateStatus", new SqlParameter("@LoadBatchID", DoorInfoInput.LoadBatchID),
                                                                                             new SqlParameter("@Status", DoorInfoInput.Status),
                                                                                             new SqlParameter("@SentNum", DoorInfoInput.SentNum));
                                }
                            }
                            //else
                            //{
                            //    Log.WriteLog("数据库中不存在未完成的上料批号");
                            //    System.Windows.MessageBox.Show("数据库中不存在未完成的上料批号");
                            //}
                        }
                        if (PLCReadInfo.LoadStep == 15 && writeDone_Flag == 1)//机器人开始抓取 && 数据发送完成
                        {

                            int query = DBHelper.ExecuteNonQueryProc("addbasicinfo", new SqlParameter("@DoorID", DoorInfoInput.DoorID),
                                                                                     new SqlParameter("@DoorMold", DoorInfoInput.DoorMold),
                                                                                     new SqlParameter("@WorkSheetNumber", DoorInfoInput.OrderNum),
                                                                                     new SqlParameter("@PlacementMode", DoorInfoInput.PlacementMode),
                                                                                     new SqlParameter("@ThicknessDistinguish", DoorInfoInput.ThicknessDistinguish),
                                                                                     new SqlParameter("@OpenDirection", DoorInfoInput.OpenDirection),
                                                                                     new SqlParameter("@StackPosition", DoorInfoInput.StackPosition),
                                                                                     new SqlParameter("@PerlitePosition", DoorInfoInput.PerlitePosition),
                                                                                     new SqlParameter("@ThinPlateLength", DoorInfoInput.ThinPlateLength),
                                                                                     new SqlParameter("@ThinPlateWidth", DoorInfoInput.ThinPlateWidth),
                                                                                     new SqlParameter("@ThickPlateLength", DoorInfoInput.ThickPlateLength),
                                                                                     new SqlParameter("@ThickPlateWidth", DoorInfoInput.ThickPlateWidth),
                                                                                     new SqlParameter("@Thickness", DoorInfoInput.Thickness),
                                                                                     new SqlParameter("@FeedingTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                                                                     new SqlParameter("@LaminationDosage", DoorInfoInput.LaminationDosage),
                                                                                     new SqlParameter("@PerliteLength", DoorInfoInput.PerliteLength),
                                                                                     new SqlParameter("@PerliteWidth", DoorInfoInput.PerliteWidth),
                                                                                     new SqlParameter("@PerliteThickness", DoorInfoInput.PerliteThickness),
                                                                                     new SqlParameter("@WeldSpacingUpDownStr", DoorInfoInput.WeldSpacingUpDownStr),
                                                                                     new SqlParameter("@WeldSpacingHingeStr", DoorInfoInput.WeldSpacingHingeStr),
                                                                                     new SqlParameter("@WeldSpacingKeyholeStr", DoorInfoInput.WeldSpacingKeyholeStr),
                                                                                     new SqlParameter("@WeldNumUpDown", DoorInfoInput.WeldNumUpDown),
                                                                                     new SqlParameter("@WeldNumHinge", DoorInfoInput.WeldNumHinge),
                                                                                     new SqlParameter("@WeldNumKeyhole", DoorInfoInput.WeldNumKeyhole),
                                                                                     new SqlParameter("@ThinPlateKeyholeX", DoorInfoInput.ThinPlateKeyholeX),
                                                                                     new SqlParameter("@ThinPlateKeyholeY", DoorInfoInput.ThinPlateKeyholeY),
                                                                                     new SqlParameter("@ThickPlateKeyholeX", DoorInfoInput.ThickPlateKeyholeX),
                                                                                     new SqlParameter("@ThickPlateKeyholeY", DoorInfoInput.ThickPlateKeyholeY),
                                                                                     new SqlParameter("@ThinPlateViewerX", DoorInfoInput.ThinPlateViewerX),
                                                                                     new SqlParameter("@ThinPlateViewerY", DoorInfoInput.ThinPlateViewerY),
                                                                                     new SqlParameter("@ThickPlateViewerX", DoorInfoInput.ThickPlateViewerX),
                                                                                     new SqlParameter("@ThickPlateViewerY", DoorInfoInput.ThickPlateViewerY),
                                                                                     new SqlParameter("@LockWidth", DoorInfoInput.LockWidth),
                                                                                     new SqlParameter("@LockLength", DoorInfoInput.LockLength));

                            DoorInfoInput.SentNum++;//发送数+1
                            DoorInfoInput.Status = 1;//状态变为1：发送中
                            int query1 = DBHelper.ExecuteNonQueryProc("UpdateStatus", new SqlParameter("@LoadBatchID", DoorInfoInput.LoadBatchID),
                                                                                      new SqlParameter("@Status", DoorInfoInput.Status),
                                                                                      new SqlParameter("@SentNum", DoorInfoInput.SentNum));
                            Log.WriteLog("上料录入成功");
                            writeDone_Flag = 0;
                            loadInbound_Flag = 1;
                            loadOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.LoadOutput == 1 && loadOutbound_Flag == 0)
                        {
                            loadInbound_Flag = 0;
                            loadOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.LoadOutput == 0 && loadOutbound_Flag == 1)
                        {
                            loadOutbound_Flag = 0;
                        }

                        if (PLCReadInfo.FilmMulchInput == 1 && filmMulchInbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateLaminationPullInTime", new SqlParameter("@FilmMulchInputTime", time),
                                                                                                   new SqlParameter("@FilmMulchDoorID", PLCReadInfo.MulchDoorID));
                            filmMulchInbound_Flag = 1;
                            filmMulchOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.FilmMulchOutput == 1 && filmMulchOutbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateLaminationPullOutTime", new SqlParameter("@FilmMulchOutputTime", time),
                                                                                                    new SqlParameter("@UpMembraneAllowance", PLCReadInfo.UpMembraneAllowance),
                                                                                                    new SqlParameter("@DownMembraneAllowance", PLCReadInfo.DownMembraneAllowance),
                                                                                                    new SqlParameter("@CutLength", PLCReadInfo.CutLength),
                                                                                                    new SqlParameter("@Cutwidth", PLCReadInfo.Cutwidth),
                                                                                                    new SqlParameter("@FilmMulchDoorID", PLCReadInfo.MulchDoorID));
                            filmMulchInbound_Flag = 0;
                            filmMulchOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.FilmMulchOutput == 0 && filmMulchOutbound_Flag == 1)
                        {
                            filmMulchOutbound_Flag = 0;
                        }

                        if (PLCReadInfo.GluingInput == 1 && gluingInbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateGluingInputtime", new SqlParameter("@GluingInputTime", time),
                                                                                              new SqlParameter("@GluingDoorID", PLCReadInfo.GluingDoorID));
                            gluingInbound_Flag = 1;
                            gluingOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.GluingOutput == 1 && gluingOutbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateGluingOutputtime", new SqlParameter("@GluingOutputTime", time),
                                                                                               new SqlParameter("@ActualDosage", PLCReadInfo.ActualDosage),
                                                                                               new SqlParameter("@ResidualGlue", PLCReadInfo.ResidualGlue),
                                                                                               new SqlParameter("@GluingTime", PLCReadInfo.GluingTime),
                                                                                               new SqlParameter("@GluingDoorID", PLCReadInfo.GluingDoorID));
                            gluingInbound_Flag = 0;
                            gluingOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.GluingOutput == 0 && gluingOutbound_Flag == 1)
                        {
                            gluingOutbound_Flag = 0;
                        }


                        if (PLCReadInfo.FillInput == 1 && fillInbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updatefillinputtime", new SqlParameter("@FillInputTime", time),
                                                                                            new SqlParameter("@FillDoorID", PLCReadInfo.FillDoorID));
                            fillInbound_Flag = 1;
                            fillOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.FillOutput == 1 && fillOutbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updatefilloutputtime", new SqlParameter("@FilloutputTime", time),
                                                                                             new SqlParameter("@FillDoorID", PLCReadInfo.FillDoorID));
                            fillInbound_Flag = 0;
                            fillOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.FillOutput == 0 && fillOutbound_Flag == 1)
                        {
                            fillOutbound_Flag = 0;
                        }
                        //if (PLCReadInfo.PressInput == 1)
                        //{
                        //    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        //    int query = DBHelper.ExecuteNonQueryProc("updatePressInputtime", new SqlParameter("@PressInputTime", time),
                        //                                                                     new SqlParameter("@PressDoorID", PLCReadInfo.PressDoorID));

                        //}
                        //if (PLCReadInfo.PressOutput == 1)
                        //{
                        //    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        //    int query = DBHelper.ExecuteNonQueryProc("updatePressOutputtime", new SqlParameter("@PressOutputTime", time),
                        //                                                                     new SqlParameter("@Presstemperature", PLCReadInfo.Presstemperature),
                        //                                                                     new SqlParameter("@PressDoorID", PLCReadInfo.PressDoorID));

                        //}
                        //压合中断改动
                        //if()//判断压合站重新上料信号
                        //{
                        //    //根据二次输入的ID号查询，
                        //输入ID；
                        //    SqlDataReader dr = DBHelper.ExecuteReader1("searchSecondID",new SqlParameter("@SecondDoorID",SecondDoorInfo.SecondDoorID));

                        //}
                        if (PLCReadInfo.PolishInput == 1 && polishInbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updatePolishInputtime", new SqlParameter("@PolishInputTime", time),
                                                                                              new SqlParameter("@PolishDoorID", PLCReadInfo.PolishDoorID));
                            polishInbound_Flag = 1;
                            polishOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.PolishOutput == 1 && polishOutbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updatePolishOutputtime", new SqlParameter("@PolishOutputTime", time),
                                                                                              new SqlParameter("@PolishDoorID", PLCReadInfo.PolishDoorID));
                            polishInbound_Flag = 0;
                            polishOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.PolishOutput == 0 && polishOutbound_Flag == 1)
                        {
                            polishOutbound_Flag = 0;
                        }

                        if (PLCReadInfo.WeldingInput == 1 && weldingInbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateWeldingInputtime", new SqlParameter("@WeldingInputTime", time),
                                                                                               new SqlParameter("@WeldingDoorID", PLCReadInfo.WeldingDoorID));
                            weldingInbound_Flag = 1;
                            weldingOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.WeldingOutput == 1 && weldingOutbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQuery("updateWeldingOutputtime", new SqlParameter("@WeldingOutputTime", time),
                                                                                            new SqlParameter("@WeldingCurrent", PLCReadInfo.WeldingCurrent),
                                                                                            new SqlParameter("@WeldingVoltage", PLCReadInfo.WeldingVoltage),
                                                                                            new SqlParameter("@WireFeedingSpeed", PLCReadInfo.WireFeedingSpeed),
                                                                                            new SqlParameter("@WeldingTime", PLCReadInfo.WeldingTime),
                                                                                            new SqlParameter("@WeldingDoorID", PLCReadInfo.WeldingDoorID));
                            weldingInbound_Flag = 0;
                            weldingOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.WeldingOutput == 0 && weldingOutbound_Flag == 1)
                        {
                            weldingOutbound_Flag = 0;
                        }

                        if (PLCReadInfo.RemoveSmokeTrainInput == 1 && removeSmokeTrainInbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateRemoveSmokeTrainInputtime", new SqlParameter("@RemoveSmokeTrainInputTime", time),
                                                                                                        new SqlParameter("@RemoveSmokeTrainDoorID", PLCReadInfo.RemoveSmokeTrainDoorID));
                            removeSmokeTrainInbound_Flag = 1;
                            removeSmokeTrainOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.RemoveSmokeTrainOutput == 1 && removeSmokeTrainOutbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateRemoveSmokeTrainOutputtime", new SqlParameter("@RemoveSmokeTrainOutputTime", time),
                                                                                                         new SqlParameter("@RemoveSmokeTrainDoorID", PLCReadInfo.RemoveSmokeTrainDoorID));
                            removeSmokeTrainInbound_Flag = 0;
                            removeSmokeTrainOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.RemoveSmokeTrainOutput == 0 && removeSmokeTrainOutbound_Flag == 1)
                        {
                            removeSmokeTrainOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.CheckInput == 1 && checkInbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateCheckInputtime", new SqlParameter("@CheckInputTime", time),
                                                                                             new SqlParameter("@CheckDoorID", PLCReadInfo.CheckDoorID));
                            checkInbound_Flag = 1;
                            checkOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.CheckOutput == 1 && checkOutbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string checkResult = null;
                            string unqualifiedCause = null;
                            if (PLCReadInfo.CheckResult == 0)
                            {
                                checkResult = "OK";
                                unqualifiedCause = "无";
                            }
                            if (PLCReadInfo.CheckResult == 1)
                            {
                                checkResult = "NG";
                                switch (PLCReadInfo.NGReason)
                                {
                                    //NG代码判定NG原因
                                }
                            }
                            int query = DBHelper.ExecuteNonQueryProc("updateCheckOutputtime", new SqlParameter("@CheckOutputTime", time),
                                                                                              new SqlParameter("@CheckResult", checkResult),
                                                                                              new SqlParameter("@NGCause", unqualifiedCause),
                                                                                              new SqlParameter("@CheckDoorID", PLCReadInfo.CheckDoorID));
                            //string date = DateTime.Now.ToString("yyyy-MM-dd");
                            //output += 1;
                            ////判断检测结果，OK：qualified+1，NG:qualified

                            //if (output != 1)
                            //{//订单编号缺少读取
                            //    int query1 = DBHelper.ExecuteNonQueryProc("updateOutput", new SqlParameter("@DoorMold", PLCReadInfo.CheckDoorType),
                            //                                                              //new SqlParameter("@OrderNum", PLCReadInfo.),
                            //                                                              new SqlParameter("@ProductionTime", date),
                            //                                                              new SqlParameter("@Output", output),
                            //                                                              new SqlParameter("@QualifiedNumber", qualified));
                            //}
                            //else
                            //{
                            //    int query2 = DBHelper.ExecuteNonQueryProc("addProduction", new SqlParameter("@DoorMold", PLCReadInfo.CheckDoorType),
                            //                                                             //new SqlParameter("@OrderNum", PLCReadInfo.),
                            //                                                             new SqlParameter("@ProductionTime", date),
                            //                                                             new SqlParameter("@Output", output),
                            //                                                             new SqlParameter("@QualifiedNumber", qualified));
                            //}
                            //ProductNumber.TotalOutput = output;
                            //ProductNumber.QualifiedNumber = qualified;
                            //ProductNumber.UnqualifiedNumber = output - qualified;
                            checkInbound_Flag = 0;
                            checkOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.CheckOutput == 0 && checkOutbound_Flag == 1)
                        {
                            checkOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.UnloadInput == 1 && unloadInbound_Flag == 0)
                        {
                            unloadInbound_Flag = 1;
                            unloadOutbound_Flag = 0;
                        }
                        if (PLCReadInfo.UnloadOutput == 1 && unloadOutbound_Flag == 0)
                        {
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int query = DBHelper.ExecuteNonQueryProc("updateUnloadOutputtime", new SqlParameter("@UnloadOutputTime", time),
                                                                                               new SqlParameter("@UnloadDoorID", PLCReadInfo.UnloadDoorID));
                            unloadInbound_Flag = 0;
                            unloadOutbound_Flag = 1;
                        }
                        else if (PLCReadInfo.UnloadOutput == 0 && unloadOutbound_Flag == 1)
                        {

                            unloadOutbound_Flag = 0;
                        }
                    }
                    else
                    {
                        int result = Client.S7Connection("192.168.1.23");
                        int reconnect = 0;//PLC重连次数
                        while (result != 0)
                        {
                            result = Client.S7Connection("192.168.1.23");
                            reconnect++;
                            if (reconnect >= 3)
                            {
                                //Log.WriteAlarmLog("PLC连接超时");
                                //System.Windows.MessageBox.Show("PLC连接超时");
                            }
                        }
                        connectDone = true;
                        string date = DateTime.Now.ToString("yyyy-MM-dd");
                        object data = DBHelper.ExecuteScalar("searchOutput", new SqlParameter("@ProductionTime", date));
                        if (data == System.DBNull.Value)
                        {
                            output = 0;
                            qualified = 0;
                        }
                        else
                        {
                            output = Convert.ToInt32(data);
                            object data1 = DBHelper.ExecuteScalar("searchQualifiedNumber", new SqlParameter("@ProductionTime", date));
                            if (data1 == System.DBNull.Value)
                            {
                                qualified = 0;
                            }
                            else
                            {
                                qualified = Convert.ToInt32(data1);
                            }
                        }
                    }
                }
            }));
            t.IsBackground = true;
            t.Priority = ThreadPriority.AboveNormal;
            t.Start();
        }


        /// <summary>
        /// PLC标志位及数据交互读取
        /// </summary>
        private static void Read()
        {
            //上料DB28
            PLCReadInfo.LoadInput = Client.ReadDBBit(28, 0, 7);
            PLCReadInfo.LoadOutput = Client.ReadDBBit(28, 1, 0);
            PLCReadInfo.SplitDoorID = Client.ReadDBString(28, 76,15);
            PLCReadInfo.SplitDoorType = Client.ReadDBWord(28, 104);
            PLCReadInfo.LoadStep = Client.ReadDBWord(28, 50);
            //覆膜DB31
            PLCReadInfo.FilmMulchOutput = Client.ReadDBBit(31, 1, 4);
            PLCReadInfo.FilmMulchInput = Client.ReadDBBit(31, 0, 3);
            PLCReadInfo.MulchDoorID = Client.ReadDBString(31, 30,15);
            PLCReadInfo.MulchDoorType = Client.ReadDBWord(31, 48);
            PLCReadInfo.UpMembraneAllowance = Client.ReadDBWord(31, 50);
            PLCReadInfo.DownMembraneAllowance = Client.ReadDBWord(31, 52);
            PLCReadInfo.CutLength = Client.ReadDBWord(31, 54);
            PLCReadInfo.Cutwidth = Client.ReadDBWord(31, 56);
            //涂胶DB7
            PLCReadInfo.GluingInput = Client.ReadDBBit(7, 0, 6);
            PLCReadInfo.GluingOutput = Client.ReadDBBit(7, 0, 7);
            PLCReadInfo.GluingDoorID = Client.ReadDBString(7, 30,15);
            PLCReadInfo.GluingDoorType = Client.ReadDBWord(7, 48);
            PLCReadInfo.ActualDosage = Client.ReadDBWord(7, 50);
            PLCReadInfo.ResidualGlue = Client.ReadDBWord(7, 52);
            PLCReadInfo.GluingTime = Client.ReadDBWord(7, 54);
            //珍珠岩填充DB8
            PLCReadInfo.FillInput = Client.ReadDBBit(8, 0, 4);
            PLCReadInfo.FillOutput = Client.ReadDBBit(8, 0, 5);
            PLCReadInfo.FillDoorID = Client.ReadDBString(8, 30,15);
            PLCReadInfo.FillDoorType = Client.ReadDBWord(8, 66);
            PLCReadInfo.PerliteAllowance = Client.ReadDBWord(8, 70);
            PLCReadInfo.ArtificialAssembleDoorID = Client.ReadDBString(8, 48,15);
            PLCReadInfo.ArtificialAssembleDoorType = Client.ReadDBWord(8, 68);
            PLCReadInfo.FillStep = Client.ReadDBWord(8, 72);
            //压合DB11
            PLCReadInfo.PressInput = Client.ReadDBBit(11, 0, 4);
            PLCReadInfo.PressOutput = Client.ReadDBBit(11, 0, 5);
            PLCReadInfo.PressDoorID = Client.ReadDBString(11, 30,15);
            PLCReadInfo.PressDoorType = Client.ReadDBWord(11, 48);
            PLCReadInfo.Presstemperature = Client.ReadDBWord(11, 50);
            //打磨DB12
            PLCReadInfo.PolishInput = Client.ReadDBBit(12, 0, 4);
            PLCReadInfo.PolishOutput = Client.ReadDBBit(12, 0, 5);
            PLCReadInfo.PolishDoorID = Client.ReadDBString(12, 30,15);
            PLCReadInfo.PolishDoorType = Client.ReadDBWord(12, 48);
            //焊接DB13
            PLCReadInfo.WeldingInput = Client.ReadDBBit(13, 0, 4);
            PLCReadInfo.WeldingOutput = Client.ReadDBBit(13, 0, 5);
            PLCReadInfo.WeldingDoorID = Client.ReadDBString(13, 30,15);
            PLCReadInfo.WeldingDoorType = Client.ReadDBWord(13, 48);
            PLCReadInfo.WeldingCurrent = Client.ReadDBWord(13, 50);
            PLCReadInfo.WeldingVoltage = Client.ReadDBWord(13, 52);
            PLCReadInfo.WireFeedingSpeed = Client.ReadDBWord(13, 54);
            PLCReadInfo.WeldingTime = Client.ReadDBWord(13, 56);
            //除烟痕DB14
            PLCReadInfo.RemoveSmokeTrainInput = Client.ReadDBBit(14, 0, 4);
            PLCReadInfo.RemoveSmokeTrainOutput = Client.ReadDBBit(14, 0, 5);
            PLCReadInfo.RemoveSmokeTrainDoorID = Client.ReadDBString(14, 30,15);
            PLCReadInfo.RemoveSmokeTrainDoorType = Client.ReadDBWord(14, 48);
            PLCReadInfo.PaintAllowance = Client.ReadDBWord(14, 50);
            PLCReadInfo.PaintingTime = Client.ReadDBWord(14, 52);
            //检测/下料DB15
            PLCReadInfo.CheckInput = Client.ReadDBBit(15, 0, 5);
            PLCReadInfo.CheckOutput = Client.ReadDBBit(15, 0, 6);
            PLCReadInfo.UnloadInput = Client.ReadDBBit(15, 0, 7);
            PLCReadInfo.UnloadOutput = Client.ReadDBBit(15, 1, 0);
            PLCReadInfo.CheckDoorID = Client.ReadDBString(15, 58,15);
            PLCReadInfo.UnloadDoorID = Client.ReadDBString(15, 76,15);
            PLCReadInfo.CheckDoorType = Client.ReadDBWord(15, 94);//检测站门类型
            PLCReadInfo.UnloadDoorType = Client.ReadDBWord(15, 96);//下料站门类型
            PLCReadInfo.UnloadTime = Client.ReadDBWord(15, 98);
            PLCReadInfo.CheckStep = Client.ReadDBWord(15, 102);
            PLCReadInfo.UnloadStep = Client.ReadDBWord(15, 104);
            //PLCReadInfo.CheckResult = Client.ReadDBBit();//检测结果
            //PLCReadInfo.NGReason = Client.ReadDBWord();//NG原因
            //标志位
            PLCReadInfo.HeartBeat = Client.ReadDBBit(30, 0, 0);
            PLCReadInfo.LoadRequest_Flag = Client.ReadDBBit(28, 0, 4);
            PLCReadInfo.LoadFault_Flag = Client.ReadDBBit(28, 0, 2);
            PLCReadInfo.MulchingFault_Flag = Client.ReadDBBit(31, 0, 2);
            PLCReadInfo.FillFault_Flag = Client.ReadDBBit(8, 0, 2);
            PLCReadInfo.CheckFault_Flag = Client.ReadDBBit(15, 0, 2);
            PLCReadInfo.LayingOffFault_Flag = Client.ReadDBBit(15, 0, 4);
            
        }
        /// <summary>
        /// PLC报警信息读取
        /// </summary>
        private static void LoadAlarm()
        {
            PLCReadInfo.LoadABBNoHome = Client.ReadDBBit(28, 2, 0);
            PLCReadInfo.LoadReverseNoHome = Client.ReadDBBit(28, 2, 1);
            PLCReadInfo.LoadLaserNoHome = Client.ReadDBBit(28, 2, 2);
            PLCReadInfo.LoadMatterCar1NoHome = Client.ReadDBBit(28, 2, 3);
            PLCReadInfo.LoadMatterCar2NoHome = Client.ReadDBBit(28, 2, 4);
            PLCReadInfo.LoadABBNotAuto = Client.ReadDBBit(28, 2, 5);
            PLCReadInfo.LoadABBNotLoop = Client.ReadDBBit(28, 2, 6);
            PLCReadInfo.LoadGluingComAbnormal = Client.ReadDBBit(28, 2, 7);
            PLCReadInfo.LoadPerliteComAbnormal = Client.ReadDBBit(28, 3, 0);
            PLCReadInfo.LoadMainStationComAbnormal = Client.ReadDBBit(28, 3, 1);
            PLCReadInfo.LoadEStop = Client.ReadDBBit(28, 16, 0);
            PLCReadInfo.LoadABBDisconnect = Client.ReadDBBit(28, 16, 1);
            PLCReadInfo.LoadABBFault = Client.ReadDBBit(28, 16, 2);
            PLCReadInfo.LoadVF0Disconnect = Client.ReadDBBit(28, 16, 3);
            PLCReadInfo.LoadVF0Fault = Client.ReadDBBit(28, 16, 4);
            PLCReadInfo.LoadVF1Disconnect = Client.ReadDBBit(28, 16, 5);
            PLCReadInfo.LoadVF1Fault = Client.ReadDBBit(28, 16, 6);
            PLCReadInfo.LoadVF2Disconnect = Client.ReadDBBit(28, 16, 7);
            PLCReadInfo.LoadVF2Fault = Client.ReadDBBit(28, 17, 0);
            PLCReadInfo.LoadVF3Disconnect = Client.ReadDBBit(28, 17, 1);
            PLCReadInfo.LoadVF3Fault = Client.ReadDBBit(28, 17, 2);
            PLCReadInfo.LoadVF4Disconnect = Client.ReadDBBit(28, 17, 3);
            PLCReadInfo.LoadVF4Fault = Client.ReadDBBit(28, 17, 4);
            PLCReadInfo.LoadVF5Disconnect = Client.ReadDBBit(28, 17, 5);
            PLCReadInfo.LoadVF5Fault = Client.ReadDBBit(28, 17, 6);
            PLCReadInfo.LoadABBVacuumError = Client.ReadDBBit(28, 18, 6);
            PLCReadInfo.LoadABBBreakVacuumError = Client.ReadDBBit(28, 18, 7);
            PLCReadInfo.LoadOverturnReturnError = Client.ReadDBBit(28, 19, 0);
            PLCReadInfo.LoadOverturnReachError = Client.ReadDBBit(28, 19, 1);
            PLCReadInfo.LoadUnableAutoStart = Client.ReadDBBit(28, 19, 2);
            PLCReadInfo.LoadUnableContinue = Client.ReadDBBit(28, 19, 3);
            PLCReadInfo.LoadVF0ToVF1Error = Client.ReadDBBit(28, 19, 4);
            PLCReadInfo.LoadVF1ToVF2Error = Client.ReadDBBit(28, 19, 5);
            PLCReadInfo.LoadVF3ToVF4Error = Client.ReadDBBit(28, 19, 6);
            PLCReadInfo.LoadVF4ToVF5Error = Client.ReadDBBit(28, 19, 7);
            PLCReadInfo.LoadVF5ToGluingError = Client.ReadDBBit(28, 20, 0);
            PLCReadInfo.LoadGluingToVF6Error = Client.ReadDBBit(28, 20, 1);
            PLCReadInfo.Load1LaserBeyondRange = Client.ReadDBBit(28, 20, 4);
            PLCReadInfo.Load2LaserBeyondRange = Client.ReadDBBit(28, 20, 5);
            PLCReadInfo.Load3LaserBeyondRange = Client.ReadDBBit(28, 20, 6);
            PLCReadInfo.LoadNoThicknessData = Client.ReadDBBit(28, 20, 7);
        }
        private static void FilmMulchAlarm()
        {
            PLCReadInfo.FrontRollerError = Client.ReadDBBit(31, 16, 0);
            PLCReadInfo.UpperAdsorptionError = Client.ReadDBBit(31, 16, 1);
            PLCReadInfo.DownAdsorptionError = Client.ReadDBBit(31, 16, 2);
            PLCReadInfo.UpperCutError = Client.ReadDBBit(31, 16, 3);
            PLCReadInfo.DownCutError = Client.ReadDBBit(31, 16, 4);
            PLCReadInfo.CrossCutError = Client.ReadDBBit(31, 16, 5);
            PLCReadInfo.UpperAdsorptionVacuumError = Client.ReadDBBit(31, 16, 6);
            PLCReadInfo.DownAdsorptionVacuumError = Client.ReadDBBit(31, 16, 7);
            PLCReadInfo.EstopError = Client.ReadDBBit(31, 17, 0);
            PLCReadInfo.UpperFrontLack = Client.ReadDBBit(31, 17, 1);
            PLCReadInfo.UpperBehindLack = Client.ReadDBBit(31, 17, 2);
            PLCReadInfo.DownFrontLack = Client.ReadDBBit(31, 17, 3);
            PLCReadInfo.DownBehindLack = Client.ReadDBBit(31, 17, 4);
            PLCReadInfo.LowAirPressureAlarm = Client.ReadDBBit(31, 17, 5);
            PLCReadInfo.FrontRollerVFDError = Client.ReadDBBit(31, 17, 6);
            PLCReadInfo.BehindRollerVFDError = Client.ReadDBBit(31, 17, 7);
            PLCReadInfo.FrontPowerVFDError = Client.ReadDBBit(31, 18, 0);
            PLCReadInfo.BehindPowerVFDError = Client.ReadDBBit(31, 18, 1);
            PLCReadInfo.UpperCutVFDError = Client.ReadDBBit(31, 18, 2);
            PLCReadInfo.DownCutVFDError = Client.ReadDBBit(31, 18, 3);
            PLCReadInfo.CrossCutVFDError = Client.ReadDBBit(31, 18, 4);
            PLCReadInfo.ServoNoHome = Client.ReadDBBit(31, 18, 5);
            PLCReadInfo.UpperCutForwardLimit = Client.ReadDBBit(31, 18, 6);
            PLCReadInfo.UpperCutReverseLimit = Client.ReadDBBit(31, 18, 7);
            PLCReadInfo.DownCutForwardLimit = Client.ReadDBBit(31, 19, 0);
            PLCReadInfo.DownCutReverseLimit = Client.ReadDBBit(31, 19, 1);
            PLCReadInfo.CrossCutForwardLimit = Client.ReadDBBit(31, 19, 2);
            PLCReadInfo.CrossCutReverseLimit = Client.ReadDBBit(31, 19, 3);
            PLCReadInfo.DoorDataTransferIncomplete = Client.ReadDBBit(31, 19, 4);
            PLCReadInfo.FrontRollerVFDNoCom = Client.ReadDBBit(31, 19, 5);
            PLCReadInfo.BehindRollerVFDNoCom = Client.ReadDBBit(31, 19, 6);
            PLCReadInfo.MainStationNoCom = Client.ReadDBBit(31, 19, 7);
            PLCReadInfo.LoadStationNoCom = Client.ReadDBBit(31, 20, 0);
            PLCReadInfo.FrontPowerServoNoCom = Client.ReadDBBit(31, 20, 1);
            PLCReadInfo.BehindPowerServoNoCom = Client.ReadDBBit(31, 20, 2);
            PLCReadInfo.UpperCutServoNoCom = Client.ReadDBBit(31, 20, 3);
            PLCReadInfo.DownCutServoNoCom = Client.ReadDBBit(31, 20, 4);
            PLCReadInfo.CrossCutServoNoCom = Client.ReadDBBit(31, 20, 5);
        }
        private static void FillAlarm()
        {
            PLCReadInfo.FillClamp1LocationError = Client.ReadDBBit(8, 2, 0);
            PLCReadInfo.FillClamp2LocationError = Client.ReadDBBit(8, 2, 1);
            PLCReadInfo.FillObstructLocationError = Client.ReadDBBit(8, 2, 2);
            PLCReadInfo.FillJackLocationError = Client.ReadDBBit(8, 2, 3);
            PLCReadInfo.FillIncomplete = Client.ReadDBBit(8, 2, 4);
            PLCReadInfo.FillABBNoHome = Client.ReadDBBit(8, 2, 5);
            PLCReadInfo.FillPerliteCar1LocationError = Client.ReadDBBit(8, 2, 6);
            PLCReadInfo.FillPerliteCar2LocationError = Client.ReadDBBit(8, 2, 7);
            PLCReadInfo.FillPerliteSecondLocationFull = Client.ReadDBBit(8, 3, 0);
            PLCReadInfo.FillLongSideLocationError = Client.ReadDBBit(8, 3, 1);
            PLCReadInfo.FillShortSideLocationError = Client.ReadDBBit(8, 3, 2);
            PLCReadInfo.Fill90DegreesNoHome = Client.ReadDBBit(8, 3, 3);
            PLCReadInfo.Fill90DegreesFull = Client.ReadDBBit(8, 3, 4);
            PLCReadInfo.Fill90DegreesJackUpLocationError = Client.ReadDBBit(8, 3, 5);
            PLCReadInfo.Fill90DegreesClampLocationError = Client.ReadDBBit(8, 3, 6);
            PLCReadInfo.FillABBNotAuto = Client.ReadDBBit(8, 3, 7);
            PLCReadInfo.FillABBNotLoopRun = Client.ReadDBBit(8, 4, 0);
            PLCReadInfo.FillNoComWithLoad = Client.ReadDBBit(8, 4, 1);
            PLCReadInfo.FillNoComWithLamination = Client.ReadDBBit(8, 4, 2);
            PLCReadInfo.FillNoComWithMain = Client.ReadDBBit(8, 4, 3);
            PLCReadInfo.FillNoPerlite = Client.ReadDBBit(8, 4, 4);
            PLCReadInfo.FillEstop = Client.ReadDBBit(8, 16, 0);
            PLCReadInfo.FillABBOffLine = Client.ReadDBBit(8, 16, 1);
            PLCReadInfo.FillABBError = Client.ReadDBBit(8, 16, 2);
            PLCReadInfo.FillVF1OffLine = Client.ReadDBBit(8, 16, 3);
            PLCReadInfo.FillVF1Error = Client.ReadDBBit(8, 16, 4);
            PLCReadInfo.FillVF2OffLine = Client.ReadDBBit(8, 16, 5);
            PLCReadInfo.FillVF2Error = Client.ReadDBBit(8, 16, 6);
            PLCReadInfo.FillVF3OffLine = Client.ReadDBBit(8, 16, 7);
            PLCReadInfo.FillVF3Error = Client.ReadDBBit(8, 17, 0);
            PLCReadInfo.FillVF4OffLine = Client.ReadDBBit(8, 17, 1);
            PLCReadInfo.FillVF4Error = Client.ReadDBBit(8, 17, 2);
            PLCReadInfo.FillVF5OffLine = Client.ReadDBBit(8, 17, 3);
            PLCReadInfo.FillVF5Error = Client.ReadDBBit(8, 17, 4);
            PLCReadInfo.FillVF6OffLine = Client.ReadDBBit(8, 17, 5);
            PLCReadInfo.FillVF6Error = Client.ReadDBBit(8, 17, 6);
            PLCReadInfo.FillVF7OffLine = Client.ReadDBBit(8, 17, 7);
            PLCReadInfo.FillVF7Error = Client.ReadDBBit(8, 18, 0);
            PLCReadInfo.FillVF8OffLine = Client.ReadDBBit(8, 18, 1);
            PLCReadInfo.FillVF8Error = Client.ReadDBBit(8, 18, 2);
            PLCReadInfo.FillJackUpLimitError = Client.ReadDBBit(8, 18, 3);
            PLCReadInfo.FillJackDownLimitError = Client.ReadDBBit(8, 18, 4);
            PLCReadInfo.FillObstructLimitError = Client.ReadDBBit(8, 18, 5);
            PLCReadInfo.FillPullBackLimitError = Client.ReadDBBit(8, 18, 6);
            PLCReadInfo.FillClamp1TightLimitError = Client.ReadDBBit(8, 18, 7);
            PLCReadInfo.FillClamp2TightLimitError = Client.ReadDBBit(8, 19, 0);
            PLCReadInfo.FillClamp1PineLimitError = Client.ReadDBBit(8, 19, 1);
            PLCReadInfo.FillClamp2PineLimitError = Client.ReadDBBit(8, 19, 2);
            PLCReadInfo.FillPullBackReturnError = Client.ReadDBBit(8, 19, 3);
            PLCReadInfo.FillObstructReturnError = Client.ReadDBBit(8, 19, 4);
            PLCReadInfo.FillPerliteVacuumErrorv = Client.ReadDBBit(8, 19, 5);
            PLCReadInfo.FillRobotNotFoundPerlite = Client.ReadDBBit(8, 19, 6);
            PLCReadInfo.FillPerliteBreakVacuumError = Client.ReadDBBit(8, 19, 7);
            PLCReadInfo.FillPerliteShortSideRiseError = Client.ReadDBBit(8, 20, 0);
            PLCReadInfo.FillPerliteLongSideRiseError = Client.ReadDBBit(8, 20, 1);
            PLCReadInfo.Fill90DegreesVacuumError = Client.ReadDBBit(8, 20, 2);
            PLCReadInfo.Fill90DegreesJackRiseError = Client.ReadDBBit(8, 20, 3);
            PLCReadInfo.Fill90DegreesClamp1Error = Client.ReadDBBit(8, 20, 4);
            PLCReadInfo.Fill90DegreesClamp2Error = Client.ReadDBBit(8, 20, 5);
            PLCReadInfo.Fill90DegreesJackReturnError = Client.ReadDBBit(8, 20, 6);
            PLCReadInfo.Fill90DegreesJackMotorRiseError = Client.ReadDBBit(8, 20, 7);
            PLCReadInfo.Fill90DegreesJackMotorNoUpLimit = Client.ReadDBBit(8, 21, 0);
            PLCReadInfo.Fill90DegreesRotateMotorForwardError = Client.ReadDBBit(8, 21, 1);
            PLCReadInfo.Fill90DegreesRotateMotorForwardLocationError = Client.ReadDBBit(8, 21, 2);
            PLCReadInfo.Fill90DegreesJackMotorReturnError = Client.ReadDBBit(8, 21, 3);
            PLCReadInfo.Fill90DegreesRotateMotorReverseError = Client.ReadDBBit(8, 21, 4);
            PLCReadInfo.FillVF1ToVF2Error = Client.ReadDBBit(8, 21, 5);
            PLCReadInfo.FillVF2ToVF3Error = Client.ReadDBBit(8, 21, 6);
            PLCReadInfo.FillVF3ToVF4Error = Client.ReadDBBit(8, 21, 7);
            PLCReadInfo.FillVF4ToVF5Error = Client.ReadDBBit(8, 22, 0);
            PLCReadInfo.FillVF5ToVF6Error = Client.ReadDBBit(8, 22, 1);
            PLCReadInfo.FillRobotImpact = Client.ReadDBBit(8, 22, 2);
        }
        private static void CheckAlarm()
        {
            PLCReadInfo.CheckJackLocationError = Client.ReadDBBit(15, 2, 0);
            PLCReadInfo.CheckSidePushBigLocationError = Client.ReadDBBit(15, 2, 1);
            PLCReadInfo.CheckSidePushSmallLocationError = Client.ReadDBBit(15, 2, 2);
            PLCReadInfo.CheckPullBackLocationError = Client.ReadDBBit(15, 2, 3);
            PLCReadInfo.CheckXNoStandby = Client.ReadDBBit(15, 2, 4);
            PLCReadInfo.CheckYNoStandby = Client.ReadDBBit(15, 2, 5);
            PLCReadInfo.CheckRotaryNoStandby = Client.ReadDBBit(15, 2, 6);
            PLCReadInfo.CheckNoComToRemoveSmoke = Client.ReadDBBit(15, 2, 7);
            PLCReadInfo.CheckNoComToMain = Client.ReadDBBit(15, 3, 0);
            PLCReadInfo.CheckEstop = Client.ReadDBBit(15, 16, 0);
            PLCReadInfo.CheckXServoError = Client.ReadDBBit(15, 16, 1);
            PLCReadInfo.CheckXServoOffLine = Client.ReadDBBit(15, 16, 2);
            PLCReadInfo.CheckYServoError = Client.ReadDBBit(15, 16, 3);
            PLCReadInfo.CheckYServoOffLine = Client.ReadDBBit(15, 16, 4);
            PLCReadInfo.CheckRotaryServoError = Client.ReadDBBit(15, 16, 5);
            PLCReadInfo.CheckRotaryServoOffLine = Client.ReadDBBit(15, 16, 6);
            PLCReadInfo.CheckUpstreamDeliveryOvertime = Client.ReadDBBit(15, 16, 7);
            PLCReadInfo.CheckFeedOvertime = Client.ReadDBBit(15, 17, 0);
            PLCReadInfo.CheckJackReachError = Client.ReadDBBit(15, 17, 1);
            PLCReadInfo.CheckPullBackReachError = Client.ReadDBBit(15, 17, 2);
            PLCReadInfo.CheckSidePushBigReachError = Client.ReadDBBit(15, 17, 3);
            PLCReadInfo.CheckSidePushSmallReachError = Client.ReadDBBit(15, 17, 4);
            PLCReadInfo.CheckXYZReturnStandbyError = Client.ReadDBBit(15, 17, 5);
            PLCReadInfo.CheckSidePushSmallReturnError = Client.ReadDBBit(15, 17, 6);
            PLCReadInfo.CheckSidePushBigReturnError = Client.ReadDBBit(15, 17, 7);
            PLCReadInfo.CheckPullBackReturnError = Client.ReadDBBit(15, 18, 0);
            PLCReadInfo.CheckJackReturnError = Client.ReadDBBit(15, 18, 1);
            PLCReadInfo.CheckDownstreamDeliveryOvertime = Client.ReadDBBit(15, 18, 2);
            PLCReadInfo.CheckDischargeOvertime = Client.ReadDBBit(15, 18, 3);
            PLCReadInfo.CheckManualNoAuto = Client.ReadDBBit(15, 18, 4);
            PLCReadInfo.CheckManualNoContinue = Client.ReadDBBit(15, 18, 5);
            PLCReadInfo.CheckVFDNoCom = Client.ReadDBBit(15, 18, 6);
            PLCReadInfo.CheckVFDError = Client.ReadDBBit(15, 18, 7);
        }
        private static void UnloadALarm()
        {
            PLCReadInfo.UnloadJackLocationError = Client.ReadDBBit(15, 30, 0);
            PLCReadInfo.UnloadClamp1LocationError = Client.ReadDBBit(15, 30, 1);
            PLCReadInfo.UnloadClamp2LocationError = Client.ReadDBBit(15, 30, 2);
            PLCReadInfo.UnloadPullBackLocationError = Client.ReadDBBit(15, 30, 3);
            PLCReadInfo.UnloadServo1NoStandby = Client.ReadDBBit(15, 30, 4);
            PLCReadInfo.UnloadServo2NoStandby = Client.ReadDBBit(15, 30, 5);
            PLCReadInfo.UnloadSkipCar1LocationError = Client.ReadDBBit(15, 30, 6);
            PLCReadInfo.UnloadSkipCar2LocationError = Client.ReadDBBit(15, 30, 7);
            PLCReadInfo.UnloadABBNoAuto = Client.ReadDBBit(15, 31, 0);
            PLCReadInfo.UnloadABBNoloop = Client.ReadDBBit(15, 31, 1);
            PLCReadInfo.UnloadABBNoHome = Client.ReadDBBit(15, 31, 2);
            PLCReadInfo.UnloadNGCarFull = Client.ReadDBBit(15, 31, 3);
            PLCReadInfo.UnloadOKCarFull = Client.ReadDBBit(15, 31, 4);
            PLCReadInfo.UnloadEstop = Client.ReadDBBit(15, 44, 0);
            PLCReadInfo.UnloadABBOffLine = Client.ReadDBBit(15, 44, 1);
            PLCReadInfo.UnloadABBError = Client.ReadDBBit(15, 44, 2);
            PLCReadInfo.UnloadServo1OffLine = Client.ReadDBBit(15, 44, 3);
            PLCReadInfo.UnloadServo1Error = Client.ReadDBBit(15, 44, 4);
            PLCReadInfo.UnloadServo2OffLine = Client.ReadDBBit(15, 44, 5);
            PLCReadInfo.UnloadServo2Error = Client.ReadDBBit(15, 44, 6);
            PLCReadInfo.UnloadUpstreamDeliveryOvertime = Client.ReadDBBit(15, 44, 7);
            PLCReadInfo.UnloadFeedOvertime = Client.ReadDBBit(15, 45, 0);
            PLCReadInfo.UnloadJackReachError = Client.ReadDBBit(15, 45, 1);
            PLCReadInfo.UnloadPullBackReachError = Client.ReadDBBit(15, 45, 2);
            PLCReadInfo.UnloadClampTightLimit = Client.ReadDBBit(15, 45, 3);
            PLCReadInfo.UnloadClampReleaseLimit = Client.ReadDBBit(15, 45, 4);
            PLCReadInfo.UnloadPullBackReturnError = Client.ReadDBBit(15, 45, 5);
            PLCReadInfo.UnloadManualNoAuto = Client.ReadDBBit(15, 45, 6);
            PLCReadInfo.UnloadManualNoContinue = Client.ReadDBBit(15, 45, 7);
            PLCReadInfo.UnloadVFDNoCom = Client.ReadDBBit(15, 46, 0);
            PLCReadInfo.UnloadVFDError = Client.ReadDBBit(15, 46, 1);
        }

        /// <summary>
        /// 插入报警
        /// </summary>
        private void InsertLoadAlarm()
        {
            //DateTime dateTime = DateTime.Now;
            //string tradeTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            if (PLCReadInfo.LoadABBNoHome == 1)
            {
                InsertAlarm("上料站提示:ABB 不在Home点");
            }
            if (PLCReadInfo.LoadReverseNoHome == 1)
            {
                InsertAlarm("上料站提示:反转气缸没有到位");
            }
            if (PLCReadInfo.LoadLaserNoHome == 1)
            {
                InsertAlarm("上料站提示:激光测距气缸没到位");
            }
            if (PLCReadInfo.LoadMatterCar1NoHome == 1)
            {
                InsertAlarm("上料站提示:料车1没到位");
            }
            if (PLCReadInfo.LoadMatterCar2NoHome == 1)
            {
                InsertAlarm("上料站提示:料车2没到位");
            }
            if (PLCReadInfo.LoadABBNotAuto == 1)
            {
                InsertAlarm("上料站提示:ABB没有在自动状态");
            }
            if (PLCReadInfo.LoadABBNotLoop == 1)
            {
                InsertAlarm("上料站提示:ABB没有循环运行");
            }
            if (PLCReadInfo.LoadGluingComAbnormal == 1)
            {
                InsertAlarm("上料站提示:与涂胶站通信异常");
            }
            if (PLCReadInfo.LoadPerliteComAbnormal == 1)
            {
                InsertAlarm("上料站提示:与珍珠岩站通信异常");
            }
            if (PLCReadInfo.LoadMainStationComAbnormal == 1)
            {
                InsertAlarm("上料站提示:与主站通信异常");
            }
            if (PLCReadInfo.LoadEStop == 1)
            {
                InsertAlarm("上料站故障:急停按钮被按下");
            }
            if (PLCReadInfo.LoadABBDisconnect == 1)
            {
                InsertAlarm("上料站故障:ABB通信掉线");
            }
            if (PLCReadInfo.LoadABBFault == 1)
            {
                InsertAlarm("上料站故障:ABB故障");
            }
            if (PLCReadInfo.LoadVF0Disconnect == 1)
            {
                InsertAlarm("上料站故障:VF0通信掉线");
            }
            if (PLCReadInfo.LoadVF0Fault == 1)
            {
                InsertAlarm("上料站故障:VF0报错");
            }
            if (PLCReadInfo.LoadVF1Disconnect == 1)
            {
                InsertAlarm("上料站故障:VF1通信掉线");
            }
            if (PLCReadInfo.LoadVF1Fault == 1)
            {
                InsertAlarm("上料站故障:VF1报错");
            }
            if (PLCReadInfo.LoadVF2Disconnect == 1)
            {
                InsertAlarm("上料站故障:VF2通信掉线");
            }
            if (PLCReadInfo.LoadVF2Fault == 1)
            {
                InsertAlarm("上料站故障:VF2报错");
            }
            if (PLCReadInfo.LoadVF3Disconnect == 1)
            {
                InsertAlarm("上料站故障:VF3通信掉线");
            }
            if (PLCReadInfo.LoadVF3Fault == 1)
            {
                InsertAlarm("上料站故障:VF3报错");
            }
            if (PLCReadInfo.LoadVF4Disconnect == 1)
            {
                InsertAlarm("上料站故障:VF4通信掉线");
            }
            if (PLCReadInfo.LoadVF4Fault == 1)
            {
                InsertAlarm("上料站故障:VF4报错");
            }
            if (PLCReadInfo.LoadVF5Disconnect == 1)
            {
                InsertAlarm("上料站故障:VF5通信掉线");
            }
            if (PLCReadInfo.LoadVF5Fault == 1)
            {
                InsertAlarm("上料站故障:VF5报错");
            }
            if (PLCReadInfo.LoadABBVacuumError == 1)
            {
                InsertAlarm("上料站故障:ABB吸真空异常");
            }
            if (PLCReadInfo.LoadABBBreakVacuumError == 1)
            {
                InsertAlarm("上料站故障:ABB破真空压力异常");
            }
            if (PLCReadInfo.LoadOverturnReturnError == 1)
            {
                InsertAlarm("上料站故障:翻转气缸退回异常");
            }
            if (PLCReadInfo.LoadOverturnReachError == 1)
            {
                InsertAlarm("上料站故障:翻转气缸伸出限位异常");
            }
            if (PLCReadInfo.LoadUnableAutoStart == 1)
            {
                InsertAlarm("上料站故障:手动按钮未回位,不能自动启动");
            }
            if (PLCReadInfo.LoadUnableContinue == 1)
            {
                InsertAlarm("上料站故障:手动按钮未回位,不能继续运行");
            }
            if (PLCReadInfo.LoadVF0ToVF1Error == 1)
            {
                InsertAlarm("上料站故障:VF0与VF1物料传输异常");
            }
            if (PLCReadInfo.LoadVF1ToVF2Error == 1)
            {
                InsertAlarm("上料站故障:VF1与VF2物料传输异常");
            }
            if (PLCReadInfo.LoadVF3ToVF4Error == 1)
            {
                InsertAlarm("上料站故障:VF3与VF4物料传输异常");
            }
            if (PLCReadInfo.LoadVF4ToVF5Error == 1)
            {
                InsertAlarm("上料站故障:VF4与VF5物料传输异常");
            }
            if (PLCReadInfo.LoadVF5ToGluingError == 1)
            {
                InsertAlarm("上料站故障:VF5与涂胶站物料传输异常");
            }
            if (PLCReadInfo.LoadGluingToVF6Error == 1)
            {
                InsertAlarm("上料站故障:涂胶站与VF6物料传输异常");
            }
            if (PLCReadInfo.Load1LaserBeyondRange == 1)
            {
                InsertAlarm("上料站故障:1#激光数值超出量程");
            }
            if (PLCReadInfo.Load2LaserBeyondRange == 1)
            {
                InsertAlarm("上料站故障:2#激光数值超出量程");
            }
            if (PLCReadInfo.Load3LaserBeyondRange == 1)
            {
                InsertAlarm("上料站故障:3#激光数值超出量程");
            }
            if (PLCReadInfo.LoadNoThicknessData == 1)
            {
                InsertAlarm("上料站故障:防火门没有门厚数据");
            }
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}
            //if (PLCReadInfo.== 1)
            //{
            //    NewMethod("", "',1)");
            //}

        }
        private void InsertFilmMulchAlarm()
        {
            if(PLCReadInfo.FrontRollerError==1)
            {
                InsertAlarm("覆膜站故障：前端辊筒顶升异常");
            }
            if(PLCReadInfo.UpperAdsorptionError==1)
            {
                InsertAlarm("覆膜站故障：上吸附板异常");
            }
            if(PLCReadInfo.DownAdsorptionError==1)
            {
                InsertAlarm("覆膜站故障：下吸附板异常");
            }
            if(PLCReadInfo.UpperCutError==1)
            {
                InsertAlarm("覆膜站故障：上纵切气缸异常");
            }
            if(PLCReadInfo.DownCutError==1)
            {
                InsertAlarm("覆膜站故障：下纵切气缸异常");
            }
            if(PLCReadInfo.CrossCutError==1)
            {
                InsertAlarm("覆膜站故障：横切气缸异常");
            }
            if(PLCReadInfo.UpperAdsorptionVacuumError==1)
            {
                InsertAlarm("覆膜站故障：上吸附真空异常");
            }
            if(PLCReadInfo.DownAdsorptionVacuumError==1)
            {
                InsertAlarm("覆膜站故障：下吸附真空异常");
            }
            if(PLCReadInfo.EstopError==1)
            {
                InsertAlarm("覆膜站故障：急停报警");
            }
            if(PLCReadInfo.UpperFrontLack==1)
            {
                InsertAlarm("覆膜站故障：上前膜缺料报警");
            }
            if(PLCReadInfo.UpperBehindLack==1)
            {
                InsertAlarm("覆膜站故障：上后膜缺料报警");
            }
            if(PLCReadInfo.DownFrontLack==1)
            {
                InsertAlarm("覆膜站故障：下前膜缺料报警");
            }
            if(PLCReadInfo.DownBehindLack==1)
            {
                InsertAlarm("覆膜站故障：下后膜缺料报警");
            }
            if(PLCReadInfo.LowAirPressureAlarm==1)
            {
                InsertAlarm("覆膜站故障：气压低报警");
            }
            if(PLCReadInfo.FrontRollerVFDError==1)
            {
                InsertAlarm("覆膜站故障：前压辊变频器故障");
            }
            if(PLCReadInfo.BehindRollerVFDError==1)
            {
                InsertAlarm("覆膜站故障：后压辊变频器故障");
            }
            if(PLCReadInfo.FrontPowerVFDError==1)
            {
                InsertAlarm("覆膜站故障：前动力辊伺服故障");
            }
            if(PLCReadInfo.BehindPowerVFDError==1)
            {
                InsertAlarm("覆膜站故障：后动力辊伺服故障");
            }
            if(PLCReadInfo.UpperCutVFDError==1)
            {
                InsertAlarm("覆膜站故障：上纵切伺服故障");
            }
            if(PLCReadInfo.DownCutVFDError==1)
            {
                InsertAlarm("覆膜站故障：下纵切伺服故障");
            }
            if(PLCReadInfo.CrossCutVFDError==1)
            {
                InsertAlarm("覆膜站故障：横切伺服故障");
            }
            if(PLCReadInfo.ServoNoHome==1)
            {
                InsertAlarm("覆膜站故障：伺服没回Home点报警");
            }
            if(PLCReadInfo.UpperCutForwardLimit==1)
            {
                InsertAlarm("覆膜站故障：上纵切伺服正极限报警");
            }
            if(PLCReadInfo.UpperCutReverseLimit==1)
            {
                InsertAlarm("覆膜站故障：上纵切伺服反极限报警");
            }
            if(PLCReadInfo.DownCutForwardLimit==1)
            {
                InsertAlarm("覆膜站故障：下纵切伺服正极限报警");
            }
            if(PLCReadInfo.DownCutReverseLimit==1)
            {
                InsertAlarm("覆膜站故障：下纵切伺服反极限报警");
            }
            if(PLCReadInfo.CrossCutForwardLimit==1)
            {
                InsertAlarm("覆膜站故障：横切伺服正极限报警");
            }
            if(PLCReadInfo.CrossCutReverseLimit==1)
            {
                InsertAlarm("覆膜站故障：横切伺服反极限报警");
            }
            if(PLCReadInfo.DoorDataTransferIncomplete==1)
            {
                InsertAlarm("覆膜站故障：门数据传递没有完成");
            }
            if(PLCReadInfo.FrontRollerVFDNoCom==1)
            {
                InsertAlarm("覆膜站故障：前压辊变频器掉线");
            }
            if(PLCReadInfo.BehindRollerVFDNoCom==1)
            {
                InsertAlarm("覆膜站故障：后压辊变频器掉线");
            }
            if(PLCReadInfo.MainStationNoCom==1)
            {
                InsertAlarm("覆膜站故障：与主站通讯故障");
            }
            if(PLCReadInfo.LoadStationNoCom==1)
            {
                InsertAlarm("覆膜站故障：与上料站通讯故障");
            }
            if(PLCReadInfo.FrontPowerServoNoCom==1)
            {
                InsertAlarm("覆膜站故障：前动力辊伺服掉线");
            }
            if(PLCReadInfo.BehindPowerServoNoCom==1)
            {
                InsertAlarm("覆膜站故障：后动力辊伺服掉线");
            }
            if(PLCReadInfo.UpperCutServoNoCom==1)
            {
                InsertAlarm("覆膜站故障：上纵切伺服掉线");
            }
            if(PLCReadInfo.DownCutServoNoCom==1)
            {
                InsertAlarm("覆膜站故障：下纵切伺服掉线");
            }
            if(PLCReadInfo.CrossCutServoNoCom==1)
            {
                InsertAlarm("覆膜站故障：横切伺服掉线");
            }
        }
        private void InsertFillAlarm()
        {
            if (PLCReadInfo.FillClamp1LocationError == 1)
            {
                InsertAlarm("填充站提示:填充夹紧1气缸未到位");
            }
            if (PLCReadInfo.FillClamp2LocationError == 1)
            {
                InsertAlarm("填充站提示:填充夹紧2气缸未到位");
            }
            if (PLCReadInfo.FillObstructLocationError == 1)
            {
                InsertAlarm("填充站提示:填充阻挡气缸未到位");
            }
            if (PLCReadInfo.FillJackLocationError == 1)
            {
                InsertAlarm("填充站提示:填充顶升气缸未到位");
            }
            if (PLCReadInfo.FillIncomplete == 1)
            {
                InsertAlarm("填充站提示:填充工位有料,未完成");
            }
            if (PLCReadInfo.FillABBNoHome == 1)
            {
                InsertAlarm("填充站提示:填充ABB机器人未回原点");
            }
            if (PLCReadInfo.FillPerliteCar1LocationError == 1)
            {
                InsertAlarm("填充站提示:珍珠岩料车1未到位");
            }
            if (PLCReadInfo.FillPerliteCar2LocationError == 1)
            {
                InsertAlarm("填充站提示:珍珠岩料车2未到位");
            }
            if (PLCReadInfo.FillPerliteSecondLocationFull == 1)
            {
                InsertAlarm("填充站提示:珍珠岩二次定位有料");
            }
            if (PLCReadInfo.FillLongSideLocationError == 1)
            {
                InsertAlarm("填充站提示:填充长边对中气缸未到位");
            }
            if (PLCReadInfo.FillShortSideLocationError == 1)
            {
                InsertAlarm("填充站提示:填充短边对中气缸未到位");
            }
            if (PLCReadInfo.Fill90DegreesNoHome == 1)
            {
                InsertAlarm("填充站提示:90度旋转/顶升电机不在初始状态");
            }
            if (PLCReadInfo.Fill90DegreesFull == 1)
            {
                InsertAlarm("填充站提示:90度工位有料");
            }
            if (PLCReadInfo.Fill90DegreesJackUpLocationError == 1)
            {
                InsertAlarm("填充站提示:90度顶升气缸未回到位");
            }
            if (PLCReadInfo.Fill90DegreesClampLocationError == 1)
            {
                InsertAlarm("填充站提示:90度夹紧气缸未回到位");
            }
            if (PLCReadInfo.FillABBNotAuto == 1)
            {
                InsertAlarm("填充站提示:ABB机器人不在自动");
            }
            if (PLCReadInfo.FillABBNotLoopRun == 1)
            {
                InsertAlarm("填充站提示:ABB机器人没有循环运行");
            }
            if (PLCReadInfo.FillNoComWithLoad == 1)
            {
                InsertAlarm("填充站提示:与上料站通信异常");
            }
            if (PLCReadInfo.FillNoComWithLamination == 1)
            {
                InsertAlarm("填充站提示:与压合站通信异常");
            }
            if (PLCReadInfo.FillNoComWithMain == 1)
            {
                InsertAlarm("填充站提示:与主站通信异常");
            }
            if (PLCReadInfo.FillNoPerlite == 1)
            {
                InsertAlarm("填充站提示:珍珠岩已抓完/请放物料");
            }
            if (PLCReadInfo.FillEstop == 1)
            {
                InsertAlarm("填充站:急停异常");
            }
            if (PLCReadInfo.FillABBOffLine == 1)
            {
                InsertAlarm("填充站:ABB通信掉线");
            }
            if (PLCReadInfo.FillABBError == 1)
            {
                InsertAlarm("填充站:ABB机器人报错");
            }
            if (PLCReadInfo.FillVF1OffLine == 1)
            {
                InsertAlarm("填充站:VF1通信掉线");
            }
            if (PLCReadInfo.FillVF1Error == 1)
            {
                InsertAlarm("填充站:VF1报错");
            }
            if (PLCReadInfo.FillVF2OffLine == 1)
            {
                InsertAlarm("填充站:VF2通信掉线");
            }
            if (PLCReadInfo.FillVF2Error == 1)
            {
                InsertAlarm("填充站:VF2报错");
            }
            if (PLCReadInfo.FillVF3OffLine == 1)
            {
                InsertAlarm("填充站:VF3通信掉线");
            }
            if (PLCReadInfo.FillVF3Error == 1)
            {
                InsertAlarm("填充站:VF3报错");
            }
            if (PLCReadInfo.FillVF4OffLine == 1)
            {
                InsertAlarm("填充站:VF4通信掉线");
            }
            if (PLCReadInfo.FillVF4Error == 1)
            {
                InsertAlarm("填充站:VF4报错");
            }
            if (PLCReadInfo.FillVF5OffLine == 1)
            {
                InsertAlarm("填充站:VF5通信掉线");
            }
            if (PLCReadInfo.FillVF5Error == 1)
            {
                InsertAlarm("填充站:VF5报错");
            }
            if (PLCReadInfo.FillVF6OffLine == 1)
            {
                InsertAlarm("填充站:VF6通信掉线");
            }
            if (PLCReadInfo.FillVF6Error == 1)
            {
                InsertAlarm("填充站:VF6报错");
            }
            if (PLCReadInfo.FillVF7OffLine == 1)
            {
                InsertAlarm("填充站:VF7通信掉线");
            }
            if (PLCReadInfo.FillVF7Error == 1)
            {
                InsertAlarm("填充站:VF7报错");
            }
            if (PLCReadInfo.FillVF8OffLine == 1)
            {
                InsertAlarm("填充站:VF8通信掉线");
            }
            if (PLCReadInfo.FillVF8Error == 1)
            {
                InsertAlarm("填充站:VF8报错");
            }
            if (PLCReadInfo.FillJackUpLimitError == 1)
            {
                InsertAlarm("填充站:顶升气缸顶升限位异常");
            }
            if (PLCReadInfo.FillJackDownLimitError == 1)
            {
                InsertAlarm("填充站:顶升气缸下降限位异常");
            }
            if (PLCReadInfo.FillObstructLimitError == 1)
            {
                InsertAlarm("填充站:阻挡气缸阻挡限位异常");
            }
            if (PLCReadInfo.FillPullBackLimitError == 1)
            {
                InsertAlarm("填充站:回拉气缸回拉限位异常");
            }
            if (PLCReadInfo.FillClamp1TightLimitError == 1)
            {
                InsertAlarm("填充站:夹紧_1气缸夹紧限位异常");
            }
            if (PLCReadInfo.FillClamp2TightLimitError == 1)
            {
                InsertAlarm("填充站:夹紧_2气缸夹紧限位异常");
            }
            if (PLCReadInfo.FillClamp1PineLimitError == 1)
            {
                InsertAlarm("填充站:夹紧_1气缸送开限位异常");
            }
            if (PLCReadInfo.FillClamp2PineLimitError == 1)
            {
                InsertAlarm("填充站:夹紧_2气缸送开限位异常");
            }
            if (PLCReadInfo.FillPullBackReturnError == 1)
            {
                InsertAlarm("填充站:回拉气缸退回限位异常");
            }
            if (PLCReadInfo.FillObstructReturnError == 1)
            {
                InsertAlarm("填充站:阻挡气缸退回限位异常");
            }
            if (PLCReadInfo.FillPerliteVacuumErrorv == 1)
            {
                InsertAlarm("填充站:珍珠岩吸真空信号异常");
            }
            if (PLCReadInfo.FillRobotNotFoundPerlite == 1)
            {
                InsertAlarm("填充站:珍珠岩机器人未感应到珍珠岩");
            }
            if (PLCReadInfo.FillPerliteBreakVacuumError == 1)
            {
                InsertAlarm("填充站:珍珠岩破真空信号异常");
            }
            if (PLCReadInfo.FillPerliteShortSideRiseError == 1)
            {
                InsertAlarm("填充站:珍珠岩短边对中气缸升出信号异常");
            }
            if (PLCReadInfo.FillPerliteLongSideRiseError == 1)
            {
                InsertAlarm("填充站:珍珠岩长边对中气缸升出信号异常");
            }
            if (PLCReadInfo.Fill90DegreesVacuumError == 1)
            {
                InsertAlarm("填充站:90度吸真空信号异常");
            }
            if (PLCReadInfo.Fill90DegreesJackRiseError == 1)
            {
                InsertAlarm("填充站:90度顶升气缸顶升信号异常");
            }
            if (PLCReadInfo.Fill90DegreesClamp1Error == 1)
            {
                InsertAlarm("填充站:90度夹紧气缸_1信号异常");
            }
            if (PLCReadInfo.Fill90DegreesClamp2Error == 1)
            {
                InsertAlarm("填充站:90度夹紧气缸_2信号异常");
            }
            if (PLCReadInfo.Fill90DegreesJackReturnError == 1)
            {
                InsertAlarm("填充站:90度顶升气缸退回信号异常");
            }
            if (PLCReadInfo.Fill90DegreesJackMotorRiseError == 1)
            {
                InsertAlarm("填充站:90度顶升电机顶升异常");
            }
            if (PLCReadInfo.Fill90DegreesJackMotorNoUpLimit == 1)
            {
                InsertAlarm("填充站:90度顶升电机不在顶升限");
            }
            if (PLCReadInfo.Fill90DegreesRotateMotorForwardError == 1)
            {
                InsertAlarm("填充站:90度旋转电机正向旋转异常");
            }
            if (PLCReadInfo.Fill90DegreesRotateMotorForwardLocationError == 1)
            {
                InsertAlarm("填充站:90度旋转电机正向旋转未到位");
            }
            if (PLCReadInfo.Fill90DegreesJackMotorReturnError == 1)
            {
                InsertAlarm("填充站:90度顶升电机退回异常");
            }
            if (PLCReadInfo.Fill90DegreesRotateMotorReverseError == 1)
            {
                InsertAlarm("填充站:90度旋转电机反向旋转异常");
            }
            if (PLCReadInfo.FillVF1ToVF2Error == 1)
            {
                InsertAlarm("填充站故障:VF1与VF2物料传输异常");
            }
            if (PLCReadInfo.FillVF2ToVF3Error == 1)
            {
                InsertAlarm("填充站故障:VF2与VF3物料传输异常");
            }
            if (PLCReadInfo.FillVF2ToVF3Error == 1)
            {
                InsertAlarm("填充站故障:VF2与VF3物料传输异常");
            }
            if (PLCReadInfo.FillVF3ToVF4Error == 1)
            {
                InsertAlarm("填充站故障:VF3与VF4物料传输异常");
            }
            if (PLCReadInfo.FillVF4ToVF5Error == 1)
            {
                InsertAlarm("填充站故障:VF4与VF5物料传输异常");
            }
            if (PLCReadInfo.FillVF5ToVF6Error == 1)
            {
                InsertAlarm("填充站故障:VF5与VF6物料传输异常");
            }
            if (PLCReadInfo.FillRobotImpact == 1)
            {
                InsertAlarm("填充站故障:机器人碰撞物料_激光测距仪数值太小");
            }
        }
        private void InsertCheckAlarm()
        {
            if (PLCReadInfo.CheckJackLocationError == 1)
            {
                InsertAlarm("检测站提示:顶升气缸未到位");
            }
            if (PLCReadInfo.CheckSidePushBigLocationError == 1)
            {
                InsertAlarm("检测站提示:侧推大气缸未到位");
            }
            if (PLCReadInfo.CheckSidePushSmallLocationError == 1)
            {
                InsertAlarm("检测站提示:侧推小气缸未到位");
            }
            if (PLCReadInfo.CheckPullBackLocationError == 1)
            {
                InsertAlarm("检测站提示:回拉气缸未到位");
            }
            if (PLCReadInfo.CheckXNoStandby == 1)
            {
                InsertAlarm("检测站提示:X轴未回待机位");
            }
            if (PLCReadInfo.CheckYNoStandby == 1)
            {
                InsertAlarm("检测站提示:Y轴未回待机位");
            }
            if (PLCReadInfo.CheckRotaryNoStandby == 1)
            {
                InsertAlarm("检测站提示:旋转轴未回待机位");
            }
            if (PLCReadInfo.CheckNoComToRemoveSmoke == 1)
            {
                InsertAlarm("检测站提示:与除烟痕站通信异常");
            }
            if (PLCReadInfo.CheckNoComToMain == 1)
            {
                InsertAlarm("检测站提示:与主站通信异常");
            }
            if (PLCReadInfo.CheckEstop == 1)
            {
                InsertAlarm("检测故障:急停报警");
            }
            if (PLCReadInfo.CheckXServoError == 1)
            {
                InsertAlarm("检测故障:X轴伺服报错");
            }
            if (PLCReadInfo.CheckXServoOffLine == 1)
            {
                InsertAlarm("检测故障:X轴伺服通信掉线");
            }
            if (PLCReadInfo.CheckYServoError == 1)
            {
                InsertAlarm("检测故障:Y轴伺服报错");
            }
            if (PLCReadInfo.CheckYServoOffLine == 1)
            {
                InsertAlarm("检测故障:Y轴伺服通信掉线");
            }
            if (PLCReadInfo.CheckRotaryServoError == 1)
            {
                InsertAlarm("检测故障:旋转轴伺服报错");
            }
            if (PLCReadInfo.CheckRotaryServoOffLine == 1)
            {
                InsertAlarm("检测故障:旋转轴伺服通信掉线");
            }
            if (PLCReadInfo.CheckUpstreamDeliveryOvertime == 1)
            {
                InsertAlarm("检测故障:与上游交互传送运动超时");
            }
            if (PLCReadInfo.CheckFeedOvertime == 1)
            {
                InsertAlarm("检测故障:本站进料完成超时");
            }
            if (PLCReadInfo.CheckJackReachError == 1)
            {
                InsertAlarm("检测故障:顶升气缸伸出限位异常");
            }
            if (PLCReadInfo.CheckPullBackReachError == 1)
            {
                InsertAlarm("检测故障:回拉气缸伸出限位异常");
            }
            if (PLCReadInfo.CheckSidePushBigReachError == 1)
            {
                InsertAlarm("检测故障:侧推大气缸伸出限位异常");
            }
            if (PLCReadInfo.CheckSidePushSmallReachError == 1)
            {
                InsertAlarm("检测故障:侧推小气缸伸出限位异常");
            }
            if (PLCReadInfo.CheckXYZReturnStandbyError == 1)
            {
                InsertAlarm("检测故障:X/Y/Z轴回待机位异常");
            }
            if (PLCReadInfo.CheckSidePushSmallReturnError == 1)
            {
                InsertAlarm("检测故障:侧推小气缸退回限位异常");
            }
            if (PLCReadInfo.CheckSidePushBigReturnError == 1)
            {
                InsertAlarm("检测故障:侧推大气缸退回限位异常");
            }
            if (PLCReadInfo.CheckPullBackReturnError == 1)
            {
                InsertAlarm("检测故障:回拉气缸退回限位异常");
            }
            if (PLCReadInfo.CheckJackReturnError == 1)
            {
                InsertAlarm("检测故障:顶升气缸退回限位异常");
            }
            if (PLCReadInfo.CheckDownstreamDeliveryOvertime == 1)
            {
                InsertAlarm("检测故障:与下游交互传送运动超时");
            }
            if (PLCReadInfo.CheckDischargeOvertime == 1)
            {
                InsertAlarm("检测故障:本站出料完成超时");
            }
            if (PLCReadInfo.CheckManualNoAuto == 1)
            {
                InsertAlarm("检测故障:手动操作画面未回位，不能自动启动");
            }
            if (PLCReadInfo.CheckManualNoContinue == 1)
            {
                InsertAlarm("检测故障:手动操作画面未回位，不能继续运行");
            }
            if (PLCReadInfo.CheckVFDNoCom == 1)
            {
                InsertAlarm("检测故障:变频器通讯异常");
            }
            if (PLCReadInfo.CheckVFDError == 1)
            {
                InsertAlarm("检测故障:变频器报错");
            }
        }
        private void InsertUnloadAlarm()
        {
            if (PLCReadInfo.UnloadJackLocationError == 1)
            {
                InsertAlarm("下料站提示:顶升气缸未回位");
            }
            if (PLCReadInfo.UnloadClamp1LocationError == 1)
            {
                InsertAlarm("下料站提示:夹紧气缸1未回位");
            }
            if (PLCReadInfo.UnloadClamp2LocationError == 1)
            {
                InsertAlarm("下料站提示:夹紧气缸2未回位");
            }
            if (PLCReadInfo.UnloadPullBackLocationError == 1)
            {
                InsertAlarm("下料站提示:回拉气缸未回位");
            }
            if (PLCReadInfo.UnloadServo1NoStandby == 1)
            {
                InsertAlarm("下料站提示:伺服1未回待机位");
            }
            if (PLCReadInfo.UnloadServo2NoStandby == 1)
            {
                InsertAlarm("下料站提示:伺服2未回待机位");
            }
            if (PLCReadInfo.UnloadSkipCar1LocationError == 1)
            {
                InsertAlarm("下料站提示:料车1未到位");
            }
            if (PLCReadInfo.UnloadSkipCar2LocationError == 1)
            {
                InsertAlarm("下料站提示:料车2未到位");
            }
            if (PLCReadInfo.UnloadABBNoAuto == 1)
            {
                InsertAlarm("下料站提示:ABB不在自动状态");
            }
            if (PLCReadInfo.UnloadABBNoloop == 1)
            {
                InsertAlarm("下料站提示:ABB不在循环状态");
            }
            if (PLCReadInfo.UnloadABBNoHome == 1)
            {
                InsertAlarm("下料站提示:ABB不在原点状态");
            }
            if (PLCReadInfo.UnloadNGCarFull == 1)
            {
                InsertAlarm("下料站提示:NG料车满料");
            }
            if (PLCReadInfo.UnloadOKCarFull == 1)
            {
                InsertAlarm("下料站提示:OK料车满料");
            }
            if (PLCReadInfo.UnloadEstop == 1)
            {
                InsertAlarm("下料站故障:急停异常");
            }
            if (PLCReadInfo.UnloadABBOffLine == 1)
            {
                InsertAlarm("下料站故障:ABB通信掉线");
            }
            if (PLCReadInfo.UnloadABBError == 1)
            {
                InsertAlarm("下料站故障:ABB机器人报错");
            }
            if (PLCReadInfo.UnloadServo1OffLine == 1)
            {
                InsertAlarm("下料站故障:伺服1通信掉线");
            }
            if (PLCReadInfo.UnloadServo1Error == 1)
            {
                InsertAlarm("下料站故障:伺服1报错");
            }
            if (PLCReadInfo.UnloadServo2OffLine == 1)
            {
                InsertAlarm("下料站故障:伺服2通信掉线");
            }
            if (PLCReadInfo.UnloadServo2Error == 1)
            {
                InsertAlarm("下料站故障:伺服2报错");
            }
            if (PLCReadInfo.UnloadUpstreamDeliveryOvertime == 1)
            {
                InsertAlarm("下料站故障:与上游交互传送运动超时");
            }
            if (PLCReadInfo.UnloadFeedOvertime == 1)
            {
                InsertAlarm("下料站故障:本站进料完成超时");
            }
            if (PLCReadInfo.UnloadJackReachError == 1)
            {
                InsertAlarm("下料站故障:顶升气缸伸出限异常");
            }
            if (PLCReadInfo.UnloadPullBackReachError == 1)
            {
                InsertAlarm("下料站故障:回拉气缸伸出限异常");
            }
            if (PLCReadInfo.UnloadClampTightLimit == 1)
            {
                InsertAlarm("下料站故障:夹紧气缸夹紧限异常");
            }
            if (PLCReadInfo.UnloadClampReleaseLimit == 1)
            {
                InsertAlarm("下料站故障:夹紧气缸松开限异常");
            }
            if (PLCReadInfo.UnloadPullBackReturnError == 1)
            {
                InsertAlarm("下料站故障:回拉气缸退回限异常");
            }
            if (PLCReadInfo.UnloadManualNoAuto == 1)
            {
                InsertAlarm("下料站故障:手动按钮未回位，不能自动启动");
            }
            if (PLCReadInfo.UnloadManualNoContinue == 1)
            {
                InsertAlarm("下料站故障:手动按钮未回位，不能继续运行");
            }
            if (PLCReadInfo.UnloadVFDNoCom == 1)
            {
                InsertAlarm("下料站故障:变频器通讯异常");
            }
            if (PLCReadInfo.UnloadVFDError == 1)
            {
                InsertAlarm("下料站故障:变频器报错");
            }
        }
        /// <summary>
        /// 报警信息存入数据库
        /// </summary>
        /// <param name="AlarmDescription"></param>
        private static void InsertAlarm(string AlarmDescription)
        {
            DateTime dateTime = DateTime.Now;
            string tradeTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string sql = DB_SQL.in_AlarmInfo;
            sql += tradeTime + "','" + AlarmDescription + "',1)";
            using (SqlConnection conn = new SqlConnection(DB_SQL.conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message.ToString() + "打开数据库失败！");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 更新报警
        /// </summary>
        private void UpdateLoadAlarm()
        {
            if (PLCReadInfo.LoadABBNoHome == 0)
            {
                UpdateAlarm("上料站提示:ABB 不在Home点");
            }
            if (PLCReadInfo.LoadReverseNoHome == 0)
            {
                UpdateAlarm("上料站提示:反转气缸没有到位");
            }
            if (PLCReadInfo.LoadLaserNoHome == 0)
            {
                UpdateAlarm("上料站提示:激光测距气缸没到位");
            }
            if (PLCReadInfo.LoadMatterCar1NoHome == 0)
            {
                UpdateAlarm("上料站提示:料车1没到位");
            }
            if (PLCReadInfo.LoadMatterCar2NoHome == 0)
            {
                UpdateAlarm("上料站提示:料车2没到位");
            }
            if (PLCReadInfo.LoadABBNotAuto == 0)
            {
                UpdateAlarm("上料站提示:ABB没有在自动状态");
            }
            if (PLCReadInfo.LoadABBNotLoop == 0)
            {
                UpdateAlarm("上料站提示:ABB没有循环运行");
            }
            if (PLCReadInfo.LoadGluingComAbnormal == 0)
            {
                UpdateAlarm("上料站提示:与涂胶站通信异常");
            }
            if (PLCReadInfo.LoadPerliteComAbnormal == 0)
            {
                UpdateAlarm("上料站提示:与珍珠岩站通信异常");
            }
            if (PLCReadInfo.LoadMainStationComAbnormal == 0)
            {
                UpdateAlarm("上料站提示:与主站通信异常");
            }
            if (PLCReadInfo.LoadEStop == 0)
            {
                UpdateAlarm("上料站故障:急停按钮被按下");
            }
            if (PLCReadInfo.LoadABBDisconnect == 0)
            {
                UpdateAlarm("上料站故障:ABB通信掉线");
            }
            if (PLCReadInfo.LoadABBFault == 0)
            {
                UpdateAlarm("上料站故障:ABB故障");
            }
            if (PLCReadInfo.LoadVF0Disconnect == 0)
            {
                UpdateAlarm("上料站故障:VF0通信掉线");
            }
            if (PLCReadInfo.LoadVF0Fault == 0)
            {
                UpdateAlarm("上料站故障:VF0报错");
            }
            if (PLCReadInfo.LoadVF1Disconnect == 0)
            {
                UpdateAlarm("上料站故障:VF1通信掉线");
            }
            if (PLCReadInfo.LoadVF1Fault == 0)
            {
                UpdateAlarm("上料站故障:VF1报错");
            }
            if (PLCReadInfo.LoadVF2Disconnect == 0)
            {
                UpdateAlarm("上料站故障:VF2通信掉线");
            }
            if (PLCReadInfo.LoadVF2Fault == 0)
            {
                UpdateAlarm("上料站故障:VF2报错");
            }
            if (PLCReadInfo.LoadVF3Disconnect == 0)
            {
                UpdateAlarm("上料站故障:VF3通信掉线");
            }
            if (PLCReadInfo.LoadVF3Fault == 0)
            {
                UpdateAlarm("上料站故障:VF3报错");
            }
            if (PLCReadInfo.LoadVF4Disconnect == 0)
            {
                UpdateAlarm("上料站故障:VF4通信掉线");
            }
            if (PLCReadInfo.LoadVF4Fault == 0)
            {
                UpdateAlarm("上料站故障:VF4报错");
            }
            if (PLCReadInfo.LoadVF5Disconnect == 0)
            {
                UpdateAlarm("上料站故障:VF5通信掉线");
            }
            if (PLCReadInfo.LoadVF5Fault == 0)
            {
                UpdateAlarm("上料站故障:VF5报错");
            }
            if (PLCReadInfo.LoadABBVacuumError == 0)
            {
                UpdateAlarm("上料站故障:ABB吸真空异常");
            }
            if (PLCReadInfo.LoadABBBreakVacuumError == 0)
            {
                UpdateAlarm("上料站故障:ABB破真空压力异常");
            }
            if (PLCReadInfo.LoadOverturnReturnError == 0)
            {
                UpdateAlarm("上料站故障:翻转气缸退回异常");
            }
            if (PLCReadInfo.LoadOverturnReachError == 0)
            {
                UpdateAlarm("上料站故障:翻转气缸伸出限位异常");
            }
            if (PLCReadInfo.LoadUnableAutoStart == 0)
            {
                UpdateAlarm("上料站故障:手动按钮未回位,不能自动启动");
            }
            if (PLCReadInfo.LoadUnableContinue == 0)
            {
                UpdateAlarm("上料站故障:手动按钮未回位,不能继续运行");
            }
            if (PLCReadInfo.LoadVF0ToVF1Error == 0)
            {
                UpdateAlarm("上料站故障:VF0与VF1物料传输异常");
            }
            if (PLCReadInfo.LoadVF1ToVF2Error == 0)
            {
                UpdateAlarm("上料站故障:VF1与VF2物料传输异常");
            }
            if (PLCReadInfo.LoadVF3ToVF4Error == 0)
            {
                UpdateAlarm("上料站故障:VF3与VF4物料传输异常");
            }
            if (PLCReadInfo.LoadVF4ToVF5Error == 0)
            {
                UpdateAlarm("上料站故障:VF4与VF5物料传输异常");
            }
            if (PLCReadInfo.LoadVF5ToGluingError == 0)
            {
                UpdateAlarm("上料站故障:VF5与涂胶站物料传输异常");
            }
            if (PLCReadInfo.LoadGluingToVF6Error == 0)
            {
                UpdateAlarm("上料站故障:涂胶站与VF6物料传输异常");
            }
            if (PLCReadInfo.Load1LaserBeyondRange == 0)
            {
                UpdateAlarm("上料站故障:1#激光数值超出量程");
            }
            if (PLCReadInfo.Load2LaserBeyondRange == 0)
            {
                UpdateAlarm("上料站故障:2#激光数值超出量程");
            }
            if (PLCReadInfo.Load3LaserBeyondRange == 0)
            {
                UpdateAlarm("上料站故障:3#激光数值超出量程");
            }
            if (PLCReadInfo.LoadNoThicknessData == 0)
            {
                UpdateAlarm("上料站故障:防火门没有门厚数据");
            }
        }
        private void UpdateFilmMulchAlarm()
        {
            if (PLCReadInfo.FrontRollerError == 0)
            {
                InsertAlarm("覆膜站故障：前端辊筒顶升异常");
            }
            if (PLCReadInfo.UpperAdsorptionError == 0)
            {
                InsertAlarm("覆膜站故障：上吸附板异常");
            }
            if (PLCReadInfo.DownAdsorptionError == 0)
            {
                InsertAlarm("覆膜站故障：下吸附板异常");
            }
            if (PLCReadInfo.UpperCutError == 0)
            {
                InsertAlarm("覆膜站故障：上纵切气缸异常");
            }
            if (PLCReadInfo.DownCutError == 0)
            {
                InsertAlarm("覆膜站故障：下纵切气缸异常");
            }
            if (PLCReadInfo.CrossCutError == 0)
            {
                InsertAlarm("覆膜站故障：横切气缸异常");
            }
            if (PLCReadInfo.UpperAdsorptionVacuumError == 0)
            {
                InsertAlarm("覆膜站故障：上吸附真空异常");
            }
            if (PLCReadInfo.DownAdsorptionVacuumError == 0)
            {
                InsertAlarm("覆膜站故障：下吸附真空异常");
            }
            if (PLCReadInfo.EstopError == 0)
            {
                InsertAlarm("覆膜站故障：急停报警");
            }
            if (PLCReadInfo.UpperFrontLack == 0)
            {
                InsertAlarm("覆膜站故障：上前膜缺料报警");
            }
            if (PLCReadInfo.UpperBehindLack == 0)
            {
                InsertAlarm("覆膜站故障：上后膜缺料报警");
            }
            if (PLCReadInfo.DownFrontLack == 0)
            {
                InsertAlarm("覆膜站故障：下前膜缺料报警");
            }
            if (PLCReadInfo.DownBehindLack == 0)
            {
                InsertAlarm("覆膜站故障：下后膜缺料报警");
            }
            if (PLCReadInfo.LowAirPressureAlarm == 0)
            {
                InsertAlarm("覆膜站故障：气压低报警");
            }
            if (PLCReadInfo.FrontRollerVFDError == 0)
            {
                InsertAlarm("覆膜站故障：前压辊变频器故障");
            }
            if (PLCReadInfo.BehindRollerVFDError == 0)
            {
                InsertAlarm("覆膜站故障：后压辊变频器故障");
            }
            if (PLCReadInfo.FrontPowerVFDError == 0)
            {
                InsertAlarm("覆膜站故障：前动力辊伺服故障");
            }
            if (PLCReadInfo.BehindPowerVFDError == 0)
            {
                InsertAlarm("覆膜站故障：后动力辊伺服故障");
            }
            if (PLCReadInfo.UpperCutVFDError == 0)
            {
                InsertAlarm("覆膜站故障：上纵切伺服故障");
            }
            if (PLCReadInfo.DownCutVFDError == 0)
            {
                InsertAlarm("覆膜站故障：下纵切伺服故障");
            }
            if (PLCReadInfo.CrossCutVFDError == 0)
            {
                InsertAlarm("覆膜站故障：横切伺服故障");
            }
            if (PLCReadInfo.ServoNoHome == 0)
            {
                InsertAlarm("覆膜站故障：伺服没回Home点报警");
            }
            if (PLCReadInfo.UpperCutForwardLimit == 0)
            {
                InsertAlarm("覆膜站故障：上纵切伺服正极限报警");
            }
            if (PLCReadInfo.UpperCutReverseLimit == 0)
            {
                InsertAlarm("覆膜站故障：上纵切伺服反极限报警");
            }
            if (PLCReadInfo.DownCutForwardLimit == 0)
            {
                InsertAlarm("覆膜站故障：下纵切伺服正极限报警");
            }
            if (PLCReadInfo.DownCutReverseLimit == 0)
            {
                InsertAlarm("覆膜站故障：下纵切伺服反极限报警");
            }
            if (PLCReadInfo.CrossCutForwardLimit == 0)
            {
                InsertAlarm("覆膜站故障：横切伺服正极限报警");
            }
            if (PLCReadInfo.CrossCutReverseLimit == 0)
            {
                InsertAlarm("覆膜站故障：横切伺服反极限报警");
            }
            if (PLCReadInfo.DoorDataTransferIncomplete == 0)
            {
                InsertAlarm("覆膜站故障：门数据传递没有完成");
            }
            if (PLCReadInfo.FrontRollerVFDNoCom == 0)
            {
                InsertAlarm("覆膜站故障：前压辊变频器掉线");
            }
            if (PLCReadInfo.BehindRollerVFDNoCom == 0)
            {
                InsertAlarm("覆膜站故障：后压辊变频器掉线");
            }
            if (PLCReadInfo.MainStationNoCom == 0)
            {
                InsertAlarm("覆膜站故障：与主站通讯故障");
            }
            if (PLCReadInfo.LoadStationNoCom == 0)
            {
                InsertAlarm("覆膜站故障：与上料站通讯故障");
            }
            if (PLCReadInfo.FrontPowerServoNoCom == 0)
            {
                InsertAlarm("覆膜站故障：前动力辊伺服掉线");
            }
            if (PLCReadInfo.BehindPowerServoNoCom == 0)
            {
                InsertAlarm("覆膜站故障：后动力辊伺服掉线");
            }
            if (PLCReadInfo.UpperCutServoNoCom == 0)
            {
                InsertAlarm("覆膜站故障：上纵切伺服掉线");
            }
            if (PLCReadInfo.DownCutServoNoCom == 0)
            {
                InsertAlarm("覆膜站故障：下纵切伺服掉线");
            }
            if (PLCReadInfo.CrossCutServoNoCom == 0)
            {
                InsertAlarm("覆膜站故障：横切伺服掉线");
            }
        }
        private void UpdateFillAlarm()
        {
            if (PLCReadInfo.FillClamp1LocationError == 0)
            {
                UpdateAlarm("填充站提示:填充夹紧1气缸未到位");
            }
            if (PLCReadInfo.FillClamp2LocationError == 0)
            {
                UpdateAlarm("填充站提示:填充夹紧2气缸未到位");
            }
            if (PLCReadInfo.FillObstructLocationError == 0)
            {
                UpdateAlarm("填充站提示:填充阻挡气缸未到位");
            }
            if (PLCReadInfo.FillJackLocationError == 0)
            {
                UpdateAlarm("填充站提示:填充顶升气缸未到位");
            }
            if (PLCReadInfo.FillIncomplete == 0)
            {
                UpdateAlarm("填充站提示:填充工位有料,未完成");
            }
            if (PLCReadInfo.FillABBNoHome == 0)
            {
                UpdateAlarm("填充站提示:填充ABB机器人未回原点");
            }
            if (PLCReadInfo.FillPerliteCar1LocationError == 0)
            {
                UpdateAlarm("填充站提示:珍珠岩料车1未到位");
            }
            if (PLCReadInfo.FillPerliteCar2LocationError == 0)
            {
                UpdateAlarm("填充站提示:珍珠岩料车2未到位");
            }
            if (PLCReadInfo.FillPerliteSecondLocationFull == 0)
            {
                UpdateAlarm("填充站提示:珍珠岩二次定位有料");
            }
            if (PLCReadInfo.FillLongSideLocationError == 0)
            {
                UpdateAlarm("填充站提示:填充长边对中气缸未到位");
            }
            if (PLCReadInfo.FillShortSideLocationError == 0)
            {
                UpdateAlarm("填充站提示:填充短边对中气缸未到位");
            }
            if (PLCReadInfo.Fill90DegreesNoHome == 0)
            {
                UpdateAlarm("填充站提示:90度旋转/顶升电机不在初始状态");
            }
            if (PLCReadInfo.Fill90DegreesFull == 0)
            {
                UpdateAlarm("填充站提示:90度工位有料");
            }
            if (PLCReadInfo.Fill90DegreesJackUpLocationError == 0)
            {
                UpdateAlarm("填充站提示:90度顶升气缸未回到位");
            }
            if (PLCReadInfo.Fill90DegreesClampLocationError == 0)
            {
                UpdateAlarm("填充站提示:90度夹紧气缸未回到位");
            }
            if (PLCReadInfo.FillABBNotAuto == 0)
            {
                UpdateAlarm("填充站提示:ABB机器人不在自动");
            }
            if (PLCReadInfo.FillABBNotLoopRun == 0)
            {
                UpdateAlarm("填充站提示:ABB机器人没有循环运行");
            }
            if (PLCReadInfo.FillNoComWithLoad == 0)
            {
                UpdateAlarm("填充站提示:与上料站通信异常");
            }
            if (PLCReadInfo.FillNoComWithLamination == 0)
            {
                UpdateAlarm("填充站提示:与压合站通信异常");
            }
            if (PLCReadInfo.FillNoComWithMain == 0)
            {
                UpdateAlarm("填充站提示:与主站通信异常");
            }
            if (PLCReadInfo.FillNoPerlite == 0)
            {
                UpdateAlarm("填充站提示:珍珠岩已抓完/请放物料");
            }
            if (PLCReadInfo.FillEstop == 0)
            {
                UpdateAlarm("填充站:急停异常");
            }
            if (PLCReadInfo.FillABBOffLine == 0)
            {
                UpdateAlarm("填充站:ABB通信掉线");
            }
            if (PLCReadInfo.FillABBError == 0)
            {
                UpdateAlarm("填充站:ABB机器人报错");
            }
            if (PLCReadInfo.FillVF1OffLine == 0)
            {
                UpdateAlarm("填充站:VF1通信掉线");
            }
            if (PLCReadInfo.FillVF1Error == 0)
            {
                UpdateAlarm("填充站:VF1报错");
            }
            if (PLCReadInfo.FillVF2OffLine == 0)
            {
                UpdateAlarm("填充站:VF2通信掉线");
            }
            if (PLCReadInfo.FillVF2Error == 0)
            {
                UpdateAlarm("填充站:VF2报错");
            }
            if (PLCReadInfo.FillVF3OffLine == 0)
            {
                UpdateAlarm("填充站:VF3通信掉线");
            }
            if (PLCReadInfo.FillVF3Error == 0)
            {
                UpdateAlarm("填充站:VF3报错");
            }
            if (PLCReadInfo.FillVF4OffLine == 0)
            {
                UpdateAlarm("填充站:VF4通信掉线");
            }
            if (PLCReadInfo.FillVF4Error == 0)
            {
                UpdateAlarm("填充站:VF4报错");
            }
            if (PLCReadInfo.FillVF5OffLine == 0)
            {
                UpdateAlarm("填充站:VF5通信掉线");
            }
            if (PLCReadInfo.FillVF5Error == 0)
            {
                UpdateAlarm("填充站:VF5报错");
            }
            if (PLCReadInfo.FillVF6OffLine == 0)
            {
                UpdateAlarm("填充站:VF6通信掉线");
            }
            if (PLCReadInfo.FillVF6Error == 0)
            {
                UpdateAlarm("填充站:VF6报错");
            }
            if (PLCReadInfo.FillVF7OffLine == 0)
            {
                UpdateAlarm("填充站:VF7通信掉线");
            }
            if (PLCReadInfo.FillVF7Error == 0)
            {
                UpdateAlarm("填充站:VF7报错");
            }
            if (PLCReadInfo.FillVF8OffLine == 0)
            {
                UpdateAlarm("填充站:VF8通信掉线");
            }
            if (PLCReadInfo.FillVF8Error == 0)
            {
                UpdateAlarm("填充站:VF8报错");
            }
            if (PLCReadInfo.FillJackUpLimitError == 0)
            {
                UpdateAlarm("填充站:顶升气缸顶升限位异常");
            }
            if (PLCReadInfo.FillJackDownLimitError == 0)
            {
                UpdateAlarm("填充站:顶升气缸下降限位异常");
            }
            if (PLCReadInfo.FillObstructLimitError == 0)
            {
                UpdateAlarm("填充站:阻挡气缸阻挡限位异常");
            }
            if (PLCReadInfo.FillPullBackLimitError == 0)
            {
                UpdateAlarm("填充站:回拉气缸回拉限位异常");
            }
            if (PLCReadInfo.FillClamp1TightLimitError == 0)
            {
                UpdateAlarm("填充站:夹紧_1气缸夹紧限位异常");
            }
            if (PLCReadInfo.FillClamp2TightLimitError == 0)
            {
                UpdateAlarm("填充站:夹紧_2气缸夹紧限位异常");
            }
            if (PLCReadInfo.FillClamp1PineLimitError == 0)
            {
                UpdateAlarm("填充站:夹紧_1气缸送开限位异常");
            }
            if (PLCReadInfo.FillClamp2PineLimitError == 0)
            {
                UpdateAlarm("填充站:夹紧_2气缸送开限位异常");
            }
            if (PLCReadInfo.FillPullBackReturnError == 0)
            {
                UpdateAlarm("填充站:回拉气缸退回限位异常");
            }
            if (PLCReadInfo.FillObstructReturnError == 0)
            {
                UpdateAlarm("填充站:阻挡气缸退回限位异常");
            }
            if (PLCReadInfo.FillPerliteVacuumErrorv == 0)
            {
                UpdateAlarm("填充站:珍珠岩吸真空信号异常");
            }
            if (PLCReadInfo.FillRobotNotFoundPerlite == 0)
            {
                UpdateAlarm("填充站:珍珠岩机器人未感应到珍珠岩");
            }
            if (PLCReadInfo.FillPerliteBreakVacuumError == 0)
            {
                UpdateAlarm("填充站:珍珠岩破真空信号异常");
            }
            if (PLCReadInfo.FillPerliteShortSideRiseError == 0)
            {
                UpdateAlarm("填充站:珍珠岩短边对中气缸升出信号异常");
            }
            if (PLCReadInfo.FillPerliteLongSideRiseError == 0)
            {
                UpdateAlarm("填充站:珍珠岩长边对中气缸升出信号异常");
            }
            if (PLCReadInfo.Fill90DegreesVacuumError == 0)
            {
                UpdateAlarm("填充站:90度吸真空信号异常");
            }
            if (PLCReadInfo.Fill90DegreesJackRiseError == 0)
            {
                UpdateAlarm("填充站:90度顶升气缸顶升信号异常");
            }
            if (PLCReadInfo.Fill90DegreesClamp1Error == 0)
            {
                UpdateAlarm("填充站:90度夹紧气缸_1信号异常");
            }
            if (PLCReadInfo.Fill90DegreesClamp2Error == 0)
            {
                UpdateAlarm("填充站:90度夹紧气缸_2信号异常");
            }
            if (PLCReadInfo.Fill90DegreesJackReturnError == 0)
            {
                UpdateAlarm("填充站:90度顶升气缸退回信号异常");
            }
            if (PLCReadInfo.Fill90DegreesJackMotorRiseError == 0)
            {
                UpdateAlarm("填充站:90度顶升电机顶升异常");
            }
            if (PLCReadInfo.Fill90DegreesJackMotorNoUpLimit == 0)
            {
                UpdateAlarm("填充站:90度顶升电机不在顶升限");
            }
            if (PLCReadInfo.Fill90DegreesRotateMotorForwardError == 0)
            {
                UpdateAlarm("填充站:90度旋转电机正向旋转异常");
            }
            if (PLCReadInfo.Fill90DegreesRotateMotorForwardLocationError == 0)
            {
                UpdateAlarm("填充站:90度旋转电机正向旋转未到位");
            }
            if (PLCReadInfo.Fill90DegreesJackMotorReturnError == 0)
            {
                UpdateAlarm("填充站:90度顶升电机退回异常");
            }
            if (PLCReadInfo.Fill90DegreesRotateMotorReverseError == 0)
            {
                UpdateAlarm("填充站:90度旋转电机反向旋转异常");
            }
            if (PLCReadInfo.FillVF1ToVF2Error == 0)
            {
                UpdateAlarm("填充站故障:VF1与VF2物料传输异常");
            }
            if (PLCReadInfo.FillVF2ToVF3Error == 0)
            {
                UpdateAlarm("填充站故障:VF2与VF3物料传输异常");
            }
            if (PLCReadInfo.FillVF2ToVF3Error == 0)
            {
                UpdateAlarm("填充站故障:VF2与VF3物料传输异常");
            }
            if (PLCReadInfo.FillVF3ToVF4Error == 0)
            {
                UpdateAlarm("填充站故障:VF3与VF4物料传输异常");
            }
            if (PLCReadInfo.FillVF4ToVF5Error == 0)
            {
                UpdateAlarm("填充站故障:VF4与VF5物料传输异常");
            }
            if (PLCReadInfo.FillVF5ToVF6Error == 0)
            {
                UpdateAlarm("填充站故障:VF5与VF6物料传输异常");
            }
            if (PLCReadInfo.FillRobotImpact == 0)
            {
                UpdateAlarm("填充站故障:机器人碰撞物料_激光测距仪数值太小");
            }
        }
        private void UpdateCheckAlarm()
        {
            if (PLCReadInfo.CheckJackLocationError == 0)
            {
                UpdateAlarm("检测站提示:顶升气缸未到位");
            }
            if (PLCReadInfo.CheckSidePushBigLocationError == 0)
            {
                UpdateAlarm("检测站提示:侧推大气缸未到位");
            }
            if (PLCReadInfo.CheckSidePushSmallLocationError == 0)
            {
                UpdateAlarm("检测站提示:侧推小气缸未到位");
            }
            if (PLCReadInfo.CheckPullBackLocationError == 0)
            {
                UpdateAlarm("检测站提示:回拉气缸未到位");
            }
            if (PLCReadInfo.CheckXNoStandby == 0)
            {
                UpdateAlarm("检测站提示:X轴未回待机位");
            }
            if (PLCReadInfo.CheckYNoStandby == 0)
            {
                UpdateAlarm("检测站提示:Y轴未回待机位");
            }
            if (PLCReadInfo.CheckRotaryNoStandby == 0)
            {
                UpdateAlarm("检测站提示:旋转轴未回待机位");
            }
            if (PLCReadInfo.CheckNoComToRemoveSmoke == 0)
            {
                UpdateAlarm("检测站提示:与除烟痕站通信异常");
            }
            if (PLCReadInfo.CheckNoComToMain == 0)
            {
                UpdateAlarm("检测站提示:与主站通信异常");
            }
            if (PLCReadInfo.CheckEstop == 0)
            {
                UpdateAlarm("检测故障:急停报警");
            }
            if (PLCReadInfo.CheckXServoError == 0)
            {
                UpdateAlarm("检测故障:X轴伺服报错");
            }
            if (PLCReadInfo.CheckXServoOffLine == 0)
            {
                UpdateAlarm("检测故障:X轴伺服通信掉线");
            }
            if (PLCReadInfo.CheckYServoError == 0)
            {
                UpdateAlarm("检测故障:Y轴伺服报错");
            }
            if (PLCReadInfo.CheckYServoOffLine == 0)
            {
                UpdateAlarm("检测故障:Y轴伺服通信掉线");
            }
            if (PLCReadInfo.CheckRotaryServoError == 0)
            {
                UpdateAlarm("检测故障:旋转轴伺服报错");
            }
            if (PLCReadInfo.CheckRotaryServoOffLine == 0)
            {
                UpdateAlarm("检测故障:旋转轴伺服通信掉线");
            }
            if (PLCReadInfo.CheckUpstreamDeliveryOvertime == 0)
            {
                UpdateAlarm("检测故障:与上游交互传送运动超时");
            }
            if (PLCReadInfo.CheckFeedOvertime == 0)
            {
                UpdateAlarm("检测故障:本站进料完成超时");
            }
            if (PLCReadInfo.CheckJackReachError == 0)
            {
                UpdateAlarm("检测故障:顶升气缸伸出限位异常");
            }
            if (PLCReadInfo.CheckPullBackReachError == 0)
            {
                UpdateAlarm("检测故障:回拉气缸伸出限位异常");
            }
            if (PLCReadInfo.CheckSidePushBigReachError == 0)
            {
                UpdateAlarm("检测故障:侧推大气缸伸出限位异常");
            }
            if (PLCReadInfo.CheckSidePushSmallReachError == 0)
            {
                UpdateAlarm("检测故障:侧推小气缸伸出限位异常");
            }
            if (PLCReadInfo.CheckXYZReturnStandbyError == 0)
            {
                UpdateAlarm("检测故障:X/Y/Z轴回待机位异常");
            }
            if (PLCReadInfo.CheckSidePushSmallReturnError == 0)
            {
                UpdateAlarm("检测故障:侧推小气缸退回限位异常");
            }
            if (PLCReadInfo.CheckSidePushBigReturnError == 0)
            {
                UpdateAlarm("检测故障:侧推大气缸退回限位异常");
            }
            if (PLCReadInfo.CheckPullBackReturnError == 0)
            {
                UpdateAlarm("检测故障:回拉气缸退回限位异常");
            }
            if (PLCReadInfo.CheckJackReturnError == 0)
            {
                UpdateAlarm("检测故障:顶升气缸退回限位异常");
            }
            if (PLCReadInfo.CheckDownstreamDeliveryOvertime == 0)
            {
                UpdateAlarm("检测故障:与下游交互传送运动超时");
            }
            if (PLCReadInfo.CheckDischargeOvertime == 0)
            {
                UpdateAlarm("检测故障:本站出料完成超时");
            }
            if (PLCReadInfo.CheckManualNoAuto == 0)
            {
                UpdateAlarm("检测故障:手动操作画面未回位，不能自动启动");
            }
            if (PLCReadInfo.CheckManualNoContinue == 0)
            {
                UpdateAlarm("检测故障:手动操作画面未回位，不能继续运行");
            }
            if (PLCReadInfo.CheckVFDNoCom == 0)
            {
                UpdateAlarm("检测故障:变频器通讯异常");
            }
            if (PLCReadInfo.CheckVFDError == 0)
            {
                UpdateAlarm("检测故障:变频器报错");
            }
        }
        private void UpdateUnloadAlarm()
        {
            if (PLCReadInfo.UnloadJackLocationError == 0)
            {
                UpdateAlarm("下料站提示:顶升气缸未回位");
            }
            if (PLCReadInfo.UnloadClamp1LocationError == 0)
            {
                UpdateAlarm("下料站提示:夹紧气缸1未回位");
            }
            if (PLCReadInfo.UnloadClamp2LocationError == 0)
            {
                UpdateAlarm("下料站提示:夹紧气缸2未回位");
            }
            if (PLCReadInfo.UnloadPullBackLocationError == 0)
            {
                UpdateAlarm("下料站提示:回拉气缸未回位");
            }
            if (PLCReadInfo.UnloadServo1NoStandby == 0)
            {
                UpdateAlarm("下料站提示:伺服1未回待机位");
            }
            if (PLCReadInfo.UnloadServo2NoStandby == 0)
            {
                UpdateAlarm("下料站提示:伺服2未回待机位");
            }
            if (PLCReadInfo.UnloadSkipCar1LocationError == 0)
            {
                UpdateAlarm("下料站提示:料车1未到位");
            }
            if (PLCReadInfo.UnloadSkipCar2LocationError == 0)
            {
                UpdateAlarm("下料站提示:料车2未到位");
            }
            if (PLCReadInfo.UnloadABBNoAuto == 0)
            {
                UpdateAlarm("下料站提示:ABB不在自动状态");
            }
            if (PLCReadInfo.UnloadABBNoloop == 0)
            {
                UpdateAlarm("下料站提示:ABB不在循环状态");
            }
            if (PLCReadInfo.UnloadABBNoHome == 0)
            {
                UpdateAlarm("下料站提示:ABB不在原点状态");
            }
            if (PLCReadInfo.UnloadNGCarFull == 0)
            {
                UpdateAlarm("下料站提示:NG料车满料");
            }
            if (PLCReadInfo.UnloadOKCarFull == 0)
            {
                UpdateAlarm("下料站提示:OK料车满料");
            }
            if (PLCReadInfo.UnloadEstop == 0)
            {
                UpdateAlarm("下料站故障:急停异常");
            }
            if (PLCReadInfo.UnloadABBOffLine == 0)
            {
                UpdateAlarm("下料站故障:ABB通信掉线");
            }
            if (PLCReadInfo.UnloadABBError == 0)
            {
                UpdateAlarm("下料站故障:ABB机器人报错");
            }
            if (PLCReadInfo.UnloadServo1OffLine == 0)
            {
                UpdateAlarm("下料站故障:伺服1通信掉线");
            }
            if (PLCReadInfo.UnloadServo1Error == 0)
            {
                UpdateAlarm("下料站故障:伺服1报错");
            }
            if (PLCReadInfo.UnloadServo2OffLine == 0)
            {
                UpdateAlarm("下料站故障:伺服2通信掉线");
            }
            if (PLCReadInfo.UnloadServo2Error == 0)
            {
                UpdateAlarm("下料站故障:伺服2报错");
            }
            if (PLCReadInfo.UnloadUpstreamDeliveryOvertime == 0)
            {
                UpdateAlarm("下料站故障:与上游交互传送运动超时");
            }
            if (PLCReadInfo.UnloadFeedOvertime == 0)
            {
                UpdateAlarm("下料站故障:本站进料完成超时");
            }
            if (PLCReadInfo.UnloadJackReachError == 0)
            {
                UpdateAlarm("下料站故障:顶升气缸伸出限异常");
            }
            if (PLCReadInfo.UnloadPullBackReachError == 0)
            {
                UpdateAlarm("下料站故障:回拉气缸伸出限异常");
            }
            if (PLCReadInfo.UnloadClampTightLimit == 0)
            {
                UpdateAlarm("下料站故障:夹紧气缸夹紧限异常");
            }
            if (PLCReadInfo.UnloadClampReleaseLimit == 0)
            {
                UpdateAlarm("下料站故障:夹紧气缸松开限异常");
            }
            if (PLCReadInfo.UnloadPullBackReturnError == 0)
            {
                UpdateAlarm("下料站故障:回拉气缸退回限异常");
            }
            if (PLCReadInfo.UnloadManualNoAuto == 0)
            {
                UpdateAlarm("下料站故障:手动按钮未回位，不能自动启动");
            }
            if (PLCReadInfo.UnloadManualNoContinue == 0)
            {
                UpdateAlarm("下料站故障:手动按钮未回位，不能继续运行");
            }
            if (PLCReadInfo.UnloadVFDNoCom == 0)
            {
                UpdateAlarm("下料站故障:变频器通讯异常");
            }
            if (PLCReadInfo.UnloadVFDError == 0)
            {
                UpdateAlarm("下料站故障:变频器报错");
            }
        }
        /// <summary>
        /// PLC报警更新存入数据库
        /// </summary>
        /// <param name="AlarmDescription"></param>
        private static void UpdateAlarm(string AlarmDescription)
        {
            DateTime dateTime = DateTime.Now;
            string tradeTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string sql = DB_SQL.up_AlarmInfo;
            sql += 0 + "', UpdateTime ='" + tradeTime + "' where AlarmContent = '" + AlarmDescription + "' and Result='" + 1 + "'";
            using (SqlConnection conn = new SqlConnection(DB_SQL.conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message.ToString() + "打开数据库失败！");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void TimeStart()
        {
            aTimer = new System.Timers.Timer(500);
            aTimer.Elapsed += new ElapsedEventHandler(ShowTV);
            aTimer.AutoReset = true;
            aTimer.Start();
        }
        private void ShowTV(object sender, ElapsedEventArgs e)
        {
            MediaPlay();
        }
        private void MediaPlay()
        {
            if (loadInbound_Flag == 1)
            {
                Load.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Load.Source = new BitmapImage(new Uri("/Resources/Images/ABC0.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (loadOutbound_Flag == 1)
            {
                Load.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Load.Source = new BitmapImage(new Uri("/Resources/Images/ABC26.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Load.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Load.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }

            if (fillInbound_Flag == 1)
            {
                FilmMulch.Dispatcher.BeginInvoke(new Action(() =>
                {
                    FilmMulch.Source = new BitmapImage(new Uri("/Resources/Images/ABC31.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (fillOutbound_Flag == 1)
            {
                FilmMulch.Dispatcher.BeginInvoke(new Action(() =>
                {
                    FilmMulch.Source = new BitmapImage(new Uri("/Resources/Images/ABC42.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                FilmMulch.Dispatcher.BeginInvoke(new Action(() =>
                {
                    FilmMulch.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }

            if (gluingInbound_Flag == 1)
            {
                Gluing.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Gluing.Source = new BitmapImage(new Uri("/Resources/Images/ABC80.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (gluingOutbound_Flag == 1)
            {
                Gluing.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Gluing.Source = new BitmapImage(new Uri("/Resources/Images/ABC95.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Gluing.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Gluing.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }

            if (fillInbound_Flag == 1)
            {
                Fill.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Fill.Source = new BitmapImage(new Uri("/Resources/Images/ABC130.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (fillOutbound_Flag == 1)
            {
                Fill.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Fill.Source = new BitmapImage(new Uri("/Resources/Images/ABC180.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Fill.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Fill.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }

            if (polishInbound_Flag == 1)
            {
                Polish.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Polish.Source = new BitmapImage(new Uri("/Resources/Images/ABC260.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (polishOutbound_Flag == 1)
            {
                Polish.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Polish.Source = new BitmapImage(new Uri("/Resources/Images/ABC270.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Polish.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Polish.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }

            if (weldingInbound_Flag == 1)
            {
                Welding.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Welding.Source = new BitmapImage(new Uri("/Resources/Images/ABC278.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (weldingOutbound_Flag == 1)
            {
                Welding.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Welding.Source = new BitmapImage(new Uri("/Resources/Images/ABC293.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Welding.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Welding.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }

            if (removeSmokeTrainInbound_Flag == 1)
            {
                RemoveSmokeTrain.Dispatcher.BeginInvoke(new Action(() =>
                {
                    RemoveSmokeTrain.Source = new BitmapImage(new Uri("/Resources/Images/ABC305.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (removeSmokeTrainOutbound_Flag == 1)
            {
                RemoveSmokeTrain.Dispatcher.BeginInvoke(new Action(() =>
                {
                    RemoveSmokeTrain.Source = new BitmapImage(new Uri("/Resources/Images/ABC310.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                RemoveSmokeTrain.Dispatcher.BeginInvoke(new Action(() =>
                {
                    RemoveSmokeTrain.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }

            if (checkInbound_Flag == 1)
            {
                Check.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Check.Source = new BitmapImage(new Uri("/Resources/Images/ABC340.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (checkOutbound_Flag == 1)
            {
                Check.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Check.Source = new BitmapImage(new Uri("/Resources/Images/ABC346.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Check.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Check.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }

            if (unloadInbound_Flag == 1)
            {
                Unload.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Unload.Source = new BitmapImage(new Uri("/Resources/Images/ABC360.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (unloadOutbound_Flag == 1)
            {
                Unload.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Unload.Source = new BitmapImage(new Uri("/Resources/Images/ABC365.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Unload.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Unload.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void LoadImage()
        {
            if (loadInbound_Flag == 1)
            {
                Load.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Load.Source = new BitmapImage(new Uri("/Resources/Images/ABC0.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (loadOutbound_Flag == 1)
            {
                Load.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Load.Source = new BitmapImage(new Uri("/Resources/Images/ABC26.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Load.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Load.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void FilmMulchImage()
        {
            if (fillInbound_Flag == 1)
            {
                FilmMulch.Dispatcher.BeginInvoke(new Action(() =>
                {
                    FilmMulch.Source = new BitmapImage(new Uri("/Resources/Images/ABC31.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (fillOutbound_Flag == 1)
            {
                FilmMulch.Dispatcher.BeginInvoke(new Action(() =>
                {
                    FilmMulch.Source = new BitmapImage(new Uri("/Resources/Images/ABC42.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                FilmMulch.Dispatcher.BeginInvoke(new Action(() =>
                {
                    FilmMulch.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void GluingImage()
        {
            if (gluingInbound_Flag == 1)
            {
                Gluing.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Gluing.Source = new BitmapImage(new Uri("/Resources/Images/ABC80.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (gluingOutbound_Flag == 1)
            {
                Gluing.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Gluing.Source = new BitmapImage(new Uri("/Resources/Images/ABC95.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Gluing.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Gluing.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void FillImage()
        {
            if (fillInbound_Flag == 1)
            {
                Fill.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Fill.Source = new BitmapImage(new Uri("/Resources/Images/ABC130.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (fillOutbound_Flag == 1)
            {
                Fill.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Fill.Source = new BitmapImage(new Uri("/Resources/Images/ABC180.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Fill.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Fill.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void PolishImage()
        {
            if (polishInbound_Flag == 1)
            {
                Polish.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Polish.Source = new BitmapImage(new Uri("/Resources/Images/ABC260.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (polishOutbound_Flag == 1)
            {
                Polish.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Polish.Source = new BitmapImage(new Uri("/Resources/Images/ABC270.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Polish.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Polish.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void WeldingImage()
        {
            if (weldingInbound_Flag == 1)
            {
                Welding.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Welding.Source = new BitmapImage(new Uri("/Resources/Images/ABC278.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (weldingOutbound_Flag == 1)
            {
                Welding.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Welding.Source = new BitmapImage(new Uri("/Resources/Images/ABC293.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Welding.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Welding.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void RemoveSmokeTrainImage()
        {
            if (removeSmokeTrainInbound_Flag == 1)
            {
                RemoveSmokeTrain.Dispatcher.BeginInvoke(new Action(() =>
                {
                    RemoveSmokeTrain.Source = new BitmapImage(new Uri("/Resources/Images/ABC305.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (removeSmokeTrainOutbound_Flag == 1)
            {
                RemoveSmokeTrain.Dispatcher.BeginInvoke(new Action(() =>
                {
                    RemoveSmokeTrain.Source = new BitmapImage(new Uri("/Resources/Images/ABC310.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                RemoveSmokeTrain.Dispatcher.BeginInvoke(new Action(() =>
                {
                    RemoveSmokeTrain.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void CheckImage()
        {
            if (checkInbound_Flag == 1)
            {
                Check.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Check.Source = new BitmapImage(new Uri("/Resources/Images/ABC340.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (checkOutbound_Flag == 1)
            {
                Check.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Check.Source = new BitmapImage(new Uri("/Resources/Images/ABC346.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Check.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Check.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
        }
        private void UnloadImage()
        {
            if (unloadInbound_Flag == 1)
            {
                Unload.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Unload.Source = new BitmapImage(new Uri("/Resources/Images/ABC360.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else if (unloadOutbound_Flag == 1)
            {
                Unload.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Unload.Source = new BitmapImage(new Uri("/Resources/Images/ABC365.png", UriKind.RelativeOrAbsolute));
                }));
            }
            else
            {
                Unload.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Unload.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                }));
            }
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
            c_daListAnimation = new DoubleAnimation();
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
        private void ShowCurTimer(object sender, EventArgs e)
        {
            this.tbTimeText.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            this.tbTimeText.Text += " ";
            this.tbTimeText.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        private void ListAdd()
        {
            MonitorList = new ObservableCollection<PojInfo>
            {
                new PojInfo { Name = "全局监控"},
                new PojInfo { Name = "上料录入"},
                //new PojInfo { Name="临时手动录入"}
            };
            ReportList = new ObservableCollection<PojInfo>
            {
                new PojInfo { Name = "检测统计"},
                new PojInfo { Name = "生产统计"},
                new PojInfo { Name = "生产明细"}
            };
            AlarmList = new ObservableCollection<PojInfo>
            {
                new PojInfo { Name = "历史报警"}
            };
            //WorkSheetList = new ObservableCollection<PojInfo>
            //{
            //    //new PojInfo { Name = "工单作成"},
            //    new PojInfo { Name = "工单排产"}
            //};
            BasicInfoList = new ObservableCollection<PojInfo>
            {
                new PojInfo { Name = "用户管理"}
                //new PojInfo { Name = "权限管理"}
            };
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
                    if (header == "全局监控")
                    {
                        Monitor.Global uc = new Monitor.Global();
                        //LitName = header;
                        temptb.Content = uc;
                    }
                    if (header == "上料录入")
                    {
                        Monitor.LoadMaterial uc = new Monitor.LoadMaterial();
                        //LitName = header;
                        temptb.Content = uc;
                    }
                    if(header=="临时录入")
                    {
                        Monitor.TemporaryLoad uc = new Monitor.TemporaryLoad();
                        temptb.Content = uc;
                    }
                }
            }
            foreach (PojInfo p in ReportList)
            {
                if (p.Name == header)
                {
                    if (header == "检测统计")
                    {
                        Check.Check uc = new Check.Check();
                        //LitName = header;
                        temptb.Content = uc;
                    }
                    else if (header == "生产统计")
                    {
                        Product.Product uc = new Product.Product();
                        //LitName = header;
                        temptb.Content = uc;
                    }
                    else if (header == "生产明细")
                    {
                        Product.ProductionSubsidiary uc = new Product.ProductionSubsidiary();
                        //LitName = header;
                        temptb.Content = uc;
                    }
                }
            }
            foreach (PojInfo p in AlarmList)
            {
                if (p.Name == header)
                {
                    Alarm.HistoryAlarm uc = new Alarm.HistoryAlarm();
                    //LitName = header;
                    temptb.Content = uc;
                }
            }
            //foreach (PojInfo p in WorkSheetList)
            //{
            //    if (p.Name == header)
            //    {
            //        WorkSchedule uc = new WorkSchedule();
            //        LitName = header;
            //        temptb.Content = uc;
            //        //if (header == "工单作成")
            //        //{
            //        //    WorkDone uc = new WorkDone();
            //        //    LitName = header;
            //        //    temptb.Content = uc;
            //        //}
            //        //else if (header == "工单排产")
            //        //{
            //        //    WorkSchedule uc = new WorkSchedule();
            //        //    LitName = header;
            //        //    temptb.Content = uc;
            //        //}
            //    }
            //}
            foreach (PojInfo p in BasicInfoList)
            {
                if (p.Name == header)
                {
                    BasicInfo.UserInfo uc = new BasicInfo.UserInfo();
                    //LitName = header;
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
        public class Test
        {
            public int Id { get; set; }
        }
    }
}
