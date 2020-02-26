using System;

namespace GameStore.Domain.Entities
{
    public class GameOverview
    {
        public Guid Id { get; protected set; }    
        public Guid GameId { get; protected set; }
        public string Html { get; protected set; }
    }
}
