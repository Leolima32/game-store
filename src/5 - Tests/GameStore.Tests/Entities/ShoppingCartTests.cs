using GameStore.Domain.Entities;
using GameStore.Tests.Mocks;
using Xunit;
using System.Linq;
using System;
using System.Collections.Generic;

namespace GameStore.Tests.Entities
{
    public class ShoppingCartTests
    {
        private FakeGameRepository _repository;
        private IList<CartItem> listOfItems = new List<CartItem>();
        public ShoppingCartTests()
        {
            _repository = new FakeGameRepository();
            for (int i = 0; i < 3; i++)
            {
                listOfItems.Add(new CartItem(
                    _repository._entities.FirstOrDefault(),
                    1));
            }
        }
        [Fact]
        public void ShouldReturnErrorWhenCartItemQuantityExceedAvaliableInStock()
        {
            var product = _repository._entities.FirstOrDefault();
            var cartItem = new CartItem(product, 15);
            var shoppingCart = new ShoppingCart(Guid.NewGuid(), cartItem);
            Assert.True(shoppingCart.Nonconformities.Count == 1);
            Assert.Equal(shoppingCart.Nonconformities[0].Property, "shoppingCart.quantity");
            Assert.Equal(false, shoppingCart.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenAddingAnValidItemToShoppingCart()
        {
            var product = _repository._entities.FirstOrDefault();
            var cartItem = new CartItem(product, 1);
            var shoppingCart = new ShoppingCart(Guid.NewGuid(), cartItem);
            Assert.True(shoppingCart.Nonconformities.Count == 0);
            Assert.Equal(true, shoppingCart.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenAddingAnListOfItemsToShoppingCart()
        {
            var shoppingCart = new ShoppingCart(Guid.NewGuid(), listOfItems);
            Assert.True(shoppingCart.Nonconformities.Count == 0);
            Assert.Equal(true, shoppingCart.IsValid);
        }
    }
}