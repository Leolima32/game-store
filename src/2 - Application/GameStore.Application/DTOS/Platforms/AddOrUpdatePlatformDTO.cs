using System;

namespace GameStore.Application.DTOS.Platforms
{
    public class AddOrUpdatePlatformDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}