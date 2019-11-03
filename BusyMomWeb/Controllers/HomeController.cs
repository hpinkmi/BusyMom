using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusyMomWeb.Models;
using System.ComponentModel.DataAnnotations;
using Logger;

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
        public ActionResult Logout()
        {
            Session.Remove("AuthUserName");
            Session.Remove("AuthRoles");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            LoginModel m = new LoginModel();
            m.Message = TempData["Message"]?.ToString() ?? "";
            m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            m.UserName = "";
            m.Password = "";
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
                    return View(info);
                }
                string actual = user.Hash;
                string potential = info.Password;
                string ValidationType = $"ClearText:({user.UserName})";
                bool validateduser = actual == potential;
                if (validateduser)
                {
                    potential = info.Password + user.Salt;
                    try
                    {
                        validateduser = System.Web.Helpers.Crypto.VerifyHashedPassword(actual, potential);
                        ValidationType = $"HASHED;({user.UserName})";
                    }
                    catch (Exception)
                    {
                        validateduser = false;
                    }
                }
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
                Rm.LastName = "";
                Rm.FirstName = "";
                Rm.Email = "";
                Rm.Phone = "";
                Rm.UserName = "";
                Rm.Password = "";
                Rm.PasswordAgain = "";
                Rm.Message = "";
                return View(Rm);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        

        [HttpPost]
        public ActionResult Register(RegistrationModel register)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(register);
                }

                using (ContextBLL ctx = new ContextBLL())
                {
                    UsersBLL user = ctx.UsersFindByEmail(register.Email);
                    if (user != null)
                    {
                        register.Message = $"The Email Address'{register.Email}' already exists in the database";
                        return View(register);
                    }
                    UsersBLL users = ctx.UsersFindByUserName(register.UserName);
                    if (users != null)
                    {
                        register.Message = $"The UserName'{register.UserName} is already in use";
                        return View(register);
                    }
                    string Salt = System.Web.Helpers.Crypto.GenerateSalt(MagicConstants.SaltSize);
                    string Hash = System.Web.Helpers.Crypto.
                        HashPassword(register.Password + Salt);
                    users = new UsersBLL();

                    users.LastName = register.LastName;
                    users.FirstName = register.FirstName;
                    users.Phone = register.Phone;
                    users.Email = register.Email;
                    users.UserName = register.UserName;
                    //users.Salt = System.Web.Helpers.Crypto.
                    //    GenerateSalt(Constants.SaltLength);
                    //user.Hash = System.Web.Helpers.Crypto.
                    //    HashPassword(register.Password + user.Salt);
                    
                    
                    ctx.UserCreate(users);
                    //users = ctx.UsersFindByUserName(register.UserName);
                    Session["AUTHUsername"] = user.UserName;
                    Session["AUTHRoles"] = "LoggedIn";
                    Session["AUTHTYPE"] = "HASHED";
                    return RedirectToAction("Index");
                }
              
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error",ex);
            }           
        }
    }
}

