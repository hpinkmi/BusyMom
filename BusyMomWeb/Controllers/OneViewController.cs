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
            List<SelectListItem> groups = new List<SelectListItem>();
 
                using (ContextBLL ctx = new ContextBLL())
                {
                    List<GroupsBLL> group = ctx.GroupsFindByUserID(0, 25,id);
                    foreach (GroupsBLL g in group)
                    {
                        SelectListItem i = new SelectListItem();
                        i.Text = g.GroupName;
                        i.Value = g.GroupID.ToString();
                        groups.Add(i);
                    }
                }
                return groups;
        }
        List<SelectListItem>RolesGetAll()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            using (ContextBLL ctx = new ContextBLL())
            {
                List<RoleBLL> role = ctx.RolesGetAll(0, 100);
                foreach (RoleBLL r in role)
                {
                    SelectListItem i = new SelectListItem();
                    i.Text = r.RoleName;
                    i.Value = r.RoleID.ToString();
                    roles.Add(i);
                }
            }
            return roles;
        }
            
        public ActionResult Create()
        {
            using (ContextBLL ctx = new ContextBLL())
                try               
                {
                        OneView Model = new OneView();
                    var user = ctx.UsersFindByUserName(User.Identity.Name);
                    
                    ViewBag.ListGroups = GroupsFindbyUserID(user.UserID);
                    ViewBag.ListRoles = RolesGetAll();
                        return View(Model);
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
          
                        return View(collection);
                    }

            
                    
                        string Salt = System.Web.Helpers.Crypto.GenerateSalt(MagicConstants.SaltSize);
                        string Hash = System.Web.Helpers.Crypto.
                            HashPassword("Password" + Salt);
                        int UserID = ctx.UserCreate(collection.LastName, collection.FirstName, collection.Email, collection.Phone, collection.UserName, Hash, Salt);
                    

                   
                    
                        int Group = ctx.UserGroupsCreate(UserID, collection.GroupID, collection.RoleID);
                        ViewBag.Groups = GroupsFindbyUserID                  (collection.GroupID);
   
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
