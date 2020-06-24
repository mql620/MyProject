using JM_GluingSystem.Common.Class;
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

namespace JM_GluingSystem.Views.Product
{
    /// <summary>
    /// SubsidiaryDetails.xaml 的交互逻辑
    /// </summary>
    public partial class SubsidiaryDetails : Window
    {
        public delegate void BackgroundChange();
        public event BackgroundChange bkChange;
        public SubsidiaryDetails(string doorID, string orderNum)
        {
            InitializeComponent();
            SelectedDetails(doorID, orderNum);
        }

        private void SelectedDetails(string doorID, string orderNum)
        {
            SubsidiaryInformation subsidiaryInformation = DB_ProductionSubsidiary.SearchInfoByID(doorID, orderNum);
            if (subsidiaryInformation != null)
            {
                DoorID.Text = subsidiaryInformation.DoorID;
                DoorMold.Text = subsidiaryInformation.DoorMold;
                OrderNum.Text = subsidiaryInformation.OrderNum;
                OpenDirection.Text = subsidiaryInformation.OpenDirection;
                Thickness.Text = subsidiaryInformation.Thickness.ToString();
                ThinPlateLengthWidth.Text = subsidiaryInformation.ThinPlateLength.ToString() + "," + subsidiaryInformation.ThinPlateWidth.ToString();
                ThickPlateLengthWidth.Text = subsidiaryInformation.ThickPlateLength.ToString() + "," + subsidiaryInformation.ThickPlateWidth.ToString();
                FeedingTime.Text = subsidiaryInformation.FeedingTime;
                BlankingTime.Text = subsidiaryInformation.BlankingTime;
                LaminationDosage.Text = subsidiaryInformation.LaminationDosage.ToString();
                Allowance.Text = subsidiaryInformation.EpisporiumAllowance.ToString() + "," + subsidiaryInformation.CounterdieAllowance.ToString();
                CuttingLengthWidth.Text = subsidiaryInformation.CuttingLength.ToString() + "," + subsidiaryInformation.CuttingWidth.ToString();
                ThinPlateKeyholeXY.Text = subsidiaryInformation.ThinPlateKeyholeX.ToString() + "," + subsidiaryInformation.ThinPlateKeyholeY.ToString();
                ThickPlateKeyholeXY.Text = subsidiaryInformation.ThickPlateKeyholeX.ToString() + "," + subsidiaryInformation.ThickPlateKeyholeY.ToString();
                ThinPlateViewerXY.Text = subsidiaryInformation.ThinPlateViewerX.ToString() + "," + subsidiaryInformation.ThinPlateViewerY.ToString();
                ThickPlateViewerXY.Text = subsidiaryInformation.ThickPlateViewerX.ToString() + "," + subsidiaryInformation.ThickPlateViewerY.ToString();
                ActualSerlantVolume.Text = subsidiaryInformation.ActualSerlantVolume.ToString();
                QuantityGlue.Text = subsidiaryInformation.QuantityGlue.ToString();
                GelatinizeTime.Text = subsidiaryInformation.GelatinizeTime.ToString();

                LaminationPullInTime.Text = subsidiaryInformation.LaminationPullInTime;
                LaminationPullOutTime.Text = subsidiaryInformation.LaminationPullOutTime;
                GluingPullInTime.Text = subsidiaryInformation.GluingPullInTime;
                GluingPullOutTime.Text = subsidiaryInformation.GluingPullOutTime;
                PressFitPullInTime.Text = subsidiaryInformation.PressFitPullInTime;
                PressFitPullOutTime.Text = subsidiaryInformation.PressFitPullOutTime;
                PressFitTemperature.Text = subsidiaryInformation.PressFitTemperature.ToString();
                PolishedPullInTime.Text = subsidiaryInformation.PolishedPullInTime;
                PolishedPullOutTime.Text = subsidiaryInformation.PolishedPullOutTime;
                WeldingPullInTime.Text = subsidiaryInformation.WeldingPullInTime;
                WeldingPullOutTime.Text = subsidiaryInformation.WeldingPullOutTime;
                WeldingVoltage.Text = subsidiaryInformation.WeldingVoltage.ToString();
                WeldingElectricity.Text = subsidiaryInformation.WeldingElectricity.ToString();
                WeldingSpendTime.Text = subsidiaryInformation.WeldingSpendTime.ToString();
                WireFeedRate.Text = subsidiaryInformation.WireFeedRate.ToString();
                PerliteLengthWidth.Text = subsidiaryInformation.PerliteLength.ToString() + "," + subsidiaryInformation.PerliteWidth.ToString();
                PerliteThickness.Text = subsidiaryInformation.PerliteThickness.ToString();
                VisualInspectionResult.Text = subsidiaryInformation.VisualInspectionResult;
                LockLengthWidth.Text = subsidiaryInformation.LockLength.ToString() + "," + subsidiaryInformation.LockWidth.ToString();

                PerliteFillingPullInTime.Text = subsidiaryInformation.PerliteFillingPullInTime;
                PerliteFillingPullOutTime.Text = subsidiaryInformation.PerliteFillingPullOutTime;
                WeldSpacingUpDownStr.Text = subsidiaryInformation.WeldSpacingUpDownStr;
                WeldSpacingHingeStr.Text = subsidiaryInformation.WeldSpacingHingeStr;
                WeldSpacingKeyholeStr.Text = subsidiaryInformation.WeldSpacingKeyholeStr;
                WeldNumUpDown.Text = subsidiaryInformation.WeldNumUpDown.ToString();
                WeldNumHinge.Text = subsidiaryInformation.WeldNumHinge.ToString();
                WeldNumKeyhole.Text = subsidiaryInformation.WeldNumKeyhole.ToString();
                SprayPaintPullInTime.Text = subsidiaryInformation.SprayPaintPullInTime;
                SprayPaintPullOutTime.Text = subsidiaryInformation.SprayPaintPullOutTime;
                SprayPaintSpendTime.Text = subsidiaryInformation.SprayPaintSpendTime.ToString();
                VisualInspectionPullInTime.Text = subsidiaryInformation.VisualInspectionPullInTime;
                VisualInspectionPullOutTime.Text = subsidiaryInformation.VisualInspectionPullOutTime;
            }
        }

        private void WindowClose(object sender, EventArgs e)
        {
            if (bkChange != null)
                bkChange();
            Close();
        }
    }
}
