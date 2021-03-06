﻿using Automotive.Data;
using Automotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automotive.Business
{
    public class BrandService
    {

        public List<BrandModel> GetAllBrands()
        {
            BrandData oBrandDataService = new BrandData();
            IEnumerable<BrandModel> brands = oBrandDataService.GetAll();
            return brands.ToList();
        }

        public bool DeleteBrand(int brandId)
        {
            BrandData oBrandDataService = new BrandData();
            return oBrandDataService.Delete(brandId);
        }

    }
}
