using GameStore.Domain.Entities.Enums;

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
        }

        public string Name { get; private set; }
        public EDepartment Department { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string ImageUrl { get; private set; }
    }
}
