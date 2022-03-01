using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Order;

namespace API.DTOs
{
    public class CreateOrderDto
    {
         public int Id {get; set;}

        public string BuyerId {get; set;}

        public ShippingAddress ShippingAddress {get; set;}

        public DateTime OrderDate {get; set;} = DateTime.Now;

        public List<OrderItemDto> OrderItems {get; set;}

        public long Subtotal {get; set;}

        public long DeliveryFee {get; set;}

        public string OrderStatus {get; set;} 

       public long Total {get; set;}
    }
}