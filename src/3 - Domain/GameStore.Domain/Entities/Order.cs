using GameStore.Domain.Entities.Common;
using System;

namespace GameStore.Domain.Entities
{
    public class Order: BaseEntity
    {
        protected Order() { }
        public Order(Guid userId, ShoppingCart shoppingCart)
        {
            UserId = userId;
            ShoppingCart = shoppingCart;
        }

        public Guid UserId { get; private set; }
        public Payment FormOfPayment { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }
    }
}
