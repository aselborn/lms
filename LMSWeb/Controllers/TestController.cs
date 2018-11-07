using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSWeb.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            return "This is my LMS index page!";
        }

        public string TestPage()
        {
            return "This is my LMS test page!";
        }
    }
}