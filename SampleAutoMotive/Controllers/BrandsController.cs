using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Automotive.Business;
using Automotive.Model;

namespace SampleAutoMotive.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            BrandService oBrandService = new BrandService();
            IEnumerable<BrandModel> brands = oBrandService.GetAllBrands();
            return View(brands);
        }

        [HttpPost]
        public JsonResult Delete(int brandId)
        {
            BrandService oBrandService = new BrandService();
            bool Result = oBrandService.DeleteBrand(brandId);
            return Json(new { Result = Result });
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            List<BrandModel> brands = (new BrandService()).GetAllBrands();
            return Json(brands);
        }
    }
}