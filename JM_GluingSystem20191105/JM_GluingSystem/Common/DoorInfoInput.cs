using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common
{
    public class DoorInfoInput
    {
        //门ID
        public string DoorID { get; set; }
        //上料批次ID
        public string LoadBatchID { set; get; }
        //订单编号
        public string OrderNum { set; get; }
        //订单数量
        public int OrderQuantity { set; get; }
        //门类型
        public string DoorMold { set; get; }
        //放置方式
        public string PlacementMode { set; get; }
        //厚薄区分
        public string ThicknessDistinguish { set; get; }
        //开合方向
        public string OpenDirection { set; get; }
        //垛位
        public string StackPosition { set; get; }
        //珍珠岩垛位
        public string PerlitePosition { get; set; }
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
        //薄板锁孔坐标X
        public int ThinPlateKeyholeX { set; get; }
        //薄板锁孔坐标Y
        public int ThinPlateKeyholeY { set; get; }
        //厚板锁孔坐标X
        public int ThickPlateKeyholeX { set; get; }
        //厚板锁孔坐标Y
        public int ThickPlateKeyholeY { set; get; }
        //焊点间距_上下(数组)
        public int[] WeldSpacingUpDown { set; get; }
        //焊点间距_铰链(数组)
        public int[] WeldSpacingHinge { set; get; }
        //焊点间距_锁孔(数组)
        public int[] WeldSpacingKeyhole { set; get; }
        //焊点间距_上下（字符串）
        public string WeldSpacingUpDownStr { set; get; }
        //焊点间距_铰链（字符串）
        public string WeldSpacingHingeStr { set; get; }
        //焊点间距_锁孔（字符串）
        public string WeldSpacingKeyholeStr { set; get; }
        //焊点个数_上下
        public int WeldNumUpDown { set; get; }
        //焊点个数_铰链
        public int WeldNumHinge { set; get; }
        //焊点个数_锁孔
        public int WeldNumKeyhole { set; get; }
        //珍珠岩长
        public int PerliteLength { set; get; }
        //珍珠岩宽
        public int PerliteWidth { set; get; }
        //珍珠岩厚
        public int PerliteThickness { set; get; }
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
        //覆膜用量
        public int LaminationDosage { set; get; }
        //状态(0：准备 1：发送中 2：已完成)
        public int Status { set; get; }
        //上料数量
        public int LoadNum { set; get; }
        //已发送数量
        public int SentNum { set; get; }
    }
}
