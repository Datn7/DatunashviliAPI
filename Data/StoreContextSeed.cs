using DatunashviliAPI.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatunashviliAPI.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!storeContext.WineTypes.Any())
                {
                    var typeData = File.ReadAllText("Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<WineType>>(typeData);

                    foreach( var item in types)
                    {
                        storeContext.WineTypes.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.WineYears.Any())
                {
                    var yearsData = File.ReadAllText("Data/SeedData/years.json");

                    var years = JsonSerializer.Deserialize<List<WineYear>>(yearsData);

                    foreach (var item in years)
                    {
                        storeContext.WineYears.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.Products.Any())
                {
                    var winesData = File.ReadAllText("Data/SeedData/wines.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(winesData);

                    foreach (var item in products)
                    {
                        storeContext.Products.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
