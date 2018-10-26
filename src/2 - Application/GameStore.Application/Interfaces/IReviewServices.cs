using System;
using System.Collections.Generic;
using GameStore.Application.DTOS.Reviews;
using GameStore.Application.ViewModels;

namespace GameStore.Application.Interfaces
{
    public interface IReviewServices {
        IEnumerable<ReviewListViewModel> GetReviewByProductId(Guid productId);
        IEnumerable<ReviewListViewModel> GetReviewByUserId(Guid userId);
        Guid Save(AddOrUpdateReviewDTO command);
        void Update(AddOrUpdateReviewDTO command);
        void Delete(Guid id);
    }
}