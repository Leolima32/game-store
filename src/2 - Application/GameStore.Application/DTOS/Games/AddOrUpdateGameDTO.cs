using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GameStore.Domain.Entities.ReleationshipEntities;

namespace GameStore.Application.DTOS.Games
{
    public class AddOrUpdateGameDTO
    {
        public Guid Id { get; set; }
        [Required()]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required()]
        public double Score { get; set; }
        [Required()]
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Developers required.")]
        public ICollection<GameDeveloper> GameDevelopers { get; set; }
        [Required(ErrorMessage = "Plataforms required.")]
        public ICollection<GamePlataform> GamePlataforms { get; set; }
        [Required(ErrorMessage = "Genres required.")]
        public ICollection<GameGenre> GameGenres { get; set; }
        public ICollection<GamePublisher> GamePublishers { get; set; }
    }
}