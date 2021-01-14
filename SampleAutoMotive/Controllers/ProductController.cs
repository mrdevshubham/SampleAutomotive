using Automotive.Business;
using Automotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleAutoMotive.Models;

namespace SampleAutoMotive.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SearchModel search = new SearchModel
            {
                currentIndex = 0,
                TotalRecordsPerPage = 100
            };
            ProductService oProductService = new ProductService();
            List<ProductModel> products = oProductService.GetAllProducts(search);
            return View(products);
        }

        public ActionResult All()
        {
            ProductService oProductService = new ProductService();
            List<ProductModel> products = oProductService.AvailableProducts();
            return View(products);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductModel product)
        {
            ProductService oPService = new ProductService();
            bool Result = oPService.AddProduct(product);
            if (Result)
                return Json(new { Result = Result, Message = "Customer has been added successfully." });
            else
                return Json(new { Result = Result, Message = "Some Technical Issue Occered." });
            
        }

        [HttpPost]
        public ActionResult List(DataTableRequest dTablerequest)
        {
            ProductService oPService = new ProductService();

            SearchModel searchModel = new SearchModel
            {
                currentIndex = dTablerequest.CurrentIndex,
                TotalRecordsPerPage = dTablerequest.length,
                searchItem = dTablerequest.search,
                OrderByColumn = dTablerequest.orderByColumnIndex,
                orderByCommand = dTablerequest.orderDirection
            };

            IEnumerable<ProductModel> products = oPService.GetAllProducts(searchModel);
            Int64 TotalCount = oPService.GetAllProductCount();

            DataTableResponse DtResponse = new DataTableResponse();
            DtResponse.draw = dTablerequest.draw;
            DtResponse.recordsTotal = TotalCount;
            DtResponse.recordsFiltered = TotalCount;
            DtResponse.data = products;

            return Json(DtResponse);
        }


    }
}