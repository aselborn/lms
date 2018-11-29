
using LMSWeb.Helper;
using LMSWeb.Models;
using ReportDao.Model;
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
    /*
     * https://www.codeproject.com/Articles/1079909/ASP-NET-MVC-Partial-Views-with-Partial-Models 
     * 
    */
    public class StatisticsController : Controller
    {
        ServiceHelper _serviceHelper = new ServiceHelper();
        IReportService _iReportService;

       
        
        // GET: Statistics
        public ActionResult Index()
        {
            return RedirectToAction("Stat");
        }

        // GET: Statistics/Details/5
        public ActionResult Details(int MasterEventId)
        {

            var SubCategories = DataProvider.GetSubEventTypes(MasterEventId);
            return Json(SubCategories, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Data(FilterParameters data)
        {
            _iReportService = _serviceHelper.GetReportService();
            
            switch (data.WithReporting)
            {
                //Antal händelser.
                case FilterParameters.ReportType.numberofevents:

                    if (data.WithGrouping == FilterParameters.GroupByOperator.Day)
                    {
                        List<List<DayDistributeReply>> distribute = _iReportService.EventLogDayDistribute(data);
                        ((IClientChannel)_iReportService).Close();

                        return Json(distribute);
                    }
                    else
                    {
                        List<ResultObject> eventLogs = _iReportService.EventlogObjectForRig(data);
                        ((IClientChannel)_iReportService).Close();

                        return Json(eventLogs, JsonRequestBehavior.AllowGet);
                    }


                    //Nyttjandegrad.
                case FilterParameters.ReportType.utilization:

                    List<ResultUtilizationObject> statistics = _iReportService.EventUtilization(data);
                    ((IClientChannel)_iReportService).Close();

                    return Json(statistics, JsonRequestBehavior.AllowGet);
                    

                default:
                    return RedirectToAction("Index");
            }

            
        }

        [HttpGet]
        public ActionResult GetData(List<ResultObject> results)
        {
            List<ResultObject> myResult = (List<ResultObject>)TempData["ResultObject"];
            return View();
        }

        //Statistics entry Point
        public ActionResult Stat()
        {
            //return PartialView("_LeftSide");

            ReportTypeViewModel reportTypes = new ReportTypeViewModel
            {
                ListOfReportTypes = DataProvider.GetReportTypes()
            };

            DateSelectModel dateSelectModel = new DateSelectModel { FromDate = DateTime.Now, TomDate = DateTime.Now };
            TestbedViewModel testbedModel = new TestbedViewModel
            {
                ListofTestbeds = DataProvider.GetTestBeds()
            };

            EventTypeViewModel eventTypeViewModel = new EventTypeViewModel
            {
                ListofEventTypes = DataProvider.GetEventTypes()
            };

            EventTypeViewModel topEvents = new EventTypeViewModel
            {
                ListofEventTypes = DataProvider.GetEventTypes(true)
            };

            _iReportService = _serviceHelper.GetReportService();
            List<SimpleResultObject> lstModel = _iReportService.EventLogDummy(null, null);
            ((IClientChannel)_iReportService).Close();

           
            var tupleModel =
                new Tuple<TestbedViewModel, EventTypeViewModel, EventTypeViewModel, DateSelectModel>
                (testbedModel, topEvents, eventTypeViewModel, dateSelectModel);

            TempData["ReportTypes"] = reportTypes;

            return View(tupleModel);
        }


        // POST: Statistics/Create
        [HttpPost]
        public ActionResult RecieveForm(FormCollection collection, string returnUrl)
        {
            try
            {
                _iReportService = _serviceHelper.GetReportService();
                FilterParameters selection = CreateSelectionParameters(collection);
                List<ResultObject> data = _iReportService.EventlogObjectForRig(selection);
                ((IClientChannel)_iReportService).Close();

                //return RedirectToAction("Pie2", "WCF", data);
                //return View(data);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private FilterParameters CreateSelectionParameters(FormCollection collection)
        {

            string groupText = collection.Get("group");
            FilterParameters.GroupByOperator groupByOperator = (FilterParameters.GroupByOperator)Enum.Parse(typeof(FilterParameters.GroupByOperator), groupText);

            bool UseSubitems = collection.Get("IsAllEvents") == "true" ? true : false;

            FilterParameters filterParameters = new FilterParameters
            {
                TestBedId = Convert.ToInt32(collection.Get("Item1.TestbedId")),
                EventTypeId = UseSubitems ? Convert.ToInt32(collection.Get("Item2.EventTypeId")) : Convert.ToInt32(collection.Get("ddlSubEvent")),
                StartDate = Convert.ToDateTime(collection.Get("Item4.FromDate")),
                StopDate = Convert.ToDateTime(collection.Get("Item4.TomDate")),
                AllSubEvents = UseSubitems,
                WithGrouping = groupByOperator
            };

            return filterParameters;
        }

        [HttpPost]
        public ActionResult Insert(FormCollection collection)
        {

            return null;
        }

        // GET: Statistics/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Statistics/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Statistics/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Statistics/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult ModalPopup(PopupViewModel viewModel)
        //{
        //}
    }
}
