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

        public IEnumerable<CustomerModel> GetAllCustomers(SearchModel searchModele)
        {
            CustomerDataService oDataService = new CustomerDataService();
            IEnumerable<CustomerModel> customers = oDataService.GetAll(searchModele);
            return customers;
        }

        public Int64 GetAllCustomersCount()
        {
            CustomerDataService oDataService = new CustomerDataService();
            return oDataService.GetTotalRecordCount();
        }

        public CustomerModel GetCustomerDetails(int customerId)
        {
            CustomerDataService oDataService = new CustomerDataService();
            return oDataService.GetCustomerDetails(customerId);
        }

        public bool AddCustomer(CustomerModel customerModel)
        {
            CustomerDataService oDataService = new CustomerDataService();
            return oDataService.Add(customerModel);
        }

        public bool UpdateCustomerDetails(CustomerModel customerModel)
        {
            CustomerDataService oDataService = new CustomerDataService();
            return oDataService.Update(customerModel);
        }


        public bool DeleteCustomer(int customerId)
        {
            CustomerDataService oDataService = new CustomerDataService();
            return oDataService.Delete(customerId);
        }


    }
}
