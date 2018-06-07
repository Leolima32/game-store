using GameStore.Domain.Entities.Common;
using GameStore.Domain.Exceptions;
using GameStore.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        protected CartItem() { }
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;

            if (product is null)
                AddNonconformity(new Nonconformity("cartItem.product", "Product cannot be null."));
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public double ItemPrice
        {
            get
            {
                if (Product != null)
                {
                    return Product.Price;
                }
                else
                {
                    throw new ProductNotExistent();
                }
            }
        }

        public double TotalValue
        {
            get
            {
                if (Quantity > 1)
                {
                    return ItemPrice * Quantity;
                }
                else
                {
                    return ItemPrice;
                }
            }
        }

        public void ChangeQuantityBy(int value)
        {
            //increase quantity by value
            Quantity += value;
        }
    }
}
