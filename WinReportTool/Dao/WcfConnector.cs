using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFReportLib;

namespace WinReportTool.Dao
{
    public class WcfConnector
    {
        private static ChannelFactory<IReportService> reportChannelFactory = null;
        private static EndpointAddress endpointAddress = null;
        private static string epAddr = "net.tcp://localhost:7778/";
        private static IReportService _iReportService;

        public static IReportService GetReportService
        {
            get
            {
                if (_iReportService == null)
                    SetupConnection();

                return _iReportService;
            }
        }

        private static void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            reportChannelFactory = new ChannelFactory<IReportService>(tcpBinding);
            endpointAddress = new EndpointAddress(epAddr);
            _iReportService = reportChannelFactory.CreateChannel(endpointAddress);
        }

        
    }
}
