using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using JM_GluingSystem.Common.Class;

namespace JM_GluingSystem.DB
{
    class DB_SQL
    {
        //数据库连接
        public static string conStr = ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString;

        /* 账号管理表Account */
        /// <summary>
        /// 根据账号ID查询账户信息
        /// </summary>
        /// <param name="accountID">账户ID</param>
        /// <returns></returns>
        public static string Sel_LoginInfo(string accountID)
        {
            string sql= "select AccountID,UserName,Password,Status,UserLevel,CreateUserID,CreateTime,UpdateUserID,UpdateUserName,UpdateTime from Account where Status = 0 and AccountID = '"+accountID + "'";
            return sql;
        }
        // 查询用户权限等级
        //public static string sel_UserLevel = "select AccountID,UserName,UserLevel from Account where Status = 0 and ";
        // 根据条件查询用户信息
        public static string sel_UserInfo = "select AccountID,UserName,Password,UserLevel,CreateTime from Account where Status = 0";
        // 更新用户账号状态
        public static string up_UserStatus = "update Account set Status = '";
        // 添加用户
        public static string in_UserInfo = "insert into Account(AccountID,UserName,Password,Status,UserLevel,CreateUserID,CreateTime,UpdateUserID,UpdateUserName,UpdateTime) values('";
        // 更新用户信息
        public static string up_UserInfo = "update Account set ";


        //插入报警
        public static string in_AlarmInfo = "insert into Alarm (AlarmTime,AlarmContent,Result) values ('";
        //更新报警
        public static string up_AlarmInfo = "update Alarm set Result= '";
        /* 报警日志表AlarmLog */
        /// <summary>
        /// 根据条件查询报警日志
        /// </summary>
        /// <param name="alarmDatePicker1">起始时间</param>
        /// <param name="alarmDatePicker2">终止时间</param>
        /// <param name="selKeyTxt">模糊报警内容</param>
        /// <returns></returns>
        public static string Sel_AlarmInfo(string alarmDatePicker1,string alarmDatePicker2,string selKeyTxt)
        {
            string sql = "select AlarmTime,AlarmContent,Result from Alarm ";
            if (alarmDatePicker2 != "")
            {
                DateTime date = Convert.ToDateTime(alarmDatePicker2);
                DateTime datetime = date.AddDays(1);
                alarmDatePicker2 = datetime.ToShortDateString().ToString();
            }
            if (alarmDatePicker1 != "" && alarmDatePicker2 != "" && selKeyTxt == "")
            {
                sql += "where AlarmTime between '" + alarmDatePicker1 + "' and '" + alarmDatePicker2 + "' order by AlarmTime";
            }
            else if (alarmDatePicker1 == "" && alarmDatePicker2 == "" && selKeyTxt != "")
            {
                sql += "where AlarmContent like '%" + selKeyTxt + "%' order by AlarmTime";
            }
            else if (alarmDatePicker1 != "" && alarmDatePicker2 != "" && selKeyTxt != "")
            {
                sql += "where AlarmTime between '" + alarmDatePicker1 + "' and '" + alarmDatePicker2 + "' and AlarmContent like '%" + selKeyTxt + "%' order by AlarmTime";
            }
            return sql;
        }

        /* 生产管理表Production */
        public static string Sel_ProductInfo(string datePicker1,string datePicker2)
        {
            string sql = "select OrderNum,ProductionTime,Output,QualifiedNumber from Production where ProductionTime between '" + datePicker1 + "' and '" + datePicker2 + "' order by ProductionTime";
            return sql;
        }
        //public static string sel_ProductInfo = "select WorkSheetNumber,ProductionTime,Output,QualifiedNumber from Production ";
        /// <summary>
        /// 查询当天的前一周的生产情况
        /// </summary>
        /// <param name="forTime">7天前</param>
        /// <param name="tradeTime">昨天</param>
        /// <returns></returns>
        public static string Sel_WeekInfo(string forTime, string tradeTime)
        {
            string sql = "select DoorMold,ProductionTime,Output,QualifiedNumber from Production where ProductionTime between '"+ forTime +"' and '"+ tradeTime +"'";
            return sql;
        }

