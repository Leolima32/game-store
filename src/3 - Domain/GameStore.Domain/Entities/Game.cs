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
            EDepartment department,
            double price,
            DateTime releaseDate,
            int availableQuantity
           ) : base(
                name,
                department,
                price,
                description,
                shortDescription,
                availableQuantity)
        {
            ReleaseDate = releaseDate;
        }

        public DateTime ReleaseDate { get; private set; }
        public string CoverImageRelativePath {get; private set; }

        public ICollection<GamePlatform> GamePlatforms { get; private set; }
        public ICollection<GameGenre> GameGenres { get; private set; }
        public ICollection<GameDeveloper> GameDevelopers { get; private set; }
        public ICollection<GamePublisher> GamePublishers { get; private set; }

        public void ChangeCoverImagePath(string path) {
            CoverImageRelativePath = path;
        }

        public void ChangeThumbImagePath(string path) {
            ImageRelativePath = path;
        }

        public void ChangeReleaseDate(DateTime date) {
            ReleaseDate = date;
        }

        public void ChangeDevelopersList(ICollection<GameDeveloper> gameDevelopers) {
            GameDevelopers = gameDevelopers;
        }

        public void ChangePublishersList(ICollection<GamePublisher> gamePublishers) {
            GamePublishers = gamePublishers;
        }

        public void ChangeGenresList(ICollection<GameGenre> gameGenres) {
            GameGenres = gameGenres;
        }

        public void ChangePlatformsList(ICollection<GamePlatform> gamePlatforms) {
            GamePlatforms = gamePlatforms;
        }
    }
}
