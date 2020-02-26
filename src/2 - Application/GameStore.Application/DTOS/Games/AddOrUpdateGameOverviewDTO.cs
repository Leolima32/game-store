using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Application.DTOS.Games
{
    public class AddOrUpdateGameOverviewDTO
    {
        public Guid GameId { get; set; }
        public string Html { get; set; }
    }
}
