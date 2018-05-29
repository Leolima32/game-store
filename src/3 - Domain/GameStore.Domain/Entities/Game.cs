using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.ReleationshipEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Domain.Entities
{
    public class Game : Product
    {
        public DateTime ReleaseDate { get; set; }
        public double Score { get; set; }

        public ICollection<GamePlataform> GamePlataforms { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; }
        public ICollection<GameDeveloper> GameDevelopers { get; set; }
        public ICollection<GamePublisher> GamePublishers { get; set; }
    }
}
