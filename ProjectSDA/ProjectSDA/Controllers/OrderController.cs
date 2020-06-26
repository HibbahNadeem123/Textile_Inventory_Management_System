using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSDA.Models;

namespace ProjectSDA.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(string Search)
        {
            OrderHandler dbhandle = new OrderHandler();
            ModelState.Clear();
            if (Search == null)
                return View(dbhandle.GetOrder());
            else
                return View(dbhandle.GetByID(Search));
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrderHandler sdb = new OrderHandler();
                    if (sdb.AddOrder(smodel))
                    {
                        ViewBag.Message = "Order Details Added Successfully";
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            OrderHandler sdb = new OrderHandler();
            return View(sdb.GetOrder().Find(smodel => smodel.Id == id));
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order smodel)
        {
            try
            {
                OrderHandler sdb = new OrderHandler();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                OrderHandler sdb = new OrderHandler();
                if (sdb.DeleteOrder(id))
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
    }
}
