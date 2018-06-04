

using GameStore.Domain.Entities.Common;
using System;

namespace GameStore.Domain.Entities
{
    public class Order: BaseEntity
    {
        public Order(Guid userId, Payment formOfPayment, ShoppingCart shoppingCart)
        {
            UserId = userId;
            FormOfPayment = formOfPayment;
            ShoppingCart = shoppingCart;
        }

        public Guid UserId { get; private set; }
        public Payment FormOfPayment { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }
    }
}
