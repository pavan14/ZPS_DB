using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZPS_DB.Models;

namespace ZPS_DB.Controllers
{
    public class StudentLCsController : Controller
    {
        private ZPSDBDATAEntities db = new ZPSDBDATAEntities();

        // GET: StudentLCs
        public ActionResult Index()
        {
            return View(db.StudentLCs.ToList());
        }

        // GET: StudentLCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLC studentLC = db.StudentLCs.Find(id);
            if (studentLC == null)
            {
                return HttpNotFound();
            }
            return View(studentLC);
        }

        // GET: StudentLCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentLCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmissionID,AadharCard,FirstName,FatherName,LastName,MotherName,Nationality,MotherTongue,Religion,Cast,SubCast,BirthPlace,Taluka,District,State,DOB,DOB_In_Words,PreviousSchool,Division,AdmissionDate,AdmissionDivision,Performance,Behaviour,SchoolLeaveDate,CurrentDivision,Reason")] StudentLC studentLC)
        {
            if (ModelState.IsValid)
            {
                db.StudentLCs.Add(studentLC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentLC);
        }

        // GET: StudentLCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLC studentLC = db.StudentLCs.Find(id);
            if (studentLC == null)
            {
                return HttpNotFound();
            }
            return View(studentLC);
        }

        // POST: StudentLCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdmissionID,AadharCard,FirstName,FatherName,LastName,MotherName,Nationality,MotherTongue,Religion,Cast,SubCast,BirthPlace,Taluka,District,State,DOB,DOB_In_Words,PreviousSchool,Division,AdmissionDate,AdmissionDivision,Performance,Behaviour,SchoolLeaveDate,CurrentDivision,Reason")] StudentLC studentLC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentLC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentLC);
        }

        // GET: StudentLCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLC studentLC = db.StudentLCs.Find(id);
            if (studentLC == null)
            {
                return HttpNotFound();
            }
            return View(studentLC);
        }

        // POST: StudentLCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentLC studentLC = db.StudentLCs.Find(id);
            db.StudentLCs.Remove(studentLC);
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
