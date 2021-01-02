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
            CustomerService ocustomerService = new CustomerService();
            IEnumerable<CustomerModel> customers = ocustomerService.GetAllCustomers(0,100);
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
            IEnumerable<CustomerModel> customers = ocustomerService.GetAllCustomers(dTablerequest.CurrentIndex, dTablerequest.length);
            Int64 TotalCount = ocustomerService.GetAllCustomersCount();

            DataTableResponse DtResponse = new DataTableResponse();
            DtResponse.draw = dTablerequest.draw;
            DtResponse.recordsTotal = TotalCount;
            DtResponse.recordsFiltered = TotalCount;
            DtResponse.data = customers;

            //var Result = new
            //{
            //    draw = 1,
            //    recordsTotal = 57,
            //    recordsFiltered = 57,
            //    data = new[] 
            //    {
            //        new string[] {"Shubham","Jain","9292929292","a@bb.com","Hi"},
            //        new string[] {"Ketan","Jain","6565656565","k@bb.com","Bye"}
            //    }
            //};
            //var Result = new
            //{
            //    draw = 1,
            //    recordsTotal = 57,
            //    recordsFiltered = 57,
            //    data = new[]
            //    {
            //        new 
            //        {
            //            firstName = "Shubham",
            //            lastName = "Jain",
            //            email = "shub@gmail.com",
            //            phone = "9494959697"

            //        },
            //        new
            //        {
            //            firstName = "Ketan",
            //            lastName = "Jain",
            //            email = "ketu@gmail.com",
            //            phone = "9823452312"

            //        }
            //    }
            //};


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