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
            UsersBLL defUser = new UsersBLL();
            defUser.UserID = 0;
            return View(defUser);
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(UsersBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx= new ContextBLL())
                {
                    ctx.UserCreate(collection);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Exeception = ex;
                return View("Error");
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            UsersBLL User;
            try
            { 
                using (ContextBLL ctx = new ContextBLL())
                {
                    User = ctx.UserFindByID(id);
                    if (null == User)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
           catch(Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(User);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsersBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx= new ContextBLL())
                {
                    ctx.UserUpdateJust(id, collection.LastName, collection.FirstName,collection.Email,collection.Phone,collection.UserName,collection.Hash,collection.Salt);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            UsersBLL users;
            try
            {
                using (ContextBLL ctx= new ContextBLL())
                {
                    users = ctx.UserFindByID(id);
                    if(null==users)
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
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UsersBLL collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    return View(collection);
                }
                {
                    using (ContextBLL ctx=new ContextBLL())
                    {
                        ctx.UsersDelete(id);
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
