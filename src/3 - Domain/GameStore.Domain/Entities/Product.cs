using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.Enums;

namespace GameStore.Domain.Entities
{
    public abstract class Product : BaseEntity
    {
        public Product(string name, ECategory category, double price, string description, string shortDescription)
        {
            Name = name;
            Category = category;
            Price = price;
            Description = description;
            ShortDescription = shortDescription;
        }

        public string Name { get; private set; }
        public ECategory Category { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string ImageUrl { get; private set; }
    }
}
