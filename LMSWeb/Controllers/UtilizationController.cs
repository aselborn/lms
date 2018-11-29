using LMSWeb.Helper;
using LMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WCFReportLib;
using static ReportDao.Model.Bridge;

namespace LMSWeb.Controllers
{
    public class UtilizationController : Controller
    {
        IReportService _iReportService;
        ServiceHelper _serviceHelper = new ServiceHelper();
        // GET: Utilization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UtilPerDate()
        {
            Session["CurrentPage"] = "Utilization"; //för meny.

            DateSelectModel dateSelectModel = new DateSelectModel { FromDate = DateTime.Now, TomDate = DateTime.Now };
            TestbedViewModel testbedModel = new TestbedViewModel
            {
                ListofTestbeds = DataProvider.GetTestBeds()
            };

            var tupleModel = new Tuple<TestbedViewModel, DateSelectModel>
                (testbedModel, dateSelectModel);



            return View(tupleModel);
        }

        
        
        public ActionResult Data(UtilizationParameters data)
        {
            _iReportService = _serviceHelper.GetReportService();
            FilterParameters filterParameters = new FilterParameters();
            

            List<ResultUtilizationObject> statistics = _iReportService.EventUtilization(filterParameters);
            ((IClientChannel)_iReportService).Close();
            return Json(statistics, JsonRequestBehavior.AllowGet);
            //return null;
        }
    }
}