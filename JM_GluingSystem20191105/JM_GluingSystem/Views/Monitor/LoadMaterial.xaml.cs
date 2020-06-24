using JM_GluingSystem.Common;
using JM_GluingSystem.Common.Class;
using JM_GluingSystem.DB;
using System;
using System.Collections.Generic;
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

namespace JM_GluingSystem.Views.Monitor
{
    /// <summary>
    /// LoadMaterial.xaml 的交互逻辑
    /// </summary>
    public partial class LoadMaterial : UserControl
    {
        public DoorInformation doorInformation;

        public LoadMaterial()
        {
            InitializeComponent();
            DoorInfoOutPutGrid.Visibility = Visibility.Hidden;
            SubmitBtn.IsEnabled = false;
        }

        private void DoorChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            string orderNoTxt = OrderNum.Text.Trim();
            if (orderNoTxt == "")
            {
                MessageBox.Show("订单编号不可为空");
            }
            else
            {
                string ponputChooseTxt = PonputChoose.Text.Trim();
                string doorMoldCombTxt = DoorMoldComb.Text.Trim();
                string stackPositionCombTxt = StackPositionComb.Text.Trim();
                string doorNumChooseTxt = DoorNumChoose.Text.Trim();
                string PerliteStackPositionTxt = PerliteStackPosition.Text.Trim();

                doorInformation = new DoorInformation();
                doorInformation.LoadBatchID = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
                doorInformation.OrderNum = orderNoTxt;
                doorInformation.DoorMold = doorMoldCombTxt;
                doorInformation.PlacementMode = ponputChooseTxt;
                doorInformation.ThicknessDistinguish = "厚板";
                doorInformation.StackPosition = stackPositionCombTxt;
                doorInformation.PerlitePosition = PerliteStackPositionTxt;
                int.TryParse(doorNumChooseTxt, out int num);
                doorInformation.LoadNum = num;
                doorInformation.SentNum = 0;
                doorInformation.Status = "0";

                OrderInformation orderInformation = DB_OrderInfo.SearchOrderInfoByOrderNum(orderNoTxt);
                if (orderInformation != null)
                {
                    if (orderInformation.ProductLine == doorMoldCombTxt)
                    {
                        doorInformation.OpenDirection = orderInformation.OpenTo;
                        int.TryParse(orderInformation.DoorThickness, out int thickness);
                        doorInformation.Thickness = thickness;
                        int.TryParse(orderInformation.OrderQuantity,out int quantity);
                        doorInformation.OrderQuantity = quantity;

                        DoorInfoCalculate.DoorModel(orderInformation, out int thinPlateLength, out int thinPlateWidth,
                            out int thickPlateLength, out int thickPlateWidth);
                        doorInformation.ThinPlateLength = thinPlateLength;
                        doorInformation.ThinPlateWidth = thinPlateWidth;
                        doorInformation.ThickPlateLength = thickPlateLength;
                        doorInformation.ThickPlateWidth = thickPlateWidth;

                        doorInformation.LaminationDosage = DoorInfoCalculate.Lamination(orderInformation);

                        DoorInfoCalculate.Gluing(orderInformation, out int thinPlateKeyholeX, out int thinPlateKeyholeY,
                            out int thickPlateKeyholeX, out int thickPlateKeyholeY, out int thinPlateViewerX,
                            out int thinPlateViewerY, out int thickPlateViewerX, out int thickPlateViewerY, 
                            out int lockWidth, out int lockLength);
                        doorInformation.ThinPlateKeyholeX = thinPlateKeyholeX;
                        doorInformation.ThinPlateKeyholeY = thinPlateKeyholeY;
                        doorInformation.ThickPlateKeyholeX = thickPlateKeyholeX;
                        doorInformation.ThickPlateKeyholeY = thickPlateKeyholeY;
                        doorInformation.ThinPlateViewerX = thinPlateViewerX;
                        doorInformation.ThinPlateViewerY = thinPlateViewerY;
                        doorInformation.ThickPlateViewerX = thickPlateViewerX;
                        doorInformation.ThickPlateViewerY = thickPlateViewerY;
                        doorInformation.LockWidth = lockWidth;
                        doorInformation.LockLength = lockLength;

                        if (doorInformation.DoorMold == "防火门")
                        {
                            DoorInfoCalculate.PerliteFilling(orderInformation, out int perliteLength, out int perliteWidth);
                            doorInformation.PerliteLength = perliteLength;
                            doorInformation.PerliteWidth = perliteWidth;
                            doorInformation.PerliteThickness = thickness - 2;
                        }
                        else
                        {
                            doorInformation.PerliteLength = 0;
                            doorInformation.PerliteWidth = 0;
                            doorInformation.PerliteThickness = 0;
                        }
                            
                        DoorInfoCalculate.GrindingWelding(orderInformation, thickPlateLength, thickPlateWidth, out int[] weldSpacingUpDown,
                            out int[] weldSpacingHinge, out int[] weldSpacingKeyhole, out int weldNumUpDown, out int weldNumHinge, out int weldNumKeyhole);
                        doorInformation.WeldNumUpDown = weldNumUpDown;
                        doorInformation.WeldSpacingUpDown = weldSpacingUpDown;
                        doorInformation.WeldNumHinge = weldNumHinge;
                        doorInformation.WeldSpacingHinge = weldSpacingHinge;
                        doorInformation.WeldNumKeyhole = weldNumKeyhole;
                        doorInformation.WeldSpacingKeyhole = weldSpacingKeyhole;

                        string spacingUpDown = doorInformation.WeldSpacingUpDown[0].ToString();
                        for (int i = 1; i < doorInformation.WeldNumUpDown; i++)
                        {
                            spacingUpDown = spacingUpDown + ",";
                            spacingUpDown = spacingUpDown + doorInformation.WeldSpacingUpDown[i].ToString();
                        }
                        doorInformation.WeldSpacingUpDownStr = spacingUpDown;
                        string spacingHinge = doorInformation.WeldSpacingHinge[0].ToString();
                        for (int i = 1; i < doorInformation.WeldNumHinge; i++)
                        {
                            spacingHinge = spacingHinge + ",";
                            spacingHinge = spacingHinge + doorInformation.WeldSpacingHinge[i].ToString();
                        }
                        doorInformation.WeldSpacingHingeStr = spacingHinge;
                        string spacingKeyhole = doorInformation.WeldSpacingKeyhole[0].ToString();
                        for (int i = 1; i < doorInformation.WeldNumKeyhole; i++)
                        {
                            spacingKeyhole = spacingKeyhole + ",";
                            spacingKeyhole = spacingKeyhole + doorInformation.WeldSpacingKeyhole[i].ToString();
                        }
                        doorInformation.WeldSpacingKeyholeStr = spacingKeyhole;

                        DoorInfoShow(doorInformation);
                    }
                    else
                    {
                        MessageBox.Show("该订单门类型不符！");
                    }
                }
            }
        }

