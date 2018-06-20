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
    public class Company : BaseEntity
    {
        protected Company() { }

        public Company(CompanyName name, DateTime founded)
        {
            Name = name;
            Founded = founded;

            if (String.IsNullOrEmpty(Name.FantasyName))
                AddNonconformity(new Nonconformity("company.name.fantasyName", "Fantasy Name cannot be null."));
        }

        public CompanyName Name { get; private set; }
        public DateTime Founded { get; private set; }
        public string LogoPath { get; private set; }

        public ICollection<GameDeveloper> GameDevelopers { get; private set; }
        public ICollection<GamePublisher> GamePublishers { get; private set; }

        public void ChangeName(string name) {
            Name = new CompanyName(name);
        }
    }
}
