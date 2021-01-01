using Automotive.Business;
using Automotive.Model;
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
            IEnumerable<CustomerModel> customers = ocustomerService.GetAllCustomers(2,10);
            return View(customers);
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