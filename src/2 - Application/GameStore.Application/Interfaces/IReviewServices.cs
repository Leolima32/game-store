using System;
using System.Collections.Generic;
using GameStore.Application.Commands;
using GameStore.Application.DTOS.Reviews;
using GameStore.Domain.Entities;

namespace GameStore.Application.Interfaces {
    public interface IReviewServices {
        IEnumerable<Review> GetReviewByProductId(Guid productId);
        IEnumerable<Review> GetReviewByUserId(Guid userId);
        Guid Save(AddOrUpdateReviewDTO command);
        void Update(AddOrUpdateReviewDTO command);
        void Delete(Guid id);
    }
}