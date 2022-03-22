using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseWork.Models;
using CourseWork.Models.Contexts;

namespace CourseWork.Controllers
{
    public class VisitsController : Controller
    {
        private VetClinicDBContext db = new VetClinicDBContext();

        // GET: Visits
        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Animal).Include(v => v.Client).Include(v => v.Employee).Include(v => v.HelperEmployee);
            return View(visits.ToList());
        }

        // GET: Visits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Include(a => a.Client).Include(a => a.Animal)
                .Include(a => a.Employee).Include(a => a.HelperEmployee).FirstOrDefault(a => a.Id == id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: Visits/Create
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name");
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FullName");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.HelperEmployeeId = new SelectList(db.Employees, "Id", "Name");
            return View();
        }

        // POST: Visits/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AnimalId,EmployeeId,HelperEmployeeId,ClientId,Date,Diagnosis,Assignment,TotalCost")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", visit.AnimalId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FullName", visit.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", visit.EmployeeId);
            ViewBag.HelperEmployeeId = new SelectList(db.Employees, "Id", "Name", visit.HelperEmployeeId);
            return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", visit.AnimalId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FullName", visit.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", visit.EmployeeId);
            ViewBag.HelperEmployeeId = new SelectList(db.Employees, "Id", "Name", visit.HelperEmployeeId);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AnimalId,EmployeeId,HelperEmployeeId,ClientId,Date,Diagnosis,Assignment,TotalCost")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", visit.AnimalId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FullName", visit.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", visit.EmployeeId);
            ViewBag.HelperEmployeeId = new SelectList(db.Employees, "Id", "Name", visit.HelperEmployeeId);
            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Include(a => a.Client).Include(a => a.Animal)
                .Include(a => a.Employee).Include(a => a.HelperEmployee).FirstOrDefault(a => a.Id == id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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
