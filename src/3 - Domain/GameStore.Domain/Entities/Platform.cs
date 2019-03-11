using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.ReleationshipEntities;
using GameStore.Domain.ValueObjects;

namespace GameStore.Domain.Entities
{
    public class Platform: BaseEntity
    {
        public Platform(string name)
        {
            Name = name;

            if (String.IsNullOrEmpty(Name))
                AddNonconformity(new Nonconformity("platform.name", "Platform Name cannot be null or empty."));
        }

        public string Name { get; private set; }
        public ICollection<GamePlatform> GamePlatforms { get; set; }

        public void ChangeName(string name) {
            Name = name;
        }
    }
}
