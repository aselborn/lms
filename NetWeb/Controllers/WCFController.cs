using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WCFReportLib;

namespace NetWeb.Controllers
{
    public class WCFController : Controller
    {

        private ChannelFactory<IReportService> reportChannelFactory = null;
        private EndpointAddress endpointAddress = null;
        private string epAddr = "net.tcp://localhost:7778/";
        private IReportService _iReportService;


        private void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            reportChannelFactory = new ChannelFactory<IReportService>(tcpBinding);
            endpointAddress = new EndpointAddress(epAddr);
            _iReportService = reportChannelFactory.CreateChannel(endpointAddress);
        }


        // GET: WCF
        public ActionResult Index()
        {
            SetupConnection();
            List<SimpleResultObject> lstModel = _iReportService.EventLogDummy(null, null);

            return View(lstModel);
        }

        public ActionResult Pie()
        {
            SetupConnection();
            List<SimpleResultObject> lstModel = _iReportService.EventLogDummy(null, null);

            return View(lstModel);
        }

        public ActionResult Line()
        {
            SetupConnection();
            List<SimpleResultObject> lstModel = _iReportService.EventLogDummy(null, null);

            return View(lstModel);
        }

        public ActionResult Stacked()
        {
            Random rnd = new Random();
            var lstModel = new List<SimpleResultObject>();
            //sales of product sales by quarter  
            


            return View(lstModel);
            
        }
    }
}