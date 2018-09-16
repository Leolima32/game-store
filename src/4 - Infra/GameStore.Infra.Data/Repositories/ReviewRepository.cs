using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;
using GameStore.Infra.Data.Repositories.Common;

namespace GameStore.Infra.Data.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private GameStoreContext _db;
        public ReviewRepository(GameStoreContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Review> GetReviewByProductId(Guid productId)
        {
            return from review in _db.Reviews
                   where review.ProductId == productId
                   select review;
        }

        public IEnumerable<Review> GetReviewByUserId(Guid userId)
        {
            return from review in _db.Reviews
                   where review.UserId == userId
                   select review;
        }
    }
}