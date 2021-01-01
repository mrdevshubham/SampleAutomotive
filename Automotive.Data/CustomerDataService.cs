using Automotive.Data.AutomotiveEntity;
using Automotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automotive.Data
{
    public class CustomerDataService
    {

        public List<CustomerModel> GetAll(int currentIndex, int TotalRecordsPerPage)
        {
            using (var bikestoreContext = new SampleAutomotiveEntities())
            {
                List<CustomerModel> customers = bikestoreContext.Customers
                    .Where(x => x.IsActive == true)
                    .Select(x => new CustomerModel
                    {
                        CustomerId = x.customer_id,
                        FirstName = x.first_name,
                        LastName = x.last_name,
                        Phone = x.phone,
                        Email = x.email

                    }).OrderBy(x => x.CustomerId).Skip(currentIndex * TotalRecordsPerPage).Take(TotalRecordsPerPage).ToList();
                return customers;
            }
        }

        public bool Delete(int customerId)
        {
            try
            {
                using (var bikestoreContext = new SampleAutomotiveEntities())
                {
                    Customer customer = bikestoreContext.Customers.Where(x => x.customer_id == customerId).FirstOrDefault();
                    if (customer != null)
                    {
                        customer.IsActive = false;
                        bikestoreContext.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            
        }

    }
}
