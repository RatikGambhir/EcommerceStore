using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{       
   
    public class BasketController : BaseApiController
    {
    private readonly StoreContext _context;
        
    public BasketController(StoreContext context)
    {
      _context = context;
        
    }

        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDTO>> GetBasket()
    {
      var basket = await RetrieveBasket(getBuyerID());

      if (basket == null) return NotFound();
      return MapBasketToDTO(basket);
    }

    


    [HttpPost]

        public async Task<ActionResult<BasketDTO>> AddItemToBasket(int productId, int quantity) {
            var basket = await RetrieveBasket(getBuyerID());
            if(basket == null) basket = CreateBasket(); 
            var products = await _context.Products.FindAsync(productId);
            if(products == null) return BadRequest(new ProblemDetails {
              Title="Product Not Found"
            });
              basket.AddItem(products, quantity);

              var result = await _context.SaveChangesAsync() > 0;
              if(result) return CreatedAtRoute("GetBasket", MapBasketToDTO(basket));

              return BadRequest(new ProblemDetails{Title = "Problem saving Item..."});
        }

   
    [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity) {
                var basket = await RetrieveBasket(getBuyerID());
                if(basket == null) return NotFound();
                basket.RemoveItem(productId, quantity);
                var result = await _context.SaveChangesAsync() > 0;
                if(result) return Ok();
                return BadRequest(new ProblemDetails{
                    Title= "Cannot delete item"
                });
        }
        private async Task<Basket> RetrieveBasket(string buyerId)
    {
        if(string.IsNullOrEmpty(buyerId)) {
          Response.Cookies.Delete("buyerId");
          return null;
        }

      return await _context.Baskets
                      .Include(i => i.Items)
                      .ThenInclude(p => p.Product)
                                  .FirstOrDefaultAsync(x => x.BuyerId == buyerId);
    }

        private string getBuyerID() {
          return User.Identity?.Name ?? Request.Cookies["buyerId"];
        }

         private Basket CreateBasket()
            {
                    var buyerId = User.Identity?.Name;
                    if(string.IsNullOrEmpty(buyerId)) {
                      buyerId = Guid.NewGuid().ToString();
                    var cookieOptions = new CookieOptions{IsEssential = true, Expires = DateTime.Now.AddDays(30)};
                    Response.Cookies.Append("buyerId", buyerId, cookieOptions);
                    }
                    

                    var basket = new Basket {BuyerId = buyerId};
                    _context.Baskets.Add(basket);
                    return basket;
            }
            private static BasketDTO MapBasketToDTO(Basket basket)
    {
      return new BasketDTO
      {
        Id = basket.Id,
        buyerId = basket.BuyerId,
        Items = basket.Items.Select(item => new BasketItemDTO
        {
          ProductId = item.ProductId,
          Name = item.Product.Name,
          Price = item.Product.Price,
          Picture = item.Product.Picture,
          Type = item.Product.Type,
          Brand = item.Product.Brand,
          Quantity = item.Quantity
        }).ToList(),
      };
    }

    }
}