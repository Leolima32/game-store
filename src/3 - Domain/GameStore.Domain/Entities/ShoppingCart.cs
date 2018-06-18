using System;
using System.Linq;
using System.Collections.Generic;
using GameStore.Domain.Entities.Common;
using GameStore.Domain.ValueObjects;

namespace GameStore.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        protected ShoppingCart() { }
        public Guid UserId { get; private set; }

        private IList<CartItem> _listOfItems = new List<CartItem>();

        public ShoppingCart(Guid userId, IList<CartItem> listOfItems)
        {
            UserId = userId;
            _listOfItems = listOfItems;
        }

        public IReadOnlyCollection<CartItem> ListOfItems
        {
            get
            {
                return _listOfItems.ToArray();
            }
        }

        public void AddItem(CartItem item)
        {
            if (!QuantityIsAvailableInStock(item)) {
                AddNonconformity(new Nonconformity("shoppingCart.quantity", "Total quantity exceed the number available in stock."));
                return;
            }

            if (!AlreadyContainThisItem(item))
            {
                _listOfItems.Add(item);
            }
            else
            {
                var foundItem = ListOfItems.Where(_ => _ == item).FirstOrDefault();
                foundItem.ChangeQuantityBy(item.Quantity);
            }
        }

        public void RemoveItem(CartItem item)
        {
            _listOfItems.Remove(item);
        }

        public bool AlreadyContainThisItem(CartItem item)
        {
            return ListOfItems.Where(_ => _.Product == item.Product).Count() > 0;
        }

        public bool QuantityIsAvailableInStock(CartItem tryingToAddItem)
        {
            var existingCartItem = ListOfItems.Where(_ => _.Product == tryingToAddItem.Product).FirstOrDefault();
            return (existingCartItem?.Quantity + tryingToAddItem.Quantity) < tryingToAddItem.Product.AvailableQuantity;
        }

    }
}
