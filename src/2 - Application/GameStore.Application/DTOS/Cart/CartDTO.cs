using System;
using System.Collections.Generic;

namespace GameStore.Application.DTOS.Cart
{
    public class CartDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItemDTO> Items { get; set; }
    }
}
