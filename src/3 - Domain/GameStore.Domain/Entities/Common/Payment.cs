using System;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;
using GameStore.Domain.ValueObjects;

namespace GameStore.Domain.Entities.Common
{
    public abstract class Payment : BaseEntity
    {
        protected Payment() { }
        public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Email = email;


            if(Total is 0)
                AddNonconformity(new Nonconformity("payment.total", "total value cannot be 0."));

            if(TotalPaid < Total)
                AddNonconformity(new Nonconformity("payment.totalPaid", "total paid cannot be less than total value."));

            if(email is null)
                AddNonconformity(new Nonconformity("payment.email","email cannot be null."));
            
            if(expireDate < DateTime.Today)
                AddNonconformity(new Nonconformity("payment.expireDate","the date limit for this payment is already expired."));
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