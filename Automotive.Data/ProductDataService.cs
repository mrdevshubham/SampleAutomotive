using Automotive.Data.AutomotiveEntity;
using Automotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automotive.Data
{
    public class ProductDataService
    {

        public List<ProductModel> GetAll()
        {
            using (var bikestorecontext = new SampleAutomotiveEntities())
            {
                var products = (from prod in bikestorecontext.Products
                                join brd in bikestorecontext.Brands on prod.brand_id equals brd.brand_id
                                join cat in bikestorecontext.Categories on prod.category_id equals cat.category_id
                                select new ProductModel
                                {
                                    ProductId = prod.product_id,
                                    ProductName = prod.product_name,
                                    BrandName = brd.brand_name,
                                    CategoryName = cat.category_name,
                                    ModelYear = prod.model_year,
                                    ListPrice = prod.list_price
                                }).ToList();

                return products;

            }
        }

    }
}
