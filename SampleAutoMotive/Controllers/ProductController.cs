using Automotive.Business;
using Automotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAutoMotive.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductService oProductService = new ProductService();
            List<ProductModel> products = oProductService.GetAllProducts();
            return View(products);
        }


        public ActionResult Add()
        {
            return View();
        }


    }
}