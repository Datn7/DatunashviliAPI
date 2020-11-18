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
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.WineType);
            AddInclude(x => x.WineYear);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x=>x.Id == id)
        {
            AddInclude(x => x.WineType);
            AddInclude(x => x.WineYear);
        }
    }
}
