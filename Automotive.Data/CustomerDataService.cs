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

        public List<CustomerModel> GetAll(SearchModel searchModel)
        {
            using (var bikestoreContext = new SampleAutomotiveEntities())
            {
                IQueryable<Customer> customer = bikestoreContext.Customers.Where(x => x.IsActive == true);

                if (!string.IsNullOrEmpty(searchModel.searchItem))
                {
                    customer = customer.Where(x => x.first_name.Contains(searchModel.searchItem));
                }

                if (!string.IsNullOrEmpty(searchModel.orderByCommand))
                {
                    if (searchModel.orderByCommand == "asc")
                        customer = customer.OrderBy(x => x.customer_id);
                    else
                        customer = customer.OrderByDescending(x => x.customer_id);
                }
                
                customer = customer
                    .Skip(searchModel.currentIndex * searchModel.TotalRecordsPerPage)
                    .Take(searchModel.TotalRecordsPerPage);
                
                    var Result = customer.Select(x => new CustomerModel
                    {
                        DT_RowId = System.Data.Entity.SqlServer.SqlFunctions.StringConvert((double)x.customer_id),
                        DT_RowData = new { pkey  = x.customer_id },
                        CustomerId = x.customer_id,
                        FirstName = x.first_name,
                        LastName = x.last_name,
                        Phone = x.phone,
                        Email = x.email

                    }).ToList();

                return Result;
            }
        }

        public Int64 GetTotalRecordCount()
        {
            using (var bikestoreContext = new SampleAutomotiveEntities())
            {
                return bikestoreContext.Customers.Where(x => x.IsActive == true).Count();
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
