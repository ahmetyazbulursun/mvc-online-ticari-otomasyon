using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {

        Context db = new Context();

        // Index Page
        public ActionResult Index()
        {
            var values = db.Products.Where(x => x.Status == true).OrderBy(x => x.Name).ToList();
            return View(values);
        }

        // Add Product
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> categories = (from x in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.ID.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Products p)
        {
            p.Status = true;

            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete Product
        public ActionResult DeleteProduct(Products p)
        {
            var value = db.Products.Find(p.ID);

            value.Status = false;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Update Product
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = db.Products.Find(id);

            List<SelectListItem> categories = (from x in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.ID.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Products p)
        {
            var value = db.Products.Find(p.ID);

            value.Name = p.Name;
            value.Brand = p.Brand;
            value.Stock = p.Stock;
            value.PurchasePrice = p.PurchasePrice;
            value.SalePrice = p.SalePrice;
            value.Image = p.Image;
            value.CategoryID = p.CategoryID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}