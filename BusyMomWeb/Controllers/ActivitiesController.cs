using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusyMomWeb.Models;
using Logger;

namespace BusyMomWeb.Controllers
{
    [MustBeLoggedIn]
    public class ActivitiesController : Controller
    {
        List<SelectListItem> LocationGetAll()
        {
            List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
            using (ContextBLL ctx = new ContextBLL())
            {
                List<LocationsBLL> locations = ctx.LocationGetAll(0, 100);
                foreach (LocationsBLL l in locations)
                {
                    SelectListItem i = new SelectListItem();
                    i.Value = l.LocationID.ToString();
                    ProposedReturnValue.Add(i);
                }
                return ProposedReturnValue;
            }
        }
        // GET: Activities
        public ActionResult Index()
        {
            try
            {
                List<ActivitiesBLL> items = null;
                using (ContextBLL ctx = new ContextBLL())
                {

                    items = ctx.ActivitiesGetAll(0, 100);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }

        }
        // GET: Activities/Details/5
        public ActionResult Details(int id)
        {
            ActivitiesBLL activities;
            try
            {
                using (ContextBLL ctx = new ContextBLL())

                {
                    activities = ctx.ActivitiesFindbyID(id);
                    if (null == activities)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error",ex);
            }
            return View(activities);
        }

        // GET: Activities/Create
        public ActionResult Create()

        {
            try
            {
                ActivitiesBLL defActivities = new ActivitiesBLL();
                defActivities.ActivityID = 0;
                ViewBag.Locations = LocationGetAll();
                return View(defActivities);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // POST: Activities/Create
        [HttpPost]
        public ActionResult Create(ActivitiesBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())

                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int id)
        {
            ActivitiesBLL activities;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    activities = ctx.ActivitiesFindbyID(id);
                    if (null == User)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
            ViewBag.Locations = LocationGetAll();
            return View(activities);
        }

        // POST: Activities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ActivitiesBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.ActivitiesUpdateJust(collection);
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int id)
        {
            ActivitiesBLL activities;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    activities = ctx.ActivitiesFindbyID(id);
                    if (null == activities)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error",ex);
            }
            return View(activities);
        }

        // POST: Activities/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ActivitiesBLL collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View(collection);
                }
                {
                    using (ContextBLL ctx = new ContextBLL())
                    {
                        ctx.ActivitiesDelete(id);
                    }
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }
    }
}