        /* 检测结果表TestingResult */
        /// <summary>
        /// 查询检测信息
        /// </summary>
        /// <param name="datePicker1">起始时间</param>
        /// <param name="datePicker2">终止时间</param>
        /// <returns>检测信息SQL文</returns>
        public static string Sel_ResultInfo(string datePicker1, string datePicker2)
        {
            string sql = "select DoorID,DoorMold,OrderNum,TestingTime,Result from TestingResult where TestingTime >= '" + datePicker1 + "' and TestingTime < '" + datePicker2 + "'";
            return sql;
        }

        /// <summary>
        /// 查询NG个数
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="failedReason">NG原因</param>
        /// <param name="num">NG边</param>
        /// <returns>SQL文</returns>
        public static string Sel_NGCountNum(string time, string failedReason, string num)
        {
            string DoorEdge = "DoorEdgeFailedReason" + num;
            string sql = "select count(*) from TestingResult where " + DoorEdge + " = '" + failedReason + "' and convert(varchar(100),TestingTime,23) = '" + time + "'";
            return sql;
        }

        /// <summary>
        /// 查询检测详情
        /// </summary>
        /// <param name="doorID">门ID</param>
        /// <param name="orderNum">工单编号</param>
        /// <returns>SQL文</returns>
        public static string Sel_InfoByID(string doorID, string orderNum)
        {
            string sql = "select DoorEdgeResult0,DoorEdgeFailedReason0,DoorEdgeResult1,DoorEdgeFailedReason1,DoorEdgeResult2,DoorEdgeFailedReason2,DoorEdgeResult3,DoorEdgeFailedReason3 from TestingResult where DoorID = '" + doorID + "' and OrderNum = '" + orderNum + "'";
            return sql;
        }


        /* 订单信息表OrderInfo */
        /// <summary>
        /// 查询门信息
        /// </summary>
        /// <param name="orderNum">订单号</param>
        /// <returns>SQL文</returns>
        public static string Sel_InfoByOrderNum(string orderNum)
        {
            string sql = "select OrderNum,OrderQuantity,ProductLine,DoorThickness,DoorStructure,SpecificationsWide,SpecificationHigh,FacadeStyle,ChildDoorStyle,Lock,Overdye,Doorframe,OpenTo,Buckles,ColorCategories,PictureDoorSpecification,CustomerSpecialRequirements from OrderInfo where OrderNum = '" + orderNum + "'";
            return sql;
        }


        /* 门信息表DoorInfo */
        /// <summary>
        /// 查询上料批次ID是否存在
        /// </summary>
        /// <param name="loadBatchID">上料批次ID</param>
        /// <returns>SQL文</returns>
        public static string Sel_InfoByLoadBatchID(string loadBatchID)
        {
            string sql = "select LoadBatchID from DoorInfo where LoadBatchID = '" + loadBatchID + "'";
            return sql;
        }

        /// <summary>
        /// 查询同一订单编号已上料数量
        /// </summary>
        /// <param name="orderNum">订单编号</param>
        /// <returns>SQL文</returns>
        public static string Sel_LoadNumAllByOrderNum(string orderNum)
        {
            string sql = "select OrderNum,OrderQuantity,LoadNum from DoorInfo where OrderNum = '" + orderNum + "'";
            return sql;
        }

