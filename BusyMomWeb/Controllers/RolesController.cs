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
            try
            {
                List<RoleBLL> items = null;
                using (ContextBLL ctx = new ContextBLL())
                {

                    items = ctx.RolesGetAll(0, 100);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                RoleBLL it = null;
                using (ContextBLL ctx = new ContextBLL())
                {

                    it = ctx.RoleFindByID(id);
                }
                return View(it);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
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
                Logger.Logger.Log(ex);
                return View("Error",ex);
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            try
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
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
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
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error",ex);
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
                Logger.Logger.Log(ex);
                return View("Error",ex);
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
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error",ex);
            }
        }
    }
}
