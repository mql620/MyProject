using JM_GluingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Globalization;
using System.Data;

namespace JM_GluingSystem.DB
{
    class DB_Account
    {
        public static UserInformation_Kp SearchUserInfo(string accountID)
        {
            UserInformation_Kp userInformation_Kp = null;
            string sql = DB_SQL.Sel_LoginInfo(accountID);
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
                            userInformation_Kp = new UserInformation_Kp()
                            {
                                AccountID = objSqlReader[0].ToString().Trim(),
                                UserName = objSqlReader[1].ToString().Trim(),
                                Password = objSqlReader[2].ToString().Trim(),
                                Status = objSqlReader[3].ToString().Trim(),
                                UserLevel = objSqlReader[4].ToString().Trim(),
                                CreateUserID = objSqlReader[5].ToString().Trim(),
                                CreateTime = objSqlReader[6].ToString().Trim(),
                                UpdateUserID = objSqlReader[7].ToString().Trim(),
                                UpdateUserName = objSqlReader[8].ToString().Trim(),
                                UpdateTime = objSqlReader[9].ToString().Trim()
                            };
                        }
                        if (n == 0)
                        {
                            MessageBox.Show("用户名不存在！");
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
            return userInformation_Kp;
        }
        /// <summary>
        /// 根据条件查询用户信息
        /// </summary>
        /// <param name="selKeyChooseTxt">选择查询条件</param>
        /// <param name="selKeyTxt">关键字</param>
        /// <returns>用户信息画面表</returns>
        public static DataTable searchBasicUserInfo(string selKeyChooseTxt, string selKeyTxt)
        {
            DataTable dt = Views.BasicInfo.UserInfo.GetTableSchema();
            string sql = DB_SQL.sel_UserInfo;
            if (selKeyTxt != "")
            {
                string s = " and ";
                switch (selKeyChooseTxt)
                {
                    case "姓名":
                        s += "UserName = '" + selKeyTxt + "'";
                        break;
                    case "工号":
                        s += "AccountID = '" + selKeyTxt + "'";
                        break;
                }
                sql += s;
            }
            using (SqlConnection conn = new SqlConnection(DB_SQL.conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader objSqlReader = null;
                try
                {
                    conn.Open();
                    objSqlReader = cmd.ExecuteReader();
                    int n = 0;
                    while (objSqlReader.Read())
                    {
                        n += 1;
                        DataRow dr = dt.NewRow();
                        dr[0] = objSqlReader[0].ToString().Trim();
                        dr[1] = objSqlReader[1].ToString().Trim();
                        dr[2] = objSqlReader[2].ToString().Trim();
                        switch (objSqlReader[3].ToString().Trim())
                        {
                            case "4":
                                dr[3] = "投屏专用";
                                break;
                            case "3":
                                dr[3] = "初级操作员";
                                break;
                            case "2":
                                dr[3] = "高级操作员";
                                break;
                            case "1":
                                dr[3] = "管理员";
                                break;
                        }
                        dr[4] = objSqlReader[4].ToString().Trim();
                        dt.Rows.Add(dr);
                    }
                    objSqlReader.Close();
                    if (n == 0)
                        MessageBox.Show("用户不存在！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + "打开数据库失败！");
                }
                finally
                {
                    conn.Close();
                }
            }
            return dt;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="AccountID">账号ID</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="UserLevel">权限等级</param>
        /// <param name="CreateUserID">登录者ID</param>
        /// <param name="CreateUserName">登录者名</param>
        /// <returns>true or false</returns>
        public static bool insertUserInfo(string AccountID, string UserName, string Password, string UserLevel, string CreateUserID, string CreateUserName)
        {
            bool flag = false;
            DateTime dt = DateTime.Now;
            string tradeTime = dt.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string sql = DB_SQL.in_UserInfo;
            sql += AccountID + "','" + UserName + "','" + Password + "', 0,'" + UserLevel + "','" + CreateUserID + "','" + tradeTime + "','" + CreateUserID + "','" + CreateUserName + "','" + tradeTime + "')";
            using (SqlConnection conn = new SqlConnection(DB_SQL.conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                        flag = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + "打开数据库失败！");
                }
                finally
                {
                    conn.Close();
                }
            }
            return flag;
        }
        /// <summary>
        /// 更新用户账号状态
        /// </summary>
        /// <param name="accountID">账号ID</param>
        /// <param name="accountIDLogin">更新者</param>
        /// <param name="status">账号状态</param>
        /// <returns>true or false</returns>
        public static bool updateUserStatus(string accountID, string accountIDLogin, string status)
        {
            bool flag = false;
            DateTime dt = DateTime.Now;
            string tradeTime = dt.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string sql = DB_SQL.up_UserStatus;
            sql += status + "', UpdateUserID = '" + accountIDLogin + "', UpdateTime = '" + tradeTime + "' where AccountID = '" + accountID + "'";
            using (SqlConnection conn = new SqlConnection(DB_SQL.conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                        flag = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + "打开数据库失败！");
                }
                finally
                {
                    conn.Close();
                }
            }
            return flag;
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="AccountID">账号ID</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="UserLevel">权限等级</param>
        /// <param name="UpdateUserID">更新者ID</param>
        /// <param name="UpdateUserName">更新者名</param>
        /// <returns>true or false</returns>
        public static bool updateUserInfo(string AccountID, string UserName, string Password, string UserLevel, string UpdateUserID, string UpdateUserName)
        {
            bool flag = false;
            DateTime dt = DateTime.Now;
            string tradeTime = dt.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string sql = DB_SQL.up_UserInfo;
            sql += "UserName = '" + UserName + "', Password = '" + Password + "', UserLevel = '" + UserLevel + "', UpdateUserID = '" + UpdateUserID + "',UpdateUserName='" + UpdateUserName + "', UpdateTime = '" + tradeTime + "' where AccountID = '" + AccountID + "'";
            using (SqlConnection conn = new SqlConnection(DB_SQL.conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                        flag = true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString() + "打开数据库失败！");
                }
                finally
                {
                    conn.Close();
                }
            }
            return flag;
        }
    }
}