        /// <summary>
        /// 插入新上料信息
        /// </summary>
        /// <param name="doorInformation">门信息类</param>
        /// <returns>SQL文</returns>
        public static string In_LoadDoorInfo(DoorInformation doorInformation)
        {
            string sql = "insert into DoorInfo values('" + doorInformation.LoadBatchID + "','" + doorInformation.OrderNum + "'," 
                + doorInformation.OrderQuantity + ",'" + doorInformation.DoorMold + "','" + doorInformation.PlacementMode + "','" 
                + doorInformation.ThicknessDistinguish + "','" + doorInformation.OpenDirection + "','" + doorInformation.StackPosition + "','" + doorInformation.PerlitePosition + "',"
                + doorInformation.ThinPlateLength + "," + doorInformation.ThinPlateWidth + "," + doorInformation.ThickPlateLength + "," 
                + doorInformation.ThickPlateWidth + "," + doorInformation.Thickness + "," + doorInformation.ThinPlateKeyholeX + "," 
                + doorInformation.ThinPlateKeyholeY + "," + doorInformation.ThickPlateKeyholeX + "," + doorInformation.ThickPlateKeyholeY + ",'" 
                + doorInformation.WeldSpacingUpDownStr + "','" + doorInformation.WeldSpacingHingeStr + "','" + doorInformation.WeldSpacingKeyholeStr + "'," 
                + doorInformation.WeldNumUpDown + "," + doorInformation.WeldNumHinge + "," + doorInformation.WeldNumKeyhole + "," 
                + doorInformation.PerliteLength + "," + doorInformation.PerliteWidth + "," + doorInformation.PerliteThickness + "," 
                + doorInformation.ThinPlateViewerX + "," + doorInformation.ThinPlateViewerY + "," + doorInformation.ThickPlateViewerX + "," 
                + doorInformation.ThickPlateViewerY+ "," +doorInformation.LockWidth + "," + doorInformation.LockLength + "," + doorInformation.LaminationDosage + ",'" + doorInformation.Status + "'," 
                + doorInformation.LoadNum + "," + doorInformation.SentNum + ")";
            return sql;
        }

        /// <summary>
        /// 查询订单编号是否存在
        /// </summary>
        /// <param name="orderNum">订单编号</param>
        /// <returns>SQL文</returns>
        public static string Sel_OrderNum(string orderNum)
        {
            string sql = "select OrderNum from DoorInfo where OrderNum = '" + orderNum + "'";
            return sql;
        }


        /* 生产明细表ProductionSubsidiary */
        /// <summary>
        /// 查询生产明细信息
        /// </summary>
        /// <param name="datePicker1">起始时间</param>
        /// <param name="datePicker2">终止时间</param>
        /// <returns>生产明细信息SQL文</returns>
        public static string Sel_SubsidiaryInfo(string datePicker1, string datePicker2)
        {
            string sql = "select DoorID,DoorMold,OrderNum,FeedingTime,BlankingTime from ProductionSubsidiary where BlankingTime >= '" + datePicker1 + "' and BlankingTime < '" + datePicker2 + "'";
            return sql;
        }

        /// <summary>
        /// 查询生产明细详情
        /// </summary>
        /// <param name="doorID">门ID</param>
        /// <param name="orderNum">工单编号</param>
        /// <returns>SQL文</returns>
        public static string Sel_SubsidiaryInfoByID(string doorID, string orderNum)
        {
            string sql = "select DoorID,DoorMold,OrderNum,OpenDirection,ThinPlateLength,ThinPlateWidth,ThickPlateLength,ThickPlateWidth,"
                + "Thickness,FeedingTime,LaminationPullInTime,LaminationPullOutTime,LaminationDosage,EpisporiumAllowance,CounterdieAllowance,"
                +"CuttingLength,CuttingWidth,GluingPullInTime,GluingPullOutTime,ThinPlateKeyholeX,ThinPlateKeyholeY,ThickPlateKeyholeX,"
                + "ThickPlateKeyholeY,ThinPlateViewerX,ThinPlateViewerY,ThickPlateViewerX,ThickPlateViewerY,LockWidth,LockLength,ActualSerlantVolume,QuantityGlue,"
                + "GelatinizeTime,PerliteFillingPullInTime,PerliteFillingPullOutTime,PerliteLength,PerliteWidth,PerliteThickness,PressFitPullInTime,"
                +"PressFitPullOutTime,PressFitTemperature,PolishedPullInTime,PolishedPullOutTime,WeldingPullInTime,WeldingPullOutTime,"
                +"WeldSpacingUpDownStr,WeldSpacingHingeStr,WeldSpacingKeyholeStr,WeldNumUpDown,WeldNumHinge,WeldNumKeyhole,WeldingVoltage,"
                +"WeldingElectricity,WeldingSpendTime,WireFeedRate,SprayPaintPullInTime,SprayPaintPullOutTime,SprayPaintSpendTime,"
                +"VisualInspectionPullInTime,VisualInspectionPullOutTime,VisualInspectionResult,BlankingTime from ProductionSubsidiary where DoorID = '" + doorID + "' and OrderNum = '" + orderNum + "'";
            return sql;
        }
    }
}
