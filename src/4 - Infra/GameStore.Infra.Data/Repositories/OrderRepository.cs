using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;

namespace GameStore.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private GameStoreContext _db;
        public OrderRepository(GameStoreContext db)
        {
            _db = db;
        }
        public void CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }
    }
}