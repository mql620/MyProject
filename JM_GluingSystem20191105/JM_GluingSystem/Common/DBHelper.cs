using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace JM_GluingSystem.Common
{
    public class DBHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private readonly static string config = ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString;
        /// <summary>
        /// 离线查询，返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string sql, params SqlParameter[] par)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, config))
            {
                if (par != null && par.Length > 0)
                {
                    sda.SelectCommand.Parameters.AddRange(par);
                }
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }

        }
        /// <summary>
        /// 查询首行首列，返回object
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(config))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    if (par != null && par.Length > 0)
                    {
                        com.Parameters.AddRange(par);
                    }
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    return com.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 在线查询，返回SqlDataReader，存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader1(string procname, params SqlParameter[] par)
        {
            SqlConnection con = new SqlConnection(config);

            using (SqlCommand com = new SqlCommand(procname, con))
            {
                com.CommandType = CommandType.StoredProcedure;
                if (par != null && par.Length > 0)
                {
                    com.Parameters.AddRange(par);
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return com.ExecuteReader(CommandBehavior.CloseConnection);

            }
        }
        /// <summary>
        /// 在线查询，返回SqlDataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string procname, params SqlParameter[] par)
        {
            SqlConnection con = new SqlConnection(config);

            using (SqlCommand com = new SqlCommand(procname, con))
            {

                if (par != null && par.Length > 0)
                {
                    com.Parameters.AddRange(par);
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return com.ExecuteReader(CommandBehavior.CloseConnection);

            }
        }
        /// <summary>
        /// 增删改方法
        /// </summary>
        /// <param name="sql"></param>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(config))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    if (par != null && par.Length > 0)
                    {
                        com.Parameters.AddRange(par);
                    }
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    return com.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 增删改方法，存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static int ExecuteNonQueryProc(string sql, params SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(config))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandTimeout = 60;
                    com.CommandType = CommandType.StoredProcedure;
                    if (par != null && par.Length > 0)
                    {
                        com.Parameters.AddRange(par);
                    }
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    return com.ExecuteNonQuery();
                }
            }
        }

        #region 
        /// <summary>
        /// 字符串转数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int[] ToIntArray( string str)
        {
            return ToIntArray(str, ',');
        }
        public static int[] ToIntArray(string str, char separator)
        {
            string[] s = str.Split(separator);
            List<int> listint = new List<int>();
            foreach (var item in s)
            {
                int i;
                if (int.TryParse(item, out i))
                    listint.Add(i);
            }
            return listint.ToArray();
        }
        #endregion
    }
}
