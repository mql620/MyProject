using JM_GluingSystem.Common;
using JM_GluingSystem.DB;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace JM_GluingSystem.Views.Check
{
    /// <summary>
    /// TestDetails.xaml 的交互逻辑
    /// </summary>
    public partial class TestDetails : Window
    {
        public delegate void BackgroundChange();
        public event BackgroundChange bkChange;
        public TestDetails(string doorID, string orderNum)
        {
            InitializeComponent();
            SelectedDetails(doorID, orderNum);
        }
        private void SelectedDetails(string doorID, string orderNum)
        {
            TestingResultInformation testingResultInformation = DB_TestingResult.SearchInfoByID(doorID, orderNum);
            txt_DoorEdgeResult0.Text = testingResultInformation.DoorEdgeResult0;
            txt_DoorEdgeFailedReason0.Text = testingResultInformation.DoorEdgeFailedReason0;
            txt_DoorEdgeResult1.Text = testingResultInformation.DoorEdgeResult1;
            txt_DoorEdgeFailedReason1.Text = testingResultInformation.DoorEdgeFailedReason1;
            txt_DoorEdgeResult2.Text = testingResultInformation.DoorEdgeResult2;
            txt_DoorEdgeFailedReason2.Text = testingResultInformation.DoorEdgeFailedReason2;
            txt_DoorEdgeResult3.Text = testingResultInformation.DoorEdgeResult3;
            txt_DoorEdgeFailedReason3.Text = testingResultInformation.DoorEdgeFailedReason3;

            //resultImage1.Source = new BitmapImage(new Uri(testingResultInformation.AroundImagePath, UriKind.Absolute));
            //resultImage2.Source = new BitmapImage(new Uri(testingResultInformation.WideLockImagePath, UriKind.Absolute));
            //resultImage3.Source = new BitmapImage(new Uri(testingResultInformation.WideHingeImagePath, UriKind.Absolute));
            //resultImage4.Source = new BitmapImage(new Uri(testingResultInformation.WideHingeImagePath, UriKind.Absolute));
        }

        private void WindowClose(object sender, EventArgs e)
        {
            if (bkChange != null)
                bkChange();
            Close();
        }
    }
}
