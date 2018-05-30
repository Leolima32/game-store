using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.ReleationshipEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameStore.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public Genre(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<GameGenre> GameGenres { get; private set; }
    }
}
