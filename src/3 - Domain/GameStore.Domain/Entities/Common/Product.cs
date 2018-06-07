using GameStore.Domain.Entities.Enums;
using GameStore.Domain.ValueObjects;

namespace GameStore.Domain.Entities.Common
{
    public abstract class Product : BaseEntity
    {
        public Product(string name, EDepartment department, double price, string description, string shortDescription)
        {
            Name = name;
            Department = department;
            Price = price;
            Description = description;
            ShortDescription = shortDescription;

            if (string.IsNullOrEmpty(name))
                AddNonconformity(new Nonconformity("product.name", "Name cannot be null or empty"));
            if (string.IsNullOrEmpty(description))
                AddNonconformity(new Nonconformity("product.description", "Description cannot be null or empty"));
            if(Price <= 0)
                AddNonconformity(new Nonconformity("product.price","Price cannot be 0 or a negative number"));
        }

        public string Name { get; private set; }
        public EDepartment Department { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string ImageUrl { get; private set; }
    }
}
