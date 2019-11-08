using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusyMomWeb.Models;
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
                    List<GroupsBLL> items = null;
                    using (ContextBLL ctx = new ContextBLL())
                    {
                        items = ctx.GroupsGetAll(0, 100);
                    }
                    return View(items);
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

            // GET: Groups/Create
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
            [HttpPost]
            public ActionResult Create(GroupsBLL collection)
            {
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
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    Logger.Logger.Log(ex);
                    return View("Error", ex);
                }
            }

            // GET: Groups/Edit/5
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
                    return View("Error",ex);
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
                    return View("Error",ex);
                }
            }
        }
    }
