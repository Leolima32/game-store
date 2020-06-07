using GameStore.Application.DTOS.Cart;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using System;
using AutoMapper;
using System.Threading.Tasks;
using GameStore.Domain.Interfaces.Repositories;

namespace GameStore.Application.Services
{
    public class CartServices : ICartServices
    {
        private readonly IShoppingCartRepository _repo;
        private readonly IMapper _mapper;
        public CartServices(IShoppingCartRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task AddItemToCart(CartItemDTO item, Guid userId)
        {
            ShoppingCart CurrentCart = await _repo.GetCartByUserId(userId);

            if(CurrentCart is null)
            {
                CurrentCart = new ShoppingCart(userId);
                await _repo.CreateCart(CurrentCart);
            }

            CurrentCart.AddItem(_mapper.Map<CartItem>(item));

            await _repo.SaveCart(CurrentCart);
        }
    }
}
