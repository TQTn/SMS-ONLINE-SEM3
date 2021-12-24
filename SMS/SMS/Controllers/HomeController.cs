using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SMS_Online.Controllers
{
    public class HomeController : Controller

    {
        private Database1Entities db = new Database1Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {


            return View();
        }

        public ActionResult Register()
        {


            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Admin page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "CustomerID,NumberPhone,Password,UserName,Status")] Customer customer)
        {

            customer.CustomerID = customer.UserName;
            customer.Status = true;
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer Customers)
        {
            var u = db.Customers.SingleOrDefault(m => m.NumberPhone == Customers.NumberPhone && m.Password == Customers.Password);

            if (u != null)
            {

                FormsAuthentication.SetAuthCookie(Customers.NumberPhone, false);
                Session["NumberPhone"] = Customers.NumberPhone;
                System.Diagnostics.Debug.WriteLine("NumberPhone" + Session["NumberPhone"]);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Username or password not found";
            }
            return View();

        }
    }
}