using Automotive.Data;
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
            CustomerDataService oDataService = new CustomerDataService();
            IEnumerable<CustomerModel> customers = oDataService.GetAll();
            return View(customers);
        }

        [HttpPost]
        public JsonResult Delete(int customerId)
        {
            CustomerDataService oDataService = new CustomerDataService();
            bool Result = oDataService.Delete(customerId);
            return Json(new { Result = Result });
        }
    }
}