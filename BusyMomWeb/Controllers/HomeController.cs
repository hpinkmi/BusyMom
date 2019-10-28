using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusyMomWeb.Models;

namespace BusyMomWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       [HttpGet]
       public ActionResult Login()
        {
            LoginModel m = new LoginModel();
            m.Message = TempData["Message"]?.ToString() ?? "";
            m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            m.UserName = "genericuser";
            m.Password = "genericpassword";
            return View(m);
        }
        [HttpGet]
        public ActionResult Login(LoginModel info)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                UsersBLL user = ctx.UsersFindByUserName(info.UserName);
                if (user == null)
                {
                    info.Message = $"The UserName'{info.UserName}' does not exist in the database";
                }
                string actual = user.Hash;
                string potential = info.Password;
                bool validateduser = potential == actual;
                if (validateduser)
                {
                    Session["AuthUserName"] = user.UserName;
                    Session["AuthRoles"] = "LoggedIn";
                    return Redirect(info.ReturnURL);
                }
                info.Message = "The password was incorrect";
                return View(info);
            }
        }
        [HttpGet] public ActionResult Register()
        {
            return View();
        }
        [HttpPost] public ActionResult Register(RegistrationModel newuser)
        {
            return Redirect("URL of a Welcome Page");
        }

    }
}