using Flunt.Validations;
using GameStore.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        public PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if(FirstName.Length < 3)
                AddNonconformity(new Nonconformity("personName.firstName", "First name requires a least 3 characters."));

            if(FirstName.Length > 30)
                AddNonconformity(new Nonconformity("personName.firstName", "First name requires a most 30 characters"));

            if(LastName.Length < 3)
                AddNonconformity(new Nonconformity("personName.lastName","Last name requires a least 3 characters."));
            
            if(LastName.Length > 30)
                AddNonconformity(new Nonconformity("personName.lastName","Last name requires a most 30 characters."));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
