using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSDA.Models;

namespace ProjectSDA.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string Search)
        {
            ProductHandler dbhandle = new ProductHandler();
            ModelState.Clear();
            if (Search == null)
                return View(dbhandle.GetProduct());
            else
                return View(dbhandle.GetByName(Search));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductHandler sdb = new ProductHandler();
                    if (sdb.AddProduct(smodel))
                    {
                        ViewBag.Message = "Product Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductHandler sdb = new ProductHandler();
            return View(sdb.GetProduct().Find(smodel => smodel.Id == id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product smodel)
        {
            try
            {
                ProductHandler sdb = new ProductHandler();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ProductHandler sdb = new ProductHandler();
                if (sdb.DeleteProduct(id))
                {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Product/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
