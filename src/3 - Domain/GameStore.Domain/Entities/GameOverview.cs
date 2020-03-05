using System;

namespace GameStore.Domain.Entities
{
    public class GameOverview
    {
        public GameOverview(Guid gameId, string html)
        {
            GameId = gameId;
            Html = html;
        }

        public Guid Id { get; protected set; }    
        public Guid GameId { get; protected set; }
        public string Html { get; protected set; }

        public void changeHtml(string html)
        {
            Html = html;
        }
    }
}
