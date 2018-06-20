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
    public class Plataform: BaseEntity
    {
        public Plataform(string name)
        {
            Name = name;

            if (String.IsNullOrEmpty(Name))
                AddNonconformity(new Nonconformity("plataform.name", "Plataform Name cannot be null or empty."));
        }

        public string Name { get; private set; }
        public ICollection<GamePlataform> GamePlataforms { get; set; }

        public void ChangeName(string name) {
            Name = name;
        }
    }
}
