using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace GameStore.Domain.Entities.Common
{
    public abstract class Payment : BaseEntity
    {
        public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "total value cannot be 0")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "total paid cannot be less than total value")
            );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public Email Email { get; private set; }
    }
}