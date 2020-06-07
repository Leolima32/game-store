using System;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;
using GameStore.Infra.Data.Repositories.Common;

namespace GameStore.Infra.Data.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly GameStoreContext _db;
        public ShoppingCartRepository (GameStoreContext db) : base(db)
        {
            _db = db;
        }

        public ShoppingCart GetActiveShoppingCartByUserId(Guid userId) {
            return _db.ShoppingCarts.Where(_ => _.UserId == userId && _.Active).FirstOrDefault();
        }

        public override Guid Add(ShoppingCart cart) {
            if(_db.ShoppingCarts.Where(_ => _.Id == cart.Id && _.Active).Count() > 0)
                throw new Exception("There is already an active shopping cart for this user");
            else 
               _db.Set<ShoppingCart>().Add(cart);

            _db.SaveChanges();
            return cart.Id;
        }

        public Task<ShoppingCart> GetCartByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateCart(ShoppingCart currentCart)
        {
            throw new NotImplementedException();
        }

        public Task SaveCart(ShoppingCart currentCart)
        {
            throw new NotImplementedException();
        }
    }
}