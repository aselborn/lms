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
    public class LoginController : Controller
    {
        private ChannelFactory<IReportService> reportChannelFactory = null;
        private EndpointAddress endpointAddress = null;
        //        private string epAddr = "net.tcp://localhost:7778/";
        private string epAddr = "net.tcp://10.8.227.128:7778/";//"net.tcp://localhost:7778/";
        private IReportService _iReportService;


        private void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            reportChannelFactory = new ChannelFactory<IReportService>(tcpBinding);
            endpointAddress = new EndpointAddress(epAddr);
            _iReportService = reportChannelFactory.CreateChannel(endpointAddress);
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(LMSWeb.Models.UserObjectModel userObjectModel )
        {
            var userDetails = GetUsers().Where(u => u.UserObjectName.ToLower() == userObjectModel.UserObjectName.Trim().ToLower() &&
                                                u.UserObjectPassword == userObjectModel.UserObjectPassword.Trim()).FirstOrDefault();
            if (userDetails == null)
            {
                userObjectModel.LoginErrorMessage = "Wrong 'User Name' or 'Password!";
                return View("Index", userObjectModel);
            }
            else
            {
                Session["userObjectId"] = userDetails.UserObjectId;
                Session["userObjectName"] = userDetails.UserObjectName;
                return RedirectToAction("Stat", "statistics");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }

        private List<UserObject> GetUsers()
        {
            SetupConnection();
            List<UserObject> users = _iReportService.GetUserObjects();
            ((IClientChannel)_iReportService).Close();
            return users;
        }
    }
}