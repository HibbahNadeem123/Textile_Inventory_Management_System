using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSDA.Models;

namespace ProjectSDA.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(string Search)
        {
            CustomerDBHandle dbhandle = new CustomerDBHandle();
            ModelState.Clear();
            if (Search == null)
                return View(dbhandle.GetCustomer());
            else
                return View(dbhandle.GetByCustomerName(Search));
        }

        //GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel cmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerDBHandle sdb = new CustomerDBHandle();
                    if (sdb.AddCustomer(cmodel))
                    {
                        ViewBag.Message = "Customers Details Added Successfully";
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerDBHandle sdb = new CustomerDBHandle();
            return View(sdb.GetCustomer().Find(cmodel => cmodel.CID == id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerModel cmodel)
        {
            try
            {
                // TODO: Add update logic here
                CustomerDBHandle sdb = new CustomerDBHandle();
                sdb.UpdateDetails(cmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerModel cmodel)
        {
            try
            {
                // TODO: Add delete logic here

                CustomerDBHandle sdb = new CustomerDBHandle();
                if (sdb.DeleteCustomer(id))
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
