using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Automotive.Data;
using Automotive.Model;

namespace SampleAutoMotive.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            BrandData bdata = new BrandData();
            IEnumerable<BrandModel> brands = bdata.GetAll();
            return View(brands);
        }

        [HttpPost]
        public JsonResult Delete(int brandId)
        {
            BrandData bdata = new BrandData();
            bool Result = bdata.Delete(brandId);
            return Json(new { Result = Result });
        }
    }
}