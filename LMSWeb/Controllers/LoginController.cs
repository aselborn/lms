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
        ServiceHelper _serviceHelper = new ServiceHelper();
        IReportService _iReportService;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(LMSWeb.Models.UserObjectModel userObjectModel )
        {
            _iReportService = _serviceHelper.GetReportService();
            UserObject user = new UserObject
            {
                UserObjectName = userObjectModel.UserObjectName,
                UserObjectPassword = userObjectModel.UserObjectPassword
            };
            int userObjectId = _iReportService.UserLogin(user);
            ((IClientChannel)_iReportService).Close();

            if (userObjectId > 0)
            {
                Session["userObjectId"] = user.UserObjectId;
                Session["userObjectName"] = user.UserObjectName;
                return RedirectToAction("Stat", "statistics");
            }
            else if (userObjectId == 0)
            {
                userObjectModel.LoginErrorMessage = "Wrong 'User Name' or 'Password!";
                return View("Index", userObjectModel);
            }
            else
            {
                userObjectModel.LoginErrorMessage = "User is locked!";
                return View("Index", userObjectModel);
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}