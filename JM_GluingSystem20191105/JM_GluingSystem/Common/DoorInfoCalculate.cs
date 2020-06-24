using JM_GluingSystem.Common.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common
{
    public class DoorInfoCalculate
    {
        //门型号
        public static void DoorModel(OrderInformation order, out int thinPlateLength, out int thinPlateWidth, out int thickPlateLength, out int thickPlateWidth)
        {
            //薄板长
            thinPlateLength = 0;
            //薄板宽
            thinPlateWidth = 0;
            //厚板长
            thickPlateLength = 0;
            //厚板宽
            thickPlateWidth = 0;
            //门框
            if (order.Doorframe == "A型框" || order.Doorframe == "A型反七字边框" || order.Doorframe == "A型铰有边框" || order.Doorframe == "A型内开外包边框" || 
                order.Doorframe == "A型内开外包反七字边框" || order.Doorframe == "A型内开外包铰有边框" || order.Doorframe == "A型内开外包七字边框" || 
                order.Doorframe == "A型内开外包上无边框" || order.Doorframe == "A型内开外包上有边框" || order.Doorframe == "A型内开外包锁有边框" ||
                order.Doorframe == "A型七字边框" || order.Doorframe == "A型上无边框" || order.Doorframe == "A型上有边框" || order.Doorframe == "A型锁有边框" ||
                order.Doorframe == "C型框" || order.Doorframe == "C型铰有边框" || order.Doorframe == "C型反七字边框" || order.Doorframe == "C型内开外包边框" || 
                order.Doorframe == "C型内开外包反七字边框" || order.Doorframe == "C型内开外包铰有边框" || order.Doorframe == "C型内开外包七字边框" || 
                order.Doorframe == "C型内开外包上无边框" || order.Doorframe == "C型内开外包上有边框" || order.Doorframe == "C型内开外包锁有边框" || 
                order.Doorframe == "C型七字边框" || order.Doorframe == "C型上无边框" || order.Doorframe == "C型上有边框" || order.Doorframe == "C型锁有边框" || 
                order.Doorframe == "E型框")
            {
                //扣边
                if (order.Buckles == "双扣边")
                {
                    int.TryParse(order.SpecificationHigh, out int high);
                    int.TryParse(order.SpecificationsWide, out int width);
                    high = high * 10;
                    width = width * 10;
                    //门厚
                    if (order.DoorThickness == "70")
                    {
                        //门体结构
                        if (order.DoorStructure == "单门")
                        {
                            thinPlateLength = ComputationalFormula.ThinPlateLengthCalculate_1(order.SpecificationHigh);
                            thinPlateWidth = ComputationalFormula.ThinPlateWidthCalculate_1(order.SpecificationsWide);
                            thickPlateLength = ComputationalFormula.ThickPlateLengthCalculate_1(order.SpecificationHigh);
                            thickPlateWidth = ComputationalFormula.ThickPlateWidthCalculate_1(order.SpecificationsWide);
                        }
                        else if (order.DoorStructure == "子母门")
                        {
                            //规格高
                            if (high >= 1500 && high <= 2200)   
                            {
                                //规格宽
                                if (width >= 1050 && width < 1250)
                                {
                                    thinPlateLength = ComputationalFormula.ThinPlateLengthCalculate_1(order.SpecificationHigh);
                                    thinPlateWidth = 772;
                                    thickPlateLength = ComputationalFormula.ThickPlateLengthCalculate_1(order.SpecificationHigh);
                                    thickPlateWidth = 739;
                                }
                                else if (width >= 1250 && width < 1500)
                                {
                                    thinPlateLength = ComputationalFormula.ThinPlateLengthCalculate_1(order.SpecificationHigh);
                                    thinPlateWidth = 872;
                                    thickPlateLength = ComputationalFormula.ThickPlateLengthCalculate_1(order.SpecificationHigh);
                                    thickPlateWidth = 839;
                                }

                                //母门子门规格
                                if (order.PictureDoorSpecification == "子门不含框276")
                                {
                                    if (width >= 1080 && width < 1150)
                                    {
                                        thinPlateLength = ComputationalFormula.ThinPlateLengthCalculate_1(order.SpecificationHigh);
                                        thinPlateWidth = ComputationalFormula.ThinPlateWidthCalculate_1(order.SpecificationsWide);
                                        thickPlateLength = ComputationalFormula.ThickPlateLengthCalculate_1(order.SpecificationHigh);
                                        thickPlateWidth = ComputationalFormula.ThickPlateWidthCalculate_1(order.SpecificationsWide);
                                    }
                                }
                            }                           
                        }
                    }
                    else if (order.DoorThickness == "90")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            thinPlateLength = ComputationalFormula.ThinPlateLengthCalculate_1(order.SpecificationHigh);
                            thinPlateWidth = ComputationalFormula.ThinPlateWidthCalculate_1(order.SpecificationsWide);
                            thickPlateLength = ComputationalFormula.ThickPlateLengthCalculate_1(order.SpecificationHigh);
                            thickPlateWidth = ComputationalFormula.ThickPlateWidthCalculate_1(order.SpecificationsWide);
                        }
                        else if (order.DoorStructure == "子母门")
                        {
                            if (high >= 1500 && high <= 2200)
                            {
                                if (width >= 1050 && width < 1250)
                                {
                                    thinPlateLength = ComputationalFormula.ThinPlateLengthCalculate_1(order.SpecificationHigh);
                                    thinPlateWidth = 772;
                                    thickPlateLength = ComputationalFormula.ThickPlateLengthCalculate_1(order.SpecificationHigh);
                                    thickPlateWidth = 739;
                                }
                                else if (width >= 1250 && width < 1500)
                                {
                                    thinPlateLength = ComputationalFormula.ThinPlateLengthCalculate_1(order.SpecificationHigh);
                                    thinPlateWidth = 872;
                                    thickPlateLength = ComputationalFormula.ThickPlateLengthCalculate_1(order.SpecificationHigh);
                                    thickPlateWidth = 839;
                                }
                                if (order.PictureDoorSpecification == "子门不含框276")
                                {
                                    if (width >= 1080 && width < 1150)
                                    {
                                        thinPlateLength = ComputationalFormula.ThinPlateLengthCalculate_1(order.SpecificationHigh);
                                        thinPlateWidth = ComputationalFormula.ThinPlateWidthCalculate_1(order.SpecificationsWide);
                                        thickPlateLength = ComputationalFormula.ThickPlateLengthCalculate_1(order.SpecificationHigh);
                                        thickPlateWidth = ComputationalFormula.ThickPlateWidthCalculate_1(order.SpecificationsWide);
                                    }
                                }
                            }
                        }
                    }          
                }
            }
        }

        //覆膜
        public static int Lamination(OrderInformation order)
        {
            int useLevel = 0;
            if (order.Doorframe == "A型框" || order.Doorframe == "A型反七字边框" || order.Doorframe == "A型铰有边框" || order.Doorframe == "A型内开外包边框" ||
                order.Doorframe == "A型内开外包反七字边框" || order.Doorframe == "A型内开外包铰有边框" || order.Doorframe == "A型内开外包七字边框" ||
                order.Doorframe == "A型内开外包上无边框" || order.Doorframe == "A型内开外包上有边框" || order.Doorframe == "A型内开外包锁有边框" ||
                order.Doorframe == "A型七字边框" || order.Doorframe == "A型上无边框" || order.Doorframe == "A型上有边框" || order.Doorframe == "A型锁有边框" ||
                order.Doorframe == "C型框" || order.Doorframe == "C型铰有边框" || order.Doorframe == "C型反七字边框" || order.Doorframe == "C型内开外包边框" ||
                order.Doorframe == "C型内开外包反七字边框" || order.Doorframe == "C型内开外包铰有边框" || order.Doorframe == "C型内开外包七字边框" ||
                order.Doorframe == "C型内开外包上无边框" || order.Doorframe == "C型内开外包上有边框" || order.Doorframe == "C型内开外包锁有边框" ||
                order.Doorframe == "C型七字边框" || order.Doorframe == "C型上无边框" || order.Doorframe == "C型上有边框" || order.Doorframe == "C型锁有边框" ||
                order.Doorframe == "E型框")
            {
                int.TryParse(order.SpecificationsWide, out int width);
                if (order.DoorThickness == "70")
                {
                    if (order.ColorCategories == "仿铜门" || order.ColorCategories == "转印门" || order.ColorCategories == "蚀刻门" || 
                        order.ColorCategories == "喷塑门" || order.ColorCategories == "皮纹门" || order.ColorCategories == "蚀刻门+转印门")
                    {                       
                        if (order.DoorStructure == "单门")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "子母门（母门）")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "对开门")
                        {
                            if (width >= 170)
                                useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                    }
                    if (order.Overdye == "CL35" || order.Overdye == "CL36" || order.Overdye == "CL38" || order.Overdye == "CL52" ||
                        order.Overdye == "CL53" || order.Overdye == "GL26" || order.Overdye == "NC26" || order.Overdye == "NC7100" ||
                        order.Overdye == "NC9019" || order.Overdye == "NC9020" || order.Overdye == "NC9022" || order.Overdye == "NC9023" ||
                        order.Overdye == "NC9100" || order.Overdye == "NC9100A" || order.Overdye == "NC9301" || order.Overdye == "GL26" ||
                        order.Overdye == "JD026" || order.Overdye == "MS032" || order.Overdye == "ZY030" || order.Overdye == "ZY033" ||
                        order.Overdye == "ZY035" || order.Overdye == "PJ033" || order.Overdye == "Y102")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "子母门（母门）")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "对开门")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                    }
                }
                else if (order.DoorThickness == "90")
                {
                    if (order.ColorCategories == "仿铜门" || order.ColorCategories == "转印门" || order.ColorCategories == "蚀刻门" ||
                        order.ColorCategories == "喷塑门" || order.ColorCategories == "皮纹门" || order.ColorCategories == "蚀刻门+转印门")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "子母门（母门）")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "对开门")
                        {
                            if (width <= 169)
                                useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "小门")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                    }
                    if (order.Overdye == "CL35" || order.Overdye == "CL36" || order.Overdye == "CL38" || order.Overdye == "CL52" ||
                        order.Overdye == "CL53" || order.Overdye == "GL26" || order.Overdye == "NC26" || order.Overdye == "NC7100" ||
                        order.Overdye == "NC9019" || order.Overdye == "NC9020" || order.Overdye == "NC9022" || order.Overdye == "NC9023" ||
                        order.Overdye == "NC9100" || order.Overdye == "NC9100A" || order.Overdye == "NC9301" || order.Overdye == "GL26" ||
                        order.Overdye == "JD026" || order.Overdye == "MS032" || order.Overdye == "ZY030" || order.Overdye == "ZY033" ||
                        order.Overdye == "ZY035" || order.Overdye == "PJ033" || order.Overdye == "Y102")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "子母门（母门）")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                        else if (order.DoorStructure == "对开门")
                        {
                            useLevel = ComputationalFormula.LaminationDosageCalculate_1(order.SpecificationHigh);
                        }
                    }
                }
            }
            return useLevel;
        }

        //涂胶
        public static void Gluing(OrderInformation order,out int thinPlateKeyholeX,out int thinPlateKeyholeY,out int thickPlateKeyholeX,
            out int thickPlateKeyholeY,out int thinPlateViewerX,out int thinPlateViewerY,out int thickPlateViewerX,out int thickPlateViewerY,
            out int lockWidth,out int lockLength)
        {
            thinPlateKeyholeX = 0;
            thinPlateKeyholeY = 0;
            thickPlateKeyholeX = 0;
            thickPlateKeyholeY = 0;
            thinPlateViewerX = 0;
            thinPlateViewerY = 0;
            thickPlateViewerX = 0;
            thickPlateViewerY = 0;
            lockWidth = 0;
            lockLength = 0;
            if (order.Doorframe == "A型框" || order.Doorframe == "A型反七字边框" || order.Doorframe == "A型铰有边框" || order.Doorframe == "A型内开外包边框" ||
                order.Doorframe == "A型内开外包反七字边框" || order.Doorframe == "A型内开外包铰有边框" || order.Doorframe == "A型内开外包七字边框" ||
                order.Doorframe == "A型内开外包上无边框" || order.Doorframe == "A型内开外包上有边框" || order.Doorframe == "A型内开外包锁有边框" ||
                order.Doorframe == "A型七字边框" || order.Doorframe == "A型上无边框" || order.Doorframe == "A型上有边框" || order.Doorframe == "A型锁有边框" ||
                order.Doorframe == "C型框" || order.Doorframe == "C型铰有边框" || order.Doorframe == "C型反七字边框" || order.Doorframe == "C型内开外包边框" ||
                order.Doorframe == "C型内开外包反七字边框" || order.Doorframe == "C型内开外包铰有边框" || order.Doorframe == "C型内开外包七字边框" ||
                order.Doorframe == "C型内开外包上无边框" || order.Doorframe == "C型内开外包上有边框" || order.Doorframe == "C型内开外包锁有边框" ||
                order.Doorframe == "C型七字边框" || order.Doorframe == "C型上无边框" || order.Doorframe == "C型上有边框" || order.Doorframe == "C型锁有边框" ||
                order.Doorframe == "E型框")
            {
                if (order.Buckles == "双扣边")
                {
                    int.TryParse(order.SpecificationHigh, out int high);
                    int.TryParse(order.SpecificationsWide, out int width);
                    high = high * 10;
                    width = width * 10;
                    if (order.DoorThickness == "70")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            if (order.FacadeStyle == "常规")
                            {
                                if (order.Lock == "特能锁" || order.Lock == "特能锁(不锈钢)" || order.Lock == "特能电控锁" || order.Lock == "特能电控锁(不锈钢)"
                                    || order.Lock == "A5020超防锁" || order.Lock == "客供锁具+特能锁(不锈钢)" || order.Lock == "A5020超防锁+A5020超防锁" 
                                    || order.Lock == "Z2000特能电控锁" || order.Lock == "Z2000特能电控锁+特能锁" || order.Lock == "A5010智防锁" 
                                    || order.Lock == "特能锁(不锈钢)+特能锁(不锈钢)" || order.Lock == "A6030特防锁" || order.Lock == "特能锁+特能锁")
                                {
                                    lockWidth = 52;
                                    if (order.Lock == "特能电控锁(不锈钢)")
                                    {
                                        lockLength = 355;
                                    }
                                    else if (order.Lock == "A5020超防锁+A5020超防锁" || order.Lock == "A5010智防锁")
                                    {
                                        lockLength = 286;
                                    }
                                    else if (order.Lock == "A6030特防锁")
                                    {
                                        lockLength = 258;
                                    }
                                    else
                                    {
                                        lockLength = 260;
                                    }
                                    if (width < 880)
                                    {
                                        thinPlateViewerX = 401;
                                        thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thickPlateViewerX = 372;
                                        thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thinPlateKeyholeX = 81;
                                        thinPlateKeyholeY = 990;
                                        thickPlateKeyholeX = 65;
                                        thickPlateKeyholeY = 974;
                                    }
                                }
                                else if (order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁" 
                                    || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)" 
                                    || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                    || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁" 
                                    || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)" 
                                    || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁" 
                                    || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁" 
                                    || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁")
                                {
                                    lockWidth = 54;
                                    lockLength = 260;
                                    if (width >= 880)
                                    {
                                        thinPlateViewerX = ComputationalFormula.ThinPlateViewerXCalculate_1(order.SpecificationsWide);
                                        thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thickPlateViewerX = ComputationalFormula.ThickPlateViewerXCalculate_1(order.SpecificationsWide);
                                        thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thinPlateKeyholeX = 76;
                                        thinPlateKeyholeY = 990;
                                        thickPlateKeyholeX = 60;
                                        thickPlateKeyholeY = 974;
                                    }
                                }
                            }
                            else if (order.FacadeStyle == "GF006")
                            {
                                if (order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                    || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                    || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                    || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                    || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)"
                                    || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁"
                                    || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁"
                                    || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁")
                                {
                                    lockWidth = 54;
                                    lockLength = 260;
                                    if (width < 880)
                                    {
                                        if (high > 2000 || (high >= 2150 && high < 2250))
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1477;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1461;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if (high >= 2000 && high < 2150)
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1420;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1404;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                    else if (width >= 880 && high >= 2250)
                                    {
                                        thinPlateViewerX = ComputationalFormula.ThinPlateViewerXCalculate_1(order.SpecificationsWide);
                                        thinPlateViewerY = 1420;
                                        thickPlateViewerX = ComputationalFormula.ThickPlateViewerXCalculate_1(order.SpecificationsWide);
                                        thickPlateViewerY = 1404;
                                        thinPlateKeyholeX = 76;
                                        thinPlateKeyholeY = 990;
                                        thickPlateKeyholeX = 60;
                                        thickPlateKeyholeY = 974;
                                    }
                                }
                            }
                            else if (order.FacadeStyle == "L907")
                            {
                                if (order.Lock == "特能锁" || order.Lock == "特能锁(不锈钢)" || order.Lock == "特能电控锁" || order.Lock == "特能电控锁(不锈钢)"
                                    || order.Lock == "A5020超防锁" || order.Lock == "客供锁具+特能锁(不锈钢)" || order.Lock == "A5020超防锁+A5020超防锁"
                                    || order.Lock == "Z2000特能电控锁" || order.Lock == "Z2000特能电控锁+特能锁" || order.Lock == "A5010智防锁"
                                    || order.Lock == "特能锁(不锈钢)+特能锁(不锈钢)" || order.Lock == "A6030特防锁" || order.Lock == "特能锁+特能锁")
                                {
                                    lockWidth = 52;
                                    if (order.Lock == "特能电控锁(不锈钢)")
                                    {
                                        lockLength = 355;
                                    }
                                    else if (order.Lock == "A5020超防锁+A5020超防锁" || order.Lock == "A5010智防锁")
                                    {
                                        lockLength = 286;
                                    }
                                    else if (order.Lock == "A6030特防锁")
                                    {
                                        lockLength = 258;
                                    }
                                    else
                                    {
                                        lockLength = 260;
                                    }
                                    if (width < 880)
                                    {
                                        if (high <= 2000 || (high >= 2050 && high < 2150))
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1477;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1461;
                                            thinPlateKeyholeX = 81;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 65;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if (high > 2000 && high < 2050)
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1351;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1335;
                                            thinPlateKeyholeX = 81;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 65;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                }
                                else if (order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                    || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                    || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                    || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                    || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)"
                                    || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁"
                                    || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁"
                                    || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁")
                                {
                                    lockWidth = 54;
                                    lockLength = 260;
                                    if (width >= 880 && (high >= 2150 && high < 2200))
                                    {
                                        thinPlateViewerX = ComputationalFormula.ThinPlateViewerXCalculate_1(order.SpecificationsWide);
                                        thinPlateViewerY = 1351;
                                        thickPlateViewerX = ComputationalFormula.ThickPlateViewerXCalculate_1(order.SpecificationsWide);
                                        thickPlateViewerY = 1335;
                                        thinPlateKeyholeX = 81;
                                        thinPlateKeyholeY = 990;
                                        thickPlateKeyholeX = 65;
                                        thickPlateKeyholeY = 974;
                                    }                       
                                }
                            }
                        }
                        else if (order.DoorStructure == "子母门")
                        {
                            if (order.FacadeStyle == "常规")
                            {
                                if (order.Lock == "特能锁" || order.Lock == "特能锁(不锈钢)" || order.Lock == "特能电控锁" || order.Lock == "特能电控锁(不锈钢)"
                                    || order.Lock == "A5020超防锁" || order.Lock == "客供锁具+特能锁(不锈钢)" || order.Lock == "A5020超防锁+A5020超防锁"
                                    || order.Lock == "Z2000特能电控锁" || order.Lock == "Z2000特能电控锁+特能锁" || order.Lock == "A5010智防锁"
                                    || order.Lock == "特能锁(不锈钢)+特能锁(不锈钢)" || order.Lock == "A6030特防锁" || order.Lock == "特能锁+特能锁")
                                {
                                    lockWidth = 52;
                                    if (order.Lock == "特能电控锁(不锈钢)")
                                    {
                                        lockLength = 355;
                                    }
                                    else if (order.Lock == "A5020超防锁+A5020超防锁" || order.Lock == "A5010智防锁")
                                    {
                                        lockLength = 286;
                                    }
                                    else if (order.Lock == "A6030特防锁")
                                    {
                                        lockLength = 258;
                                    }
                                    else
                                    {
                                        lockLength = 260;
                                    }
                                    if (high >= 1500 && high <= 2200)
                                    {
                                        if (width >= 1050 && width < 1250)
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thinPlateKeyholeX = 81;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 65;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if (width >= 1250 && width < 1500)
                                        {
                                            thinPlateViewerX = 436;
                                            thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thickPlateViewerX = 407;
                                            thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thinPlateKeyholeX = 81;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 65;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }                                
                                }
                                else if (order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                    || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                    || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                    || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                    || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)"
                                    || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁"
                                    || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁"
                                    || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁")
                                {
                                    lockWidth = 54;
                                    lockLength = 260;
                                    if (high >= 1500 && high <= 2200)
                                    {
                                        if (width >= 1050 && width < 1250)
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if (width >= 1250 && width < 1500)
                                        {
                                            thinPlateViewerX = 436;
                                            thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thickPlateViewerX = 407;
                                            thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                }
                            }
                            else if (order.FacadeStyle == "GF006")
                            {
                                if (order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                    || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                    || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                    || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                    || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)"
                                    || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁"
                                    || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁"
                                    || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁")
                                {
                                    lockWidth = 54;
                                    lockLength = 260;
                                    if (width >= 1050 && width < 1250)
                                    {
                                        if (high < 2000 || (high >= 2150 && high < 2250))
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1477;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1461;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if ((high >= 2000 && high < 2150) || high >= 2250)
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1420;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1404;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                    else if (width >= 1250 && width < 1500)
                                    {
                                        if (high < 2000 || (high >= 2150 && high < 2250))
                                        {
                                            thinPlateViewerX = 436;
                                            thinPlateViewerY = 1477;
                                            thickPlateViewerX = 407;
                                            thickPlateViewerY = 1461;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if ((high >= 2000 && high < 2150) || high >= 2250)
                                        {
                                            thinPlateViewerX = 436;
                                            thinPlateViewerY = 1420;
                                            thickPlateViewerX = 407;
                                            thickPlateViewerY = 1404;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                }
                            }
                            else if (order.FacadeStyle == "L907")
                            {
                                if (order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                    || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                    || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                    || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                    || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)"
                                    || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁"
                                    || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁"
                                    || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁")
                                {
                                    lockWidth = 54;
                                    lockLength = 260;
                                    if (width >= 1050 && width < 1250)
                                    {
                                        if (high >= 2000 || (high >= 2050 && high < 2150))
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1477;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1461;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }     
                                        else if ((high > 2000 && high < 2050) || (high >= 2150 && high < 2200))
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1351;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1335;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                    else if (width >= 1250 && width < 1500)
                                    {
                                        if (high >= 2000 || (high >= 2050 && high < 2150))
                                        {
                                            thinPlateViewerX = 436;
                                            thinPlateViewerY = 1477;
                                            thickPlateViewerX = 407;
                                            thickPlateViewerY = 1461;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if ((high > 2000 && high < 2050) || (high >= 2150 && high < 2200))
                                        {
                                            thinPlateViewerX = 436;
                                            thinPlateViewerY = 1351;
                                            thickPlateViewerX = 407;
                                            thickPlateViewerY = 1335;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                }
                            }
                            if (order.PictureDoorSpecification == "子门不含框276")
                            {
                                if (order.FacadeStyle == "常规")
                                {
                                    if ((order.Lock == "特能锁" || order.Lock == "特能锁(不锈钢)" || order.Lock == "特能电控锁" 
                                        || order.Lock == "特能电控锁(不锈钢)" || order.Lock == "A5020超防锁" || order.Lock == "客供锁具+特能锁(不锈钢)" 
                                        || order.Lock == "A5020超防锁+A5020超防锁"|| order.Lock == "Z2000特能电控锁" || order.Lock == "Z2000特能电控锁+特能锁"
                                        || order.Lock == "A5010智防锁" || order.Lock == "特能锁(不锈钢)+特能锁(不锈钢)" || order.Lock == "A6030特防锁" 
                                        || order.Lock == "特能锁+特能锁") && (width >= 1080 && width <1150) && (high >= 1500 && high <= 2200))
                                    {
                                        lockWidth = 52;
                                        if (order.Lock == "特能电控锁(不锈钢)")
                                        {
                                            lockLength = 355;
                                        }
                                        else if (order.Lock == "A5020超防锁+A5020超防锁" || order.Lock == "A5010智防锁")
                                        {
                                            lockLength = 286;
                                        }
                                        else if (order.Lock == "A6030特防锁")
                                        {
                                            lockLength = 258;
                                        }
                                        else
                                        {
                                            lockLength = 260;
                                        }
                                        thinPlateViewerX = 401;
                                        thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thickPlateViewerX = 372;
                                        thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thinPlateKeyholeX = 81;
                                        thinPlateKeyholeY = 990;
                                        thickPlateKeyholeX = 65;
                                        thickPlateKeyholeY = 974;
                                    }
                                    else if ((order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁" 
                                        || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)" 
                                        || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁" 
                                        || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁" 
                                        || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" 
                                        || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)" || order.Lock == "双动双快大插芯锁(不锈钢)" 
                                        || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁" || order.Lock == "A7-1外防内快锁" 
                                        || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁" || order.Lock == "Z5002五舌电控锁" 
                                        || order.Lock == "巨力五舌锁") && (width >= 1080 && width < 1150) && (high >= 1500 && high <= 2200))
                                    {
                                        lockWidth = 54;
                                        lockLength = 260;
                                        thinPlateViewerX = 401;
                                        thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thickPlateViewerX = 372;
                                        thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thinPlateKeyholeX = 76;
                                        thinPlateKeyholeY = 990;
                                        thickPlateKeyholeX = 60;
                                        thickPlateKeyholeY = 974;
                                    }
                                }
                                else if (order.FacadeStyle == "GF006")
                                {
                                    if ((order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                        || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                        || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                        || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                        || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" 
                                        || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)" || order.Lock == "双动双快大插芯锁(不锈钢)" 
                                        || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁" || order.Lock == "A7-1外防内快锁" 
                                        || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁" || order.Lock == "Z5002五舌电控锁" 
                                        || order.Lock == "巨力五舌锁") && (width >= 1080 && width < 1150))
                                    {
                                        lockWidth = 54;
                                        lockLength = 260;
                                        if (high < 2000 || (high >= 2150 && high < 2250))
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1477;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1461;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if ((high >= 2000 && high < 2150) || high >= 2250)
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1420;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1404;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                }
                                else if (order.FacadeStyle == "L907")
                                {
                                    if ((order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                        || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                        || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                        || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                        || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" 
                                        || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)" || order.Lock == "双动双快大插芯锁(不锈钢)" 
                                        || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁" || order.Lock == "A7-1外防内快锁" 
                                        || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁" || order.Lock == "Z5002五舌电控锁" 
                                        || order.Lock == "巨力五舌锁") && (width >= 1080 && width < 1150))
                                    {
                                        lockWidth = 54;
                                        lockLength = 260;
                                        if (high <= 2000 || (high >= 2050 && high < 2150))
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1477;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1461;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if ((high > 2000 && high < 2050) || (high >= 2150 && high < 2200))
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = 1351;
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = 1335;
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (order.DoorThickness == "90")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            if (order.FacadeStyle == "常规")
                            {
                                if ((order.Lock == "特能锁" || order.Lock == "特能锁(不锈钢)" || order.Lock == "特能电控锁" || order.Lock == "特能电控锁(不锈钢)"
                                    || order.Lock == "A5020超防锁" || order.Lock == "客供锁具+特能锁(不锈钢)" || order.Lock == "A5020超防锁+A5020超防锁"
                                    || order.Lock == "Z2000特能电控锁" || order.Lock == "Z2000特能电控锁+特能锁" || order.Lock == "A5010智防锁"
                                    || order.Lock == "特能锁(不锈钢)+特能锁(不锈钢)" || order.Lock == "A6030特防锁" || order.Lock == "特能锁+特能锁") 
                                    && width < 880)
                                {
                                    lockWidth = 52;
                                    if (order.Lock == "特能电控锁(不锈钢)")
                                    {
                                        lockLength = 355;
                                    }
                                    else if (order.Lock == "A5020超防锁+A5020超防锁" || order.Lock == "A5010智防锁")
                                    {
                                        lockLength = 286;
                                    }
                                    else if (order.Lock == "A6030特防锁")
                                    {
                                        lockLength = 258;
                                    }
                                    else
                                    {
                                        lockLength = 260;
                                    }
                                    thinPlateViewerX = 401;
                                    thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                    thickPlateViewerX = 372;
                                    thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                    thinPlateKeyholeX = 81;
                                    thinPlateKeyholeY = 990;
                                    thickPlateKeyholeX = 65;
                                    thickPlateKeyholeY = 974;
                                }
                                else if ((order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                    || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                    || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                    || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                    || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)"
                                    || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁"
                                    || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁"
                                    || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁") && width >= 880)
                                {
                                    lockWidth = 54;
                                    lockLength = 260;
                                    thinPlateViewerX = ComputationalFormula.ThinPlateViewerXCalculate_1(order.SpecificationsWide);
                                    thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                    thickPlateViewerX = ComputationalFormula.ThickPlateViewerXCalculate_1(order.SpecificationsWide);
                                    thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                    thinPlateKeyholeX = 76;
                                    thinPlateKeyholeY = 990;
                                    thickPlateKeyholeX = 60;
                                    thickPlateKeyholeY = 974;
                                }
                            }
                        }
                        else if (order.DoorStructure == "子母门")
                        {
                            if (order.FacadeStyle == "常规")
                            {
                                if (order.Lock == "特能锁" || order.Lock == "特能锁(不锈钢)" || order.Lock == "特能电控锁" || order.Lock == "特能电控锁(不锈钢)"
                                    || order.Lock == "A5020超防锁" || order.Lock == "客供锁具+特能锁(不锈钢)" || order.Lock == "A5020超防锁+A5020超防锁"
                                    || order.Lock == "Z2000特能电控锁" || order.Lock == "Z2000特能电控锁+特能锁" || order.Lock == "A5010智防锁"
                                    || order.Lock == "特能锁(不锈钢)+特能锁(不锈钢)" || order.Lock == "A6030特防锁" || order.Lock == "特能锁+特能锁")
                                {
                                    lockWidth = 52;
                                    if (order.Lock == "特能电控锁(不锈钢)")
                                    {
                                        lockLength = 355;
                                    }
                                    else if (order.Lock == "A5020超防锁+A5020超防锁" || order.Lock == "A5010智防锁")
                                    {
                                        lockLength = 286;
                                    }
                                    else if (order.Lock == "A6030特防锁")
                                    {
                                        lockLength = 258;
                                    }
                                    else
                                    {
                                        lockLength = 260;
                                    }
                                    if (high >= 1500 && high <= 2200)
                                    {
                                        if (width >= 1050 && width < 1250)
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thinPlateKeyholeX = 81;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 65;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if (width >= 1250 && width < 1500)
                                        {
                                            thinPlateViewerX = 436;
                                            thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thickPlateViewerX = 407;
                                            thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thinPlateKeyholeX = 81;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 65;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                }
                                else if (order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                    || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                    || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                    || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                    || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)"
                                    || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁"
                                    || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁"
                                    || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁")
                                {
                                    lockWidth = 54;
                                    lockLength = 260;
                                    if (high >= 1500 && high <= 2200)
                                    {
                                        if (width >= 1050 && width < 1250)
                                        {
                                            thinPlateViewerX = 401;
                                            thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thickPlateViewerX = 372;
                                            thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                        else if (width >= 1250 && width < 1500)
                                        {
                                            thinPlateViewerX = 436;
                                            thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thickPlateViewerX = 407;
                                            thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                            thinPlateKeyholeX = 76;
                                            thinPlateKeyholeY = 990;
                                            thickPlateKeyholeX = 60;
                                            thickPlateKeyholeY = 974;
                                        }
                                    }
                                }
                            }
                            if (order.PictureDoorSpecification == "子门不含框276")
                            {
                                if (order.FacadeStyle == "常规")
                                {
                                    if ((order.Lock == "特能锁" || order.Lock == "特能锁(不锈钢)" || order.Lock == "特能电控锁" || order.Lock == "特能电控锁(不锈钢)"
                                        || order.Lock == "A5020超防锁" || order.Lock == "客供锁具+特能锁(不锈钢)" || order.Lock == "A5020超防锁+A5020超防锁"
                                        || order.Lock == "Z2000特能电控锁" || order.Lock == "Z2000特能电控锁+特能锁" || order.Lock == "A5010智防锁"
                                        || order.Lock == "特能锁(不锈钢)+特能锁(不锈钢)" || order.Lock == "A6030特防锁" || order.Lock == "特能锁+特能锁")
                                        && (width >= 1080 && width < 1150) && (high >= 1500 && high <= 2200))
                                    {
                                        lockWidth = 52;
                                        if (order.Lock == "特能电控锁(不锈钢)")
                                        {
                                            lockLength = 355;
                                        }
                                        else if (order.Lock == "A5020超防锁+A5020超防锁" || order.Lock == "A5010智防锁")
                                        {
                                            lockLength = 286;
                                        }
                                        else if (order.Lock == "A6030特防锁")
                                        {
                                            lockLength = 258;
                                        }
                                        else
                                        {
                                            lockLength = 260;
                                        }
                                        thinPlateViewerX = 401;
                                        thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thickPlateViewerX = 372;
                                        thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thinPlateKeyholeX = 81;
                                        thinPlateKeyholeY = 990;
                                        thickPlateKeyholeX = 65;
                                        thickPlateKeyholeY = 974;
                                    }
                                    else if ((order.Lock == "Z5003霸王电控锁" || order.Lock == "大插芯锁+大插芯锁" || order.Lock == "大插芯锁"
                                        || order.Lock == "大插芯锁(不锈钢)" || order.Lock == "双快大插芯锁" || order.Lock == "双快大插芯锁(不锈钢)"
                                        || order.Lock == "霸王锁" || order.Lock == "双快霸王锁(禁用)" || order.Lock == "豪华插芯锁" || order.Lock == "五舌锁"
                                        || order.Lock == "A5001大插芯锁" || order.Lock == "Z5001大插芯电控锁" || order.Lock == "A5003霸王锁"
                                        || order.Lock == "霸王锁+霸王锁(禁用)" || order.Lock == "大插芯锁+客供小锁" || order.Lock == "A6外防内快锁+A6外防内快锁(禁用)"
                                        || order.Lock == "双动双快大插芯锁(不锈钢)" || order.Lock == "双动双快大插芯锁" || order.Lock == "防爆锁"
                                        || order.Lock == "A7-1外防内快锁" || order.Lock == "A5外防内快锁" || order.Lock == "A6外防内快锁"
                                        || order.Lock == "Z5002五舌电控锁" || order.Lock == "巨力五舌锁")
                                        && (width >= 1080 && width < 1150) && (high >= 1500 && high <= 2200))
                                    {
                                        lockWidth = 54;
                                        lockLength = 260;
                                        thinPlateViewerX = 401;
                                        thinPlateViewerY = ComputationalFormula.ThinPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thickPlateViewerX = 372;
                                        thickPlateViewerY = ComputationalFormula.ThickPlateViewerYCalculate_1(order.SpecificationHigh);
                                        thinPlateKeyholeX = 76;
                                        thinPlateKeyholeY = 990;
                                        thickPlateKeyholeX = 60;
                                        thickPlateKeyholeY = 974;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //珍珠岩
        public static void PerliteFilling(OrderInformation order,out int perliteLength,out int perliteWidth)
        {
            perliteLength = 0;
            perliteWidth = 0;
            if (order.Doorframe == "A型框" || order.Doorframe == "A型反七字边框" || order.Doorframe == "A型铰有边框" || order.Doorframe == "A型内开外包边框" ||
                order.Doorframe == "A型内开外包反七字边框" || order.Doorframe == "A型内开外包铰有边框" || order.Doorframe == "A型内开外包七字边框" ||
                order.Doorframe == "A型内开外包上无边框" || order.Doorframe == "A型内开外包上有边框" || order.Doorframe == "A型内开外包锁有边框" ||
                order.Doorframe == "A型七字边框" || order.Doorframe == "A型上无边框" || order.Doorframe == "A型上有边框" || order.Doorframe == "A型锁有边框" ||
                order.Doorframe == "C型框" || order.Doorframe == "C型铰有边框" || order.Doorframe == "C型反七字边框" || order.Doorframe == "C型内开外包边框" ||
                order.Doorframe == "C型内开外包反七字边框" || order.Doorframe == "C型内开外包铰有边框" || order.Doorframe == "C型内开外包七字边框" ||
                order.Doorframe == "C型内开外包上无边框" || order.Doorframe == "C型内开外包上有边框" || order.Doorframe == "C型内开外包锁有边框" ||
                order.Doorframe == "C型七字边框" || order.Doorframe == "C型上无边框" || order.Doorframe == "C型上有边框" || order.Doorframe == "C型锁有边框" ||
                order.Doorframe == "E型框")
            {
                if (order.Buckles == "双扣边")
                {
                    int.TryParse(order.SpecificationHigh, out int high);
                    int.TryParse(order.SpecificationsWide, out int width);
                    high = high * 10;
                    width = width * 10;
                    if (order.DoorThickness == "70")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            perliteLength = ComputationalFormula.PerliteLengthCalculate_1(order.SpecificationHigh);
                            perliteWidth = ComputationalFormula.PerliteWidthCalculate_1(order.SpecificationsWide);
                        }
                        else if (order.DoorStructure == "子母门")
                        {
                            if (high >= 1500 && high <= 2200)
                            {
                                if (width >= 1050 && width < 1250)
                                {
                                    perliteLength = ComputationalFormula.PerliteLengthCalculate_1(order.SpecificationHigh);
                                    perliteWidth = 710;
                                }
                                else if (width >= 1250 && width < 1500)
                                {
                                    perliteLength = ComputationalFormula.PerliteLengthCalculate_1(order.SpecificationHigh);
                                    perliteWidth = 810;
                                }
                                if (order.PictureDoorSpecification == "子门不含框276" && (width >= 1080 && width < 1150))
                                {
                                    perliteLength = ComputationalFormula.PerliteLengthCalculate_1(order.SpecificationHigh);
                                    perliteWidth = 710;
                                }
                            }
                        }
                    }
                    else if (order.DoorThickness == "90")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            perliteLength = ComputationalFormula.PerliteLengthCalculate_1(order.SpecificationHigh);
                            perliteWidth = ComputationalFormula.PerliteWidthCalculate_1(order.SpecificationsWide);
                        }
                        else if (order.DoorStructure == "子母门")
                        {
                            if (high >= 1500 && high <= 2200)
                            {
                                if (width >= 1050 && width < 1250)
                                {
                                    perliteLength = ComputationalFormula.PerliteLengthCalculate_1(order.SpecificationHigh);
                                    perliteWidth = 705;
                                }
                                else if (width >= 1250 && width < 1500)
                                {
                                    perliteLength = ComputationalFormula.PerliteLengthCalculate_1(order.SpecificationHigh);
                                    perliteWidth = 805;
                                }
                                if (order.PictureDoorSpecification == "子门不含框276" && (width >= 1080 && width < 1150))
                                {
                                    perliteLength = ComputationalFormula.PerliteLengthCalculate_1(order.SpecificationHigh);
                                    perliteWidth = 705;
                                }
                            }
                        }
                    }
                }
            }
        }

        //打磨焊接
        public static void GrindingWelding(OrderInformation order,int thickPlateLength,int thickPlateWidth, out int[] weldSpacingUpDown,out int[] weldSpacingHinge,out int[] weldSpacingKeyhole,
            out int weldNumUpDown,out int weldNumHinge,out int weldNumKeyhole)
        {
            weldSpacingUpDown = new int[10];
            weldSpacingHinge = new int[20];
            weldSpacingKeyhole = new int[20];
            weldNumUpDown = 0;
            weldNumHinge = 0;
            weldNumKeyhole = 0;
            if (order.Doorframe == "A型框" || order.Doorframe == "A型反七字边框" || order.Doorframe == "A型铰有边框" || order.Doorframe == "A型内开外包边框" ||
                order.Doorframe == "A型内开外包反七字边框" || order.Doorframe == "A型内开外包铰有边框" || order.Doorframe == "A型内开外包七字边框" ||
                order.Doorframe == "A型内开外包上无边框" || order.Doorframe == "A型内开外包上有边框" || order.Doorframe == "A型内开外包锁有边框" ||
                order.Doorframe == "A型七字边框" || order.Doorframe == "A型上无边框" || order.Doorframe == "A型上有边框" || order.Doorframe == "A型锁有边框" ||
                order.Doorframe == "C型框" || order.Doorframe == "C型铰有边框" || order.Doorframe == "C型反七字边框" || order.Doorframe == "C型内开外包边框" ||
                order.Doorframe == "C型内开外包反七字边框" || order.Doorframe == "C型内开外包铰有边框" || order.Doorframe == "C型内开外包七字边框" ||
                order.Doorframe == "C型内开外包上无边框" || order.Doorframe == "C型内开外包上有边框" || order.Doorframe == "C型内开外包锁有边框" ||
                order.Doorframe == "C型七字边框" || order.Doorframe == "C型上无边框" || order.Doorframe == "C型上有边框" || order.Doorframe == "C型锁有边框" ||
                order.Doorframe == "E型框")
            {
                if (order.Buckles == "双扣边")
                {
                    int.TryParse(order.SpecificationHigh, out int high);
                    int.TryParse(order.SpecificationsWide, out int width);
                    high = high * 10;
                    width = width * 10;
                    if (order.DoorThickness == "70")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            //上下边
                            if (width <= 850)
                            {                                
                                weldNumUpDown = 7;                               
                                double spaceUpDown = ComputationalFormula.SpacingUpDownCalculate_1(order.SpecificationsWide);
                                double endSpace = spaceUpDown * 5 * 10;
                                int endSpaceInt = (int)endSpace;
                                weldSpacingUpDown[0] = 25 * 10;
                                for (int i = 1; i < 6; i++)
                                {
                                    double space = spaceUpDown * 10;
                                    weldSpacingUpDown[i] = (int)space;
                                }                              
                                weldSpacingUpDown[6] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                            }
                            else if (width > 850 && width <= 950)
                            {
                                weldNumUpDown = 8;
                                double spaceUpDown = ComputationalFormula.SpacingUpDownCalculate_2(order.SpecificationsWide);
                                double endSpace = spaceUpDown * 6 * 10;
                                int endSpaceInt = (int)endSpace;
                                weldSpacingUpDown[0] = 25 * 10;
                                for (int i = 1; i < 7; i++)
                                {
                                    double space = spaceUpDown * 10;
                                    weldSpacingUpDown[i] = (int)space;
                                }                 
                                weldSpacingUpDown[7] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                            }
                            else if (width > 950 && width <= 1050)
                            {
                                weldNumUpDown = 9;
                                double spaceUpDown = ComputationalFormula.SpacingUpDownCalculate_3(order.SpecificationsWide);
                                double endSpace = spaceUpDown * 7 * 10;
                                int endSpaceInt = (int)endSpace;
                                weldSpacingUpDown[0] = 25 * 10;
                                for (int i = 1; i < 8; i++)
                                {
                                    double space = spaceUpDown * 10;
                                    weldSpacingUpDown[i] = (int)space;
                                }                                
                                weldSpacingUpDown[8] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                            }

                            //铰链边
                            int middleNumHinge = ComputationalFormula.NumHingeMiddleCalculate_1(order.SpecificationHigh);
                            weldNumHinge = 6 + 8 + middleNumHinge;
                            int middleHingeLength = thickPlateLength - 610 - 1035;
                            int[] upHinge = { 30, 164, 120, 88, 88, 120 };
                            int[] downHinge = { 30, 164, 120, 175, 120, 153, 153, 120 };
                            for (int i = 0; i < 6; i++)
                            {
                                weldSpacingHinge[i] = upHinge[i] * 10;
                            }
                            for (int i = 0; i < middleNumHinge; i++)
                            {
                                weldSpacingHinge[6 + i] = 100 * 10;
                            }
                            weldSpacingHinge[6 + middleNumHinge] = (middleHingeLength - middleNumHinge * 100) * 10;
                            int x = 6 + middleNumHinge + 1;
                            for (int j = 7; j > 0; j--)
                            {
                                weldSpacingHinge[x] = downHinge[j] * 10;
                                x++;
                            }

                            //锁扣边
                            int middleNumKeyhole = ComputationalFormula.NumKeyholeMiddleCalculate_1(order.SpecificationHigh);
                            weldNumKeyhole = 1 + 12 + middleNumKeyhole;
                            int middleKeyholeLength = thickPlateLength - 1675 - 30;
                            int[] downKeyhole = { 30, 120, 125, 200, 115, 120, 115, 300, 115, 120, 115, 200 };
                            weldSpacingKeyhole[0] = 30 * 10;
                            for (int i = 0; i < middleNumKeyhole; i++)
                            {
                                weldSpacingKeyhole[1 + i] = 100 * 10;
                            }
                            weldSpacingKeyhole[1 + middleNumKeyhole] = (middleKeyholeLength - middleNumKeyhole * 100) * 10;
                            int y = 1 + middleNumKeyhole + 1;
                            for (int j = 11; j > 0; j--)
                            {
                                weldSpacingKeyhole[y] = downKeyhole[j] * 10;
                                y++;
                            }
                        }
                        else if (order.DoorStructure == "子母门")
                        {
                            if (high >= 1500 && high <= 2200)
                            {
                                if (width >= 1050 && width < 1250)
                                {
                                    weldNumUpDown = 7;
                                    double spaceUpDown = (double)677 / 6;
                                    spaceUpDown = Math.Round(spaceUpDown, 1);
                                    double endSpace = spaceUpDown * 5 * 10;
                                    int endSpaceInt = (int)endSpace;
                                    weldSpacingUpDown[0] = 25 * 10;
                                    for (int i = 1; i < 6; i++)
                                    {
                                        double space = spaceUpDown * 10;
                                        weldSpacingUpDown[i] = (int)space;
                                    }
                                    weldSpacingUpDown[6] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                                }
                                else if (width >= 1250 && width < 1500)
                                {
                                    weldNumUpDown = 8;
                                    int spaceUpDown = 111;
                                    int endSpaceInt = 5550;
                                    weldSpacingUpDown[0] = 25 * 10;
                                    for (int i = 1; i < 7; i++)
                                    {
                                        weldSpacingUpDown[i] = 1110;
                                    }
                                    weldSpacingUpDown[7] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                                }
                                
                                if (order.PictureDoorSpecification == "子门不含框276" && (width >= 1080 && width < 1150))
                                {
                                    weldNumUpDown = 7;
                                    double spaceUpDown = (double)677 / 6;
                                    spaceUpDown = Math.Round(spaceUpDown, 1);
                                    double endSpace = spaceUpDown * 5 * 10;
                                    int endSpaceInt = (int)endSpace;
                                    weldSpacingUpDown[0] = 25 * 10;
                                    for (int i = 1; i < 6; i++)
                                    {
                                        double space = spaceUpDown * 10;
                                        weldSpacingUpDown[i] = (int)space;
                                    }
                                    weldSpacingUpDown[6] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                                }

                                //铰链边
                                int middleNumHinge = ComputationalFormula.NumHingeMiddleCalculate_1(order.SpecificationHigh);
                                weldNumHinge = 6 + 8 + middleNumHinge;
                                int middleHingeLength = thickPlateLength - 610 - 1035;
                                int[] upHinge = { 30, 164, 120, 88, 88, 120 };
                                int[] downHinge = { 30, 164, 120, 175, 120, 153, 153, 120 };
                                for (int i = 0; i < 6; i++)
                                {
                                    weldSpacingHinge[i] = upHinge[i] * 10;
                                }
                                for (int i = 0; i < middleNumHinge; i++)
                                {
                                    weldSpacingHinge[6 + i] = 100 * 10;
                                }
                                weldSpacingHinge[6 + middleNumHinge] = (middleHingeLength - middleNumHinge * 100) * 10;
                                int x = 6 + middleNumHinge + 1;
                                for (int j = 7; j > 0; j--)
                                {
                                    weldSpacingHinge[x] = downHinge[j] * 10;
                                    x++;
                                }

                                //锁扣边
                                int middleNumKeyhole = ComputationalFormula.NumKeyholeMiddleCalculate_1(order.SpecificationHigh);
                                weldNumKeyhole = 1 + 12 + middleNumKeyhole;
                                int middleKeyholeLength = thickPlateLength - 1675 - 30;
                                int[] downKeyhole = { 30, 120, 125, 200, 115, 120, 115, 300, 115, 120, 115, 200 };
                                weldSpacingKeyhole[0] = 30 * 10;
                                for (int i = 0; i < middleNumKeyhole; i++)
                                {
                                    weldSpacingKeyhole[1 + i] = 100 * 10;
                                }
                                weldSpacingKeyhole[1 + middleNumKeyhole] = (middleKeyholeLength - middleNumKeyhole * 100) * 10;
                                int y = 1 + middleNumKeyhole + 1;
                                for (int j = 11; j > 0; j--)
                                {
                                    weldSpacingKeyhole[y] = downKeyhole[j] * 10;
                                    y++;
                                }
                            }
                        }
                    }
                    else if (order.DoorThickness == "90")
                    {
                        if (order.DoorStructure == "单门")
                        {
                            //上下边
                            if (width <= 850)
                            {
                                weldNumUpDown = 7;
                                double spaceUpDown = ComputationalFormula.SpacingUpDownCalculate_1(order.SpecificationsWide);
                                double endSpace = spaceUpDown * 5 * 10;
                                int endSpaceInt = (int)endSpace;
                                weldSpacingUpDown[0] = 25 * 10;
                                for (int i = 1; i < 6; i++)
                                {
                                    double space = spaceUpDown * 10;
                                    weldSpacingUpDown[i] = (int)space;
                                }
                                weldSpacingUpDown[6] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                            }
                            else if (width > 850 && width <= 950)
                            {
                                weldNumUpDown = 8;
                                double spaceUpDown = ComputationalFormula.SpacingUpDownCalculate_2(order.SpecificationsWide);
                                double endSpace = spaceUpDown * 6 * 10;
                                int endSpaceInt = (int)endSpace;
                                weldSpacingUpDown[0] = 25 * 10;
                                for (int i = 1; i < 7; i++)
                                {
                                    double space = spaceUpDown * 10;
                                    weldSpacingUpDown[i] = (int)space;
                                }
                                weldSpacingUpDown[7] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                            }
                            else if (width > 950 && width <= 1050)
                            {
                                weldNumUpDown = 9;
                                double spaceUpDown = ComputationalFormula.SpacingUpDownCalculate_3(order.SpecificationsWide);
                                double endSpace = spaceUpDown * 7 * 10;
                                int endSpaceInt = (int)endSpace;
                                weldSpacingUpDown[0] = 25 * 10;
                                for (int i = 1; i < 8; i++)
                                {
                                    double space = spaceUpDown * 10;
                                    weldSpacingUpDown[i] = (int)space;
                                }
                                weldSpacingUpDown[8] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                            }

                            //铰链边
                            int middleNumHinge = ComputationalFormula.NumHingeMiddleCalculate_1(order.SpecificationHigh);
                            weldNumHinge = 6 + 8 + middleNumHinge;
                            int middleHingeLength = thickPlateLength - 610 - 1035;
                            int[] upHinge = { 30, 164, 120, 88, 88, 120 };
                            int[] downHinge = { 30, 164, 120, 175, 120, 153, 153, 120 };
                            for (int i = 0; i < 6; i++)
                            {
                                weldSpacingHinge[i] = upHinge[i] * 10;
                            }
                            for (int i = 0; i < middleNumHinge; i++)
                            {
                                weldSpacingHinge[6 + i] = 100 * 10;
                            }
                            weldSpacingHinge[6 + middleNumHinge] = (middleHingeLength - middleNumHinge * 100) * 10;
                            int x = 6 + middleNumHinge + 1;
                            for (int j = 7; j > 0; j--)
                            {
                                weldSpacingHinge[x] = downHinge[j] * 10;
                                x++;
                            }

                            //锁扣边
                            int middleNumKeyhole = ComputationalFormula.NumKeyholeMiddleCalculate_1(order.SpecificationHigh);
                            weldNumKeyhole = 1 + 12 + middleNumKeyhole;
                            int middleKeyholeLength = thickPlateLength - 1675 - 30;
                            int[] downKeyhole = { 30, 120, 125, 200, 115, 120, 115, 300, 115, 120, 115, 200 };
                            weldSpacingKeyhole[0] = 30 * 10;
                            for (int i = 0; i < middleNumKeyhole; i++)
                            {
                                weldSpacingKeyhole[1 + i] = 100 * 10;
                            }
                            weldSpacingKeyhole[1 + middleNumKeyhole] = (middleKeyholeLength - middleNumKeyhole * 100) * 10;
                            int y = 1 + middleNumKeyhole + 1;
                            for (int j = 11; j > 0; j--)
                            {
                                weldSpacingKeyhole[y] = downKeyhole[j] * 10;
                                y++;
                            }
                        }
                        else if (order.DoorStructure == "子母门")
                        {
                            if (high >= 1500 && high <= 2200)
                            {
                                if (width >= 1050 && width < 1250)
                                {
                                    weldNumUpDown = 7;
                                    double spaceUpDown = (double)677 / 6;
                                    spaceUpDown = Math.Round(spaceUpDown, 1);
                                    double endSpace = spaceUpDown * 5 * 10;
                                    int endSpaceInt = (int)endSpace;
                                    weldSpacingUpDown[0] = 25 * 10;
                                    for (int i = 1; i < 6; i++)
                                    {
                                        double space = spaceUpDown * 10;
                                        weldSpacingUpDown[i] = (int)space;
                                    }
                                    weldSpacingUpDown[6] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                                }
                                else if (width >= 1250 && width < 1500)
                                {
                                    weldNumUpDown = 8;
                                    int spaceUpDown = 111;
                                    int endSpaceInt = 5550;
                                    weldSpacingUpDown[0] = 25 * 10;
                                    for (int i = 1; i < 7; i++)
                                    {
                                        weldSpacingUpDown[i] = 1110;
                                    }
                                    weldSpacingUpDown[7] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                                }

                                if (order.PictureDoorSpecification == "子门不含框276" && (width >= 1080 && width < 1150))
                                {
                                    weldNumUpDown = 7;
                                    double spaceUpDown = (double)677 / 6;
                                    spaceUpDown = Math.Round(spaceUpDown, 1);
                                    double endSpace = spaceUpDown * 5 * 10;
                                    int endSpaceInt = (int)endSpace;
                                    weldSpacingUpDown[0] = 25 * 10;
                                    for (int i = 1; i < 6; i++)
                                    {
                                        double space = spaceUpDown * 10;
                                        weldSpacingUpDown[i] = (int)space;
                                    }
                                    weldSpacingUpDown[6] = (thickPlateWidth - 50 - 12) * 10 - endSpaceInt;
                                }

                                //铰链边
                                int middleNumHinge = ComputationalFormula.NumHingeMiddleCalculate_1(order.SpecificationHigh);
                                weldNumHinge = 6 + 8 + middleNumHinge;
                                int middleHingeLength = thickPlateLength - 610 - 1035;
                                int[] upHinge = { 30, 164, 120, 88, 88, 120 };
                                int[] downHinge = { 30, 164, 120, 175, 120, 153, 153, 120 };
                                for (int i = 0; i < 6; i++)
                                {
                                    weldSpacingHinge[i] = upHinge[i] * 10;
                                }
                                for (int i = 0; i < middleNumHinge; i++)
                                {
                                    weldSpacingHinge[6 + i] = 100 * 10;
                                }
                                weldSpacingHinge[6 + middleNumHinge] = (middleHingeLength - middleNumHinge * 100) * 10;
                                int x = 6 + middleNumHinge + 1;
                                for (int j = 7; j > 0; j--)
                                {
                                    weldSpacingHinge[x] = downHinge[j] * 10;
                                    x++;
                                }

                                //锁扣边
                                int middleNumKeyhole = ComputationalFormula.NumKeyholeMiddleCalculate_1(order.SpecificationHigh);
                                weldNumKeyhole = 1 + 12 + middleNumKeyhole;
                                int middleKeyholeLength = thickPlateLength - 1675 - 30;
                                int[] downKeyhole = { 30, 120, 125, 200, 115, 120, 115, 300, 115, 120, 115, 200 };
                                weldSpacingKeyhole[0] = 30 * 10;
                                for (int i = 0; i < middleNumKeyhole; i++)
                                {
                                    weldSpacingKeyhole[1 + i] = 100 * 10;
                                }
                                weldSpacingKeyhole[1 + middleNumKeyhole] = (middleKeyholeLength - middleNumKeyhole * 100) * 10;
                                int y = 1 + middleNumKeyhole + 1;
                                for (int j = 11; j > 0; j--)
                                {
                                    weldSpacingKeyhole[y] = downKeyhole[j] * 10;
                                    y++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
