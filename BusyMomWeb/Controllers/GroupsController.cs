using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusyMomWeb.Models;
using static BusyMomWeb.Models.MustBeLoggedInAttribute;
using Logger;
using DataAccessLayer;
using System.Web.Security;

namespace BusyMomWeb.Controllers

{
    [MustBeLoggedIn]
    public class GroupsController : Controller
    {

        // GET: Groups
        public ActionResult Index()
        {
            try
            {
                List<GroupsBLL> groups = null;
                using (ContextBLL ctx = new ContextBLL())
                {
                    UsersBLL user = ctx.UsersFindByUserName(User.Identity.Name);

                    groups = ctx.GroupsFindByUserID(0,100,user.UserID); 
                }
                return View(groups);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Groups/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                GroupsBLL it = null;
                using (ContextBLL ctx = new ContextBLL())
                {
                    it = ctx.GroupsFindByID(id);
                }
                return View(it);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);

            }
        }

        
        public ActionResult Create()
        {
            try
            {

                GroupsBLL defGroups = new GroupsBLL();
                defGroups.GroupID = 0;
                return View(defGroups);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // POST: Groups/Create
        [MustBeInRole(Roles=(MagicConstants.ParentAboveName))]
        [HttpPost]
        public ActionResult Create(GroupsBLL collection )
        {
            //GroupsBLL groups;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    
                    ctx.GroupsCreate(collection);
                }
                return RedirectToAction ("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Groups/Edit/5
        [MustBeInRole(Roles = MagicConstants.ParentAboveName)]
        public ActionResult Edit(int id)
        {
            GroupsBLL groups;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {

                    groups = ctx.GroupsFindByID(id);
                    if (null == groups)
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
            return View(groups);
        }

        // POST: Groups/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GroupsBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.GroupsUpdateJust(collection.GroupID, collection.GroupName);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Groups/Delete/5
        [MustBeInRole(Roles = MagicConstants.ParentAboveName)]
        public ActionResult Delete(int id)
        {
            GroupsBLL groups;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    groups = ctx.GroupsFindByID(id);
                    if (null == groups)
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
            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GroupsBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                {
                    using (ContextBLL ctx = new ContextBLL())
                    {
                        ctx.GroupsDelete(id);
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
        public ActionResult SelectGroup(int id)
        {
            try
            {
                List<GroupsBLL> groups = null;
                using (ContextBLL ctx = new ContextBLL())
                {
                    UsersBLL user = ctx.UsersFindByUserName(User.Identity.Name);

                    groups = ctx.GroupsFindByUserID(0, 100, user.UserID);
                    var group = (groups
                        .Where(x => x.GroupID == id)).FirstOrDefault();
                    Session["AuthRoles"] = group.RoleName;
                     Session["AuthType"] = (Session["AuthType"].ToString().Split(':')[0])+ ":" +group.GroupID.ToString();
                }
                return RedirectToRoute(new { Controller = "Activities"});
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }
        public ActionResult Activity(int id)
        {
            try
            {
                List<ActivitiesBLL> items = null;
                using (ContextBLL ctx = new ContextBLL())
                {
                    items = ctx.ActivitiesGetAllbyGroupID(0, 100, id);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }
    }
}

