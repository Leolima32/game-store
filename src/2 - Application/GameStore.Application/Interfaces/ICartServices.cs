using GameStore.Application.DTOS.Cart;
using System;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface ICartServices
    {
        Task AddItemToCart(CartItemDTO item, Guid userId);
    }
}
