using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace BusyMomWeb.Controllers
{
    public class UserActivitiesController : Controller
    {
        // GET: UserActivities
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserActivities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserActivities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserActivities/Create
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

        // GET: UserActivities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserActivities/Edit/5
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

        // GET: UserActivities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserActivities/Delete/5
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
