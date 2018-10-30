using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WCFReportLib;
using WCFReportLib.Model;
using static ReportDao.Model.Bridge;

namespace NetWeb.Controllers
{
    public class WCFController : Controller
    {

        private ChannelFactory<IReportService> reportChannelFactory = null;
        private EndpointAddress endpointAddress = null;
        private string epAddr = "net.tcp://10.8.227.128:7778/";//"net.tcp://localhost:7778/";
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


        public ActionResult Pie2()
        {
            SetupConnection();

            FilterParameters parameters = new FilterParameters { WithGrouping = FilterParameters.GroupByOperator.Month };
            List<ResultObject> data = _iReportService.EventlogObjectForRig(parameters);
            return View(data);
        }

        public ActionResult Stacked()
        {
            Random rnd = new Random();
            var lstModel = new List<SimpleStackModel>();
            //sales of product sales by quarter  

            lstModel.Add(new SimpleStackModel
            {
                DimensionText = "First Quarter",
                LstData = new List<SimpleResultObject>()
                {
                    new SimpleResultObject
                    {
                        myValue = rnd.Next(10),
                        text = "tv"
                    },
                    new SimpleResultObject
                    {
                        myValue=rnd.Next(),
                        text="Games"
                    },
                    new SimpleResultObject
                    {
                        text="Books",
                        myValue=rnd.Next(10)
                    }

                }

            });

            lstModel.Add(new SimpleStackModel
            {
                DimensionText = "Second Quarter",
                LstData = new List<SimpleResultObject>()
                {
                    new SimpleResultObject
                    {
                        myValue = rnd.Next(10),
                        text = "tv"
                    },
                    new SimpleResultObject
                    {
                        myValue=rnd.Next(),
                        text="Games"
                    },
                    new SimpleResultObject
                    {
                        text="Books",
                        myValue=rnd.Next(10)
                    }

                }

            });


            lstModel.Add(new SimpleStackModel
            {
                DimensionText = "Third Quarter",
                LstData = new List<SimpleResultObject>()
                {
                    new SimpleResultObject
                    {
                        myValue = rnd.Next(10),
                        text = "tv"
                    },
                    new SimpleResultObject
                    {
                        myValue=rnd.Next(),
                        text="Games"
                    },
                    new SimpleResultObject
                    {
                        text="Books",
                        myValue=rnd.Next(10)
                    }

                }

            });



            return View(lstModel);
            
        }
    }
}