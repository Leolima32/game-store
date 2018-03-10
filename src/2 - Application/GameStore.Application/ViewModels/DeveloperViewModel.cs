using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Application.DTOS.Developers;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.ReleationshipEntities;

namespace GameStore.Application.ViewModels
{
    public class DeveloperViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundedDate { get; set; }
        public string Country { get; set; }

        private ICollection<GameDeveloper> GameDevelopers { get; set; }

        public IEnumerable<dynamic> DevelopedGames
        {
            get
            {
                return GameDevelopers.Select(e => new
                {
                    Id = e.Game.Id,
                    Name = e.Game.Name,
                });
            }
        }
    }
}