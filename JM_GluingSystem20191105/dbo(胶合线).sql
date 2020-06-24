/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : SQL Server
 Source Server Version : 14001000
 Source Host           : localhost:1433
 Source Catalog        : JM_GluingSystem_DataBase_2019
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 14001000
 File Encoding         : 65001

 Date: 27/02/2020 18:44:57
*/


-- ----------------------------
-- Table structure for Account
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type IN ('U'))
	DROP TABLE [dbo].[Account]
GO

CREATE TABLE [dbo].[Account] (
  [AccountID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [UserName] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Password] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Status] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [UserLevel] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateUserID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateTime] datetime  NULL,
  [UpdateUserID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [UpdateUserName] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [UpdateTime] datetime  NULL
)
GO

ALTER TABLE [dbo].[Account] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Account
-- ----------------------------
INSERT INTO [dbo].[Account] VALUES (N'D0001', N'admin', N'0000', N'0', N'1', N'admin', N'2019-06-25 00:00:00.000', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Account] VALUES (N'D0002', N'张三', N'0000', N'0', N'4', N'D0001', N'2019-10-29 15:50:44.000', N'D0001', N'admin', N'2019-12-13 17:12:40.000')
GO

INSERT INTO [dbo].[Account] VALUES (N'D0003', N'李四', N'1111', N'1', N'3', N'D0001', N'2019-12-13 17:17:30.000', N'D0001', N'admin', N'2019-12-13 17:17:54.000')
GO

INSERT INTO [dbo].[Account] VALUES (N'D0010', N'李四', N'1234', N'1', N'3', N'D0001', N'2019-12-16 10:07:13.000', N'D0001', N'admin', N'2019-12-16 10:07:34.000')
GO


-- ----------------------------
-- Table structure for Alarm
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Alarm]') AND type IN ('U'))
	DROP TABLE [dbo].[Alarm]
GO

CREATE TABLE [dbo].[Alarm] (
  [AlarmTime] datetime  NULL,
  [AlarmContent] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [Result] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [UpdateTime] datetime  NULL
)
GO

ALTER TABLE [dbo].[Alarm] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Alarm
-- ----------------------------
INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-08 14:59:55.000', N'上料站提示:ABB 不在Home点', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:10.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:10.000', N'上料站提示:与主站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'填充站提示:与上料站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:39:11.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:29.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:29.000', N'上料站提示:与主站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:29.000', N'填充站提示:与上料站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:29.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:29.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:30.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:30.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:30.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:30.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:30.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:44:30.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:45.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:45.000', N'上料站提示:与主站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'填充站提示:与上料站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:47:46.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:00.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:00.000', N'上料站提示:与主站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:00.000', N'填充站提示:与上料站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:00.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:00.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:01.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:01.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:01.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:01.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:01.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:49:01.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:21.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:21.000', N'上料站提示:与主站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:22.000', N'填充站提示:与上料站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:22.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:22.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:22.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:22.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:22.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:22.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:23.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:50:23.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:55.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:55.000', N'上料站提示:与主站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'填充站提示:与上料站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:58:56.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:55.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:55.000', N'上料站提示:与主站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'填充站提示:与上料站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 09:02:56.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:37.000', N'上料站提示:ABB 不在Home点', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:37.000', N'上料站提示:ABB没有循环运行', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:37.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:38.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:39.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:39.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:13:39.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:32.000', N'上料站提示:ABB 不在Home点', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:32.000', N'上料站提示:ABB没有在自动状态', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:32.000', N'上料站提示:ABB没有循环运行', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:32.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:33.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:18:58.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:15.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:15.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:16.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:17.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:17.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:26:17.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:25.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:25.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:26.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:26.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:06.000', N'上料站提示:与涂胶站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:06.000', N'上料站提示:与主站通信异常', N'0', N'2019-11-12 14:18:57.000')
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'填充站提示:与上料站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 08:57:07.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:51.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:51.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:37:53.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:22.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:22.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:39:23.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:17.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:17.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:43:18.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:05.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:05.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:06.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:07.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:07.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:50:07.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:02:54.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:02:54.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:02:55.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:02:55.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:02:55.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:02:56.000', N'下料站提示:ABB不在自动状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:02:56.000', N'下料站提示:ABB不在循环状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:02:56.000', N'下料站提示:ABB不在原点状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:26.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:31:27.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:39.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:39.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:39.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:39.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:39.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:40.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:40.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:40.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:40.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:40.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:40.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:40.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:40.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:41.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:41.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:40:41.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:28.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:29.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:30.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:30.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:48:30.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:04.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:04.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'检测站提示:与主站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'检测故障:急停报警', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'检测故障:X轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'检测故障:X轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'检测故障:Y轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'检测故障:Y轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'检测故障:旋转轴伺服报错', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:05.000', N'检测故障:旋转轴伺服通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:06.000', N'下料站故障:急停异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:06.000', N'下料站故障:伺服1通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 14:54:06.000', N'下料站故障:伺服2通信掉线', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:08:00.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:08:00.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:08:01.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:08:01.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:08:01.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:08:01.000', N'下料站提示:ABB不在自动状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:08:01.000', N'下料站提示:ABB不在循环状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:08:01.000', N'下料站提示:ABB不在原点状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:26.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:26.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:27.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:27.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:27.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:27.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:29.000', N'下料站提示:ABB不在自动状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:29.000', N'下料站提示:ABB不在循环状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:09:29.000', N'下料站提示:ABB不在原点状态', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:17:27.000', N'上料站提示:ABB没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:17:27.000', N'上料站提示:与涂胶站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:17:28.000', N'填充站提示:ABB机器人不在自动', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:17:28.000', N'填充站提示:ABB机器人没有循环运行', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:17:28.000', N'填充站提示:与压合站通信异常', N'1', NULL)
GO

