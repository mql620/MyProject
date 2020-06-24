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
    class DB_DoorInfo
    {
        /// <summary>
        /// 查询上料批次ID是否存在
        /// </summary>
        /// <param name="loadBatchID">上料批次ID</param>
        /// <returns>true or false</returns>
        public static bool SearchLoadBatchID(string loadBatchID)
        {
            bool flag = false;
            string sql = DB_SQL.Sel_InfoByLoadBatchID(loadBatchID);
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
                            flag = true;
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
            return flag;
        }

        /// <summary>
        /// 查询同一订单编号已上料数量
        /// </summary>
        /// <param name="orderNum">订单编号</param>
        /// <returns>已上料数量</returns>
        public static int SearchLoadNumAllByOrderNum(string orderNum,out int orderQuantity)
        {
            int loadNumAll = 0;
            orderQuantity = 0;
            string sql = DB_SQL.Sel_LoadNumAllByOrderNum(orderNum);
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
                            int.TryParse(objSqlReader[1].ToString(), out int quantity);
                            orderQuantity = quantity;
                            int.TryParse(objSqlReader[2].ToString(), out int loadNum);
                            loadNumAll = loadNumAll + loadNum;
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
            return loadNumAll;
        }

        /// <summary>
        /// 插入新上料信息
        /// </summary>
        /// <param name="doorInformation">门信息类</param>
        /// <returns>true or false</returns>
        public static bool InsertLoadDoorInfo(DoorInformation doorInformation)
        {
            bool flag = false;
            string sql = DB_SQL.In_LoadDoorInfo(doorInformation);
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                using (conn = new SqlConnection(DB_SQL.conStr))
                {
                    using (cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        int n = cmd.ExecuteNonQuery();
                        if (n > 0)
                            flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败！");
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }            
            return flag;
        }

        /// <summary>
        /// 查询订单编号是否存在
        /// </summary>
        /// <param name="orderNum">订单编号</param>
        /// <returns>true or false</returns>
        public static bool SearchOrderNum(string orderNum)
        {
            bool flag = false;
            string sql = DB_SQL.Sel_OrderNum(orderNum);
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
                            flag = true;
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
            return flag;
        }
    }
}
