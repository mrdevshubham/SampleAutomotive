using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automotive.Data;
using Automotive.Model;

namespace Automotive.Business
{
    public class ProductCatogoryService
    {

        public List<ProductCategory> GetAllCategory()
        {
            return (new ProductCategoryDataService()).GetAll();
        }

    }
}
