using GameStore.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IShoppingCartRepository: IRepository<ShoppingCart>
    {
        Task<ShoppingCart> GetCartByUserId(Guid userId);
        Task CreateCart(ShoppingCart currentCart);
    }
}
