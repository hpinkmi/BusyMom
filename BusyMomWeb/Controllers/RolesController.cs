using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;


namespace BusyMomWeb.Controllers
{
    
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            List<RoleBLL> items = null;
            using (ContextBLL ctx = new ContextBLL())
            {

                items = ctx.RolesGetAll(0, 100);
            }
            return View(items);
            
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            RoleBLL it = null;
            using (ContextBLL ctx = new ContextBLL())
            {

                it = ctx.RoleFindByID(id);
            }
            return View(it);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
                return View();
        }


        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(RoleBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx= new ContextBLL())
                {
                    ctx.RoleCreate(collection.RoleName);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error",ex);
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            RoleBLL Role;
            using (ContextBLL ctx = new ContextBLL())
            {
                {
                    Role = ctx.RoleFindByID(id);
                }
                return View(Role);
            }
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoleBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.RoleUpdateJust(collection);
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            RoleBLL Role;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    Role = ctx.RoleFindByID(id);
                    if (null== Role)
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
            return View(Role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RoleBLL collection)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(collection);
                }
                // TODO: Add delete logic here
                {
                    using (ContextBLL ctx = new ContextBLL())
                    {
                        ctx.RoleDelete(id);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
    }
}
