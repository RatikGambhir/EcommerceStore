using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly UserManager<User> _userManager;
    private readonly TokenService _token;
    private readonly StoreContext _context;
    public AccountController(UserManager<User> userManager, TokenService token, StoreContext context)
    {
      _context = context;
      _token = token;
      _userManager = userManager;

    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) {
        var user = await _userManager.FindByNameAsync(loginDto.Username);

        if(user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password)) return Unauthorized(); 

            var basket = await RetrieveBasket(loginDto.Username);
            var anonBasket = await RetrieveBasket(Request.Cookies["buyerId"]);
            if(anonBasket != null) {
                if(basket != null) _context.Baskets.Remove(basket);
                anonBasket.BuyerId = user.UserName;
                Response.Cookies.Delete("buyerId");
                await _context.SaveChangesAsync();

            

            }


        return new UserDto 
        {
           Email = user.Email,
           Token = await _token.GenerateToken(user),
           Basket = anonBasket != null ? anonBasket.MapBasketToDto() : basket?.MapBasketToDto()
        };
    }

    [HttpPost("register")]

    public async Task<ActionResult> Register(RegisterDto registerDto) {
        var user = new User{UserName = registerDto.Username, Email = registerDto.Email};

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if(!result.Succeeded) {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        await _userManager.AddToRoleAsync(user, "Member");

        return StatusCode(201);
    }
           [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

          var userBasket = await RetrieveBasket(User.Identity.Name);

            return new UserDto
            {
                Email = user.Email,
                Token = await _token.GenerateToken(user),
                Basket = userBasket?.MapBasketToDto()
            };
        }

        //  [Authorize]
        // [HttpGet("savedAddress")]
        // public async Task<ActionResult<UsersAddress>> GetSavedAddress()
        // {
        //     return await _userManager.Users
        //         .Where(x => x.UserName == User.Identity.Name)
        //         .Select(user => user.Address)
        //         .FirstOrDefaultAsync();
        // }
       
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

  }
}