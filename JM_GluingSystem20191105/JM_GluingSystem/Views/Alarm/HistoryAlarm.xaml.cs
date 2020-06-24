using JM_GluingSystem.DB;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace JM_GluingSystem.Views.Alarm
{
    /// <summary>
    /// HistoryAlarm.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryAlarm : UserControl
    {
        public HistoryAlarm()
        {
            InitializeComponent();
            AlarmInfo_DgSource.LoadingRow += new EventHandler<DataGridRowEventArgs>(dataGrid_LoadingRow);
        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void SearchAlarmInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            string alarmDatePicker1 = AlarmDatePicker1.Text;
            string alarmDatePicker2 = AlarmDatePicker2.Text;
            string selKeyTxt = SelKeyTxt.Text;
            DataTable dt = DB_Alarm.searchAlarmInfo(alarmDatePicker1, alarmDatePicker2, selKeyTxt);
            if (dt != null)
            {
                AlarmInfo_DgSource.ItemsSource = dt.DefaultView;
                AlarmInfo_Page.ShowPages(AlarmInfo_DgSource, dt, 17);
            }
        }
        public static DataTable GetAlarmTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("AlarmTime",typeof(string)),
                new DataColumn("AlarmContent",typeof(string)),
                new DataColumn("Result",typeof(string))
            });
            return dt;
        }
    }
}
