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

        public CustomerModel GetCustomerDetails(int customerId)
        {
            using (var bikestoreContext = new SampleAutomotiveEntities())
            {
                Customer customer = bikestoreContext.Customers.Where(x => x.customer_id == customerId).FirstOrDefault();

                if (customer != null)
                {
                    CustomerModel objCustomerModel = new CustomerModel();
                    objCustomerModel.CustomerId = customer.customer_id;
                    objCustomerModel.FirstName = customer.first_name;
                    objCustomerModel.LastName = customer.last_name;
                    objCustomerModel.Phone = customer.phone;
                    objCustomerModel.ZipCode = customer.zip_code;

                    return objCustomerModel;
                }
                return null;
            }
        }

        public bool Add(CustomerModel customer)
        {
            try
            {
                using (var bikestoreContext = new SampleAutomotiveEntities())
                {
                    Customer custObj = new Customer();
                    custObj.first_name = customer.FirstName;
                    custObj.last_name = customer.LastName;
                    custObj.phone = customer.Phone;
                    custObj.email = customer.Email;
                    custObj.IsActive = true;
                    custObj.zip_code = customer.ZipCode;
                    bikestoreContext.Customers.Add(custObj);
                    bikestoreContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CustomerModel customer)
        {
            using(var bikestoreContext = new SampleAutomotiveEntities())
            {
                Customer ucustomer = bikestoreContext.Customers.Where(x => x.customer_id == customer.CustomerId).FirstOrDefault();
                if (ucustomer != null)
                {
                    ucustomer.first_name = customer.FirstName;
                    ucustomer.last_name = customer.LastName;
                    ucustomer.phone = customer.Phone;
                    ucustomer.zip_code = customer.ZipCode;
                    bikestoreContext.SaveChanges();
                    return true;
                }
            }
            return false;
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
