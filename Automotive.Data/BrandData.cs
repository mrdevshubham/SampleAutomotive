using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automotive.Model;
using Automotive.Data.AutomotiveEntity;

namespace Automotive.Data
{
    public class BrandData
    { 
        public List<BrandModel> GetAll()
        {
            using (var bikestorecontext = new SampleAutomotiveEntities() )
            {
                List<BrandModel> brands = bikestorecontext.Brands
                    .Where(x => x.IsActive == true)
                    .Select(x => new BrandModel
                    {
                        BrandId = x.brand_id,
                        BrandName = x.brand_name
                    }).ToList();
                return brands;
            }
        }

        public bool Delete(int brandId)
        {
            try
            {
                using (var bikestoreContext = new SampleAutomotiveEntities())
                {
                    Brand brand = bikestoreContext.Brands.Where(x => x.brand_id == brandId).FirstOrDefault();
                    if (brand != null)
                    {
                        brand.IsActive = false;
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
