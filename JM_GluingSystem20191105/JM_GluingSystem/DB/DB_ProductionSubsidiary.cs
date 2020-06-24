using JM_GluingSystem.Common.Class;
using JM_GluingSystem.Views.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JM_GluingSystem.DB
{
    class DB_ProductionSubsidiary
    {
        /// <summary>
        /// 查询生产信息
        /// </summary>
        /// <param name="datePicker1">起始时间</param>
        /// <param name="datePicker2">终止时间</param>
        /// <returns>生产信息</returns>
        public static DataTable SearchSubsidiaryInfo(string datePicker1, string datePicker2)
        {
            DataTable dt = ProductionSubsidiary.GetTableSchema();
            string sql = DB_SQL.Sel_SubsidiaryInfo(datePicker1, datePicker2);
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader objSqlReader = null;
            try
            {
                using (conn = new SqlConnection(DB_SQL.conStr))
                {
                    using (cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        objSqlReader = cmd.ExecuteReader();
                        int n = 0;
                        while (objSqlReader.Read())
                        {
                            n += 1;
                            DataRow dr = dt.NewRow();
                            dr[0] = objSqlReader[0].ToString();
                            dr[1] = objSqlReader[1].ToString();
                            dr[2] = objSqlReader[2].ToString();
                            dr[3] = objSqlReader[3].ToString();
                            dr[4] = objSqlReader[4].ToString();
                            dt.Rows.Add(dr);
                        }
                        if (n == 0)
                            MessageBox.Show("没有生产数据！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败！");
            }
            finally
            {
                if (objSqlReader != null)
                    objSqlReader.Close();
                if (cmd != null)
                    cmd.Dispose();
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dt;
        }

        /// <summary>
        /// 查询生产信息详情
        /// </summary>
        /// <param name="doorID">门ID</param>
        /// <param name="workSheetNumber">工单编号</param>
        /// <returns>详情信息</returns>
        public static SubsidiaryInformation SearchInfoByID(string doorID, string workSheetNumber)
        {
            SubsidiaryInformation subsidiaryInformation = null;
            string sql = DB_SQL.Sel_SubsidiaryInfoByID(doorID, workSheetNumber);
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader objSqlReader = null;
            try
            {
                using (conn = new SqlConnection(DB_SQL.conStr))
                {
                    using (cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        objSqlReader = cmd.ExecuteReader();
                        int n = 0;
                        while (objSqlReader.Read())
                        {
                            subsidiaryInformation = new SubsidiaryInformation();
                            subsidiaryInformation.DoorID = objSqlReader[0].ToString();
                            subsidiaryInformation.DoorMold = objSqlReader[1].ToString();
                            subsidiaryInformation.OrderNum = objSqlReader[2].ToString();
                            subsidiaryInformation.OpenDirection = objSqlReader[3].ToString();
                            int.TryParse(objSqlReader[4].ToString(), out int thinPlateLength);
                            subsidiaryInformation.ThinPlateLength = thinPlateLength;
                            int.TryParse(objSqlReader[5].ToString(), out int thinPlateWidth);
                            subsidiaryInformation.ThinPlateWidth = thinPlateWidth;
                            int.TryParse(objSqlReader[6].ToString(), out int thickPlateLength);
                            subsidiaryInformation.ThickPlateLength = thickPlateLength;
                            int.TryParse(objSqlReader[7].ToString(), out int thickPlateWidth);
                            subsidiaryInformation.ThickPlateWidth = thickPlateWidth;
                            int.TryParse(objSqlReader[8].ToString(), out int thickness);
                            subsidiaryInformation.Thickness = thickness;
                            subsidiaryInformation.FeedingTime = objSqlReader[9].ToString();
                            subsidiaryInformation.LaminationPullInTime = objSqlReader[10].ToString();
                            subsidiaryInformation.LaminationPullOutTime = objSqlReader[11].ToString();
                            int.TryParse(objSqlReader[12].ToString(), out int laminationDosage);
                            subsidiaryInformation.LaminationDosage = laminationDosage;
                            int.TryParse(objSqlReader[13].ToString(), out int episporiumAllowance);
                            subsidiaryInformation.EpisporiumAllowance = episporiumAllowance;
                            int.TryParse(objSqlReader[14].ToString(), out int counterdieAllowance);
                            subsidiaryInformation.CounterdieAllowance = counterdieAllowance;
                            int.TryParse(objSqlReader[15].ToString(), out int cuttingLength);
                            subsidiaryInformation.CuttingLength = cuttingLength;
                            int.TryParse(objSqlReader[16].ToString(), out int cuttingWidth);
                            subsidiaryInformation.CuttingWidth = cuttingWidth;
                            subsidiaryInformation.GluingPullInTime = objSqlReader[17].ToString();
                            subsidiaryInformation.GluingPullOutTime = objSqlReader[18].ToString();
                            int.TryParse(objSqlReader[19].ToString(), out int thinPlateKeyholeX);
                            subsidiaryInformation.ThinPlateKeyholeX = thinPlateKeyholeX;
                            int.TryParse(objSqlReader[20].ToString(), out int thinPlateKeyholeY);
                            subsidiaryInformation.ThinPlateKeyholeY = thinPlateKeyholeY;
                            int.TryParse(objSqlReader[21].ToString(), out int thickPlateKeyholeX);
                            subsidiaryInformation.ThickPlateKeyholeX = thickPlateKeyholeX;
                            int.TryParse(objSqlReader[22].ToString(), out int thickPlateKeyholeY);
                            subsidiaryInformation.ThickPlateKeyholeY = thickPlateKeyholeY;
                            int.TryParse(objSqlReader[23].ToString(), out int thinPlateViewerX);
                            subsidiaryInformation.ThinPlateViewerX = thinPlateViewerX;
                            int.TryParse(objSqlReader[24].ToString(), out int thinPlateViewerY);
                            subsidiaryInformation.ThinPlateViewerY = thinPlateViewerY;
                            int.TryParse(objSqlReader[25].ToString(), out int thickPlateViewerX);
                            subsidiaryInformation.ThickPlateViewerX = thickPlateViewerX;
                            int.TryParse(objSqlReader[26].ToString(), out int thickPlateViewerY);
                            subsidiaryInformation.ThickPlateViewerY = thickPlateViewerY;
                            int.TryParse(objSqlReader[27].ToString(), out int lockWidth);
                            subsidiaryInformation.LockWidth = lockWidth;
                            int.TryParse(objSqlReader[28].ToString(), out int lockLength);
                            subsidiaryInformation.LockLength = lockLength;
                            int.TryParse(objSqlReader[29].ToString(), out int actualSerlantVolume);
                            subsidiaryInformation.ActualSerlantVolume = actualSerlantVolume;
                            int.TryParse(objSqlReader[30].ToString(), out int quantityGlue);
                            subsidiaryInformation.QuantityGlue = quantityGlue;
                            int.TryParse(objSqlReader[31].ToString(), out int gelatinizeTime);
                            subsidiaryInformation.GelatinizeTime = gelatinizeTime;
                            subsidiaryInformation.PerliteFillingPullInTime = objSqlReader[32].ToString();
                            subsidiaryInformation.PerliteFillingPullOutTime = objSqlReader[33].ToString();
                            int.TryParse(objSqlReader[34].ToString(), out int perliteLength);
                            subsidiaryInformation.PerliteLength = perliteLength;
                            int.TryParse(objSqlReader[35].ToString(), out int perliteWidth);
                            subsidiaryInformation.PerliteWidth = perliteWidth;
                            int.TryParse(objSqlReader[36].ToString(), out int perliteThickness);
                            subsidiaryInformation.PerliteThickness = perliteThickness;
                            subsidiaryInformation.PressFitPullInTime = objSqlReader[37].ToString();
                            subsidiaryInformation.PressFitPullOutTime = objSqlReader[38].ToString();
                            int.TryParse(objSqlReader[39].ToString(), out int pressFitTemperature);
                            subsidiaryInformation.PressFitTemperature = pressFitTemperature;
                            subsidiaryInformation.PolishedPullInTime = objSqlReader[40].ToString();
                            subsidiaryInformation.PolishedPullOutTime = objSqlReader[41].ToString();
                            subsidiaryInformation.WeldingPullInTime = objSqlReader[42].ToString();
                            subsidiaryInformation.WeldingPullOutTime = objSqlReader[43].ToString();
                            subsidiaryInformation.WeldSpacingUpDownStr = objSqlReader[44].ToString();
                            subsidiaryInformation.WeldSpacingHingeStr = objSqlReader[45].ToString();
                            subsidiaryInformation.WeldSpacingKeyholeStr = objSqlReader[46].ToString();
                            int.TryParse(objSqlReader[47].ToString(), out int weldNumUpDown);
                            subsidiaryInformation.WeldNumUpDown = weldNumUpDown;
                            int.TryParse(objSqlReader[48].ToString(), out int weldNumHinge);
                            subsidiaryInformation.WeldNumHinge = weldNumHinge;
                            int.TryParse(objSqlReader[49].ToString(), out int weldNumKeyhole);
                            subsidiaryInformation.WeldNumKeyhole = weldNumKeyhole;
                            int.TryParse(objSqlReader[50].ToString(), out int weldingVoltage);
                            subsidiaryInformation.WeldingVoltage = weldingVoltage;
                            int.TryParse(objSqlReader[51].ToString(), out int weldingElectricity);
                            subsidiaryInformation.WeldingElectricity = weldingElectricity;
                            int.TryParse(objSqlReader[52].ToString(), out int weldingSpendTime);
                            subsidiaryInformation.WeldingSpendTime = weldingSpendTime;
                            int.TryParse(objSqlReader[53].ToString(), out int wireFeedRate);
                            subsidiaryInformation.WireFeedRate = wireFeedRate;
                            subsidiaryInformation.SprayPaintPullInTime = objSqlReader[54].ToString();
                            subsidiaryInformation.SprayPaintPullOutTime = objSqlReader[55].ToString();
                            int.TryParse(objSqlReader[56].ToString(), out int sprayPaintSpendTime);
                            subsidiaryInformation.SprayPaintSpendTime = sprayPaintSpendTime;
                            subsidiaryInformation.VisualInspectionPullInTime = objSqlReader[57].ToString();
                            subsidiaryInformation.VisualInspectionPullOutTime = objSqlReader[58].ToString();
                            subsidiaryInformation.VisualInspectionResult = objSqlReader[59].ToString();
                            subsidiaryInformation.BlankingTime = objSqlReader[60].ToString();
                        }
                        if (n == 0)
                        {
                            MessageBox.Show("该数据不存在！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败！");
            }
            finally
            {
                if (objSqlReader != null)
                    objSqlReader.Close();
                if (cmd != null)
                    cmd.Dispose();
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return subsidiaryInformation;
        }
    }
}
