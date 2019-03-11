using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Application.DTOS.Genres;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.ReleationshipEntities;

namespace GameStore.Application.ViewModels
{
    public class PlatformViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private ICollection<GamePlatform> GamePlatforms { get; set; }

        public IEnumerable<dynamic> GamesOfThisPlatform
        {
            get
            {
                return GamePlatforms.Select(e => new
                {
                    Id = e.Game.Id,
                    Name = e.Game.Name,
                });
            }
        }
    }
}