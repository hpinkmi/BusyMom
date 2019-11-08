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
            List<SelectListItem> proposedReturnValue = new List<SelectListItem>();
            List<GroupsBLL> groups = ctx.GroupsGetAll(0, 25);
            foreach (GroupsBLL g in groups)
            {
                SelectListItem i = new SelectListItem();

                i.Value = g.GroupID.ToString();
                i.Text = g.GroupName.ToString();
                //i.Text = u.FirstName.ToString();
                //i.Text = u.Email.ToString();
                //i.Text = u.Phone.ToString();
                //i.Text = u.UserName.ToString();
                proposedReturnValue.Add(i);
            }
            return proposedReturnValue;

        }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Create()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                //ViewBag.Users = UsersGetAll(ctx);
                //UsersBLL users = ctx.UserFindByID();
                OneView Model = new OneView();
                //if (users != null)
                //{
                //    //Model.UserID = users.UserID;
                //    Model.NewUserName = "";
                //}
                return View(Model);
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
                        //ViewBag.Users = UsersGetAll(ctx);
                        return View(collection);
                    }

                    if (!string.IsNullOrWhiteSpace(collection.NewUserName))
                    {
                        string Salt = System.Web.Helpers.Crypto.GenerateSalt(MagicConstants.SaltSize);
                        string Hash = System.Web.Helpers.Crypto.
                            HashPassword("Password" + Salt);
                        collection.UserID = ctx.UserCreate(collection.LastName, collection.FirstName, collection.Email, collection.Phone, collection.UserName, Hash, Salt);
                    }
                    
                    else
                    {
                        int GroupID = ctx.GroupsCreate( collection.GroupName);
                        ctx.GroupsCreate( collection.GroupName);
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
