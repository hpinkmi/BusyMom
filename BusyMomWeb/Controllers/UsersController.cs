using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusyMomWeb.Models;

namespace BusyMomWeb.Controllers
{
    public class UsersController : Controller
    {
        [MustBeLoggedIn]
        public ActionResult Index()
        {
            try
            {
                List<UsersBLL> items = null;
                using (ContextBLL ctx = new ContextBLL())
                {
                    items = ctx.UsersGetAll(0, 100);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error",ex);
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                UsersBLL it = null;
                using (ContextBLL ctx = new ContextBLL())
                {
                    it = ctx.UserFindByID(id);
                }
                return View(it);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            try
            {
                UsersBLL defUser = new UsersBLL();
                defUser.UserID = 0;
                return View(defUser);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
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
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.UserCreate(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
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
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
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
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.UserUpdateJust(id, collection.LastName, collection.FirstName, collection.Email, collection.Phone, collection.UserName, collection.Hash, collection.Salt);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            UsersBLL users;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    users = ctx.UserFindByID(id);
                    if (null == users)
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
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UsersBLL collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.UsersDelete(id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }
        public ActionResult Groups(int id)
        {
            try
            {
                List<GroupsBLL> items = null;
                using (ContextBLL ctx = new ContextBLL())
                {
                    items = ctx.GroupsGetAll( 0,100);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error",ex);
            }
        }
    }
    

        

}