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

        public List<ProductModel> GetAllProducts(SearchModel search)
        {
            ProductDataService odataService = new ProductDataService();
            return odataService.GetAll(search);
        }

        public Int64 GetAllProductCount()
        {
            ProductDataService oPService = new ProductDataService();
            return oPService.GetTotalRecordCount();
        }

        public List<ProductModel> AvailableProducts()
        {
            ProductDataService odataService = new ProductDataService();
            return odataService.ListOfProducts();
        }

        public bool AddProduct(ProductModel product)
        {
            ProductDataService oPService = new ProductDataService();
            return oPService.Add(product);
        }

    }
}
