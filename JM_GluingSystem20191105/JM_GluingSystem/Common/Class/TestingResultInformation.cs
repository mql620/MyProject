using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common
{
    class TestingResultInformation
    {
        public string DoorID { set; get; }
        public string DoorMold { set; get; }
        public string WorkSheetNumber { set; get; }
        public string TestingTime { set; get; }
        public string Result { set; get; }
        public string DoorEdgeResult0 { set; get; }
        public string DoorEdgeFailedReason0 { set; get; }
        public string DoorEdgeResult1 { set; get; }
        public string DoorEdgeFailedReason1 { set; get; }
        public string DoorEdgeResult2 { set; get; }
        public string DoorEdgeFailedReason2 { set; get; }
        public string DoorEdgeResult3 { set; get; }
        public string DoorEdgeFailedReason3 { set; get; }
    }
}
