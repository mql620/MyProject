using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common.Class
{
    class SubsidiaryInformation
    {
        //门ID
        public string DoorID { set; get; }
        //门类型
        public string DoorMold { set; get; }
        //工单编号
        public string OrderNum { set; get; }
        //放置方式
        public string PlacementMode { set; get; }
        //厚薄区分
        public string ThicknessDistinguish { set; get; }
        //开合方向
        public string OpenDirection { set; get; }
        //垛位
        public string StackPosition { set; get; }
        //薄板长
        public int ThinPlateLength { set; get; }
        //薄板宽
        public int ThinPlateWidth { set; get; }
        //厚板长
        public int ThickPlateLength { set; get; }
        //厚板宽
        public int ThickPlateWidth { set; get; }
        //门厚
        public int Thickness { set; get; }
        //上料时间
        public string FeedingTime { set; get; }
        //覆膜入站时间
        public string LaminationPullInTime { set; get; }
        //覆膜出站时间
        public string LaminationPullOutTime { set; get; }
        //覆膜用量
        public int LaminationDosage { set; get; }
        //上膜余量
        public int EpisporiumAllowance { set; get; }
        //底膜余量
        public int CounterdieAllowance { set; get; }
        //裁切长度
        public int CuttingLength { set; get; }
        //裁切宽度
        public int CuttingWidth { set; get; }
        //涂胶入站时间
        public string GluingPullInTime { set; get; }
        //涂胶出站时间
        public string GluingPullOutTime { set; get; }
        //薄板锁孔坐标X
        public int ThinPlateKeyholeX { set; get; }
        //薄板锁孔坐标Y
        public int ThinPlateKeyholeY { set; get; }
        //厚板锁孔坐标X
        public int ThickPlateKeyholeX { set; get; }
        //厚板锁孔坐标Y
        public int ThickPlateKeyholeY { set; get; }
        //薄板猫眼坐标X
        public int ThinPlateViewerX { set; get; }
        //薄板猫眼坐标Y
        public int ThinPlateViewerY { set; get; }
        //厚板猫眼坐标X
        public int ThickPlateViewerX { set; get; }
        //厚板猫眼坐标Y
        public int ThickPlateViewerY { set; get; }
        //锁具宽
        public int LockWidth { set; get; }
        //锁具长
        public int LockLength { set; get; }
        //实际出胶量
        public int ActualSerlantVolume { set; get; }
        //剩余胶量
        public int QuantityGlue { set; get; }
        //涂胶时间
        public int GelatinizeTime { set; get; }
        //珍珠岩填充入站时间
        public string PerliteFillingPullInTime { set; get; }
        //珍珠岩填充出站时间
        public string PerliteFillingPullOutTime { set; get; }
        //珍珠岩长
        public int PerliteLength { set; get; }
        //珍珠岩宽
        public int PerliteWidth { set; get; }
        //珍珠岩厚
        public int PerliteThickness { set; get; }
        //压合入站时间
        public string PressFitPullInTime { set; get; }
        //压合出站时间
        public string PressFitPullOutTime { set; get; }
        //压合温度
        public int PressFitTemperature { set; get; }
        //打磨入站时间
        public string PolishedPullInTime { set; get; }
        //打磨出站时间
        public string PolishedPullOutTime { set; get; }
        //焊接入站时间
        public string WeldingPullInTime { set; get; }
        //焊接出站时间
        public string WeldingPullOutTime { set; get; }
        //焊点间距_上下
        public string WeldSpacingUpDownStr { set; get; }
        //焊点间距_铰链
        public string WeldSpacingHingeStr { set; get; }
        //焊点间距_锁孔
        public string WeldSpacingKeyholeStr { set; get; }
        //焊点个数_上下
        public int WeldNumUpDown { set; get; }
        //焊点个数_铰链
        public int WeldNumHinge { set; get; }
        //焊点个数_锁孔
        public int WeldNumKeyhole { set; get; }
        //焊接电压
        public int WeldingVoltage { set; get; }
        //焊接电流
        public int WeldingElectricity { set; get; }
        //焊接时间
        public int WeldingSpendTime { set; get; }
        //送丝速度
        public int WireFeedRate { set; get; }
        //喷漆除烟痕入站时间
        public string SprayPaintPullInTime { set; get; }
        //喷漆除烟痕出站时间
        public string SprayPaintPullOutTime { set; get; }
        //喷漆/除烟痕时间
        public int SprayPaintSpendTime { set; get; }
        //视觉检测入站时间
        public string VisualInspectionPullInTime { set; get; }
        //视觉检测出站时间
        public string VisualInspectionPullOutTime { set; get; }
        //产品检测结果
        public string VisualInspectionResult { set; get; }
        //下料时间
        public string BlankingTime { set; get; }

    }
}
