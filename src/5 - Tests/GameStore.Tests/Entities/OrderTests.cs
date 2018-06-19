using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Common;
using GameStore.Domain.ValueObjects;
using GameStore.Tests.Mocks;
using Xunit;

namespace GameStore.Tests.Entities
{
    public class OrderTests
    {
        private FakeGameRepository _repository;
        private IList<CartItem> listOfItems = new List<CartItem>();
        private Payment payment;

        public OrderTests()
        {
            _repository = new FakeGameRepository();
            for (int i = 0; i < 10; i++)
            {
                listOfItems.Add(new CartItem(
                    _repository._entities.FirstOrDefault(),
                    1));
            }
        }

        [Fact]
        public void ShouldReturnErrorWhenShoppingCartIsNull()
        {
            var userGuid = Guid.NewGuid();
            payment = new CreditCardPayment(
               "John Doe",
               "123456789",
               DateTime.Now,
               DateTime.Now.AddDays(-1),
               6000,
               6000,
               "John Doe",
               new Email("jd@email.com"));

            var fakeOrder = new Order(new Guid(), null, payment);
            Assert.True(fakeOrder.Nonconformities.Count == 1);
            Assert.Equal(fakeOrder.Nonconformities[0].Property, "order.shoppingCart");
            Assert.Equal(false, fakeOrder.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPaymentIsNull()
        {
            var userGuid = Guid.NewGuid();
            var shoppingCart = new ShoppingCart(userGuid, listOfItems);

            var fakeOrder = new Order(new Guid(), shoppingCart, null);

            Assert.True(fakeOrder.Nonconformities.Count == 1);
            Assert.Equal(fakeOrder.Nonconformities[0].Property, "order.payment");
            Assert.Equal(false, fakeOrder.IsValid);
        }

        [Fact]
        public void ShouldAddSeveralValidationMessages()
        {
            payment = new CreditCardPayment(
               "John Doe",
               "123456789",
               DateTime.Now,
               DateTime.Now.AddDays(-1),
               6000,
               5000,
               "John Doe",
               null);
            var fakeOrder = new Order(new Guid(), null, payment);
            Assert.True(fakeOrder.Nonconformities.Count > 1);
        }
    }
}