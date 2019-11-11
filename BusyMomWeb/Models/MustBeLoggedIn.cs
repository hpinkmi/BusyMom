using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusyMomWeb.Models
{
    public class MustBeLoggedInAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                string ReturnURL = filterContext.RequestContext.HttpContext.Request.Path.ToString();
                filterContext.Controller.TempData.Add("Message", $"You Must Be Logged In");
                filterContext.Controller.TempData.Add("ReturnURL", ReturnURL);
                System.Web.Routing.RouteValueDictionary dict = new System.Web.Routing.RouteValueDictionary();
                dict.Add("Controller", "Home");
                dict.Add("Action", "Login");
                filterContext.Result = new RedirectToRouteResult(dict);
            }
        }   
    }
}