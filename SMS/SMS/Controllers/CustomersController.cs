using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Controllers
{
    public class CustomersController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Advertisement).Include(c => c.PersonalDetail).Include(c => c.ProfessionalDetail);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.AdvertisementID = new SelectList(db.Advertisements, "AdvertisementID", "Brand");
            ViewBag.CustomerID = new SelectList(db.PersonalDetails, "CustomerID", "Name");
            ViewBag.CustomerID = new SelectList(db.ProfessionalDetails, "CustomerID", "Qualification");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,NumberPhone,Password,UserName,Status,AdvertisementID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.AdvertisementID = new SelectList(db.Advertisements, "AdvertisementID", "Brand", customer.AdvertisementID);
            ViewBag.CustomerID = new SelectList(db.PersonalDetails, "CustomerID", "Name", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.ProfessionalDetails, "CustomerID", "Qualification", customer.CustomerID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvertisementID = new SelectList(db.Advertisements, "AdvertisementID", "Brand", customer.AdvertisementID);
            ViewBag.CustomerID = new SelectList(db.PersonalDetails, "CustomerID", "Name", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.ProfessionalDetails, "CustomerID", "Qualification", customer.CustomerID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,NumberPhone,Password,UserName,Status,AdvertisementID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvertisementID = new SelectList(db.Advertisements, "AdvertisementID", "Brand", customer.AdvertisementID);
            ViewBag.CustomerID = new SelectList(db.PersonalDetails, "CustomerID", "Name", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.ProfessionalDetails, "CustomerID", "Qualification", customer.CustomerID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
