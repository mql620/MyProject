using JM_GluingSystem.DB;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JM_GluingSystem.Views.Check
{
    /// <summary>
    /// Check.xaml 的交互逻辑
    /// </summary>
    public partial class Check : UserControl
    {
        List<string> name = new List<string>();
        List<double> dislocation_LeftAndRight = new List<double>();
        List<double> dislocation_TopAndBottom = new List<double>();
        List<double> rightFit = new List<double>();
        List<double> wideTemplate = new List<double>();
        List<double> wireResidual = new List<double>();
        List<double> meltThrough = new List<double>();
        List<double> solderJointOversize = new List<double>();
        List<double> weldJointOversize = new List<double>();
        public Check()
        {
            InitializeComponent();
            mychart.LegendLocation = LegendLocation.Top;
            myaxis.Separator.Stroke = Brushes.Red;
            myaxis.Separator.Step = 1;
            myaxis.Title = "检测时间";
            myaxis.FontSize = 14;
            myaxis.LabelsRotation = 45;

            mytootip.Background = Brushes.LightGray;
            mytootip.SelectionMode = TooltipSelectionMode.OnlySender;
            mytootip.CornerRadius = new CornerRadius(5);
            mytootip.BorderThickness = new Thickness(2);

            DataContext = this;
        }
        private void SearchWorkInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker1.Text.Trim() == "" || DatePicker2.Text.Trim() == "")
            {
                MessageBox.Show("时间不可以为空！");
            }
            else
            {
                name.Clear();
                dislocation_LeftAndRight.Clear();
                dislocation_TopAndBottom.Clear();
                rightFit.Clear();
                wideTemplate.Clear();
                wireResidual.Clear();
                meltThrough.Clear();
                solderJointOversize.Clear();
                weldJointOversize.Clear();

                DateTime dt1 = Convert.ToDateTime(DatePicker1.Text.Trim());
                DateTime dt2 = Convert.ToDateTime(DatePicker2.Text.Trim());
                string time = dt2.AddDays(1).ToString();
                DataTable dt = DB_TestingResult.SearchResultInfo(DatePicker1.Text.Trim(), time);
                if (dt != null)
                {
                    CheckInfo_DgSource.ItemsSource = dt.DefaultView;
                    CheckInfo_Page.ShowPages(CheckInfo_DgSource, dt, 9);
                }
                // 计算时间差
                TimeSpan ts1 = new TimeSpan(dt1.Ticks);
                TimeSpan ts2 = new TimeSpan(dt2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                int dateDiff = ts.Days;
                if (dateDiff < 14) // 时间差不超过两周
                {
                    for (int i = 0; i <= dateDiff; i++)
                    {
                        int[] n = new int[8]; //每天NG个数的数组
                        string tradeTime = dt1.AddDays(i).ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
                        for (int j = 0; j < 8; j++)
                        {
                            int n0 = DB_TestingResult.SearchNGCountNum(tradeTime, j, "0");//第一条边
                            int n1 = DB_TestingResult.SearchNGCountNum(tradeTime, j, "1");//第二条边
                            int n2 = DB_TestingResult.SearchNGCountNum(tradeTime, j, "2");//第三条边
                            int n3 = DB_TestingResult.SearchNGCountNum(tradeTime, j, "3");//第四条边
                            n[j] = n0 + n1 + n2 + n3;//累加每种NG原因的个数
                        }
                        name.Add(tradeTime);
                        dislocation_LeftAndRight.Add(n[0]);
                        dislocation_TopAndBottom.Add(n[1]);
                        rightFit.Add(n[2]);
                        wideTemplate.Add(n[3]);
                        wireResidual.Add(n[4]);
                        meltThrough.Add(n[5]);
                        solderJointOversize.Add(n[6]);
                        weldJointOversize.Add(n[7]);
                    }
                }
                else
                {
                    string weekStart = dt1.DayOfWeek.ToString(); //获得起始日期是星期几
                    //string weekStop = dt2.DayOfWeek.ToString();
                    int weekOneCount = 0; //第一周的天数
                    switch (weekStart)
                    {
                        case "Monday":
                            weekOneCount = 7;
                            break;
                        case "Tuesday":
                            weekOneCount = 6;
                            break;
                        case "Wednesday":
                            weekOneCount = 5;
                            break;
                        case "Thursday":
                            weekOneCount = 4;
                            break;
                        case "Friday":
                            weekOneCount = 3;
                            break;
                        case "Saturday":
                            weekOneCount = 2;
                            break;
                        case "Sunday":
                            weekOneCount = 1;
                            break;
                    }
                    int dateDiffNum = dateDiff + 1 - weekOneCount; //扣除第一周所剩余的天数
                    int weekCount = 1; //周数
                    int[] n = new int[1];//放每周天数的数组(数组必须先定义长度，目前已经确定第一周天数，故先定义数组长度为1)
                    n[0] = weekOneCount;  //第一周的天数
                    do //计算从第二周开始每周天数
                    {
                        weekCount++;
                        int count = dateDiffNum;
                        dateDiffNum = dateDiffNum - 7;
                        Array.Resize<int>(ref n, weekCount);//调整数组长度
                        if (dateDiffNum < 0)
                            n[weekCount - 1] = count;
                        else
                            n[weekCount - 1] = 7;
                    } while (dateDiffNum > 0);
                    //计算NG个数
                    for (int i = 0; i < weekCount; i++) //按周循环
                    {
                        DateTime date = dt1;
                        for (int x = 0; x < i; x++) // 计算该周周一日期
                        {
                            date = date.AddDays(n[x]);
                        }
                        int daysNum = n[i]; //该周天数
                        int[] NGCount = new int[8];  //每周NG个数的数组
                        for (int j = 0; j < daysNum; j++)  // 该周按天循环
                        {
                            string tradeTime = date.AddDays(j).ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo); //日期
                            for (int k = 0; k < 8; k++) //按NG原因循环
                            {
                                int n0 = DB_TestingResult.SearchNGCountNum(tradeTime, k, "0"); //第一条边
                                int n1 = DB_TestingResult.SearchNGCountNum(tradeTime, k, "1"); //第二条边
                                int n2 = DB_TestingResult.SearchNGCountNum(tradeTime, k, "2"); //第三条边
                                int n3 = DB_TestingResult.SearchNGCountNum(tradeTime, k, "3"); //第四条边
                                NGCount[k] = NGCount[k] + n0 + n1 + n2 + n3; //累加每种NG原因的个数
                            }
                        }
                        name.Add(date.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo) + "-" + date.AddDays(daysNum - 1).ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo));
                        dislocation_LeftAndRight.Add(NGCount[0]);
                        dislocation_TopAndBottom.Add(NGCount[1]);
                        rightFit.Add(NGCount[2]);
                        wideTemplate.Add(NGCount[3]);
                        wireResidual.Add(NGCount[4]);
                        meltThrough.Add(NGCount[5]);
                        solderJointOversize.Add(NGCount[6]);
                        weldJointOversize.Add(NGCount[7]);
                    }
                }
                myaxis.Labels = name.ToArray();
                BuckleDislocation_LeftAndRightLine.Values = new ChartValues<double>(dislocation_LeftAndRight);
                BuckleDislocation_TopAndBottomLine.Values = new ChartValues<double>(dislocation_TopAndBottom);
                RightFitLine.Values = new ChartValues<double>(rightFit);
                WideTemplateLine.Values = new ChartValues<double>(wideTemplate);
                WireResidualLine.Values = new ChartValues<double>(wireResidual);
                MeltThroughLine.Values = new ChartValues<double>(meltThrough);
                SolderJointOversizeLine.Values = new ChartValues<double>(solderJointOversize);
                WeldJointOversizeLine.Values = new ChartValues<double>(weldJointOversize);
            }
        }
        private void changeBk()
        {
            this.borderBody.Visibility = Visibility.Hidden;
        }
        private void TestDetailsInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView myselect = (DataRowView)CheckInfo_DgSource.SelectedItem;
            if (myselect != null)
            {
                this.borderBody.Visibility = Visibility.Visible;
                string doorID = myselect.Row[0].ToString();
                string orderNum = myselect.Row[2].ToString();
                TestDetails testDetails = new TestDetails(doorID, orderNum);
                testDetails.Owner = this.Parent as Window;
                testDetails.bkChange += new TestDetails.BackgroundChange(changeBk);
                testDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("未选中数据！");
            }
        }
        public static DataTable GetTableSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                //new DataColumn("GateMold",typeof(string)),
                new DataColumn("DoorID",typeof(string)),
                new DataColumn("DoorMold",typeof(string)),
                new DataColumn("OrderNum",typeof(string)),
                new DataColumn("TestingTime",typeof(string)),
                new DataColumn("Result",typeof(string))
            });
            return dt;
        }


    }
}
