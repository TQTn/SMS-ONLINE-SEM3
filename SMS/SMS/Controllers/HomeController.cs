using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS_Online.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Regis page.";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Admin page.";

            return View();
        }
    }
}