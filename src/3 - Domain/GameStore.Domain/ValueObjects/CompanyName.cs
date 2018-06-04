using Flunt.Validations;
using GameStore.Domain.Entities.Common;

namespace GameStore.Domain.ValueObjects
{
    public class CompanyName : ValueObject
    {
        public CompanyName(string name)
        {
            Name = name;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "CompanyName.Name", "Name requires a least 3 characters")
                .HasMaxLen(Name, 30, "CompanyName.Name", "Name requires a most 50 characters"));
        }

        public string Name { get; private set; }
    }
}
