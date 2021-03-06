using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class BasketExtensions
    {
        public static BasketDTO MapBasketToDto(this Basket basket) {
                return new BasketDTO
                {
                Id = basket.Id,
                buyerId = basket.BuyerId,
                PaymentIntentId = basket.PaymentIntentId,
                ClientSecret = basket.ClientSecret,
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

            public static IQueryable<Basket> RetrieveBasketWithItems(this IQueryable<Basket> query, string buyerId)
            {
                return query.Include(i => i.Items).ThenInclude(p => p.Product).Where(x => x.BuyerId == buyerId);
            }
        }
    }
