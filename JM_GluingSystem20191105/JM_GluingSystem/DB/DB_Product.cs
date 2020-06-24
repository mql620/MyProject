using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JM_GluingSystem.Views;
using System.Data.SqlClient;
using System.Windows;
using JM_GluingSystem.Views.Product;
using JM_GluingSystem.Views.Monitor;

namespace JM_GluingSystem.DB
{
    class DB_Product
    {
        public static DataTable searchProductInfo(string datePicker1, string datePicker2)
        {
            DataTable dt = Product.GetTableSchema();
            if (datePicker1 != "" && datePicker2 != "")
            {
                string sql = DB_SQL.Sel_ProductInfo(datePicker1, datePicker2);
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
                                dr[0] = objSqlReader[0].ToString().Trim();
                                string str = objSqlReader[1].ToString().Trim();
                                string[] strArray = str.Split(' ');
                                dr[1] = strArray[0];
                                //dr[1] = objSqlReader[1].ToString().Trim().Remove(10);
                                dr[2] = objSqlReader[2].ToString().Trim();
                                dr[3] = objSqlReader[3].ToString().Trim();
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
            }
            else
            {
                MessageBox.Show("请选择需要的时间！");
            }
            return dt;
        }
    }
}
