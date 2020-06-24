using JM_GluingSystem.Views;
using JM_GluingSystem.Views.Alarm;
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
    class DB_Alarm
    {
        public static DataTable searchAlarmInfo(string alarmDatePicker1,string alarmDatePicker2,string selKeyTxt)
        {
            DataTable dt = HistoryAlarm.GetAlarmTable();
            string sql = DB_SQL.Sel_AlarmInfo(alarmDatePicker1, alarmDatePicker2, selKeyTxt);
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader objSqlReader = null;
            if ((alarmDatePicker1==""|| alarmDatePicker2 == "")&& selKeyTxt=="")
            {
                MessageBox.Show("请选择正确的时间段！");
            }
            else
            {
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
                                dr[1] = objSqlReader[1].ToString().Trim();
                                switch (objSqlReader[2].ToString().Trim())
                                {
                                    case "0":
                                        dr[2] = "已处理";
                                        break;
                                    case "1":
                                        dr[2] = "未处理";
                                        break;
                                }
                                dt.Rows.Add(dr);
                            }
                            if (n == 0)
                                MessageBox.Show("没有报警！");
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
            return dt;
        }
    }
}
