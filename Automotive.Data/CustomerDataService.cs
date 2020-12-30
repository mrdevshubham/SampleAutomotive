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

        public List<CustomerModel> GetAll()
        {
            using (var bikestoreContext = new SampleAutomotiveEntities())
            {
                List<CustomerModel> customers = bikestoreContext.Customers
                    .Select(x => new CustomerModel
                    {
                        FirstName = x.first_name,
                        LastName = x.last_name,
                        Phone = x.phone,
                        Email = x.email

                    }).ToList();
                return customers;
            }
        }


    }
}
