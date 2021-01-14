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

        [AllowAnonymous]
        public ActionResult Test()
        {
            FormsAuthentication.SetAuthCookie("hemanth", false);
            return RedirectToAction("Index", "Product");
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (Authenticate(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Product");
                //return Json(new { Result = true });
            }
            return Json(new { Result = false });
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