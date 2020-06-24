using JM_GluingSystem.Common;
using JM_GluingSystem.Views.Check;
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
    class DB_TestingResult
    {
        /// <summary>
        /// 查询检测信息
        /// </summary>
        /// <param name="datePicker1">起始时间</param>
        /// <param name="datePicker2">终止时间</param>
        /// <returns>检测信息</returns>
        public static DataTable SearchResultInfo(string datePicker1, string datePicker2)
        {
            DataTable dt = Check.GetTableSchema();
            string sql = DB_SQL.Sel_ResultInfo(datePicker1, datePicker2);
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
                            switch (objSqlReader[4].ToString())
                            {
                                case "0":
                                    dr[4] = "NG";
                                    break;
                                case "1":
                                    dr[4] = "OK";
                                    break;
                            }
                            dt.Rows.Add(dr);
                        }
                        if (n == 0)
                            MessageBox.Show("没有检测数据！");
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
        /// 查询检测详情
        /// </summary>
        /// <param name="doorID">门ID</param>
        /// <param name="orderNum">订单编号</param>
        /// <returns>详情信息</returns>
        public static TestingResultInformation SearchInfoByID(string doorID, string orderNum)
        {
            TestingResultInformation testingResultInformation = null;
            string sql = DB_SQL.Sel_InfoByID(doorID, orderNum);
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
                        while (objSqlReader.Read())
                        {
                            testingResultInformation = new TestingResultInformation();
                            switch (objSqlReader[0].ToString())
                            {
                                case "0":
                                    testingResultInformation.DoorEdgeResult0 = "NG";
                                    testingResultInformation.DoorEdgeFailedReason0 = DetailValue(objSqlReader[1].ToString());
                                    break;
                                case "1":
                                    testingResultInformation.DoorEdgeResult0 = "OK";
                                    testingResultInformation.DoorEdgeFailedReason0 = "-";
                                    break;
                            }
                            switch (objSqlReader[2].ToString())
                            {
                                case "0":
                                    testingResultInformation.DoorEdgeResult1 = "NG";
                                    testingResultInformation.DoorEdgeFailedReason1 = DetailValue(objSqlReader[3].ToString());
                                    break;
                                case "1":
                                    testingResultInformation.DoorEdgeResult1 = "OK";
                                    testingResultInformation.DoorEdgeFailedReason1 = "-";
                                    break;
                            }
                            switch (objSqlReader[4].ToString())
                            {
                                case "0":
                                    testingResultInformation.DoorEdgeResult2 = "NG";
                                    testingResultInformation.DoorEdgeFailedReason2 = DetailValue(objSqlReader[5].ToString());
                                    break;
                                case "1":
                                    testingResultInformation.DoorEdgeResult2 = "OK";
                                    testingResultInformation.DoorEdgeFailedReason2 = "-";
                                    break;
                            }
                            switch (objSqlReader[6].ToString())
                            {
                                case "0":
                                    testingResultInformation.DoorEdgeResult3 = "NG";
                                    testingResultInformation.DoorEdgeFailedReason3 = DetailValue(objSqlReader[7].ToString());
                                    break;
                                case "1":
                                    testingResultInformation.DoorEdgeResult3 = "OK";
                                    testingResultInformation.DoorEdgeFailedReason3 = "-";
                                    break;
                            }
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
            return testingResultInformation;
        }

        private static string DetailValue(string result)
        {
            string str = "";
            switch (result)
            {
                case "1":
                    str = "扣板左右错位";
                    break;
                case "2":
                    str = "扣板上下错位";
                    break;
                case "4":
                    str = "门面正确扣合";
                    break;
                case "8":
                    str = "门扇偏出模板";
                    break;
                case "16":
                    str = "焊丝残留";
                    break;
                case "32":
                    str = "焊穿";
                    break;
                case "64":
                    str = "焊点过大";
                    break;
                case "128":
                    str = "焊缝过大";
                    break;
            }
            return str;
        }
        /// <summary>
        /// 查询NG个数
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="num">NG原因</param>
        /// <param name="NGno">NG边</param>
        /// <returns>NG个数</returns>
        public static int SearchNGCountNum(string time, int num, string NGno)
        {
            int NGCount = 0;
            string failedReason = "";
            switch (num)
            {
                case 0:
                    failedReason = "1";
                    break;
                case 1:
                    failedReason = "2";
                    break;
                case 2:
                    failedReason = "4";
                    break;
                case 3:
                    failedReason = "8";
                    break;
                case 4:
                    failedReason = "16";
                    break;
                case 5:
                    failedReason = "32";
                    break;
                case 6:
                    failedReason = "64";
                    break;
                case 7:
                    failedReason = "128";
                    break;
            }
            string sql = DB_SQL.Sel_NGCountNum(time, failedReason, NGno);
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
                        while (objSqlReader.Read())
                        {
                            NGCount = int.Parse(objSqlReader[0].ToString());
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
            return NGCount;
        }
    }
}