INSERT INTO [dbo].[Alarm] VALUES (N'2019-11-12 15:17:28.000', N'填充站提示:珍珠岩已抓完/请放物料', N'1', NULL)
GO


-- ----------------------------
-- Table structure for AlarmLog
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[AlarmLog]') AND type IN ('U'))
	DROP TABLE [dbo].[AlarmLog]
GO

CREATE TABLE [dbo].[AlarmLog] (
  [AlarmCode] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [AlarmTime] datetime  NULL,
  [AlarmContent] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [AlarmResult] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [HandleTime] datetime  NULL
)
GO

ALTER TABLE [dbo].[AlarmLog] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of AlarmLog
-- ----------------------------
INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-25 13:00:03.000', N'上料ABB报警', N'1', N'2019-06-25 13:00:20.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-25 14:01:06.000', N'急停报警按下', N'1', N'2019-06-25 14:01:37.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-26 08:47:59.000', N'上料ABB无真空报警', N'1', N'2019-06-26 08:48:15.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-26 13:53:15.000', N'变频器报错', N'1', N'2019-06-26 13:53:32.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-27 08:55:06.000', N'上料ABB通信掉线', N'1', N'2019-06-27 08:55:20.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-27 15:47:33.000', N'下料ABB报错', N'1', N'2019-06-27 15:49:00.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-28 16:48:42.000', N'下料ABB通信掉线', N'1', N'2019-06-28 16:49:59.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-28 10:49:32.000', N'CCD伺服报错', N'1', N'2019-06-28 10:50:50.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-28 13:50:42.000', N'珍珠岩ABB报错', N'1', N'2019-06-28 13:51:52.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-29 16:51:09.000', N'珍珠岩ABB通信掉线', N'1', N'2019-06-29 16:52:28.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-29 14:52:06.000', N'CCD伺服通信掉线', N'1', N'2019-06-29 14:53:26.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-30 16:53:26.000', N'上料ABB报警', N'1', N'2019-06-30 16:54:35.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-06-30 14:53:46.000', N'上料ABB无真空报警', N'1', N'2019-06-30 14:54:56.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-07-01 15:54:14.000', N'急停报警按下', N'1', N'2019-07-01 15:56:24.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-07-01 10:54:50.000', N'CCD伺服报错', N'1', N'2019-07-01 10:55:59.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-07-02 09:55:24.000', N'变频器报错', N'1', N'2019-07-02 09:56:38.000')
GO

INSERT INTO [dbo].[AlarmLog] VALUES (NULL, N'2019-07-02 12:55:57.000', N'珍珠岩ABB报错', N'1', N'2019-07-02 12:57:06.000')
GO


-- ----------------------------
-- Table structure for DoorInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DoorInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[DoorInfo]
GO

CREATE TABLE [dbo].[DoorInfo] (
  [LoadBatchID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderNum] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderQuantity] int  NULL,
  [DoorMold] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PlacementMode] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ThicknessDistinguish] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OpenDirection] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [StackPosition] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PerlitePosition] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ThinPlateLength] int  NULL,
  [ThinPlateWidth] int  NULL,
  [ThickPlateLength] int  NULL,
  [ThickPlateWidth] int  NULL,
  [Thickness] int  NULL,
  [ThinPlateKeyholeX] int  NULL,
  [ThinPlateKeyholeY] int  NULL,
  [ThickPlateKeyholeX] int  NULL,
  [ThickPlateKeyholeY] int  NULL,
  [WeldSpacingUpDownStr] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [WeldSpacingHingeStr] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [WeldSpacingKeyholeStr] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [WeldNumUpDown] int  NULL,
  [WeldNumHinge] int  NULL,
  [WeldNumKeyhole] int  NULL,
  [PerliteLength] int  NULL,
  [PerliteWidth] int  NULL,
  [PerliteThickness] int  NULL,
  [ThinPlateViewerX] int  NULL,
  [ThinPlateViewerY] int  NULL,
  [ThickPlateViewerX] int  NULL,
  [ThickPlateViewerY] int  NULL,
  [LockWidth] int  NULL,
  [LockLength] int  NULL,
  [LaminationDosage] int  NULL,
  [Status] int  NULL,
  [LoadNum] int  NULL,
  [SentNum] int  NULL
)
GO

