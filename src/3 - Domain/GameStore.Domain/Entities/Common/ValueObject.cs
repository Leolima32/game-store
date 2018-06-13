using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.Domain.ValueObjects;

namespace GameStore.Domain.Entities.Common
{
    public class ValueObject
    {
        [NotMapped]
        public IList<Nonconformity> Nonconformities  { get; private set; } = new List<Nonconformity>(); 
        [NotMapped]
        public bool IsInvalid { get { return Nonconformities.Count > 0; } }
        [NotMapped]
        public bool IsValid { get {return Nonconformities.Count == 0; } }

        public void AddNonconformity(Nonconformity nonconformity) {
            Nonconformities.Add(nonconformity);
        }
    }
}
