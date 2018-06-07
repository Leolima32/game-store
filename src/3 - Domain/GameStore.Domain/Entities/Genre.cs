using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.ReleationshipEntities;
using GameStore.Domain.ValueObjects;
using System;
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
            if (String.IsNullOrEmpty(name))
                AddNonconformity(new Nonconformity("genre.name", "Genre Name cannot be null."));
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<GameGenre> GameGenres { get; private set; }
    }
}
