using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Application.DTOS.Reviews
{
    public class AddOrUpdateReviewDTO
    {
        public Guid? Id { get; set; }
        public string Review { get; set; }
        [MaxLength(5)]
        [MinLength(0)]
        public float Rating { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}