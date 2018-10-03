using System;
using System.Collections.Generic;
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
        private static string strReportAddress = "net.tcp://localhost:7778/";
        private static IReportService _iReportService;


        static void Main(string[] args)
        {

            //ReportController reportController = new ReportController();
            //Console.WriteLine("WCF ReportController is started.");
            //Uri _baseAdress = new Uri("http://localhost:8081/ReportService");

            //using (ServiceHost host = new ServiceHost(typeof(WCFReportLib.WcfModel)))
            //{

            //    host.Open();


            //    Console.WriteLine("Service up and running at:");
            //    foreach (var ea in host.Description.Endpoints)
            //    {
            //        Console.WriteLine(ea.Address);
            //    }

            //    Console.ReadLine();
            //    host.Close();

            //}



            using (ServiceHost host = new ServiceHost(typeof(WCFReportLib.ReportService)))
            {

                host.Open();


                Console.WriteLine("Service up and running at:");
                foreach (var ea in host.Description.Endpoints)
                {
                    Console.WriteLine(ea.Address);
                }
                // var blabb = _iReportService.GetEventTypes();

              
                Console.ReadLine();
                host.Close();

            }

        }

        private static void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            reportChannelFactory = new ChannelFactory<IReportService>(tcpBinding);
            reportEndpointAddress = new EndpointAddress(strReportAddress);

            _iReportService = reportChannelFactory.CreateChannel(reportEndpointAddress);


       
        }
    }
}
