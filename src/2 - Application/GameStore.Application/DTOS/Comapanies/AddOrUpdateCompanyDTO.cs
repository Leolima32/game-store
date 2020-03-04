using System;

namespace GameStore.Application.DTOS.Companies
{
    public class AddOrUpdateCompanyDTO {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Founded { get; set; }
    }
}