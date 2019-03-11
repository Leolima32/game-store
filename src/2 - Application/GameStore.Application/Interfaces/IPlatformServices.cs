using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Application.DTOS.Platforms;
using GameStore.Application.ViewModels;

namespace GameStore.Application.Interfaces
{
    public interface IPlatformServices
    {
         Task<IEnumerable<PlatformViewModel>> GetAllPlatforms();
        Task<PlatformViewModel> GetPlatformById(Guid platform);
        void InsertPlatform(AddOrUpdatePlatformDTO platform);
        void UpdatePlatform(AddOrUpdatePlatformDTO platform);
        void DeletePlatform(Guid id);
    }
}