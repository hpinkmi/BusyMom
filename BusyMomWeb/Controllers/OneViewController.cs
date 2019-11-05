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
        
            List<SelectListItem>UsersGetAll(ContextBLL ctx)
            {
                List<SelectListItem> proposedReturnValue = new List<SelectListItem>();
                List<UsersBLL> users = ctx.UsersGetAll(0, 25);
                foreach (UsersBLL u in users)
                {
                    SelectListItem i = new SelectListItem();

                    i.Value = u.UserID.ToString();
                    i.Text = u.LastName.ToString();
                    i.Text = u.FirstName.ToString();
                    i.Text = u.Email.ToString();
                    i.Text = u.Phone.ToString();
                    i.Text = u.UserName.ToString();
                    proposedReturnValue.Add(i);
                }
                return proposedReturnValue;

            }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Create ()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                ViewBag.Users = UsersGetAll(ctx);
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
                        ViewBag.Users = UsersGetAll(ctx);
                        return View(collection);
                    }

                    if (!string.IsNullOrWhiteSpace(collection.NewUserName))
                    {
                        string Salt = System.Web.Helpers.Crypto.GenerateSalt(MagicConstants.SaltSize);
                        string Hash = System.Web.Helpers.Crypto.
                            HashPassword("Password" + Salt);
                        collection.UserID = ctx.UserCreate(collection.LastName, collection.FirstName, collection.Email, collection.Phone, collection.UserName,Hash,Salt);
                    }9
                    else
                    {
                        int GroupID = ctx.GroupsCreate(collection.GroupID, collection.GroupName);
                        ctx.GroupsCreate(GroupID, collection.GroupName);
                    }
                }
                return RedirectToAction("Index", "OneView");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error",ex);
            }

        }

    }
}