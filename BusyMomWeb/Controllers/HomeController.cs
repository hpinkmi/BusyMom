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
            m.UserName = "User";
            m.Password = "Password";
            return View(m);
        }
        [HttpPost]
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
        [HttpGet]
        public ActionResult Register()
        {
            try
            {
                RegistrationModel Rm = new RegistrationModel();
                Rm.LastName = "LastName";
                Rm.FirstName = "FirstName";
                Rm.Email = "Email";
                Rm.Phone = "Phone";
                Rm.UserName = "UserName";
                Rm.Password = "Password";
                Rm.PasswordAgain = "PasswordAgain";
                Rm.Message = "";
                return View(Rm);
            }
            catch (Exception ex)
            {
                //Logger.Log(ex);
                return View("Error", ex);
            }

        }

        [HttpPost]
        public ActionResult Register(RegistrationModel register)
        {
            
            
                using (ContextBLL ctx = new ContextBLL())
                {
                    UsersBLL user = ctx.UsersFindByEmail(register.Email);
                    if (user != null)
                    {
                        register.Message = $"The Email Address          '{register.Email}' already exists in the database";
                        return View(register);
                    }
                    UsersBLL users = ctx.UsersFindByUserName(register.UserName);
                    if (user != null)
                    {
                        register.Message = $"The UserName'{register.UserName} is already in use";
                        return View(register);
                    }
                    user = new UsersBLL();
                    user.LastName = register.LastName;
                    user.FirstName = register.FirstName;
                    user.Phone = register.Phone;
                    user.Email = register.Email;
                    user.UserName = register.UserName;
                    user.Salt = System.Web.Helpers.Crypto.
                        GenerateSalt(15);
                    user.Hash = System.Web.Helpers.Crypto.
                        HashPassword(register.Password + user.Salt);
                    

                    ctx.UserCreate(users);
                    Session["AUTHUsername"] = user.Email;
                    Session["AUTHRoles"] = "LoggedIn";
                    Session["AUTHTYPE"] = "HASHED";
                    return RedirectToAction("Index");
                }
            }
        }

   
}