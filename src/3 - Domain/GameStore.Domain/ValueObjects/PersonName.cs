using Flunt.Validations;
using GameStore.Domain.Entities.Common;

namespace GameStore.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        public PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "First name requires a least 3 characters")
                .HasMinLen(LastName, 3, "Name.LastName", "Last name requires a least 3 characters")
                .HasMaxLen(FirstName, 30, "Name.FirstName", "First name requires a most 30 characters")
                .HasMaxLen(LastName, 30, "Name.LastName", "Last name requires a most 30 characters"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
