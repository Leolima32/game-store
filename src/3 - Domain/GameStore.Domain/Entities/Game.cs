using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.Enums;
using GameStore.Domain.Entities.ReleationshipEntities;
using System;
using System.Collections.Generic;

namespace GameStore.Domain.Entities
{
    public class Game : Product
    {
        protected Game() {}
        public Game(
            string name,
            string description,
            string shortDescription,
            double score,
            EDepartment department,
            double price,
            DateTime releaseDate
           ) : base(
                name,
                department,
                price,
                description,
                shortDescription)
        {
            ReleaseDate = releaseDate;
            Score = score;
        }

        public DateTime ReleaseDate { get; private set; }
        public double Score { get; private set; }

        public ICollection<GamePlataform> GamePlataforms { get; private set; }
        public ICollection<GameGenre> GameGenres { get; private set; }
        public ICollection<GameDeveloper> GameDevelopers { get; private set; }
        public ICollection<GamePublisher> GamePublishers { get; private set; }
    }
}
