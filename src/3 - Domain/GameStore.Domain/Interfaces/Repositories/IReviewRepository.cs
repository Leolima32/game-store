using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetReviewByProductId(Guid productId);
        IEnumerable<Review> GetReviewByUserId(Guid userId);
    }
}
