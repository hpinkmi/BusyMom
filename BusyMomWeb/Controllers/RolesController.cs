using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using BusinessLogicLayer;

namespace BusyMomWeb.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            List<RoleBLL> items = null;
            using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
            {
                items = ctx.RoleGetAll(0, 100);
            }
            return View();
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            RoleDAL it = null;
            using (DataAccessLayer.ContextDAL ctx = new DataAccessLayer.ContextDAL())
            {
                ctx.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=BusyMom;Integrated Security=True";
                it = ctx.RoleFindbyID(id);
            }
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
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

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            RoleDAL item;
            using (ContextDAL ctx= new ContextDAL())
            {
                ctx.ConnectionString = @"Data Source =.\sqlexpress; Initial Catalog = BusyMom; Integrated Security = True";
                item = ctx.RoleFindbyID(id);
            }
            return View();
        }

        // POST: Roles/Edit/5
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

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles/Delete/5
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
