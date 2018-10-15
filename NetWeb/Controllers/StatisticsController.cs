﻿
using NetWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WCFReportLib;
using static ReportDao.Model.Bridge;

namespace NetWeb.Controllers
{
    public class StatisticsController : Controller
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

        private IEnumerable<SelectListItem> GetTestBeds()
        {
            SetupConnection();
            List<TestBed> testBeds = _iReportService.GetTestBeds();


            var myData = testBeds.Select(x => new SelectListItem()
            {
                Text = x.TestBedName,
                Value = x.TestBedId.ToString()
            });

            return new SelectList(myData, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetEventTypes(bool topTypes = false)
        {
            SetupConnection();
            List<EventType> eventTypes = _iReportService.GetEventTypes();

            if (topTypes)
            {
                eventTypes = eventTypes.Where(p => !p.EventTypeSubId.HasValue).ToList();
            }

            var myData = eventTypes.Select(x => new SelectListItem()
            {
                Text = x.EventTypeDescription,
                Value = x.EventTypeId.ToString()
            });

            return new SelectList(myData, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetSubEventTypes(int masterId)
        {
            //This is not good, two calls to DB.
            SetupConnection();
            var filtered = _iReportService.GetEventTypes().Where(h => h.EventTypeSubId == masterId).ToList();

            var myData = filtered.Select(x => new SelectListItem()
            {
                Text = x.EventTypeDescription,
                Value=x.EventTypeId.ToString()
            });

            return new SelectList(myData, "Value", "Text");
        }
        // GET: Statistics
        public ActionResult Index()
        {
            
            TestbedViewModel testbedModel = new TestbedViewModel
            {
                ListofTestbeds = GetTestBeds()
            };

            EventTypeViewModel eventTypeViewModel = new EventTypeViewModel
            {
                ListofEventTypes = GetEventTypes()
            };

            EventTypeViewModel topEvents = new EventTypeViewModel
            {
                ListofEventTypes = GetEventTypes(true)
            };

            var tupleModel = new Tuple<TestbedViewModel, EventTypeViewModel, EventTypeViewModel>(testbedModel, topEvents, eventTypeViewModel);

            return View(tupleModel);
        }

        [HttpPost]
        public ActionResult Index(int testBedId)
        {

            return View();
        }

        // GET: Statistics/Details/5
        public ActionResult Details(int MasterEventId)
        {
            var SubCategories = GetSubEventTypes(MasterEventId);

            return Json(SubCategories, JsonRequestBehavior.AllowGet);
            
        }

        // GET: Statistics/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Statistics/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}