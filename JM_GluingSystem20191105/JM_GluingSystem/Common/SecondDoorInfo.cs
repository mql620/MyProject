using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common
{
    public class SecondDoorInfo
    {
        //压合后二次上料ID
        public string SecondDoorID { get; set; }
        //上料批次ID
        public string LoadBatchID { set; get; }
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
    }
}