ALTER TABLE [dbo].[DoorInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of DoorInfo
-- ----------------------------
INSERT INTO [dbo].[DoorInfo] VALUES (N'20190923162642', N'50', N'50', N'1', N'1', N'1', N'1', N'1', NULL, N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', NULL, NULL, N'1', N'2', N'20', N'20')
GO

INSERT INTO [dbo].[DoorInfo] VALUES (N'20190921152642', N'50', N'50', N'1', N'1', N'1', N'1', N'1', NULL, N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', NULL, NULL, N'1', N'2', N'20', N'20')
GO

INSERT INTO [dbo].[DoorInfo] VALUES (N'20190922152642', N'1', N'50', N'1', N'1', N'1', N'1', N'1', NULL, N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', NULL, NULL, N'1', N'2', N'20', N'20')
GO

INSERT INTO [dbo].[DoorInfo] VALUES (N'20190920152642', N'100000000152', N'100', N'防盗门', N'平放', N'厚板', N'外左', N'A垛', N'A垛', N'1980', N'772', N'1948', N'739', N'70', N'81', N'990', N'65', N'974', N'250,1128,1128,1128,1128,1128,1130', N'300,1640,1200,880,880,1200,1000,1000,1000,30,1200,1530,1530,1200,1750,1200,1640', N'300,1000,1000,430,2000,1150,1200,1150,3000,1150,1200,1150,2000,1250,1200', N'7', N'17', N'15', N'0', N'0', N'0', N'401', N'1477', N'372', N'1461', N'70', N'50', N'1990', N'1', N'15', N'15')
GO

INSERT INTO [dbo].[DoorInfo] VALUES (N'20191228200826', N'100000000152', N'100', N'防盗门', N'平放', N'厚板', N'外左', N'A垛', N'A垛', N'1980', N'772', N'1948', N'739', N'70', N'81', N'990', N'65', N'974', N'250,1128,1128,1128,1128,1128,1130', N'300,1640,1200,880,880,1200,1000,1000,1000,30,1200,1530,1530,1200,1750,1200,1640', N'300,1000,1000,430,2000,1150,1200,1150,3000,1150,1200,1150,2000,1250,1200', N'7', N'17', N'15', N'0', N'0', N'0', N'401', N'1477', N'372', N'1461', N'52', N'260', N'1990', N'0', N'1', N'0')
GO


-- ----------------------------
-- Table structure for ErrorReport
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorReport]') AND type IN ('U'))
	DROP TABLE [dbo].[ErrorReport]
GO

CREATE TABLE [dbo].[ErrorReport] (
  [ErrorTime] datetime  NULL,
  [ErrorInfo] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ErrorReport] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ErrorReport
-- ----------------------------
INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-09-18 00:00:00.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-09-18 14:16:26.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-11 13:30:53.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-11 13:30:57.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-11 13:31:00.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-11 13:31:03.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-29 13:53:12.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-29 13:53:15.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-29 13:53:21.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-29 13:54:43.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-29 13:54:49.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-10-29 13:54:55.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 09:45:34.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 09:45:37.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 14:42:33.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 14:42:39.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:20:39.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:20:43.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:20:46.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 16:41:36.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 14:42:42.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:37:23.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 14:44:15.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 14:51:54.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:08:25.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:08:30.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:12:18.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:25:38.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:40:59.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:51:32.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 15:55:25.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 16:03:03.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 16:03:08.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 16:03:11.000', N'PLC连接超时')
GO

INSERT INTO [dbo].[ErrorReport] VALUES (N'2019-12-13 16:07:24.000', N'PLC连接超时')
GO


-- ----------------------------
-- Table structure for OrderInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[OrderInfo]
GO

CREATE TABLE [dbo].[OrderInfo] (
  [OrderNum] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [StockNum] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Batch] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderQuantity] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DeliveredQuantity] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [MRPController] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BasicStartDate] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BasicCompletionDate] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BasicStartYear] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BasicStartMonth] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BasicStartDay] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [MaterialDescription] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [StorageLocation] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PlannedPlant] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Brand] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ProductLine] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorThickness] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorStructure] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SpecificationsWide] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SpecificationHigh] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [TransomWindowHigh] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [StandardOrNon_standard] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [FacadeStyle] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ChildDoorStyle] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SecurityLevel] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [FireRating] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Lock] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [KeyCylinder] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DeputyLock] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Overlay] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Overdye] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Doorframe] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Downside] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [NonDownsideDoorLeafGround] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [FrontDoorPlank] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ContraryDoorPlank] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [FramePlate] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Filler] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BellDoorMirror] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Thong] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Handle] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Hinge] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [HingeNo] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OpenTo] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CompositeGateStyle] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Amboss] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Framework] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Bolt] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [HeavenEarthLock] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Key] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SpecialDoor] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Buckles] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ColorCategories] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [WicketGauze] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CompositeGateLatticeWindow] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [StructureCategories] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [TransomStructure] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [TransomStyle] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BlankingPlateStructure] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PictureDoorSpecification] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [MainframeObserveIris] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorCloser] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorHead] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Doorpost] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CoatingProcess] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CustomerSpecialRequirements] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ConventionalOrCustomized] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DealerAddress] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SystemState] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[OrderInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of OrderInfo
-- ----------------------------
INSERT INTO [dbo].[OrderInfo] VALUES (N'100000000152', N'810000018', N'012U013', N'100', N'0', N'B01', N'2017/3/1', N'2017/3/1', N'2017', N'03', N'01', N'王力/防盗门/70/单门', N'2001', N'8A01', N'王力', N'防盗门', N'70', N'单门', N'85', N'205', N'0', N'标准单门', N'L907', N'无', N'乙级防盗', N'无', N'特能锁', N'特能全黑', N'28面板二头副锁', N'无', N'L907', N'A型框', N'0.8不锈钢下档', N'0', N'1', N'1', N'2', N'蜂窝纸板', N'防拆铜门镜', N'PU皮条', N'C9008拉手', N'轴承铰链', N'四个铰链', N'外左', N'无', N'双面压花', N'无', N'无', N'有天地锁', N'无', N'无', N'双扣边', N'转印门', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'户内工艺', N'无', N'常规', NULL, N'CLSD PCNF DLV  PRC  标记   BASC BCRQ GMPS*')
GO

INSERT INTO [dbo].[OrderInfo] VALUES (N'100000037444', N'810000018', N'A13X071', N'1', N'0', N'A01', N'2017/3/31', N'2017/4/12', N'2017', N'03', N'31', N'王力/防盗门/70/单门', N'2002', N'8A10', N'王力', N'防盗门', N'70', N'单门', N'85', N'175', N'0', N'非标', N'常规', N'无', N'无', N'无', N'特能锁', N'特能全黑', N'无副锁', N'无', N'L907', N'E型框', N'0.8不锈钢下档', N'0', N'1', N'1', N'2', N'蜂窝纸板', N'无门铃门镜', N'PU皮条', N'C9008拉手', N'军工轴承铰链', N'三个铰链', N'内右', N'无', N'无', N'无', N'无', N'有天地锁', N'无', N'无', N'双扣边', N'转印门', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'无', N'户外工艺', N'无', N'定制', NULL, N'CLSD PCNF DLV  PRC  BASC BCRQ GMPS ILAS*')
GO


-- ----------------------------
-- Table structure for Production
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Production]') AND type IN ('U'))
	DROP TABLE [dbo].[Production]
