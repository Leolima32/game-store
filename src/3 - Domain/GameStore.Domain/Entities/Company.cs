using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GameStore.Domain.Entities.Common;
using GameStore.Domain.Entities.ReleationshipEntities;

namespace GameStore.Domain.Entities
{
    public class Company: BaseEntity
    {
        public Company(string name, string country, DateTime founded)
        {
            Name = name;
            Country = country;
            Founded = founded;
        }

        public string Name { get; private set; }
        public string Country { get; private set; }
        public DateTime Founded { get; private set; }

        public ICollection<GameDeveloper> GameDevelopers { get; private set; }
        public ICollection<GamePublisher> GamePublishers { get; private set; }
    }
}
