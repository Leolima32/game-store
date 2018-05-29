using GameStore.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Domain.Entities
{
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            if (product != null && quantity >= 0)
            {
                Product = product;
                Quantity = quantity;
            }
            else
            {
                throw new InvalidParameters();
            }
        }

        private Product Product;
        private int Quantity;

        public int GetQuantity()
        {
            return Quantity;
        }

        public Product GetProduct()
        {
            return Product;
        }

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

        public void ChangeQuantity(int value)
        {
            //increase quantity by value
            Quantity += value;
        }
    }
}
