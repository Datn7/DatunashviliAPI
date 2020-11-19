using DatunashviliAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatunashviliAPI.Specifications
{
    public class ProductWithFiltersForCountSpecification:BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(x =>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
        && (!productParams.WineTypeId.HasValue || x.WineTypeId == productParams.WineTypeId)
        && (!productParams.WineYearId.HasValue || x.WineYearId == productParams.WineYearId))
        {

        }
    }
}
