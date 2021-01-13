using Automotive.Data.AutomotiveEntity;
using Automotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automotive.Data
{
    public class ProductCategoryDataService
    {
        public List<ProductCategory> GetAll()
        {
            using (var bikestorecontext = new SampleAutomotiveEntities())
            {
                List<ProductCategory> categories = bikestorecontext.Categories
                    .Select(x => new ProductCategory
                    {
                        CategoryId = x.category_id,
                        CategoryName = x.category_name
                    }).ToList();
                return categories;
            }
        }
    }
}
