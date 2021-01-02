using Automotive.Data;
using Automotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automotive.Business
{
    public class CustomerService
    {

        public IEnumerable<CustomerModel> GetAllCustomers(int currentIndex, int TotalRecordsPerPage)
        {
            CustomerDataService oDataService = new CustomerDataService();
            IEnumerable<CustomerModel> customers = oDataService.GetAll(currentIndex, TotalRecordsPerPage);
            return customers;
        }

        public Int64 GetAllCustomersCount()
        {
            CustomerDataService oDataService = new CustomerDataService();
            return oDataService.GetTotalRecordCount();
        }

        public bool DeleteCustomer(int customerId)
        {
            CustomerDataService oDataService = new CustomerDataService();
            return oDataService.Delete(customerId);
        }


    }
}
