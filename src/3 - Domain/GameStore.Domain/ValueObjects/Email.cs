using Flunt.Validations;
using GameStore.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace GameStore.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            if(string.IsNullOrEmpty(Address))
                AddNonconformity(new Nonconformity("email.address", "address cannot be empty"));

            if(!Regex.IsMatch(Address,@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                AddNonconformity(new Nonconformity("email.address", "address is not an valid Email"));
        }

        public string Address { get; private set; }
    }
}