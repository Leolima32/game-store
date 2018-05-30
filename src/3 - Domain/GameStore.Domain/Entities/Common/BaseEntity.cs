using System;

namespace GameStore.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public BaseEntity() { Id = Guid.NewGuid(); }

        public Guid Id { get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Active { get; set; }
    }
}
