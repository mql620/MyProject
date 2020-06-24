using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common
{
    public class PLCReadInfo
    {
        //检测/下料站
        public int CheckInput { get; set; }//检测进站
        public int CheckOutput { get; set; }//检测出站
        public int UnloadInput { get; set; }//下料进站
        public int UnloadOutput { get; set; }//下料出站
        public string CheckDoorID { get; set; }//检测门ID
        public string UnloadDoorID { get; set; }// 下料门ID
        public int CheckDoorType { get; set; }//检测门类型
        public int UnloadDoorType { get; set; }//下料门类型
        public int UnloadTime { get; set; }//下料时间-------------------------
        public int CheckStep { get; set; }//检测站步骤
        public int UnloadStep { get; set; }//下料站步骤
        public int CheckResult { get; set; }//检测结果
        public int NGReason { get; set; }//NG原因

        //除烟痕站
        public int RemoveSmokeTrainInput { get; set; }//除烟痕进站
        public int RemoveSmokeTrainOutput { get; set; }//除烟痕出站
        public string RemoveSmokeTrainDoorID { get; set; }//除烟痕门ID
        public int RemoveSmokeTrainDoorType { get; set; }//除烟痕门类型
        public int PaintAllowance { get; set; }//漆余量
        public int PaintingTime { get; set; }//喷漆时间-------------------------

        //焊接站
        public int WeldingInput { get; set; }//焊接进站
        public int WeldingOutput { get; set; }//焊接出站
        public string WeldingDoorID { get; set; } //焊接门ID
        public int WeldingDoorType { get; set; } //焊接门类型
        public int WeldingCurrent { get; set; }//焊接电流
        public int WeldingVoltage { get; set; }//焊接电压
        public int WireFeedingSpeed { get; set; }//送丝速度
        public int WeldingTime { get; set; }//焊接时间-----------------------

        //打磨站
        public int PolishInput { get; set; }//打磨进站
        public int PolishOutput { get; set; }//打磨出站
        public string PolishDoorID { get; set; }//打磨门ID
        public int PolishDoorType { get; set; }//打磨门类型

        //压合站
        public int PressInput { get; set; }//压合进站
        public int PressOutput { get; set; }//压合出站
        public string PressDoorID { get; set; }//压合门ID
        public int PressDoorType { get; set; } //压合门类型
        public int Presstemperature { get; set; }//压合温度

        //珍珠岩站
        public int FillInput { get; set; }//珍珠岩填充进站
        public int FillOutput { get; set; }//珍珠岩填充出站
        public string FillDoorID { get; set; }//珍珠岩填充站门ID
        public int FillDoorType { get; set; }//珍珠岩填充站门类型
        public int PerliteAllowance { get; set; }//珍珠岩余量
        public string ArtificialAssembleDoorID { get; set; }//人工合门ID
        public int ArtificialAssembleDoorType { get; set; }//人工合门类型
        public int FillStep { get; set; }//珍珠岩填充站步骤

        //涂胶站
        public int GluingInput { get; set; }//涂胶进站
        public int GluingOutput { get; set; }//涂胶出站
        public string GluingDoorID { get; set; }//涂胶门ID
        public int GluingDoorType { get; set; }//涂胶门类型
        public int ActualDosage { get; set; }//实际出胶量
        public int ResidualGlue { get; set; }//剩余胶量
        public int GluingTime { get; set; }//涂胶时间----------------------

        //覆膜站
        public int FilmMulchInput { get; set; }//覆膜进站
        public int FilmMulchOutput { get; set; }//覆膜出站
        public string MulchDoorID { get; set; }//覆膜门ID
        public int MulchDoorType { get; set; }//覆膜门类型
        public int UpMembraneAllowance { get; set; }//上膜的剩余量
        public int DownMembraneAllowance { get; set; }//下膜的剩余量
        public int CutLength { get; set; }//覆膜膜裁剪长度
        public int Cutwidth { get; set; }//覆膜膜裁剪宽度

        //上料站
        public int LoadInput { get; set; }//上料进站
        public int LoadOutput { get; set; }//上料出站
        public string SplitDoorID { get; set; }//分门门ID
        public int SplitDoorType { get; set; }//分门门类型
        public int LoadStep { get; set; }//上料站步骤



        //标志位
        public int HeartBeat { get; set; }//心跳
        public int SendDone { get; set; }//发送完成信号
        public int LoadRequest_Flag { get; set; }//上料站请求数据标志位
        public int LoadReceive_Flag { get; set; }//上料站接收完成标志位
        public int LoadFault_Flag { get; set; }//上料站故障标志位
        public int MulchingFault_Flag { get; set; }//覆膜站故障标志位
        public int FillFault_Flag { get; set; }//填充站故障标志位
        public int CheckFault_Flag { get; set; }//检测故障标志位
        public int LayingOffFault_Flag { get; set; }//下料站故障标志位

        //报警
        public int LoadABBNoHome { get; set; }//上料站提示:ABB 不在Home点
        public int LoadReverseNoHome { get; set; }//上料站提示:反转气缸没有到位
        public int LoadLaserNoHome { get; set; }//上料站提示:激光测距气缸没到位
        public int LoadMatterCar1NoHome { get; set; }//上料站提示:料车1没到位
        public int LoadMatterCar2NoHome { get; set; }//上料站提示:料车2没到位
        public int LoadABBNotAuto { get; set; }//上料站提示:ABB没有在自动状态
        public int LoadABBNotLoop { get; set; }//上料站提示:ABB没有循环运行
        public int LoadGluingComAbnormal { get; set; }//上料站提示:与涂胶站通信异常
        public int LoadPerliteComAbnormal { get; set; }//上料站提示:与珍珠岩站通信异常
        public int LoadMainStationComAbnormal { get; set; }//上料站提示:与主站通信异常
        public int LoadEStop { get; set; }//上料站故障:急停按钮被按下
        public int LoadABBDisconnect { get; set; }//上料站故障:ABB通信掉线
        public int LoadABBFault { get; set; }//上料站故障:ABB故障
        public int LoadVF0Disconnect { get; set; }//上料站故障:VF0通信掉线
        public int LoadVF0Fault { get; set; }//上料站故障:VF0报错
        public int LoadVF1Disconnect { get; set; }//上料站故障:VF1通信掉线
        public int LoadVF1Fault { get; set; }//上料站故障:VF1报错
        public int LoadVF2Disconnect { get; set; }//上料站故障:VF2通信掉线
        public int LoadVF2Fault { get; set; }//上料站故障:VF2报错
        public int LoadVF3Disconnect { get; set; }//上料站故障:VF3通信掉线
        public int LoadVF3Fault { get; set; }//上料站故障:VF3报错
        public int LoadVF4Disconnect { get; set; }//上料站故障:VF4通信掉线
        public int LoadVF4Fault { get; set; }//上料站故障:VF4报错
        public int LoadVF5Disconnect { get; set; }//上料站故障:VF5通信掉线
        public int LoadVF5Fault { get; set; }//上料站故障:VF5报错
        public int LoadABBVacuumError { get; set; }//上料站故障:ABB吸真空异常
        public int LoadABBBreakVacuumError { get; set; }//上料站故障:ABB破真空压力异常
        public int LoadOverturnReturnError { get; set; }//上料站故障:翻转气缸退回异常
        public int LoadOverturnReachError { get; set; }//上料站故障:翻转气缸伸出限位异常
        public int LoadUnableAutoStart { get; set; }//上料站故障:手动按钮未回位,不能自动启动
        public int LoadUnableContinue { get; set; }//上料站故障:手动按钮未回位,不能继续运行
        public int LoadVF0ToVF1Error { get; set; }//上料站故障:VF0与VF1物料传输异常
        public int LoadVF1ToVF2Error { get; set; }//上料站故障:VF1与VF2物料传输异常
        public int LoadVF3ToVF4Error { get; set; }//上料站故障:VF3与VF4物料传输异常
        public int LoadVF4ToVF5Error { get; set; }//上料站故障:VF4与VF5物料传输异常
        public int LoadVF5ToGluingError { get; set; }//上料站故障:VF5与涂胶站物料传输异常
        public int LoadGluingToVF6Error { get; set; }//上料站故障:涂胶站与VF6物料传输异常
        public int Load1LaserBeyondRange { get; set; }//上料站故障:1#激光数值超出量程
        public int Load2LaserBeyondRange { get; set; }//上料站故障:2#激光数值超出量程
        public int Load3LaserBeyondRange { get; set; }//上料站故障:3#激光数值超出量程
        public int LoadNoThicknessData { get; set; }//上料站故障:防火门没有门厚数据

        public int FrontRollerError { get; set; }//覆膜站故障：前端辊筒顶升异常（DB31，16.0开始）
        public int UpperAdsorptionError { get; set; }//覆膜站故障：上吸附板异常
        public int DownAdsorptionError { get; set; }//覆膜站故障：下吸附板异常
        public int UpperCutError { get; set; }//覆膜站故障：上纵切气缸异常
        public int DownCutError { get; set; }//覆膜站故障：下纵切气缸异常
        public int CrossCutError { get; set; }//覆膜站故障：横切气缸异常
        public int UpperAdsorptionVacuumError { get; set; }//覆膜站故障：上吸附真空异常
        public int DownAdsorptionVacuumError { get; set; }//覆膜站故障：下吸附真空异常
        public int EstopError { get; set; }//覆膜站故障：急停报警
        public int UpperFrontLack { get; set; }//覆膜站故障：上前膜缺料报警
        public int UpperBehindLack { get; set; }//覆膜站故障：上后膜缺料报警
        public int DownFrontLack { get; set; }//覆膜站故障：下前膜缺料报警
        public int DownBehindLack { get; set; }//覆膜站故障：下后膜缺料报警
        public int LowAirPressureAlarm { get; set; }//覆膜站故障：气压低报警
        public int FrontRollerVFDError { get; set; }//覆膜站故障：前压辊变频器故障
        public int BehindRollerVFDError { get; set; }//覆膜站故障：后压辊变频器故障
        public int FrontPowerVFDError { get; set; }//覆膜站故障：前动力辊伺服故障
        public int BehindPowerVFDError { get; set; }//覆膜站故障：后动力辊伺服故障
        public int UpperCutVFDError { get; set; }//覆膜站故障：上纵切伺服故障
        public int DownCutVFDError { get; set; }//覆膜站故障：下纵切伺服故障
        public int CrossCutVFDError { get; set; }//覆膜站故障：横切伺服故障
        public int ServoNoHome { get; set; }//覆膜站故障：伺服没回Home点报警
        public int UpperCutForwardLimit { get; set; }//覆膜站故障：上纵切伺服正极限报警
        public int UpperCutReverseLimit { get; set; }//覆膜站故障：上纵切伺服反极限报警
        public int DownCutForwardLimit { get; set; }//覆膜站故障：下纵切伺服正极限报警
        public int DownCutReverseLimit { get; set; }//覆膜站故障：下纵切伺服反极限报警
        public int CrossCutForwardLimit { get; set; }//覆膜站故障：横切伺服正极限报警
        public int CrossCutReverseLimit { get; set; }//覆膜站故障：横切伺服反极限报警
        public int DoorDataTransferIncomplete { get; set; }//覆膜站故障：门数据传递没有完成
        public int FrontRollerVFDNoCom { get; set; }//覆膜站故障：前压辊变频器掉线
        public int BehindRollerVFDNoCom { get; set; }//覆膜站故障：后压辊变频器掉线
        public int MainStationNoCom { get; set; }//覆膜站故障：与主站通讯故障
        public int LoadStationNoCom { get; set; }//覆膜站故障：与上料站通讯故障
        public int FrontPowerServoNoCom { get; set; }//覆膜站故障：前动力辊伺服掉线
        public int BehindPowerServoNoCom { get; set; }//覆膜站故障：后动力辊伺服掉线
        public int UpperCutServoNoCom { get; set; }//覆膜站故障：上纵切伺服掉线
        public int DownCutServoNoCom { get; set; }//覆膜站故障：下纵切伺服掉线
        public int CrossCutServoNoCom { get; set; }//覆膜站故障：横切伺服掉线


        
        public int FillClamp1LocationError { get; set; }//填充站提示:填充夹紧1气缸未到位
        public int FillClamp2LocationError { get; set; }//填充站提示:填充夹紧2气缸未到位
        public int FillObstructLocationError { get; set; }//填充站提示:填充阻挡气缸未到位
        public int FillJackLocationError { get; set; }//填充站提示:填充顶升气缸未到位
        public int FillIncomplete { get; set; }//填充站提示:填充工位有料,未完成
        public int FillABBNoHome { get; set; }//填充站提示:填充ABB机器人未回原点
        public int FillPerliteCar1LocationError { get; set; }//填充站提示:珍珠岩料车1未到位
        public int FillPerliteCar2LocationError { get; set; }//填充站提示:珍珠岩料车2未到位
        public int FillPerliteSecondLocationFull { get; set; }//填充站提示:珍珠岩二次定位有料
        public int FillLongSideLocationError { get; set; }//填充站提示:填充长边对中气缸未到位
        public int FillShortSideLocationError { get; set; }//填充站提示:填充短边对中气缸未到位
        public int Fill90DegreesNoHome { get; set; }//填充站提示:90度旋转/顶升电机不在初始状态
        public int Fill90DegreesFull { get; set; }//填充站提示:90度工位有料
        public int Fill90DegreesJackUpLocationError { get; set; }//填充站提示:90度顶升气缸未回到位
        public int Fill90DegreesClampLocationError { get; set; }//填充站提示:90度夹紧气缸未回到位
        public int FillABBNotAuto { get; set; }//填充站提示:ABB机器人不在自动
        public int FillABBNotLoopRun { get; set; }//填充站提示:ABB机器人没有循环运行
        public int FillNoComWithLoad { get; set; }//填充站提示:与上料站通信异常
        public int FillNoComWithLamination { get; set; }//填充站提示:与压合站通信异常
        public int FillNoComWithMain { get; set; }//填充站提示:与主站通信异常
        public int FillNoPerlite { get; set; }//填充站提示:珍珠岩已抓完/请放物料
        public int FillEstop { get; set; }//填充站:急停异常
        public int FillABBOffLine { get; set; }//填充站:ABB通信掉线
        public int FillABBError { get; set; }//填充站:ABB机器人报错
        public int FillVF1OffLine { get; set; }//填充站:VF1通信掉线
        public int FillVF1Error { get; set; }//填充站:VF1报错
        public int FillVF2OffLine { get; set; }//填充站:VF2通信掉线
        public int FillVF2Error { get; set; }//填充站:VF2报错
        public int FillVF3OffLine { get; set; }//填充站:VF3通信掉线
        public int FillVF3Error { get; set; }//填充站:VF3报错
        public int FillVF4OffLine { get; set; }//填充站:VF4通信掉线
        public int FillVF4Error { get; set; }//填充站:VF4报错
        public int FillVF5OffLine { get; set; }//填充站:VF5通信掉线
        public int FillVF5Error { get; set; }//填充站:VF5报错
        public int FillVF6OffLine { get; set; }//填充站:VF6通信掉线
        public int FillVF6Error { get; set; }//填充站:VF6报错
        public int FillVF7OffLine { get; set; }//填充站:VF7通信掉线
        public int FillVF7Error { get; set; }//填充站:VF7报错
        public int FillVF8OffLine { get; set; }//填充站:VF8通信掉线
        public int FillVF8Error { get; set; }//填充站:VF8报错
        public int FillJackUpLimitError { get; set; }//填充站:顶升气缸顶升限位异常
        public int FillJackDownLimitError { get; set; }//填充站:顶升气缸下降限位异常
        public int FillObstructLimitError { get; set; }//填充站:阻挡气缸阻挡限位异常
        public int FillPullBackLimitError { get; set; }//填充站:回拉气缸回拉限位异常
        public int FillClamp1TightLimitError { get; set; }//填充站:夹紧_1气缸夹紧限位异常
        public int FillClamp2TightLimitError { get; set; }//填充站:夹紧_2气缸夹紧限位异常
        public int FillClamp1PineLimitError { get; set; }//填充站:夹紧_1气缸送开限位异常
        public int FillClamp2PineLimitError { get; set; }//填充站:夹紧_2气缸送开限位异常
        public int FillPullBackReturnError { get; set; }//填充站:回拉气缸退回限位异常
        public int FillObstructReturnError { get; set; }//填充站:阻挡气缸退回限位异常
        public int FillPerliteVacuumErrorv { get; set; }//填充站:珍珠岩吸真空信号异常
        public int FillRobotNotFoundPerlite { get; set; }//填充站:珍珠岩机器人未感应到珍珠岩
        public int FillPerliteBreakVacuumError { get; set; }//填充站:珍珠岩破真空信号异常
        public int FillPerliteShortSideRiseError { get; set; }//填充站:珍珠岩短边对中气缸升出信号异常
        public int FillPerliteLongSideRiseError { get; set; }//填充站:珍珠岩长边对中气缸升出信号异常
        public int Fill90DegreesVacuumError { get; set; }//填充站:90度吸真空信号异常
        public int Fill90DegreesJackRiseError { get; set; }//填充站:90度顶升气缸顶升信号异常
        public int Fill90DegreesClamp1Error { get; set; }//填充站:90度夹紧气缸_1信号异常
        public int Fill90DegreesClamp2Error { get; set; }//填充站:90度夹紧气缸_2信号异常
        public int Fill90DegreesJackReturnError { get; set; }//填充站:90度顶升气缸退回信号异常
        public int Fill90DegreesJackMotorRiseError { get; set; }//填充站:90度顶升电机顶升 异常
        public int Fill90DegreesJackMotorNoUpLimit { get; set; }//填充站:90度顶升电机不在顶升限
        public int Fill90DegreesRotateMotorForwardError { get; set; }//填充站:90度旋转电机正向旋转异常
        public int Fill90DegreesRotateMotorForwardLocationError { get; set; }//填充站:90度旋转电机正向旋转未到位
        public int Fill90DegreesJackMotorReturnError { get; set; }//填充站:90度顶升电机退回 异常
        public int Fill90DegreesRotateMotorReverseError { get; set; }//填充站:90度旋转电机反向旋转异常
        public int FillVF1ToVF2Error { get; set; }//#填充站故障:VF1与VF2物料传输异常
        public int FillVF2ToVF3Error { get; set; }//#填充站故障:VF2与VF3物料传输异常
        public int FillVF3ToVF4Error { get; set; }//#填充站故障:VF3与VF4物料传输异常
        public int FillVF4ToVF5Error { get; set; }//#填充站故障:VF4与VF5物料传输异常
        public int FillVF5ToVF6Error { get; set; }//#填充站故障:VF5与VF6物料传输异常
        public int FillRobotImpact { get; set; }//填充站故障:机器人碰撞物料_激光测距仪数值太小
        public int CheckJackLocationError { get; set; }//检测站提示:顶升气缸未到位
        public int CheckSidePushBigLocationError { get; set; }//检测站提示:侧推大气缸未到位
        public int CheckSidePushSmallLocationError { get; set; }//检测站提示:侧推小气缸未到位
        public int CheckPullBackLocationError { get; set; }//检测站提示:回拉气缸未到位
        public int CheckXNoStandby { get; set; }//检测站提示:X轴未回待机位
        public int CheckYNoStandby { get; set; }//检测站提示:Y轴未回待机位
        public int CheckRotaryNoStandby { get; set; }//检测站提示:旋转轴未回待机位
        public int CheckNoComToRemoveSmoke { get; set; }//检测站提示:与除烟痕站通信异常
        public int CheckNoComToMain { get; set; }//检测站提示:与主站通信异常
        public int CheckEstop { get; set; }//检测故障:急停报警
        public int CheckXServoError { get; set; }//检测故障:X轴伺服报错
        public int CheckXServoOffLine { get; set; }//检测故障:X轴伺服通信掉线
        public int CheckYServoError { get; set; }//检测故障:Y轴伺服报错
        public int CheckYServoOffLine { get; set; }//检测故障:Y轴伺服通信掉线
        public int CheckRotaryServoError { get; set; }//检测故障:旋转轴伺服报错
        public int CheckRotaryServoOffLine { get; set; }//检测故障:旋转轴伺服通信掉线
        public int CheckUpstreamDeliveryOvertime { get; set; }//检测故障:与上游交互传送运动超时
        public int CheckFeedOvertime { get; set; }//检测故障:本站进料完成超时
        public int CheckJackReachError { get; set; }//检测故障:顶升气缸伸出限位异常
        public int CheckPullBackReachError { get; set; }//检测故障:回拉气缸伸出限位异常
        public int CheckSidePushBigReachError { get; set; }//检测故障:侧推大气缸伸出限位异常
        public int CheckSidePushSmallReachError { get; set; }//检测故障:侧推小气缸伸出限位异常
        public int CheckXYZReturnStandbyError { get; set; }//检测故障:X/Y/Z轴回待机位异常
        public int CheckSidePushSmallReturnError { get; set; }//检测故障:侧推小气缸退回限位异常
        public int CheckSidePushBigReturnError { get; set; }//检测故障:侧推大气缸退回限位异常
        public int CheckPullBackReturnError { get; set; }//检测故障:回拉气缸退回限位异常
        public int CheckJackReturnError { get; set; }//检测故障:顶升气缸退回限位异常
        public int CheckDownstreamDeliveryOvertime { get; set; }//检测故障:与下游交互传送运动超时
        public int CheckDischargeOvertime { get; set; }//检测故障:本站出料完成超时
        public int CheckManualNoAuto { get; set; }//检测故障:手动操作画面未回位，不能自动启动
        public int CheckManualNoContinue { get; set; }//检测故障:手动操作画面未回位，不能继续运行
        public int CheckVFDNoCom { get; set; }//检测故障:变频器通讯异常
        public int CheckVFDError { get; set; }//检测故障:变频器报错
        public int UnloadJackLocationError { get; set; }//下料站提示:顶升气缸未回位
        public int UnloadClamp1LocationError { get; set; }//下料站提示:夹紧气缸1未回位
        public int UnloadClamp2LocationError { get; set; }//下料站提示:夹紧气缸2未回位
        public int UnloadPullBackLocationError { get; set; }//下料站提示:回拉气缸未回位
        public int UnloadServo1NoStandby { get; set; }//下料站提示:伺服1未回待机位
        public int UnloadServo2NoStandby { get; set; }//下料站提示:伺服2未回待机位
        public int UnloadSkipCar1LocationError { get; set; }//下料站提示:料车1未到位
        public int UnloadSkipCar2LocationError { get; set; }//下料站提示:料车2未到位
        public int UnloadABBNoAuto { get; set; }//下料站提示:ABB不在自动状态
        public int UnloadABBNoloop { get; set; }//下料站提示:ABB不在循环状态
        public int UnloadABBNoHome { get; set; }//下料站提示:ABB不在原点状态
        public int UnloadNGCarFull { get; set; }//下料站提示:NG料车满料
        public int UnloadOKCarFull { get; set; }//下料站提示:OK料车满料
        public int UnloadEstop { get; set; }//下料站故障:急停异常
        public int UnloadABBOffLine { get; set; }//下料站故障:ABB通信掉线
        public int UnloadABBError { get; set; }//下料站故障:ABB机器人报错
        public int UnloadServo1OffLine { get; set; }//下料站故障:伺服1通信掉线
        public int UnloadServo1Error { get; set; }//下料站故障:伺服1报错
        public int UnloadServo2OffLine { get; set; }//下料站故障:伺服2通信掉线
        public int UnloadServo2Error { get; set; }//下料站故障:伺服2报错
        public int UnloadUpstreamDeliveryOvertime { get; set; }//下料站故障:与上游交互传送运动超时
        public int UnloadFeedOvertime { get; set; }//下料站故障:本站进料完成超时
        public int UnloadJackReachError { get; set; }//下料站故障:顶升气缸伸出限异常
        public int UnloadPullBackReachError { get; set; }//下料站故障:回拉气缸伸出限异常
        public int UnloadClampTightLimit { get; set; }//下料站故障:夹紧气缸夹紧限异常
        public int UnloadClampReleaseLimit { get; set; }//下料站故障:夹紧气缸松开限异常
        public int UnloadPullBackReturnError { get; set; }//下料站故障:回拉气缸退回限异常
        public int UnloadManualNoAuto { get; set; }//下料站故障:手动按钮未回位，不能自动启动
        public int UnloadManualNoContinue { get; set; }//下料站故障:手动按钮未回位，不能继续运行
        public int UnloadVFDNoCom { get; set; }//下料站故障:变频器通讯异常
        public int UnloadVFDError { get; set; }//下料站故障:变频器报错
        
    }
}
