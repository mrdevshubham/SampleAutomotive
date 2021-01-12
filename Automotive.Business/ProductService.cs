using Automotive.Data;
using Automotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automotive.Business
{
    public class ProductService
    {

        public List<ProductModel> GetAllProducts()
        {
            ProductDataService odataService = new ProductDataService();
            return odataService.GetAll();
        }

    }
}
