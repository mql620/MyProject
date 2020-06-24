using JM_GluingSystem.Common.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JM_GluingSystem.DB
{
    class DB_OrderInfo
    {
        /// <summary>
        /// 根据订单号查询门信息
        /// </summary>
        /// <param name="orderNum">订单号</param>
        /// <returns>门信息</returns>
        public static OrderInformation SearchOrderInfoByOrderNum(string orderNum)
        {
            OrderInformation orderInformation = null;
            string sql = DB_SQL.Sel_InfoByOrderNum(orderNum);
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
                            orderInformation = new OrderInformation
                            {
                                OrderNum = objSqlReader[0].ToString().Trim(),
                                OrderQuantity = objSqlReader[1].ToString().Trim(),
                                ProductLine = objSqlReader[2].ToString().Trim(),
                                DoorThickness = objSqlReader[3].ToString().Trim(),
                                DoorStructure = objSqlReader[4].ToString().Trim(),
                                SpecificationsWide = objSqlReader[5].ToString().Trim(),
                                SpecificationHigh = objSqlReader[6].ToString().Trim(),
                                FacadeStyle = objSqlReader[7].ToString().Trim(),
                                ChildDoorStyle = objSqlReader[8].ToString().Trim(),
                                Lock = objSqlReader[9].ToString().Trim(),
                                Overdye = objSqlReader[10].ToString().Trim(),
                                Doorframe = objSqlReader[11].ToString().Trim(),
                                OpenTo = objSqlReader[12].ToString().Trim(),
                                Buckles = objSqlReader[13].ToString().Trim(),
                                ColorCategories = objSqlReader[14].ToString().Trim(),
                                PictureDoorSpecification = objSqlReader[15].ToString().Trim(),
                                CustomerSpecialRequirements = objSqlReader[16].ToString().Trim()
                            };
                        }
                        if (n == 0)
                        {
                            MessageBox.Show("订单号" + orderNum + "不存在！");
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
            return orderInformation;
        }
    }
}
