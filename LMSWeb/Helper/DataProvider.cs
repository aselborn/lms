using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WCFReportLib;
using static ReportDao.Model.Bridge;

namespace LMSWeb.Helper
{
    public class DataProvider
    {
        static ServiceHelper _serviceHelper = new ServiceHelper();
        static IReportService _iReportService;
        public static IEnumerable<SelectListItem> GetTestBeds()
        {
            _iReportService = _serviceHelper.GetReportService();
            List<TestBed> testBeds = _iReportService.GetTestBeds();
            ((IClientChannel)_iReportService).Close();

            var myData = testBeds.Select(x => new SelectListItem()
            {
                Text = x.TestBedName,
                Value = x.TestBedId.ToString()
            });

            return new SelectList(myData, "Value", "Text");
        }

        public static IEnumerable<SelectListItem> GetEventTypes(bool topTypes = false)
        {
            _iReportService = _serviceHelper.GetReportService();
            List<EventType> eventTypes = _iReportService.GetEventTypes();
            ((IClientChannel)_iReportService).Close();

            if (topTypes)
            {
                eventTypes = eventTypes.Where(p => !p.EventTypeSubId.HasValue).ToList();
            }

            var myData = eventTypes.Select(x => new SelectListItem()
            {
                Text = x.EventTypeDescription,
                Value = x.EventTypeId.ToString()
            });

            myData = myData.OrderBy(n => n.Text);


            return new SelectList(myData, "Value", "Text", myData.FirstOrDefault());
        }

        public static IEnumerable<SelectListItem> GetReportTypes()
        {
            _iReportService = _serviceHelper.GetReportService();
            List<ReportType> reportTypes = _iReportService.GetReportTypes();
            ((IClientChannel)_iReportService).Close();

            var data = reportTypes.Select(x => new SelectListItem()
            {
                Text = x.ReportTypeText,
                Value = x.ReportTypeId.ToString()
            });

            return new SelectList(data, "Value", "Text");
        }


        public static IEnumerable<SelectListItem> GetSubEventTypes(int masterId)
        {
            //This is not good, two calls to DB.
            _iReportService = _serviceHelper.GetReportService();
            var filtered = _iReportService.GetEventTypes().Where(h => h.EventTypeSubId == masterId).ToList();
            ((IClientChannel)_iReportService).Close();

            var myData = filtered.Select(x => new SelectListItem()
            {
                Text = x.EventTypeDescription,
                Value = x.EventTypeId.ToString()
            });

            return new SelectList(myData, "Value", "Text");
        }
    }
}