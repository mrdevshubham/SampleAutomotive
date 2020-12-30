using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleAutoMotive.Data;
using SampleAutoMotive.Model;

namespace SampleAutoMotive.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserDto oUserData = new UserDto();
             List<UserModel> models = oUserData.GetUsers();
            return View(models);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserDto oUserData = new UserDto();
                oUserData.AddUser(model);

                return RedirectToAction("Index");
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            UserDto oUserData = new UserDto();
            UserModel user = oUserData.GetSingleUser(id);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            UserDto oUserData = new UserDto();
            oUserData.Update(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            UserDto oUserData = new UserDto();
            oUserData.Delete(id);
            return RedirectToAction("Index");
        }

    }
}