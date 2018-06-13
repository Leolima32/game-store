using System;
using GameStore.Domain.Entities;
using GameStore.Domain.ValueObjects;
using Xunit;

namespace GameStore.Tests.Entities {
    public class CreditCardPaymentTests {
        [Fact]
        public void ShouldReturnErrorWhenPaymentDayIsExpired() {
            var payment = new CreditCardPayment(
               "John Doe",
               "123456789",
               DateTime.Now,
               DateTime.Now.AddDays(-1),
               6000,
               6000,
               "John Doe",
               new Email("jd@email.com"));
            Assert.True(payment.Nonconformities.Count == 1);
            Assert.Equal(payment.Nonconformities[0].Property, "payment.expireDate");
            Assert.Equal(false, payment.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenTotalPaidIsLessThanTotalValue() {
            var payment = new CreditCardPayment(
               "John Doe",
               "123456789",
               DateTime.Now,
               DateTime.Now.AddDays(1),
               6000,
               5000,
               "John Doe",
               new Email("jd@email.com"));
            Assert.True(payment.Nonconformities.Count == 1);
            Assert.Equal(payment.Nonconformities[0].Property, "payment.totalPaid");
            Assert.Equal(false, payment.IsValid);
        }
    }
}
