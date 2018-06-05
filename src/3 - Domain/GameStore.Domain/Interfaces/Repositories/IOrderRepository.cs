using GameStore.Domain.Entities;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IOrderRepository {
        void CreateOrder(Order order);
    }
}