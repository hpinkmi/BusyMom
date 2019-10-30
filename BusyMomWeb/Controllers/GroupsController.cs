﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;


namespace BusyMomWeb.Controllers
{
    
    public class GroupsController : Controller
        
    {
        // GET: Groups
        public ActionResult Index()
        {
            List<GroupsBLL> items = null;
            using (ContextBLL ctx = new ContextBLL())
            { 
                items = ctx.GroupsGetAll(0, 100);
            }
            return View(items);
        }

        // GET: Groups/Details/5
        public ActionResult Details(int id)
        {
            GroupsBLL it = null;
            using(ContextBLL ctx = new ContextBLL())
            {
                it = ctx.GroupsFindByID(id);
            }
            return View(it);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            
                GroupsBLL defGroups = new GroupsBLL();
                defGroups.GroupID = 0;
                return View(defGroups);
            
        }

        // POST: Groups/Create
        [HttpPost]
        public ActionResult Create(GroupsBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.GroupsCreate(collection.GroupID,collection.GroupName);
                }
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
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
                ViewBag.Exception = ex;
                return View("Error");
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
                {
                    using (ContextBLL ctx = new ContextBLL())
                    {
                        ctx.GroupsUpdateJust(collection.GroupID,collection.GroupName);
                    }
                }
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
                    if (null==groups)
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
            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(collection);
                }
                {
                    using (ContextBLL ctx= new ContextBLL())
                    {
                        ctx.GroupsDelete(id);
                    }
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }
    }
}
