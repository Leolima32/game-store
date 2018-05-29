using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.Enums;

namespace GameStore.Domain.Entities
{
    public abstract class Product: BaseEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
