using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities.Order;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class OrderExtensions
    {
        public static IQueryable<CreateOrderDto> MapOrderToOrderDto (this IQueryable<Order> query)
        {
            return query
                    .Select(order => new CreateOrderDto {
                        Id = order.Id,
                        BuyerId = order.BuyerId,
                        OrderDate = order.OrderDate,
                        Subtotal = order.Subtotal,
                        DeliveryFee = order.DeliveryFee,
                        Total = order.GetTotal(),
                        ShippingAddress = order.ShippingAddress,
                        OrderStatus = order.OrderStatus.ToString(),
                        OrderItems = order.OrderItems.Select(item => new OrderItemDto{
                                ProductId = item.itemOrdered.ProductId,
                                Name = item.itemOrdered.Name,
                                Picture = item.itemOrdered.PictureUrl,
                                Price = item.Price,
                                Quantity = item.Quantity

                        }).ToList()
                    }).AsNoTracking();
        }
    }
}