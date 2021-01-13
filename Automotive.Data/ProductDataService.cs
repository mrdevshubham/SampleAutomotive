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

        public List<ProductModel> GetAll(SearchModel search)
        {
            using (var bikestorecontext = new SampleAutomotiveEntities())
            {
                // IQueryable<Product> product = bikestorecontext.Products.ToList();
                IEnumerable<Product> product = bikestorecontext.Products.ToList();

                if (!string.IsNullOrEmpty(search.searchItem))
                {
                    product = product.Where(x => x.product_name.Contains(search.searchItem));
                }

                if (!string.IsNullOrEmpty(search.orderByCommand))
                {
                    if (search.orderByCommand == "asc")
                        product = product.OrderBy(x => x.product_name);
                    else
                        product = product.OrderByDescending(x => x.product_name);
                }

                //product = product
                //.Skip(search.currentIndex * search.TotalRecordsPerPage)
                //.Take(search.TotalRecordsPerPage);


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
                                }).OrderBy(x => x.ProductName).Skip(search.currentIndex * search.TotalRecordsPerPage)
                .Take(search.TotalRecordsPerPage).ToList();

                return products;

            }
        }

        public Int64 GetTotalRecordCount()
        {
            using (var bikestoreContext = new SampleAutomotiveEntities())
            {
                return bikestoreContext.Products.Count();
            }
        }

        public List<ProductModel> ListOfProducts()
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
