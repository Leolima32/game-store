using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Application.DTOS.Platforms;
using GameStore.Application.Interfaces;
using GameStore.Application.ViewModels;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;

namespace GameStore.Application.Services
{
    public class PlatformServices: IPlatformServices
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;
        public PlatformServices(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlatformViewModel>> GetAllPlatforms()
        {
            return _mapper.Map<IEnumerable<PlatformViewModel>>(await _unit.Platforms.GetAllAsync());
        }

        public async Task<PlatformViewModel> GetPlatformById(Guid id)
        {
            return _mapper.Map<PlatformViewModel>(await _unit.Games.GetByIdAsync(id));
        }
        public void InsertPlatform(AddOrUpdatePlatformDTO platform)
        {
            _unit.Platforms.Add(_mapper.Map<Platform>(platform));
        }
        public void UpdatePlatform(AddOrUpdatePlatformDTO platform)
        {
            _unit.Platforms.Update(_mapper.Map<Platform>(platform));
        }
        public void DeletePlatform(Guid id)
        {
            _unit.Platforms.Remove(id);
        }
    }
}