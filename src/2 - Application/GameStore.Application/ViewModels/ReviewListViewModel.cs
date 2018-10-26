using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Application.ViewModels
{
    public class ReviewListViewModel
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public double Rating { get; set; }
        public string Considerations { get; set; }
    }
}