        private void DoorInfoShow(DoorInformation doorInfo)
        {
            OpenDirection.Text = doorInfo.OpenDirection;
            ThinPlateLength.Text = doorInfo.ThinPlateLength.ToString();
            ThinPlateWidth.Text = doorInfo.ThinPlateWidth.ToString();
            ThickPlateLength.Text = doorInfo.ThickPlateLength.ToString();
            ThickPlateWidth.Text = doorInfo.ThickPlateWidth.ToString();
            Thickness.Text = doorInfo.Thickness.ToString();
            ThinPlateKeyholeX.Text = doorInfo.ThinPlateKeyholeX.ToString();
            ThinPlateKeyholeY.Text = doorInfo.ThinPlateKeyholeY.ToString();
            ThickPlateKeyholeX.Text = doorInfo.ThickPlateKeyholeX.ToString();
            ThickPlateKeyholeY.Text = doorInfo.ThickPlateKeyholeY.ToString();

            WeldNumUpDown.Text = doorInfo.WeldNumUpDown.ToString();
            WeldNumHinge.Text = doorInfo.WeldNumHinge.ToString();
            WeldNumKeyhole.Text = doorInfo.WeldNumKeyhole.ToString();
            PerliteLength.Text = doorInfo.PerliteLength.ToString();
            PerliteWidth.Text = doorInfo.PerliteWidth.ToString();
            PerliteThickness.Text = doorInfo.PerliteThickness.ToString();
            ThinPlateViewerX.Text = doorInfo.ThinPlateViewerX.ToString();
            ThinPlateViewerY.Text = doorInfo.ThinPlateViewerY.ToString();
            ThickPlateViewerX.Text = doorInfo.ThickPlateViewerX.ToString();
            ThickPlateViewerY.Text = doorInfo.ThickPlateViewerY.ToString();

            WeldSpacingUpDown.Text = doorInfo.WeldSpacingUpDownStr;
            WeldSpacingHinge.Text = doorInfo.WeldSpacingHingeStr;
            WeldSpacingKeyhole.Text = doorInfo.WeldSpacingKeyholeStr;
            LaminationDosage.Text = doorInfo.LaminationDosage.ToString();
            LockLengthWidth.Text = doorInfo.LockLength.ToString() + "/" + doorInfo.LockWidth.ToString();

            DoorInfoOutPutGrid.Visibility = Visibility.Visible;
            SubmitBtn.IsEnabled = true;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定提交该上料信息？", "提示", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (doorInformation != null)
                    {
                        if (DB_DoorInfo.SearchLoadBatchID(doorInformation.LoadBatchID))
                        {
                            MessageBox.Show("该批次上料门已经录入，请勿重复录入！");
                        }
                        else
                        {
                            if (DB_DoorInfo.SearchOrderNum(doorInformation.OrderNum))
                            {
                                int loadNumAll = DB_DoorInfo.SearchLoadNumAllByOrderNum(doorInformation.OrderNum, out int orderQuantity);
                                int loadNumPlus = loadNumAll + doorInformation.LoadNum;
                                if (loadNumPlus > orderQuantity)
                                {
                                    MessageBox.Show("上料数量已超出订单数量，共超出" + (loadNumPlus - orderQuantity).ToString() + "扇门！");
                                }
                                else
                                {
                                    if (DB_DoorInfo.InsertLoadDoorInfo(doorInformation))
                                    {
                                        doorInformation = null;
                                        DoorInfoOutPutGrid.Visibility = Visibility.Hidden;
                                        SubmitBtn.IsEnabled = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("上料信息提交失败！");
                                    }
                                }
                            }
                            else
                            {
                                if (doorInformation.LoadNum > doorInformation.OrderQuantity)
                                {
                                    MessageBox.Show("上料数量已超出订单数量，共超出" + (doorInformation.LoadNum - doorInformation.OrderQuantity).ToString() + "扇门！");
                                }
                                else
                                {
                                    if (DB_DoorInfo.InsertLoadDoorInfo(doorInformation))
                                    {
                                        doorInformation = null;
                                        DoorInfoOutPutGrid.Visibility = Visibility.Hidden;
                                        SubmitBtn.IsEnabled = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("上料信息提交失败");
                                    }
                                }
                            }                           
                        }
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }   
        }
    }
}
