using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common.Class
{
    public class OrderInformation
    {
        //订单
        public string OrderNum { set; get; }
        //物料编号
        public string StockNum { set; get; }
        //批次
        public string Batch { set; get; }
        // 订单数量 (GMEIN)
        public string OrderQuantity { set; get; }
        // 已交货数量 (GMEIN)
        public string DeliveredQuantity { set; get; }
        // MRP控制者
        public string MRPController { set; get; }
        //基本开始日期
        public string BasicStartDate { set; get; }
        // 基本完成日期
        public string BasicCompletionDate { set; get; }
        //基本开始年份
        public string BasicStartYear { set; get; }
        //基本开始月份
        public string BasicStartMonth { set; get; }
        //基本开始日
        public string BasicStartDay { set; get; }
        //物料描述
        public string MaterialDescription { set; get; }
        //库存地点
        public string StorageLocation { set; get; }
        //计划工厂
        public string PlannedPlant { set; get; }
        //商标
        public string Brand { set; get; }
        //产品系列
        public string ProductLine { set; get; }
        //门体厚度mm
        public string DoorThickness { set; get; }
        //门体结构
        public string DoorStructure { set; get; }
        //规格宽cm
        public string SpecificationsWide { set; get; }
        //规格高cm
        public string SpecificationHigh { set; get; }
        //气窗高cm
        public string TransomWindowHigh { set; get; }
        //标准/非标
        public string StandardOrNon_standard { set; get; }
        //门面款式
        public string FacadeStyle { set; get; }
        //子门款式
        public string ChildDoorStyle { set; get; }
        //防盗等级
        public string SecurityLevel { set; get; }
        //防火等级
        public string FireRating { set; get; }
        //锁具
        public string Lock { set; get; }
        //锁芯
        public string KeyCylinder { set; get; }
        //副锁
        public string DeputyLock { set; get; }
        //装饰片
        public string Overlay { set; get; }
        //套色
        public string Overdye { set; get; }
        //门框
        public string Doorframe { set; get; }
        //下档
        public string Downside { set; get; }
        //无平下档门扇离地mm
        public string NonDownsideDoorLeafGround { set; get; }
        //正门板mm
        public string FrontDoorPlank { set; get; }
        //反门板mm
        public string ContraryDoorPlank { set; get; }
        //门框板mm
        public string FramePlate { set; get; }
        //填充物
        public string Filler { set; get; }
        //门铃门镜
        public string BellDoorMirror { set; get; }
        //皮条
        public string Thong { set; get; }
        //拉手
        public string Handle { set; get; }
        //铰链
        public string Hinge { set; get; }
        //铰链个数
        public string HingeNo { set; get; }
        //开向 
        public string OpenTo { set; get; }
        //复合内门款式
        public string CompositeGateStyle { set; get; }
        //压花
        public string Amboss { set; get; }
        //骨架
        public string Framework { set; get; }
        //插销
        public string Bolt { set; get; }
        //天地锁 
        public string HeavenEarthLock { set; get; }
        //钥匙
        public string Key { set; get; }
        //特殊门类
        public string SpecialDoor { set; get; }
        //扣边
        public string Buckles { set; get; }
        //颜色类别
        public string ColorCategories { set; get; }
        //小门纱网
        public string WicketGauze { set; get; }
        //复合门花窗 
        public string CompositeGateLatticeWindow { set; get; }
        //结构类别
        public string StructureCategories { set; get; }
        //气窗结构
        public string TransomStructure { set; get; }
        //气窗款式
        public string TransomStyle { set; get; }
        //封板结构
        public string BlankingPlateStructure { set; get; }
        //母门子门规格
        public string PictureDoorSpecification { set; get; }
        //开主机观察窗孔
        public string MainframeObserveIris { set; get; }
        //闭门器 
        public string DoorCloser { set; get; }
        //门头
        public string DoorHead { set; get; }
        //门柱
        public string Doorpost { set; get; }
        //涂装工艺
        public string CoatingProcess { set; get; }
        //客户特殊要求
        public string CustomerSpecialRequirements { set; get; }
        //常规或定制 
        public string ConventionalOrCustomized { set; get; }
        //经销商地址
        public string DealerAddress { set; get; }
        //系统状态
        public string SystemState { set; get; }
    }
}