GO

CREATE TABLE [dbo].[Production] (
  [DoorMold] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderNum] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [ProductionTime] date  NULL,
  [Output] int  NULL,
  [QualifiedNumber] int  NULL
)
GO

ALTER TABLE [dbo].[Production] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Production
-- ----------------------------
INSERT INTO [dbo].[Production] VALUES (N'A1', N'GB0001', N'2019-10-22', N'150', N'148')
GO

INSERT INTO [dbo].[Production] VALUES (N'A2', N'GB0001', N'2019-10-22', N'80', N'78')
GO

INSERT INTO [dbo].[Production] VALUES (N'A1', N'GB0002', N'2019-06-22', N'200', N'198')
GO

INSERT INTO [dbo].[Production] VALUES (N'A1', N'GB0003', N'2019-06-22', N'120', N'117')
GO

INSERT INTO [dbo].[Production] VALUES (N'A2', N'GB0003', N'2019-06-23', N'100', N'97')
GO

INSERT INTO [dbo].[Production] VALUES (N'A1', N'GB0004', N'2019-06-24', N'180', N'178')
GO

INSERT INTO [dbo].[Production] VALUES (N'A2', N'GB0004', N'2019-06-24', N'100', N'99')
GO

INSERT INTO [dbo].[Production] VALUES (N'A2', N'GB0005', NULL, N'200', N'195')
GO


-- ----------------------------
-- Table structure for ProductionSubsidiary
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductionSubsidiary]') AND type IN ('U'))
	DROP TABLE [dbo].[ProductionSubsidiary]
GO

CREATE TABLE [dbo].[ProductionSubsidiary] (
  [DoorID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorMold] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderNum] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PlacementMode] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ThicknessDistinguish] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OpenDirection] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [StackPosition] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [PerlitePosition] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ThinPlateLength] int  NULL,
  [ThinPlateWidth] int  NULL,
  [ThickPlateLength] int  NULL,
  [ThickPlateWidth] int  NULL,
  [Thickness] int  NULL,
  [FeedingTime] datetime  NULL,
  [LaminationPullInTime] datetime  NULL,
  [LaminationPullOutTime] datetime  NULL,
  [LaminationDosage] int  NULL,
  [EpisporiumAllowance] int  NULL,
  [CounterdieAllowance] int  NULL,
  [CuttingLength] int  NULL,
  [CuttingWidth] int  NULL,
  [GluingPullInTime] datetime  NULL,
  [GluingPullOutTime] datetime  NULL,
  [ThinPlateKeyholeX] int  NULL,
  [ThinPlateKeyholeY] int  NULL,
  [ThickPlateKeyholeX] int  NULL,
  [ThickPlateKeyholeY] int  NULL,
  [ThinPlateViewerX] int  NULL,
  [ThinPlateViewerY] int  NULL,
  [ThickPlateViewerX] int  NULL,
  [ThickPlateViewerY] int  NULL,
  [LockWidth] int  NULL,
  [LockLength] int  NULL,
  [ActualSerlantVolume] int  NULL,
  [QuantityGlue] int  NULL,
  [GelatinizeTime] int  NULL,
  [PerliteFillingPullInTime] datetime  NULL,
  [PerliteFillingPullOutTime] datetime  NULL,
  [PerliteLength] int  NULL,
  [PerliteWidth] int  NULL,
  [PerliteThickness] int  NULL,
  [PressFitPullInTime] datetime  NULL,
  [PressFitPullOutTime] datetime  NULL,
  [PressFitTemperature] int  NULL,
  [PolishedPullInTime] datetime  NULL,
  [PolishedPullOutTime] datetime  NULL,
  [WeldingPullInTime] datetime  NULL,
  [WeldingPullOutTime] datetime  NULL,
  [WeldSpacingUpDownStr] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [WeldSpacingHingeStr] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [WeldSpacingKeyholeStr] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [WeldNumUpDown] int  NULL,
  [WeldNumHinge] int  NULL,
  [WeldNumKeyhole] int  NULL,
  [WeldingVoltage] int  NULL,
  [WeldingElectricity] int  NULL,
  [WeldingSpendTime] int  NULL,
  [WireFeedRate] int  NULL,
  [SprayPaintPullInTime] datetime  NULL,
  [SprayPaintPullOutTime] datetime  NULL,
  [SprayPaintSpendTime] int  NULL,
  [VisualInspectionPullInTime] datetime  NULL,
  [VisualInspectionPullOutTime] datetime  NULL,
  [VisualInspectionResult] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [NGCause] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [BlankingTime] datetime  NULL
)
GO

