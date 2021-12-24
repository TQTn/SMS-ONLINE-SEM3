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
    public class ProfessionalDetailsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: ProfessionalDetails
        public ActionResult Index()
        {
            var professionalDetails = db.ProfessionalDetails.Include(p => p.Customer);
            return View(professionalDetails.ToList());
        }

        // GET: ProfessionalDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalDetail professionalDetail = db.ProfessionalDetails.Find(id);
            if (professionalDetail == null)
            {
                return HttpNotFound();
            }
            return View(professionalDetail);
        }

        // GET: ProfessionalDetails/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "NumberPhone");
            return View();
        }

        // POST: ProfessionalDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Qualification,School,College,Workstatus,Organization_,Designation")] ProfessionalDetail professionalDetail)
        {
            if (ModelState.IsValid)
            {
                db.ProfessionalDetails.Add(professionalDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "NumberPhone", professionalDetail.CustomerID);
            return View(professionalDetail);
        }

        // GET: ProfessionalDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalDetail professionalDetail = db.ProfessionalDetails.Find(id);
            if (professionalDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "NumberPhone", professionalDetail.CustomerID);
            return View(professionalDetail);
        }

        // POST: ProfessionalDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Qualification,School,College,Workstatus,Organization_,Designation")] ProfessionalDetail professionalDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionalDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "NumberPhone", professionalDetail.CustomerID);
            return View(professionalDetail);
        }

        // GET: ProfessionalDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalDetail professionalDetail = db.ProfessionalDetails.Find(id);
            if (professionalDetail == null)
            {
                return HttpNotFound();
            }
            return View(professionalDetail);
        }

        // POST: ProfessionalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProfessionalDetail professionalDetail = db.ProfessionalDetails.Find(id);
            db.ProfessionalDetails.Remove(professionalDetail);
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
