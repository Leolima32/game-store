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
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public CartServices(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task AddItemToCart(CartItemDTO item, Guid userId)
        {
            ShoppingCart CurrentCart = await _unit.Carts.GetCartByUserId(userId);

            if(CurrentCart is null)
            {
                CurrentCart = new ShoppingCart(userId);
                await _unit.Carts.CreateCart(CurrentCart);
            }

            CurrentCart.AddItem(_mapper.Map<CartItem>(item));

            _unit.Carts.Update(CurrentCart);
        }
    }
}