ALTER TABLE [dbo].[ProductionSubsidiary] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ProductionSubsidiary
-- ----------------------------
INSERT INTO [dbo].[ProductionSubsidiary] VALUES (N'20190927134114', N'防盗门', N'100000000152', N'平放', N'厚板', N'外左', N'A垛', NULL, N'1980', N'772', N'1948', N'739', N'70', N'2019-09-27 13:41:14.000', NULL, NULL, N'1990', NULL, NULL, NULL, NULL, NULL, NULL, N'81', N'990', N'65', N'974', N'401', N'1477', N'372', N'1461', NULL, NULL, NULL, NULL, NULL, NULL, N'2019-10-10 09:45:20.000', N'0', N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'250,1128,1128,1128,1128,1128,1130', N'300,1640,1200,880,880,1200,1000,1000,1000,30,1200,1530,1530,1200,1750,1200,1640', N'300,1000,1000,430,2000,1150,1200,1150,3000,1150,1200,1150,2000,1250,1200', N'7', N'17', N'15', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2019-09-27 13:48:14.000')
GO

INSERT INTO [dbo].[ProductionSubsidiary] VALUES (N'20191112145413', N'防盗门', N'100000000152', N'平放', N'厚板', N'外左', N'A垛', N'A垛', N'1980', N'772', N'1948', N'739', N'70', N'2019-11-12 14:54:15.000', NULL, NULL, N'1990', NULL, NULL, NULL, NULL, NULL, NULL, N'81', N'990', N'65', N'974', N'401', N'1477', N'372', N'1461', N'70', N'50', NULL, NULL, NULL, NULL, NULL, N'0', N'0', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'250,1128,1128,1128,1128,1128,1130', N'300,1640,1200,880,880,1200,1000,1000,1000,30,1200,1530,1530,1200,1750,1200,1640', N'300,1000,1000,430,2000,1150,1200,1150,3000,1150,1200,1150,2000,1250,1200', N'7', N'17', N'15', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2019-11-12 15:17:43.000', N'2019-11-12 15:18:41.000', NULL, NULL, N'2019-11-12 14:59:15.000')
GO


-- ----------------------------
-- Table structure for ProductLog
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductLog]') AND type IN ('U'))
	DROP TABLE [dbo].[ProductLog]
GO

CREATE TABLE [dbo].[ProductLog] (
  [ProductTime] datetime  NULL,
  [DoorID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ProductLog] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for TestingResult
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TestingResult]') AND type IN ('U'))
	DROP TABLE [dbo].[TestingResult]
GO

CREATE TABLE [dbo].[TestingResult] (
  [DoorID] varchar(250) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorMold] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderNum] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [TestingTime] datetime  NULL,
  [Result] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorEdgeResult0] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorEdgeFailedReason0] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorEdgeResult1] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorEdgeFailedReason1] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorEdgeResult2] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorEdgeFailedReason2] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorEdgeResult3] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DoorEdgeFailedReason3] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[TestingResult] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of TestingResult
-- ----------------------------
INSERT INTO [dbo].[TestingResult] VALUES (N'T0001', N'A1', N'GB0001', N'2019-06-14 15:25:03.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0002', N'A2', N'GB0001', N'2019-06-15 11:16:12.000', N'0', N'1', NULL, N'0', N'1', N'1', NULL, N'0', N'2')
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0003', N'A2', N'GB0002', N'2019-06-15 11:16:12.000', N'0', N'0', N'4', N'0', N'8', N'0', N'16', N'0', N'32')
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0004', N'A1', N'GB0002', N'2019-06-16 11:16:12.000', N'0', N'0', N'64', N'0', N'128', N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0005', N'A1', N'GB0002', N'2019-06-17 11:16:12.000', N'0', N'1', NULL, N'1', NULL, N'0', N'2', N'0', N'4')
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0006', N'A1', N'GB0003', N'2019-06-17 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0007', N'A1', N'GB0003', N'2019-06-17 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0008', N'A1', N'GB0003', N'2019-06-17 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0009', N'A1', N'GB0003', N'2019-06-17 11:16:12.000', N'0', N'0', N'8', N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0010', N'A1', N'GB0003', N'2019-06-18 11:16:12.000', N'0', N'1', NULL, N'0', N'32', N'0', N'1', N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0011', N'A1', N'GB0003', N'2019-06-18 11:16:12.000', N'0', N'0', N'16', N'0', N'4', N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0012', N'A1', N'GB0003', N'2019-06-18 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0013', N'A1', N'GB0003', N'2019-06-19 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0014', N'A1', N'GB0004', N'2019-06-19 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0015', N'A1', N'GB0004', N'2019-06-20 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0016', N'A1', N'GB0004', N'2019-06-21 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0017', N'A1', N'GB0004', N'2019-06-22 11:16:12.000', N'0', N'0', N'1', N'0', N'4', N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0018', N'A1', N'GB0005', N'2019-06-23 11:16:12.000', N'0', N'1', NULL, N'0', N'128', N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0019', N'A1', N'GB0005', N'2019-06-24 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0020', N'A1', N'GB0005', N'2019-06-25 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0021', N'A1', N'GB0005', N'2019-06-25 11:16:12.000', N'0', N'0', N'64', N'1', NULL, N'1', NULL, N'0', N'8')
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0022', N'A2', N'GB0005', N'2019-06-26 11:16:12.000', N'0', N'1', NULL, N'0', N'2', N'0', N'16', N'0', N'32')
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0023', N'A2', N'GB0005', N'2019-06-27 11:16:12.000', N'0', N'1', NULL, N'1', NULL, N'0', N'1', N'0', N'4')
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0024', N'A2', N'GB0005', N'2019-06-27 11:16:12.000', N'0', N'1', NULL, N'1', NULL, N'1', NULL, N'0', N'8')
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0025', N'A2', N'GB0005', N'2019-06-28 11:16:12.000', N'0', N'0', N'2', N'1', NULL, N'1', NULL, N'1', NULL)
GO

INSERT INTO [dbo].[TestingResult] VALUES (N'T0026', N'A2', N'GB0005', N'2019-06-29 11:16:12.000', N'1', N'1', NULL, N'1', NULL, N'1', NULL, N'1', NULL)
GO


-- ----------------------------
-- Procedure structure for searchOutput
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[searchOutput]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[searchOutput]
GO

CREATE PROCEDURE [dbo].[searchOutput]
@ProductionTime date
as
begin
select SUM(Output) from Production where ProductionTime=@ProductionTime
end
GO


-- ----------------------------
-- Procedure structure for searchQualifiedNumber
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[searchQualifiedNumber]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[searchQualifiedNumber]
GO

CREATE PROCEDURE [dbo].[searchQualifiedNumber]
@ProductionTime date
as
begin
select SUM(QualifiedNumber) from Production where ProductionTime=@ProductionTime
end
GO


-- ----------------------------
-- Procedure structure for updateOutput
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateOutput]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateOutput]
GO

