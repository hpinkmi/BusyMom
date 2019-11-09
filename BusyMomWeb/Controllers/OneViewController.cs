using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusyMomWeb.Models;
using Logger;

namespace BusyMomWeb.Controllers
{
    public class OneViewController : Controller
    {
        // GET: OneView

        List<SelectListItem> GroupsGetAll(ContextBLL ctx)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            ViewBag.ListItems = items;
            List<GroupsBLL> groups = ctx.GroupsGetAll(0, 25);
            foreach (GroupsBLL g in groups)
            {
                SelectListItem i = new SelectListItem();

                i.Value = g.GroupID.ToString();
                i.Text = g.GroupName;
                items.Add(i);
            }
            return items;

        }


        public ActionResult Create()
        {
            using (ContextBLL ctx = new ContextBLL())
                try
                {
                    {
                        OneView Model = new OneView();
                        return View(Model);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Logger.Log(ex);
                    return View("Error", ex);
                }
        }

        [HttpPost]
        public ActionResult Create(OneView collection)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    if (!ModelState.IsValid)
                    {
                        //ViewBag.Groups = GroupsGetAll(ctx);
                        return View(collection);
                    }

                    if (!ModelState.IsValid)
                    {
                        string Salt = System.Web.Helpers.Crypto.GenerateSalt(MagicConstants.SaltSize);
                        string Hash = System.Web.Helpers.Crypto.
                            HashPassword("Password" + Salt);
                        collection.UserID = ctx.UserCreate(collection.LastName, collection.FirstName, collection.Email, collection.Phone, collection.UserName, Hash, Salt);
                    }
                    
                    else
                    {
                        int GroupID = ctx.GroupsCreate(collection.GroupName);
                        ctx.GroupsCreate(collection.GroupName);
                        ViewBag.items = GroupsGetAll(ctx);
                    }
                }
                return RedirectToAction("Index", "Users");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }

        }

    }

}
