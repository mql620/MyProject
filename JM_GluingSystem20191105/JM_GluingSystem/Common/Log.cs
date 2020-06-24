using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JM_GluingSystem.Common
{
    public class Log
    {
        public static void WriteAlarmLog(string strLog)
        {
            string sFilePath = "C:\\Users\\one\\Desktop\\ErrorLog";//获取文件路径
            string sFileName = "Error" + DateTime.Now.ToString("yyyyMMdd") + ".csv";//命名error+时间
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);
                //不存在则创建
            }
            FileStream fs;//创建数据流
            StreamWriter sw;//直接将字符和字符串写入文件
            if (File.Exists(sFileName))
            //验证文件是否存在
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);//有就添加
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);//没有创建
            }
            //DateTime t = DateTime.Now;
            sw = new StreamWriter(fs);//实例化
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss") + "," + strLog);//时间+内容写入
            int query = DBHelper.ExecuteNonQueryProc("addlog", new SqlParameter("@ErrorTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                                               new SqlParameter("@ErrorInfo", strLog));//存入数据库
            sw.Close();//关闭流
            fs.Close();//关闭流
           
        }
        public static void WriteLog(string strLog)
        {
            string sFilePath = "C:\\Users\\one\\Desktop\\ProductLog";//获取文件路径
            string sFileName = "Error" + DateTime.Now.ToString("yyyyMMdd") + ".csv";//命名error+时间
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);
                //不存在则创建
            }
            FileStream fs;//创建数据流
            StreamWriter sw;//直接将字符和字符串写入文件
            if (File.Exists(sFileName))
            //验证文件是否存在
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);//有就添加
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);//没有创建
            }
            //DateTime t = DateTime.Now;
            sw = new StreamWriter(fs);//实例化
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss") + "," + strLog);//时间+内容写入
            //int query = DBHelper.ExecuteNonQueryProc("addlog", new SqlParameter("@ErrorTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                                               //new SqlParameter("@ErrorInfo", strLog));//存入数据库
            sw.Close();//关闭流
            fs.Close();//关闭流
        }
    }
}
