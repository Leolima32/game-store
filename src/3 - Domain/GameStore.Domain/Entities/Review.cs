using System;
using GameStore.Domain.Entities.Common;

namespace GameStore.Domain.Entities
{
    public class Review: BaseEntity
    {
        public Review(Guid userId, Guid productId, double rating)
        {
            UserId = userId;
            ProductId = productId;
            Rating = rating;
        }

        public Review(Guid userId, Guid productId, double rating, string considerations)
        {
            UserId = userId;
            ProductId = productId;
            Rating = rating;
            Considerations = considerations;
        }

        public string Considerations { get; private set; }
        public Guid UserId { get; private set; }
        public double Rating { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; set; }
    }
}