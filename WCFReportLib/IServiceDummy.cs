using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFReportLib
{
    /*
     * Just for dummy purpose... 
    */

    [ServiceContract]
    public interface IServiceDummy
    {
        [OperationContract]
        string GetDummyReply();
    }
}
