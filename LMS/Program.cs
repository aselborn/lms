using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFReportLib;

namespace LMS
{
    class Program
    {
        private static ChannelFactory<IReportService> reportChannelFactory = null;
        private static EndpointAddress reportEndpointAddress = null;
        
        private static string _serviceAddress = null;
        private static IReportService _iReportService;

        static void Main(string[] args)
        {
            _serviceAddress = ConfigurationManager.AppSettings["WCFService"];

            using (ServiceHost host = new ServiceHost(typeof(WCFReportLib.ReportService)))
            {

                host.Open();

                Console.WriteLine("Service up and running at:");
                foreach (var ea in host.Description.Endpoints)
                {
                    Console.WriteLine(ea.Address);
                }
              
                Console.ReadLine();
                host.Close();

            }

        }

        private static void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            reportChannelFactory = new ChannelFactory<IReportService>(tcpBinding);
            reportEndpointAddress = new EndpointAddress(_serviceAddress);

            _iReportService = reportChannelFactory.CreateChannel(reportEndpointAddress);


       
        }
    }
}
