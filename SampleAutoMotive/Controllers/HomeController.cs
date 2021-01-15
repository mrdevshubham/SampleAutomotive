using SampleAutoMotive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SampleAutoMotive.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //[AllowAnonymous]
        //public ActionResult Test()
        //{
        //    FormsAuthentication.SetAuthCookie("hemanth", false);
        //    return RedirectToAction("Index", "Product");
        //}

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.username) || string.IsNullOrEmpty(userModel.password))
            {
                return RedirectToAction("Login");
            }
            if (Authenticate(userModel.username, userModel.password))
            {
                FormsAuthentication.SetAuthCookie(userModel.username, userModel.isRememberMe);
                return RedirectToAction("Index", "Product");
            }
            return RedirectToAction("Login");
        }

        private bool Authenticate(string username, string password)
        {
            if (username == "hemanth" && password == "123")
            {
                return true;
            }
            return false;
        }

    }
}