CREATE PROCEDURE [dbo].[updateOutput]
@DoorMold varchar(500),
@OrderNum varchar(500),
@ProductionTime date,
@Output int,
@QualifiedNumber int
as
begin
update Production set Output=@Output,QualifiedNumber=@QualifiedNumber where ProductionTime=@ProductionTime and OrderNum=@OrderNum and DoorMold=@DoorMold
end
GO


-- ----------------------------
-- Procedure structure for addProduction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[addProduction]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[addProduction]
GO

CREATE PROCEDURE [dbo].[addProduction]
@DoorMold varchar(500),
@OrderNum varchar(500),
@ProductionTime date,
@Output int,
@QualifiedNumber int
as
begin
insert into Production(DoorMold,OrderNum,ProductionTime,Output,QualifiedNumber)values(@DoorMold,@OrderNum,@ProductionTime,@Output,@QualifiedNumber)
end
GO


-- ----------------------------
-- Procedure structure for searchSecondID
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[searchSecondID]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[searchSecondID]
GO

CREATE PROCEDURE [dbo].[searchSecondID]
@SecondDoorID varchar(50)
as
begin
select * from ProductionSubsidiary where DoorID=@SecondDoorID
end
GO


-- ----------------------------
-- Procedure structure for insertAlarm
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[insertAlarm]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[insertAlarm]
GO

CREATE PROCEDURE [dbo].[insertAlarm]
@AlarmTime datetime,
@AlarmContent varchar(500)
as
begin
insert into Alarm(AlarmTime,AlarmContent,Result)values(@AlarmTime,@AlarmContent,0)
end
GO


-- ----------------------------
-- Procedure structure for searchRepeatAlarm
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[searchRepeatAlarm]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[searchRepeatAlarm]
GO

CREATE PROCEDURE [dbo].[searchRepeatAlarm]
@AlarmContent varchar(500)
as
begin
select * from Alarm where AlarmContent=@AlarmContent and Result=0
end
GO


-- ----------------------------
-- Procedure structure for addlog
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[addlog]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[addlog]
GO

CREATE PROCEDURE [dbo].[addlog]
@ErrorTime datetime,
@ErrorInfo varchar(500)
as
begin
insert into ErrorReport(ErrorTime,ErrorInfo)values(@ErrorTime,@ErrorInfo)
end
GO


-- ----------------------------
-- Procedure structure for EnterDoorInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[EnterDoorInfo]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[EnterDoorInfo]
GO

CREATE PROCEDURE [dbo].[EnterDoorInfo]
@LoadBatchID VarChar(50),
@OrderNum VarChar(50),
@OrderQuantity int,
@DoorMold VarChar(50),
@PlacementMode VarChar(50),
@ThicknessDistinguish VarChar(50),
@OpenDirection VarChar(50),
@StackPosition VarChar(50),
@PerlitePosition varchar(50),
@ThinPlateLength int,
@ThinPlateWidth int,
@ThickPlateLength int,
@ThickPlateWidth int,
@Thickness int,
@ThinPlateKeyholeX int,
@ThinPlateKeyholeY int,
@ThickPlateKeyholeX int,
@ThickPlateKeyholeY int,
@WeldSpacingUpDownStr VarChar(50),
@WeldSpacingHingeStr VarChar(50),
@WeldSpacingKeyholeStr VarChar(50),
@WeldNumUpDown int,
@WeldNumHinge int,
@WeldNumKeyhole int,
@PerliteLength int,
@PerliteWidth int,
@PerliteThickness int,
@ThinPlateViewerX int,
@ThinPlateViewerY int,
@ThickPlateViewerX int,
@ThickPlateViewerY int,
@LaminationDosage int,
@Status VarChar(50),
@LoadNum int,
@SentNum int
as
begin
insert into DoorInfo(LoadBatchID,OrderNum,OrderQuantity,DoorMold,PlacementMode,ThicknessDistinguish,OpenDirection,StackPosition,PerlitePosition,ThinPlateLength,
ThinPlateWidth,ThickPlateLength,ThickPlateWidth,Thickness,ThinPlateKeyholeX,ThinPlateKeyholeY,ThickPlateKeyholeX,ThickPlateKeyholeY,WeldSpacingUpDownStr,
WeldSpacingHingeStr,WeldSpacingKeyholeStr,WeldNumUpDown,WeldNumHinge,WeldNumKeyhole,PerliteLength,PerliteWidth,PerliteThickness,ThinPlateViewerX,
ThinPlateViewerY,ThickPlateViewerX,ThickPlateViewerY,LaminationDosage,Status,LoadNum,SentNum)values(@LoadBatchID,@OrderNum,@OrderQuantity,@DoorMold,
@PlacementMode,@ThicknessDistinguish,@OpenDirection,@StackPosition,@PerlitePosition,@ThinPlateLength,@ThinPlateWidth,@ThickPlateLength,@ThickPlateWidth,@Thickness,
@ThinPlateKeyholeX,@ThinPlateKeyholeY,@ThickPlateKeyholeX,@ThickPlateKeyholeY,@WeldSpacingUpDownStr,@WeldSpacingHingeStr,@WeldSpacingKeyholeStr,
@WeldNumUpDown,@WeldNumHinge,@WeldNumKeyhole,@PerliteLength,@PerliteWidth,@PerliteThickness,@ThinPlateViewerX,@ThinPlateViewerY,@ThickPlateViewerX,
@ThickPlateViewerY,@LaminationDosage,@Status,@LoadNum,@SentNum)
end
GO


-- ----------------------------
-- Procedure structure for searchdoorInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[searchdoorInfo]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[searchdoorInfo]
GO

CREATE PROCEDURE [dbo].[searchdoorInfo]
as
begin
select top 1 * from DoorInfo where Status!=2 order by LoadBatchID
end
GO


-- ----------------------------
-- Procedure structure for UpdateStatus
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateStatus]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[UpdateStatus]
GO

