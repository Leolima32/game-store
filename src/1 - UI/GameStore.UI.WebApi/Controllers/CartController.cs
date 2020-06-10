using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GameStore.Application.DTOS.Cart;
using GameStore.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.WebApi.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cartService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(ICartServices cartService, IHttpContextAccessor httpContextAccessor)
        {
            _cartService = cartService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> AddItemToCart(CartItemDTO item)
        {
            try
            {
                var userId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                await _cartService.AddItemToCart(item, userId);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}