﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusyMomWeb.Models
{
    public class MustBeInRoleAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
         if (this.Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
             {
              base.OnAuthorization(filterContext);
             }
             else
             {
              string ReturnURL = filterContext.RequestContext.HttpContext.Request.Path.ToString();
              filterContext.Controller.TempData.Add("Message",
                        $"You must be in at least one of the following roles to access this resource:  {Roles}");
              filterContext.Controller.TempData.Add("ReturnURL", ReturnURL);
                 System.Web.Routing.RouteValueDictionary dict = new System.Web.Routing.RouteValueDictionary();
              dict.Add("Controller", "Home");
                 dict.Add("Action", "Login");
                 filterContext.Result = new RedirectToRouteResult(dict);
             }
        }
    }
}