CREATE PROCEDURE [dbo].[UpdateStatus]
@LoadBatchID varchar(50),
@Status int,
@SentNum int
as
begin
update DoorInfo set Status=@Status,SentNum=@SentNum where LoadBatchID=@LoadBatchID
end
GO


-- ----------------------------
-- Procedure structure for addbasicinfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[addbasicinfo]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[addbasicinfo]
GO

CREATE PROCEDURE [dbo].[addbasicinfo]
@DoorID varchar(50),
@DoorMold varchar(50),
@WorkSheetNumber varchar(50),
@PlacementMode varchar(50),
@ThicknessDistinguish varchar(50),
@OpenDirection varchar(50),
@StackPosition varchar(50),
@PerlitePosition varchar(50),
@ThinPlateLength int,
@ThinPlateWidth int,
@ThickPlateLength int,
@ThickPlateWidth int,
@Thickness int,
@FeedingTime datetime,
@LaminationDosage int,
@PerliteLength int,
@PerliteWidth int,
@PerliteThickness int,
@WeldSpacingUpDownStr varchar(500),
@WeldSpacingHingeStr varchar(500),
@WeldSpacingKeyholeStr varchar(500),
@WeldNumUpDown int,
@WeldNumHinge int,
@WeldNumKeyhole int,
@ThinPlateKeyholeX int,
@ThinPlateKeyholeY int,
@ThickPlateKeyholeX int,
@ThickPlateKeyholeY int,
@ThinPlateViewerX int,
@ThinPlateViewerY int,
@ThickPlateViewerX int,
@ThickPlateViewerY int,
@LockWidth int,
@LockLength int
as
begin
insert into ProductionSubsidiary(DoorID,DoorMold,OrderNum,PlacementMode,ThicknessDistinguish,OpenDirection,StackPosition,PerlitePosition,ThinPlateLength,ThinPlateWidth,ThickPlateLength,ThickPlateWidth,Thickness,FeedingTime,LaminationDosage,PerliteLength,PerliteWidth,PerliteThickness,WeldSpacingUpDownStr,WeldSpacingHingeStr,WeldSpacingKeyholeStr,WeldNumUpDown,WeldNumHinge,WeldNumKeyhole,ThinPlateKeyholeX,ThinPlateKeyholeY,ThickPlateKeyholeX,ThickPlateKeyholeY,ThinPlateViewerX,ThinPlateViewerY,ThickPlateViewerX,ThickPlateViewerY,LockWidth,LockLength)values(@DoorID,@DoorMold,@WorkSheetNumber,@PlacementMode,@ThicknessDistinguish,@OpenDirection,@StackPosition,@PerlitePosition,@ThinPlateLength,@ThinPlateWidth,@ThickPlateLength,@ThickPlateWidth,@Thickness,@FeedingTime,@LaminationDosage,@PerliteLength,@PerliteWidth,@PerliteThickness,@WeldSpacingUpDownStr,@WeldSpacingHingeStr,@WeldSpacingKeyholeStr,@WeldNumUpDown,@WeldNumHinge,@WeldNumKeyhole,@ThinPlateKeyholeX,@ThinPlateKeyholeY,@ThickPlateKeyholeX,@ThickPlateKeyholeY,@ThinPlateViewerX,@ThinPlateViewerY,@ThickPlateViewerX,@ThickPlateViewerY,@LockWidth,@LockLength)
end
GO


-- ----------------------------
-- Procedure structure for updatefillinputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updatefillinputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updatefillinputtime]
GO

CREATE PROCEDURE [dbo].[updatefillinputtime]
@FillInputTime datetime,
@FillDoorID varchar(50)
as
begin
update ProductionSubsidiary set PerliteFillingPullInTime=@FillInputTime where DoorID=@FillDoorID 
end
GO


-- ----------------------------
-- Procedure structure for updatefilloutputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updatefilloutputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updatefilloutputtime]
GO

CREATE PROCEDURE [dbo].[updatefilloutputtime]
@FilloutputTime datetime,
@FillDoorID varchar(50)
as
begin
update ProductionSubsidiary set PerliteFillingPullOutTime=@FilloutputTime where DoorID=@FillDoorID 
end
GO


-- ----------------------------
-- Procedure structure for updateLaminationPullInTime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateLaminationPullInTime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateLaminationPullInTime]
GO

CREATE PROCEDURE [dbo].[updateLaminationPullInTime]
@FilmMulchInputTime datetime,
@FilmMulchDoorID varchar(50)
as
begin
update ProductionSubsidiary set LaminationPullInTime=@FilmMulchInputTime where DoorID=@FilmMulchDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateLaminationPullOutTime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateLaminationPullOutTime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateLaminationPullOutTime]
GO

CREATE PROCEDURE [dbo].[updateLaminationPullOutTime]
@FilmMulchOutputTime datetime,
@UpMembraneAllowance int,
@DownMembraneAllowance int,
@CutLength int,
@Cutwidth int,
@MulchDoorID varchar(50)
as
begin
update ProductionSubsidiary set LaminationPullOutTime=@FilmMulchOutputTime,EpisporiumAllowance=@UpMembraneAllowance,CounterdieAllowance=@DownMembraneAllowance,CuttingLength=@CutLength,CuttingWidth=@Cutwidth where DoorID=@MulchDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateGluingInputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateGluingInputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateGluingInputtime]
GO

CREATE PROCEDURE [dbo].[updateGluingInputtime]
@GluingInputTime datetime,
@GluingDoorID varchar(50)
as
begin
update ProductionSubsidiary set GluingPullInTime=@GluingInputTime where DoorID=@GluingDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateGluingOutputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateGluingOutputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateGluingOutputtime]
GO

