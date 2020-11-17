using DatunashviliAPI.Data;
using DatunashviliAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatunashviliAPI.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await storeContext.Products.Include(p => p.WineType).Include(p => p.WineYear).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await storeContext.Products.Include(p => p.WineType).Include(p => p.WineYear).ToListAsync();
        }

        public async Task<IReadOnlyList<WineType>> GetProductTypesAsync()
        {
            return await storeContext.WineTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<WineYear>> GetProductYearsAsync()
        {
            return await storeContext.WineYears.ToListAsync();
        }
    }
}
