using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common
{
    public class ComputationalFormula
    {
        //薄板宽"=(K-95)*10+872"
        public static int ThinPlateWidthCalculate_1(string k)
        {
            int.TryParse(k,out int width);
            width = (width - 95)*10+872;
            return width;
        }

        //薄板长"=(G-205)*10+1980"
        public static int ThinPlateLengthCalculate_1(string g)
        {
            int.TryParse(g, out int length);
            length = (length - 205) * 10 + 1980;
            return length;
        }

        //厚板宽"=(K-95)*10+839"
        public static int ThickPlateWidthCalculate_1(string k)
        {
            int.TryParse(k, out int width);
            width = (width - 95) * 10 + 839;
            return width;
        }

        //厚板长"=(G-205)*10+1948"
        public static int ThickPlateLengthCalculate_1(string g)
        {
            int.TryParse(g, out int length);
            length = (length - 205) * 10 + 1948;
            return length;
        }

        //膜用量"=(G-205)*10+1980+10"
        public static int LaminationDosageCalculate_1(string g)
        {
            int.TryParse(g, out int dosage);
            dosage = (dosage - 205) * 10 + 1980 + 10;
            return dosage;
        }

        //薄板猫眼坐标Y"=(G-205)*10+1980-502"
        public static int ThinPlateViewerYCalculate_1(string g)
        {
            int.TryParse(g, out int y);
            y = (y - 205) * 10 + 1980 - 502;
            return y;
        }

        //厚板猫眼坐标Y"=(G-205)*10+1948-486"
        public static int ThickPlateViewerYCalculate_1(string g)
        {
            int.TryParse(g, out int y);
            y = (y - 205) * 10 + 1948 - 486;
            return y;
        }

        //薄板猫眼坐标X"=(K-95)*10/2+176+520/2"
        public static int ThinPlateViewerXCalculate_1(string k)
        {
            int.TryParse(k, out int x);
            x = (x - 95) * 10 / 2 + 176 + 520 / 2;
            return x;
        }

        //厚板猫眼坐标X"=(K-95)*10/2+147+520/2"      
        public static int ThickPlateViewerXCalculate_1(string k)
        {
            int.TryParse(k, out int x);
            x = (x - 95) * 10 / 2 + 147 + 520 / 2;        
            return x;
        }

        //珍珠岩宽"=(K-95)*10+805"
        public static int PerliteWidthCalculate_1(string k)
        {
            int.TryParse(k, out int width);
            width = (width - 95) * 10 + 805;
            return width;
        }

        //珍珠岩长"=(G-205)*10-1920"
        public static int PerliteLengthCalculate_1(string g)
        {
            int.TryParse(g, out int length);
            length = (length - 205) * 10 + 1920;
            return length;
        }

        //上下边焊点间距"=｛(K-95)*10+839-50-12｝/（7-1）"
        public static double SpacingUpDownCalculate_1(string k)
        {
            int.TryParse(k,out int result);
            result = (result - 95) * 10 + 839 - 50 - 12;
            double spaceUpDown = (double)result / 6;
            spaceUpDown = Math.Round(spaceUpDown, 1);
            return spaceUpDown;
        }

        //上下边焊点间距"=｛(K-95)*10+839-50-12｝/（8-1）"
        public static double SpacingUpDownCalculate_2(string k)
        {
            int.TryParse(k, out int result);
            result = (result - 95) * 10 + 839 - 50 - 12;
            double spaceUpDown = (double)result / 7;
            spaceUpDown = Math.Round(spaceUpDown, 1);
            return spaceUpDown;
        }

        //上下边焊点间距"=｛(K-95)*10+839-50-12｝/（9-1）"
        public static double SpacingUpDownCalculate_3(string k)
        {
            int.TryParse(k, out int result);
            result = (result - 95) * 10 + 839 - 50 - 12;
            double spaceUpDown = (double)result / 8;
            spaceUpDown = Math.Round(spaceUpDown, 1);
            return spaceUpDown;
        }

        //铰链边中间段焊点数"=｛(G-205)*10+1948-609-1035｝/100"
        public static int NumHingeMiddleCalculate_2(string g)
        {
            int.TryParse(g, out int length);
            int middleNum = ((length - 205) * 10 + 1948 - 609 - 1035) / 100;
            return middleNum;
        }

        //铰链边中间段焊点数"=｛(G-205)*10+1948-610-1035｝/100"
        public static int NumHingeMiddleCalculate_1(string g)
        {
            int.TryParse(g, out int length);
            int middleNum = ((length - 205) * 10 + 1948 - 610 - 1035) / 100;
            return middleNum;
        }

        //锁扣边中间段焊点数"=｛(G-205)*10+1948-30-1675｝/100"
        public static int NumKeyholeMiddleCalculate_1(string g)
        {
            int.TryParse(g, out int length);
            int middleNum = ((length - 205) * 10 + 1948 - 30 - 1675) / 100;
            return middleNum;
        }


    }
}
