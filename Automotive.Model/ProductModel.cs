using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automotive.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public int ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        public int BrandID { get; set; }

        public int CategoryID { get; set; }
    }
}
