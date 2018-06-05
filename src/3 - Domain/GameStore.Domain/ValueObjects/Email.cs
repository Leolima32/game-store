using Flunt.Validations;
using GameStore.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            //AddNotifications(new Contract()
            //    .Requires()
            //    .IsEmail(Address, "Email.Address", "Invalid E-mail")
            //);
        }

        public string Address { get; private set; }
    }
}