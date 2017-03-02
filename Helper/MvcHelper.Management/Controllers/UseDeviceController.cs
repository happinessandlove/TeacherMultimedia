using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHelper.Management.Controllers
{
    public class UseDeviceController : Controller
    {
        // GET: UseDevice
        public ActionResult Index()
        {
            return View();
        }

        // GET: UseDevice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UseDevice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UseDevice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UseDevice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UseDevice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UseDevice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UseDevice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
