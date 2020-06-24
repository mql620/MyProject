using JM_GluingSystem.DB;
using LiveCharts;
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
    /// Product.xaml 的交互逻辑
    /// </summary>
    public partial class Product : UserControl
    {
        List<string> name = new List<string>();
        List<double> output = new List<double>();
        List<double> Qualified = new List<double>();
        public Product()
        {
            InitializeComponent();
            mychart.LegendLocation = LegendLocation.Top;
            myaxis.Separator.Stroke = Brushes.Red;
            myaxis.Separator.Step = 1;
            myaxis.Title = "门类型";
            myaxis.FontSize = 14;
            myaxis.LabelsRotation = 45;

            mytootip.Background = Brushes.LightGray;
            mytootip.SelectionMode = TooltipSelectionMode.OnlySender;
            mytootip.CornerRadius = new CornerRadius(5);
            mytootip.BorderThickness = new Thickness(2);

            DataContext = this;
        }
        private void ProductInfo_DgSource_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        private void SearchProductInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            string datePicker1 = DatePicker1.Text.Trim();
            string datePicker2 = DatePicker2.Text.Trim();
            if (datePicker1 == "" || datePicker2 == "")
            {
                MessageBox.Show("时间不可以为空！");
            }
            else
            {
                name.Clear();
                output.Clear();
                Qualified.Clear();
                DataTable dt = DB_Product.searchProductInfo(datePicker1, datePicker2);
                if (dt != null)
                {
                    ProductInfo_DgSource.ItemsSource = dt.DefaultView;
                    ProductInfo_Page.ShowPages(ProductInfo_DgSource, dt, 9);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name.Add(dt.Rows[i][1].ToString().Trim());
                    output.Add(Convert.ToDouble(dt.Rows[i][2]));
                    Qualified.Add(Convert.ToDouble(dt.Rows[i][3]));
                }
                myaxis.Labels = name.ToArray();
                outputline.Values = new ChartValues<double>(output);
                Qualifiedline.Values = new ChartValues<double>(Qualified);
            }
        }
        public static DataTable GetTableSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                //new DataColumn("GateMold",typeof(string)),
                new DataColumn("OrderNum",typeof(string)),
                new DataColumn("ProductionTime",typeof(string)),
                new DataColumn("Output",typeof(string)),
                new DataColumn("QualifiedNumber",typeof(string))
            });
            return dt;
        }
    }
}
