using Flunt.Notifications;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GameStore.Application.Commands
{
    public class FinishCreditCardOrderCommand: Notifiable
    {
        public Guid UserId { get; private set; }
        private IList<CartItem> _listOfItems = new List<CartItem>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }

        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public string PayerEmail { get; set; }


        public void Validate() { }
    }
}
