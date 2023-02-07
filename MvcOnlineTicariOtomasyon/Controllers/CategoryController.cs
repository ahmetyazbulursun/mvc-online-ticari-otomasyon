using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {

        Context db = new Context();

        // Index Page
        public ActionResult Index()
        {
            var values = db.Categories.OrderBy(x => x.CategoryName).ToList();
            return View(values);
        }

        // Add New Category
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete Category
        public ActionResult DeleteCategory(int id)
        {
            var value = db.Categories.Find(id);
            db.Categories.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Update Category
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            var values = db.Categories.Find(c.ID);

            values.CategoryName = c.CategoryName;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
