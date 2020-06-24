using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_GluingSystem.Common
{
    public class ProductNumber
    {
        //生产总数
        public int TotalOutput { get; set; }
        //合格数
        public int QualifiedNumber { get; set; }
        //不合格数
        public int UnqualifiedNumber { get; set; }

    }
}
