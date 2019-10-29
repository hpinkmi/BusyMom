using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;


namespace BusyMomWeb.Controllers
{
   
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<UsersBLL> items = null;
            using (ContextBLL ctx = new ContextBLL())
            {
                items = ctx.UsersGetAll(0,100);
            }
            return View(items);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            UsersBLL it = null;
            using (ContextBLL ctx = new ContextBLL())
            {  
             it = ctx.UserFindByID(id);
            }
            return View(it);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            UsersBLL User;
                using (ContextBLL ctx = new ContextBLL())
                {
                    User = ctx.UserFindByID(id);
                }
                return View("ItemNotFound");
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsersBLL collection)
        {
            try
            {
                using (ContextBLL ctx= new ContextBLL())
                {
                    ctx.UserUpdateJust(id, collection.LastName, collection.FirstName,collection.Email,collection.Phone,collection.UserName,collection.Hash,collection.Salt);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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
