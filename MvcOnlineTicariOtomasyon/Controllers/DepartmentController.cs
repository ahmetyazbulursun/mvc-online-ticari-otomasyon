using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {

        Context db = new Context();

        // Index Page
        public ActionResult Index()
        {
            var value = db.Departments.Where(x => x.Status == true).OrderBy(x => x.Name).ToList();
            return View(value);
        }

        // Add Department
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department p)
        {
            p.Status = true;

            db.Departments.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete Department
        public ActionResult DeleteDepartment(Department p)
        {
            var value = db.Departments.Find(p.ID);

            value.Status = false;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Update Department
        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            var value = db.Departments.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department p)
        {
            var value = db.Departments.Find(p.ID);

            value.Name = p.Name;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Department Details
        public ActionResult DepartmentDetails(int id)
        {
            var values = db.Personnels.Where(x => x.DepartmentID == id).OrderBy(x => x.Name).ToList();

            var department = db.Departments.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.DepartmentName = department.Name;

            return View(values);
        }

        // Personnels Belonging Sales
        public ActionResult PersonnelsBelongingSales(int id)
        {
            var value = db.SalesMovings.Where(x => x.PersonnelID == id).ToList();

            var personnel = db.Personnels.Where(x=>x.ID == id).FirstOrDefault();
            ViewBag.Personnel = personnel.Name + " " + personnel.Surname;

            return View(value);
        }


    }
}