using DatunashviliAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatunashviliAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<WineType>> GetProductTypesAsync();
        Task<IReadOnlyList<WineYear>> GetProductYearsAsync();
    }
}
