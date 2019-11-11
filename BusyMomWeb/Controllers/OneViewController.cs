using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusyMomWeb.Models;
using Logger;
using static BusyMomWeb.Models.MustBeLoggedInAttribute;
using System.Web.Security;
using DataAccessLayer;

namespace BusyMomWeb.Controllers
{
    [MustBeInRole(Roles = MagicConstants.ParentAboveName)]
    public class OneViewController : Controller
    {
        // GET: OneView

        List<SelectListItem> GroupsFindbyUserID(int id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            ViewBag.ListItems = items;

                using (ContextBLL ctx = new ContextBLL())
                {
                    List<GroupsBLL> groups = ctx.GroupsFindByUserID(0, 25,id);
                    foreach (GroupsBLL g in groups)
                    {
                        SelectListItem i = new SelectListItem();
                        i.Text = g.GroupName;
                        i.Value = g.GroupID.ToString();
                        items.Add(i);
                    }
                }
                return items;
        }
            
        public ActionResult Create()
        {
            using (ContextBLL ctx = new ContextBLL())
                try               
                {
                        OneView Model = new OneView();
                    var user = ctx.UsersFindByUserName(User.Identity.Name);
                    
                    ViewBag.ListItems = GroupsFindbyUserID(user.UserID);
                        return View(Model);
                }               
                catch (Exception ex)
                {
                    Logger.Logger.Log(ex);
                    return View("Error", ex);
                }
        }

        [HttpPost]
        public ActionResult Create(OneView collection, int id)
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
                        int Group = ctx.GroupsCreate(collection.GroupName);
                        ctx.GroupsCreate(collection.GroupName);
                        ViewBag.items = GroupsFindbyUserID(id);
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
