using DatunashviliAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatunashviliAPI.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification :BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams) 
            : base(x=>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
        &&(!productParams.WineTypeId.HasValue || x.WineTypeId == productParams.WineTypeId)
        && (!productParams.WineYearId.HasValue || x.WineYearId == productParams.WineYearId))
        {
            AddInclude(x => x.WineType);
            AddInclude(x => x.WineYear);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x=>x.Id == id)
        {
            AddInclude(x => x.WineType);
            AddInclude(x => x.WineYear);
        }
    }
}
