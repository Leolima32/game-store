using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.ReleationshipEntities;
using GameStore.Domain.ValueObjects;

namespace GameStore.Application.ViewModels
{
    public class CompanyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public string LogoPath { get; set; }

        private ICollection<GameDeveloper> GameDevelopers { get; set; }
        private ICollection<GamePublisher> GamePublishers { get; set; }

        public IEnumerable<dynamic> DevelopedGames
        {
            get
            {
                return GameDevelopers.Select(e => new
                {
                    Id = e.Game.Id,
                    Name = e.Game.Name
                });
            }
        }

        public IEnumerable<dynamic> PublishedGames
        {
            get
            {
                return GamePublishers.Select(p => new
                {
                    Id = p.Game.Id,
                    Name = p.Game.Name
                });
            }
        }
    }
}