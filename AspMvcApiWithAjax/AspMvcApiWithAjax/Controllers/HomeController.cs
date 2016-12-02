using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspMvcApiWithAjax.Controllers
{
    public class HomeController : Controller
    {
        FormsAuthenticationTicket obj = new FormsAuthenticationTicket();
        public ActionResult Index()
        {
           

            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            ViewBag.Title = "Test Page";

            return View();
        }
    }
}
