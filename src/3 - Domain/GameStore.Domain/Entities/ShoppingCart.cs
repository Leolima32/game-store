﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace GameStore.Domain.Entities
{
    public class ShoppingCart
    {
        
        public User User { get; private set; }

        private IList<CartItem> _listOfItems;
        public IReadOnlyCollection<CartItem> ListOfItems
        {
            get
            {
                return _listOfItems.ToArray();
            }
        }

        public void AddItem(CartItem item)
        {
            if (!AlreadyContainThisItem(item))
            {
                _listOfItems.Add(item);
            }
            else
            {
                var foundItem = ListOfItems.Where(_ => _ == item).FirstOrDefault();
                foundItem.ChangeQuantity(item.Quantity);
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

    }
}