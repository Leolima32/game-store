using GameStore.Domain.Entities.Common;
using GameStore.Domain.ValueObjects;
using System;


namespace GameStore.Domain.Entities
{
    public class CreditCardPayment: Payment
    {
        protected CreditCardPayment() { }
        public CreditCardPayment(
            string cardHolderName,
            string cardNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Email email) : base(
                paidDate,
                expireDate,
                total,
                totalPaid,
                payer,
                email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
    }
}
