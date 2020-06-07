using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Application.DTOS.Cart;
using GameStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.WebApi.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cartService;
        public CartController(ICartServices cartService)
        {
            _cartService = cartService;
        }
        public async Task<IActionResult> AddItemToCart(CartItemDTO item)
        {
            try
            {
                await _cartService.AddItemToCart(item, Guid.NewGuid());
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}