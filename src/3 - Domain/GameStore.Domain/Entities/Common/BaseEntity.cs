using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.Domain.ValueObjects;

namespace GameStore.Domain.Entities.Common
{

    public abstract class BaseEntity
    {
        
        [NotMapped]
        public IList<Nonconformity> Nonconformities  { get; private set; } = new List<Nonconformity>(); 
        [NotMapped]
        public bool IsInvalid { get { return Nonconformities.Count > 0; } }
        [NotMapped]
        public bool IsValid { get {return Nonconformities.Count == 0; } }

        public BaseEntity() { Id = Guid.NewGuid(); }

        public Guid Id { get; private set; }
        public DateTime CreatedDate{ get; private set; }
        public DateTime LastUpdated { get; private set; }
        public bool Active { get; private set; }

        public void AddNonconformity(Nonconformity nonconformity) {
            Nonconformities.Add(nonconformity);
        }
    }
}
