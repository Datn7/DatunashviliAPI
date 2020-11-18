using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatunashviliAPI.Data;
using DatunashviliAPI.Dtos;
using DatunashviliAPI.Entities;
using DatunashviliAPI.Errors;
using DatunashviliAPI.Interfaces;
using DatunashviliAPI.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatunashviliAPI.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productsRepo;
        private readonly IGenericRepository<WineType> wineTypeRepo;
        private readonly IGenericRepository<WineYear> wineYearRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<WineType> wineTypeRepo, IGenericRepository<WineYear> wineYearRepo,
            IMapper mapper)
        {
            this.productsRepo = productsRepo;
            this.wineTypeRepo = wineTypeRepo;
            this.wineYearRepo = wineYearRepo;
            this.mapper = mapper;
        }

        /*Generic რეპოზიტორის დახმარებით წაღება ინფორმაციის*/

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await productsRepo.ListAsync(spec);

            /* mapping with automapper
             * 
              return products.Select(product => new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                WineType = product.WineType.Name,
                WineYear = product.WineYear.Name
            }).ToList();
             */

            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await productsRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));

            /*
             return new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                WineType = product.WineType.Name,
                WineYear = product.WineYear.Name
            };
            */



            return mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<WineType>>> GetProductType()
        {
            return Ok(await wineTypeRepo.ListAllAsync());
        }

        [HttpGet("years")]
        public async Task<ActionResult<IReadOnlyList<WineType>>> GetProductYears()
        {
            return Ok(await wineYearRepo.ListAllAsync());
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
