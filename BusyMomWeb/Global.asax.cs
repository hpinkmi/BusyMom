using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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
            string Sessrole = Session["Authroles"] as string;
            if (string.IsNullOrEmpty(UserName))
            {
                return;
            }
                
                    GenericIdentity i = new GenericIdentity(UserName, "MyCustomType");
                    if (Sessrole == null) { Sessrole = ""; }
                    string[] roles = Sessrole.Split(',');
                    GenericPrincipal p = new GenericPrincipal(i, roles);
                    HttpContext.Current.User = p;
                
            
        }
    }
}
