using GameStore.Domain.Entities.Common;
using PaymentContext.Domain.ValueObjects;
using System;

namespace GameStore.Domain.Entities
{
    public class PayPalPayment: Payment
    {
        public PayPalPayment(
            string transactionCode,
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
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}
