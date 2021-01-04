using Automotive.Business;
using Automotive.Model;
using SampleAutoMotive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAutoMotive.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult List()
        {
            SearchModel searchModele = new SearchModel
            {
                currentIndex = 0,
                TotalRecordsPerPage = 100
            };
            CustomerService ocustomerService = new CustomerService();
            IEnumerable<CustomerModel> customers = ocustomerService.GetAllCustomers(searchModele);
            return View(customers);
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List(DataTableRequest dTablerequest)
        {
            CustomerService ocustomerService = new CustomerService();

            SearchModel searchModel = new SearchModel
            {
                currentIndex = dTablerequest.CurrentIndex,
                TotalRecordsPerPage = dTablerequest.length,
                searchItem = dTablerequest.search,
                OrderByColumn = dTablerequest.orderByColumnIndex,
                orderByCommand = dTablerequest.orderDirection
            };

            IEnumerable<CustomerModel> customers = ocustomerService.GetAllCustomers(searchModel);
            Int64 TotalCount = ocustomerService.GetAllCustomersCount();

            DataTableResponse DtResponse = new DataTableResponse();
            DtResponse.draw = dTablerequest.draw;
            DtResponse.recordsTotal = TotalCount;
            DtResponse.recordsFiltered = TotalCount;
            DtResponse.data = customers;

            return Json(DtResponse);
        }

        [HttpPost]
        public JsonResult Delete(int customerId)
        {
            CustomerService ocustomerService = new CustomerService();
            bool Result = ocustomerService.DeleteCustomer(customerId);
            return Json(new { Result = Result });
        }
    }
}