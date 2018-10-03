using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFReportLib
{
    public class ServiceDummy : IServiceDummy
    {
        public string GetDummyReply()
        {
            return "This is an answer from Dummy!";
        }
    }
}
