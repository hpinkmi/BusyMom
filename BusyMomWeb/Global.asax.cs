using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Threading;
using System.Security.Principal;
using BusinessLogicLayer;
using BusyMomWeb.Models;
using Logger;

namespace BusyMomWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            string UserName = Session["AuthUserName"] as string;
            string Sessrole = Session["AuthRoles"] as string;
            string SessType = Session["AuthType"] as string;

            if (string.IsNullOrEmpty(UserName))
            {
                return;
            }

            GenericIdentity i = new GenericIdentity(UserName, Sessrole);
            if (Sessrole == null) { Sessrole = ""; }
            string[] roles = Sessrole.Split(',');
            GenericPrincipal p = new GenericPrincipal(i, roles);
            HttpContext.Current.User = p;


        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            if (ex is ThreadAbortException)
                return; // Redirects may cause this exception..
            Logger.Logger.Log(ex);
        }
    }
}
