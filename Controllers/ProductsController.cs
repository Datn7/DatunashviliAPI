using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatunashviliAPI.Data;
using DatunashviliAPI.Entities;
using DatunashviliAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatunashviliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;
        private readonly IProductRepository repository;

        public ProductsController(StoreContext context, IProductRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }

        /* რეპოზიტორის დახმარებით წაღება ინფორმაციის*/

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await repository.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await repository.GetProductByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<WineType>>> GetProductType()
        {
            return Ok(await repository.GetProductTypesAsync());
        }

        [HttpGet("years")]
        public async Task<ActionResult<IReadOnlyList<WineType>>> GetProductYears()
        {
            return Ok(await repository.GetProductYearsAsync());
        }

        /* 
         * "პირდაპირ storeContext-ის გამოყენება"
         * 
         
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await context.Products.FindAsync(id);
        }
         */


        /*
         * "სტრინგების მიწოდება"
         * 
           [HttpGet("getSingleString")]
          public string GetProductString()
          {
             return "ეს არი პროდუქციის სია.";
          }

          [HttpGet("getSingleString/{id}")]
          public string GetProductString(int id)
          {
              return "ერთი პროდუქტი";
          }
         */
    }
}
