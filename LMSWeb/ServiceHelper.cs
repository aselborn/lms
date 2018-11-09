using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using WCFReportLib;

namespace LMSWeb
{
    public class ServiceHelper
    {
        private ChannelFactory<IReportService> reportChannelFactory = null;
        private EndpointAddress endpointAddress = null;
        //        private string epAddr = "net.tcp://localhost:7778/";
        private string epAddr = "net.tcp://10.8.227.128:7778/";//"net.tcp://localhost:7778/";
        private IReportService _iReportService;

        public IReportService GetReportService()
        {
            SetupConnection();
            return _iReportService;
        }

        private void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            reportChannelFactory = new ChannelFactory<IReportService>(tcpBinding);
            endpointAddress = new EndpointAddress(epAddr);
            _iReportService = reportChannelFactory.CreateChannel(endpointAddress);
        }
    }
}