CREATE PROCEDURE [dbo].[updateGluingOutputtime]
@GluingOutputTime datetime,
@ActualDosage int,
@ResidualGlue int,
@GluingTime int,
@GluingDoorID varchar(50)
as
begin
update ProductionSubsidiary set GluingPullOutTime=@GluingOutputTime,ActualSerlantVolume=@ActualDosage,QuantityGlue=@ResidualGlue,GelatinizeTime=@GluingTime where DoorID=@GluingDoorID
end
GO


-- ----------------------------
-- Procedure structure for updatePressInputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updatePressInputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updatePressInputtime]
GO

CREATE PROCEDURE [dbo].[updatePressInputtime]
@PressInputTime datetime,
@PressDoorID varchar(50)
as
begin
update ProductionSubsidiary set PressFitPullInTime=@PressInputTime where DoorID=@PressDoorID
end
GO


-- ----------------------------
-- Procedure structure for updatePressOutputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updatePressOutputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updatePressOutputtime]
GO

CREATE PROCEDURE [dbo].[updatePressOutputtime]
@PressOutputTime datetime,
@Presstemperature int,
@PressDoorID varchar(50)
as
begin
update ProductionSubsidiary set PressFitPullOutTime=@PressOutputTime,PressFitTemperature=@Presstemperature where DoorID=@PressDoorID
end
GO


-- ----------------------------
-- Procedure structure for updatePolishInputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updatePolishInputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updatePolishInputtime]
GO

CREATE PROCEDURE [dbo].[updatePolishInputtime]
@PolishInputTime datetime,
@PolishDoorID varchar(50)
as
begin
update ProductionSubsidiary set PolishedPullInTime=@PolishInputTime where DoorID=@PolishDoorID
end
GO


-- ----------------------------
-- Procedure structure for updatePolishOutputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updatePolishOutputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updatePolishOutputtime]
GO

CREATE PROCEDURE [dbo].[updatePolishOutputtime]
@PolishOutputTime datetime,
@PolishDoorID varchar(50)
as
begin
update ProductionSubsidiary set PolishedPullOutTime=@PolishOutputTime where DoorID=@PolishDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateWeldingInputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateWeldingInputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateWeldingInputtime]
GO

CREATE PROCEDURE [dbo].[updateWeldingInputtime]
@WeldingInputTime datetime,
@WeldingDoorID varchar(50)
as
begin
update ProductionSubsidiary set WeldingPullInTime=@WeldingInputTime where DoorID=@WeldingDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateWeldingOutputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateWeldingOutputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateWeldingOutputtime]
GO

CREATE PROCEDURE [dbo].[updateWeldingOutputtime]
@WeldingOutputTime datetime,
@WeldingCurrent int,
@WeldingVoltage int,
@WireFeedingSpeed int,
@WeldingTime int,
@WeldingDoorID varchar(50)
as
begin
update ProductionSubsidiary set WeldingPullOutTime=@WeldingOutputTime,WeldingElectricity=@WeldingCurrent,WeldingVoltage=@WeldingVoltage,WeldingSpendTime=@WeldingTime,WireFeedRate=@WireFeedingSpeed where DoorID=@WeldingDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateRemoveSmokeTrainInputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateRemoveSmokeTrainInputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateRemoveSmokeTrainInputtime]
GO

CREATE PROCEDURE [dbo].[updateRemoveSmokeTrainInputtime]
@RemoveSmokeTrainInputTime datetime,
@RemoveSmokeTrainDoorID varchar(50)
as
begin
update ProductionSubsidiary set SprayPaintPullInTime=@RemoveSmokeTrainInputTime where DoorID=@RemoveSmokeTrainDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateRemoveSmokeTrainOutputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateRemoveSmokeTrainOutputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateRemoveSmokeTrainOutputtime]
GO

CREATE PROCEDURE [dbo].[updateRemoveSmokeTrainOutputtime]
@RemoveSmokeTrainOutputTime datetime,
@PaintingTime int,
@RemoveSmokeTrainDoorID varchar(50)
as
begin
update ProductionSubsidiary set SprayPaintPullOutTime=@RemoveSmokeTrainOutputTime,SprayPaintSpendTime=@PaintingTime where DoorID=@RemoveSmokeTrainDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateCheckInputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateCheckInputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateCheckInputtime]
GO

CREATE PROCEDURE [dbo].[updateCheckInputtime]
@CheckInputTime datetime,
@CheckDoorID varchar(50)
as
begin
update ProductionSubsidiary set VisualInspectionPullInTime=@CheckInputTime where DoorID=@CheckDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateCheckOutputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateCheckOutputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateCheckOutputtime]
GO

CREATE PROCEDURE [dbo].[updateCheckOutputtime]
@CheckOutputTime datetime,
@CheckResult varchar(500),
@NGCause varchar(500),
@CheckDoorID varchar(50)
as
begin
update ProductionSubsidiary set VisualInspectionPullOutTime=@CheckOutputTime,VisualInspectionResult=@CheckResult,NGCause=@NGCause where DoorID=@CheckDoorID
end
GO


-- ----------------------------
-- Procedure structure for updateUnloadOutputtime
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[updateUnloadOutputtime]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[updateUnloadOutputtime]
GO

CREATE PROCEDURE [dbo].[updateUnloadOutputtime]
@UnloadOutputTime datetime,
@UnloadDoorID varchar(50)
as
begin
update ProductionSubsidiary set BlankingTime=@UnloadOutputTime where DoorID=@UnloadDoorID
end
GO


-- ----------------------------
-- Primary Key structure for table Account
-- ----------------------------
ALTER TABLE [dbo].[Account] ADD CONSTRAINT [PK__Account__349DA586C6F59296] PRIMARY KEY CLUSTERED ([AccountID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table OrderInfo
-- ----------------------------
ALTER TABLE [dbo].[OrderInfo] ADD CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED ([OrderNum])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

