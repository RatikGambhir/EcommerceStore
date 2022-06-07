using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.DTOs;

namespace API.Controllers
{   

    public class ProductsController : BaseApiController
    {
    private readonly StoreContext context;
        
        public ProductsController(StoreContext context)
        {
                this.context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery]ProductParams productParams) {
                var query = context.Products
                .SortProducts(productParams.OrderBy)
                .SearchByName(productParams.SearchName)
                .FilterProducts(productParams.Brands, productParams.Types)
                .AsQueryable();
                

                var products = await PagedList<Product>.ToPagedList(query, productParams.PageNumber, productParams.PageSize);

                Response.AddPaginationHeader(products.MetaData);

                return products;
               
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            var product = await context.Products.FindAsync(id);
        
                if(product == null) return NotFound();

                return product;
        }

        [HttpGet("filter")]

        public async Task<IActionResult> GetFilters()
        {
            var brands = await context.Products.Select(p => p.Brand).Distinct().ToListAsync();
            var types = await context.Products.Select(p => p.Type).Distinct().ToListAsync();

            return Ok(new {
                brands,
                types
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody]CreateProductDto createProductDto)
        {
            
            var product = new Product 
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Picture = createProductDto.Picture.FileName,
                Type = createProductDto.Type,
                Brand = createProductDto.Brand,
                QuantityInStock = createProductDto.QuantityInStock
            };
            
            context.Products.Add(product);

            var result = await context.SaveChangesAsync() > 0;

            if(result) return CreatedAtRoute("GetProduct", new {Id = product.Id}, product);

            return BadRequest(new ProblemDetails {Title = "Trouble adding product..."});
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var productToBeUpdated = await context.Products.FindAsync(updateProductDto.Id);
            if(productToBeUpdated == null) return NotFound();
            var product = new Product
            {
                Name = updateProductDto.Name,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                Picture = updateProductDto.Picture.FileName,
                Type = updateProductDto.Type,
                Brand = updateProductDto.Brand,
                QuantityInStock = updateProductDto.QuantityInStock
            };

            var result = await context.SaveChangesAsync() > 0;

            if(result) return NoContent();

            return BadRequest(new ProblemDetails {Title = "Trouble updating Product..."});
        }

    }
}