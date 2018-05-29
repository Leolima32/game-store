using System;
using System.Linq;
using System.Collections.Generic;

namespace GameStore.Domain.Entities
{
    public class ShoppingCart
    {
        ICollection<CartItem> ListOfItems { get; }
        User User { get; }

        public void AddItem(CartItem item)
        {
            if (!AlreadyContainThisItem(item))
            {
                ListOfItems.Add(item);
            }
            else
            {
                var foundItem = ListOfItems.Where(_ => _ == item).FirstOrDefault();
                foundItem.ChangeQuantity(item.GetQuantity());
            }   
        }

        public void RemoveItem(CartItem item)
        {
            ListOfItems.Remove(item);
        }

        public bool AlreadyContainThisItem (CartItem item)
        {
            return ListOfItems.Where(_ => _.GetProduct() == item.GetProduct()).Count() > 0;
        }

    }
}
