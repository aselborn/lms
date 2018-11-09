using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WCFReportLib;
using WCFReportLib.Model;
using static ReportDao.Model.Bridge;

namespace LMSWeb.Controllers
{
    public class WCFController : Controller
    {
        ServiceHelper _serviceHelper = new ServiceHelper();
        IReportService _iReportService;
        
        // GET: WCF
        public ActionResult Index()
        {
            _iReportService = _serviceHelper.GetReportService();
            List<SimpleResultObject> lstModel = _iReportService.EventLogDummy(null, null);
            ((IClientChannel)_iReportService).Close();
            return View(lstModel);
        }

        public ActionResult Pie()
        {
            _iReportService = _serviceHelper.GetReportService();
            List<SimpleResultObject> lstModel = _iReportService.EventLogDummy(null, null);
            ((IClientChannel)_iReportService).Close();
            return View(lstModel);
        }

        public ActionResult Line()
        {
            _iReportService = _serviceHelper.GetReportService();
            List<SimpleResultObject> lstModel = _iReportService.EventLogDummy(null, null);
            ((IClientChannel)_iReportService).Close();
            return View(lstModel);
        }


        public ActionResult Pie2()
        {
            _iReportService = _serviceHelper.GetReportService();

            FilterParameters parameters = new FilterParameters { WithGrouping = FilterParameters.GroupByOperator.Month };
            List<ResultObject> data = _iReportService.EventlogObjectForRig(parameters);
            ((IClientChannel)_iReportService).Close();
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