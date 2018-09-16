using System;
using GameStore.Domain.Entities.Common;

namespace GameStore.Domain.Entities
{
    public class Review: BaseEntity
    {
        public string Considerations { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public float Rating { get; set; }
    }
}