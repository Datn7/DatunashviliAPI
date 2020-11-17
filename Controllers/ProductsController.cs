using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatunashviliAPI.Data;
using DatunashviliAPI.Entities;
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

        public ProductsController(StoreContext context)
        {
            this.context = context;
        }

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



        [HttpGet("getSingleString")]
        public string GetProductString()
        {
           return "ეს არი პროდუქციის სია.";
        }

        [HttpGet("getSingleString/{id}")]
        public string GetProduct(int id)
        {
            return "ერთი პროდუქტი";
        }
    }
}
