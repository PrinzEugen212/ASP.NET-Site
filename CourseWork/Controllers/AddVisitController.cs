using CourseWork.Models;
using CourseWork.Models.Contexts;
using CourseWork.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.Controllers
{
    public class AddVisitController : Controller
    {
        private VetClinicDBContext db = new VetClinicDBContext();

        // GET: AddVisit
        public ActionResult Index()
        {
            return View(db.Employees./*Where(e => !string.IsNullOrEmpty(e.Speciality)).*/ToList());
        }

        [HttpPost]
        public ActionResult Index(int employeeID)
        {
            ViewBag.EmployeeID = employeeID;
            return View("ChooseHelper", db.Employees.Where(e => e.CanHelp && e.Id != employeeID).ToList());
        }

        [HttpPost]
        public ActionResult ChooseHelper(int employeeID, int helperID)
        {
            List<Employee> employess = db.Employees.Where(e => e.CanHelp).ToList();
            ViewBag.EmployeeID = employeeID;
            ViewBag.HelperID = helperID;
            return View("ChooseDate");
        }

        [HttpPost]
        public ActionResult ChooseDate(int employeeID, int helperID, DateTime date)
        {
            ViewBag.EmployeeID = employeeID;
            ViewBag.HelperID = helperID;
            ViewData["Date"] = date;
            List<Client> clients = db.Clients.ToList();
            return View("ChooseClient", clients);
        }

        [HttpPost]
        public ActionResult ChooseClient(int employeeID, int helperID, int clientID, DateTime date)
        {
            ViewBag.EmployeeID = employeeID;
            ViewBag.HelperID = helperID;
            ViewBag.ClientID = clientID;
            ViewData["Date"] = date;
            return View("ChooseAnimal");
        }

        [HttpPost]
        public ActionResult ChooseAnimal(int employeeID, int helperID, int clientID, DateTime date)
        {
            List<Animal> animals = db.Animals.Where(a => a.ClientId == clientID).ToList();
            ViewBag.EmployeeID = employeeID;
            ViewBag.HelperID = helperID;
            ViewBag.ClientID = clientID;
            ViewData["Date"] = date;
            return View("ChooseAnimal", animals);
        }

        [HttpPost]
        public ActionResult FillVisit(int employeeID, int helperID, int clientID, int animalID, DateTime date)
        {
            ViewBag.EmployeeID = employeeID;
            ViewBag.HelperID = helperID;
            ViewBag.ClientID = clientID;
            ViewBag.AnimalID = animalID;
            ViewData["Date"] = date;
            return View("FillVisit");
        }

        [HttpPost]
        public ActionResult ChooseProcedures(int employeeID, int helperID, int clientID, int animalID, string assignment, string diagnosis, DateTime date)
        {
            List<Procedure> procedures = db.Procedures.ToList();
            ViewBag.EmployeeID = employeeID;
            ViewBag.HelperID = helperID;
            ViewBag.ClientID = clientID;
            ViewBag.AnimalID = animalID;
            ViewData["Assignment"] = assignment;
            ViewData["Diagnosis"] = diagnosis;
            ViewData["Date"] = date;
            return View("ChooseProcedures", procedures);
        }

        [HttpPost]
        public ActionResult Confirm(int employeeID, int helperID, int clientID, int animalID, string assignment, string diagnosis, DateTime date, ProceduresCheckViewModel[] proceduresChecked)
        {
            int[] ids = proceduresChecked.Select(p => p.ProcedureID).ToArray();
            Procedure[] procedures = db.Procedures.Where(p => ids.Contains(p.Id)).ToArray();
            float totalCost = 0;
            foreach (var item in procedures)
            {
                totalCost += item.Cost;
            }

            Visit visit = new Visit(animalID, employeeID, helperID, clientID, date, diagnosis, assignment, totalCost);
            visit.Procedures = procedures;
            db.Entry(visit).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index", "Visits");
        }
    }
}