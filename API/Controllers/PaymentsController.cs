using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities.Order;
using API.Extensions;
using API.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace API.Controllers
{
    public class PaymentsController : BaseApiController
    {
    public readonly PaymentService _paymentService;
    public readonly StoreContext _context;
    public IConfiguration _config { get; set; }
        public PaymentsController(PaymentService paymentService, StoreContext context, IConfiguration config)
        {
      _config = config;
      _context = context;
      _paymentService = paymentService;
            
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BasketDTO>> CreateOrUpdatePaymentIntent()
        {
            var basket = await _context.Baskets.RetrieveBasketWithItems(User.Identity.Name).FirstOrDefaultAsync();

            if(basket == null) return NotFound();

            var intent = await _paymentService.CreateOrUpdatePaymentIntent(basket);

            if(intent == null) return BadRequest(new ProblemDetails{Title = "Problem Submitting Payment!"});

            basket.PaymentIntentId = basket.PaymentIntentId ?? intent.Id;
            basket.ClientSecret = basket.ClientSecret ?? intent.ClientSecret;

            _context.Update(basket);

            var result = await _context.SaveChangesAsync() > 0;

            if(!result) return BadRequest(new ProblemDetails {Title = "Problem Submitting Payment!"});

            return basket.MapBasketToDto();
        }
        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var striptEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], _config["StripeSettings:WHSecret"]);

            var chargeEvent = (Charge)striptEvent.Data.Object;

            var order = await _context.Orders.FirstOrDefaultAsync(x => x.PaymentIntentId == chargeEvent.PaymentIntentId);

            if(chargeEvent.Status == "succeeded") order.OrderStatus = OrderStatus.PaymentRecieved;

            await _context.SaveChangesAsync();

            return new EmptyResult();
        }

    }
}