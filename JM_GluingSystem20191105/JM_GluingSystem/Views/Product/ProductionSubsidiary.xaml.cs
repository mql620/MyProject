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

namespace JM_GluingSystem.Views.Product
{
    /// <summary>
    /// ProductionSubsidiary.xaml 的交互逻辑
    /// </summary>
    public partial class ProductionSubsidiary : UserControl
    {
        public ProductionSubsidiary()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SubsidiaryInfo_DgSource_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void SearchSubsidiaryInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker1.Text.Trim() == "" || DatePicker2.Text.Trim() == "")
            {
                MessageBox.Show("时间不可以为空！");
            }
            else
            {
                DateTime dt1 = Convert.ToDateTime(DatePicker1.Text.Trim());
                DateTime dt2 = Convert.ToDateTime(DatePicker2.Text.Trim());
                string time = dt2.AddDays(1).ToString();
                DataTable dt = DB_ProductionSubsidiary.SearchSubsidiaryInfo(DatePicker1.Text.Trim(), time);
                if (dt != null)
                {
                    SubsidiaryInfo_DgSource.ItemsSource = dt.DefaultView;
                    SubsidiaryInfo_Page.ShowPages(SubsidiaryInfo_DgSource,dt,17);
                }
            }
        }

        private void changeBk()
        {
            this.borderBody.Visibility = Visibility.Hidden;
        }

        private void SubsidiaryDetailsInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView myselect = (DataRowView)SubsidiaryInfo_DgSource.SelectedItem;
            if (myselect != null)
            {
                this.borderBody.Visibility = Visibility.Visible;
                string doorID = myselect.Row[1].ToString();
                string orderNum = myselect.Row[3].ToString();
                SubsidiaryDetails subsidiaryDetails = new SubsidiaryDetails(doorID, orderNum);
                subsidiaryDetails.Owner = this.Parent as Window;
                subsidiaryDetails.bkChange += new SubsidiaryDetails.BackgroundChange(changeBk);
                subsidiaryDetails.ShowDialog();
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
                new DataColumn("DoorID",typeof(string)),
                new DataColumn("DoorMold",typeof(string)),
                new DataColumn("OrderNum",typeof(string)),
                new DataColumn("FeedingTime",typeof(string)),
                new DataColumn("BlankingTime",typeof(string))
            });
            return dt;
        }
    }
}
