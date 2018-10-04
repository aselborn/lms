using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFReportLib.Model
{
    public class SimpleStackModel
    {
        public string DimensionText { get; set; }
        public List<SimpleResultObject> LstData { get; set; }
    }
}
