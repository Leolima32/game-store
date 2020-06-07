using System;

namespace GameStore.Application.DTOS.Cart
{
    public class CartItemDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
    }
}
