using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;


namespace BusyMomWeb.Controllers
{
    
    public class LocationsController : Controller
    {
        // GET: Locations
        public ActionResult Index()
        {
            List<LocationsBLL> items = null;
            using (ContextBLL ctx = new ContextBLL())
            {

                items = ctx.LocationGetAll(0, 100);
            }
            return View(items);
        }

        // GET: Locations/Details/5
        public ActionResult Details(int id)
        {
            LocationsBLL it = null;
            using (ContextBLL ctx = new ContextBLL())
            {
                it = ctx.LocationFindbyID(id);
            }
            return View(it);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            LocationsBLL defLocations = new LocationsBLL();
            defLocations.LocationID = 0;
            return View(defLocations);
        }

        // POST: Locations/Create
        [HttpPost]
        public ActionResult Create(LocationsBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exection = Ex;
                return View("Error");
            }
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int id)
        {
            LocationsBLL locations;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    locations = ctx.LocationFindbyID(id);
                    if (null == locations)
                    {
                        return View("ItemNotFound");
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(locations);
        }

        // POST: Locations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LocationsBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL()) 
                {
                    ctx.LocationsUpdateJust(collection);
                }
                return RedirectToAction("Index");
            }  
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View();
            }
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int id)
        {
            LocationsBLL locations;
            try
            {
                using (ContextBLL ctx= new ContextBLL())
                {
                    locations = ctx.LocationFindbyID(id);
                    if (null==locations)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LocationsBLL collection)
        {
            try
            { if(ModelState.IsValid)
                {
                    return View(collection);
                }
                {
                    using (ContextBLL ctx = new ContextBLL())
                    {
                        ctx.LocationDelete(id);
                    }
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }
    }
}
