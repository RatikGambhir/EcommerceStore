using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Entities.Order;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
    private readonly StoreContext _context;
        public OrdersController(StoreContext context) {
      _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<CreateOrderDto>>> GetAllOrders() {
            return await _context.Orders.MapOrderToOrderDto().Where(x => x.BuyerId == User.Identity.Name).ToListAsync();
        }

        [HttpGet("{id}", Name = "GetOrder")]

        public async Task<ActionResult<CreateOrderDto>> GetSpecificOrder(int id) 
        {
            return await _context.Orders.MapOrderToOrderDto()
            .Where(x => x.BuyerId == User.Identity.Name && x.Id == id)
            .FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto) 
        {
                var basket = await _context.Baskets.RetrieveBasketWithItems(User.Identity.Name)
                            .FirstOrDefaultAsync();

                
                if(basket == null) return BadRequest(new ProblemDetails{Title = "Could not locate basket"});

                var items = new List<OrderItem>();

                foreach(var item in basket.Items)
                {
                    var productItem = await _context.Products.FindAsync(item.ProductId);
                    var itemOrdered = new ProductItemOrdered
                    {
                        ProductId = productItem.Id,
                        Name = productItem.Name,
                        PictureUrl = productItem.Picture
                    };

                    var orderItem = new OrderItem
                    {
                        Id = 1,
                        itemOrdered = itemOrdered,
                        Price = productItem.Price,
                        Quantity = item.Quantity
                    };
                    items.Add(orderItem);
                    productItem.QuantityInStock -= item.Quantity;

                }
                var subtotal = items.Sum(item => item.Price * item.Quantity);
                var DeliveryFee = subtotal > 30000 ? 0 : 1000; 

                var order = new Order
                {
                    BuyerId = User.Identity.Name,
                    OrderItems = items,
                    Subtotal = subtotal,
                    DeliveryFee = DeliveryFee,
                    ShippingAddress = orderDto.ShippingAddress,
                };

                _context.Orders.Add(order);
                _context.Baskets.Remove(basket);

                if(orderDto.SaveAddress)
                {
                    var user = await _context.Users
                    .Include(a => a.Address).FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
                    var address = new UsersAddress
                    {
                            FullName = orderDto.ShippingAddress.FullName,
                            Address1 = orderDto.ShippingAddress.Address1,
                            Address2 = orderDto.ShippingAddress.Address2,
                            City = orderDto.ShippingAddress.City,
                            State = orderDto.ShippingAddress.State,
                            Zip = orderDto.ShippingAddress.Zip,
                            Country = orderDto.ShippingAddress.Country
                    };
                    user.Address = address;
                    _context.Update(user);
                }

                var result = await _context.SaveChangesAsync() > 0;

                if(result) return CreatedAtRoute("GetOrder", new {id = order.Id}, order.Id);

                return BadRequest("Problem Ordering Items");


        }
    }
}