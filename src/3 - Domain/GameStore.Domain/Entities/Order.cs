using GameStore.Domain.Entities.Common;
using GameStore.Domain.ValueObjects;
using System;

namespace GameStore.Domain.Entities
{
    public class Order : BaseEntity
    {
        protected Order() { }
        public Order(Guid userId, ShoppingCart shoppingCart, Payment payment)
        {
            UserId = userId;
            ShoppingCart = shoppingCart;
            FormOfPayment = payment;

            if (shoppingCart is null)
                AddNonconformity(new Nonconformity("order.shoppingCart", "Shopping Cart cannot be empty to issue an order."));
            if (payment is null)
                AddNonconformity(new Nonconformity("order.payment", "Any order should have a least one method of payment."));
        }

        public Guid UserId { get; private set; }
        public Payment FormOfPayment { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }
    }
}
