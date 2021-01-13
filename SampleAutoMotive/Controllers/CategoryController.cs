using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Automotive.Business;
using Automotive.Model;

namespace SampleAutoMotive.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GetAll()
        {
            List<ProductCategory> categories = (new ProductCatogoryService()).GetAllCategory();
            return Json(categories);
        }

    }
}