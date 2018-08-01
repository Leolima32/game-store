using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using GameStore.Application.Interfaces;
using GameStore.Application.ViewModels;
using GameStore.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Application.DTOS.Games;

namespace GameStore.Application.Services
{
    public class GameServices : IGameServices
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;
        public GameServices(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<IEnumerable<dynamic>> GetAllGamesWithDevelopersAsync()
        {
            return await _unit.Games.GetAllGamesWithDevelopersAsync();
        }

        public async Task<IEnumerable<GameViewModel>> GetAllGames()
        {
            return _mapper.Map<IEnumerable<GameViewModel>>(await _unit.Games.GetAllAsync());
        }

        public async Task<GameViewModel> GetGameById(Guid gameId)
        {
            return _mapper.Map<GameViewModel>(await _unit.Games.GetByIdAsync(gameId));
        }
        public void InsertGame(AddOrUpdateGameDTO gamevm)
        {
            _unit.Games.Add(_mapper.Map<Game>(gamevm));
        }
        public void UpdateGame(AddOrUpdateGameDTO gamevm)
        {
            _unit.Games.Update(_mapper.Map<Game>(gamevm));
        }
        public void DeleteGame(Guid id)
        {
            _unit.Games.Remove(id);
        }

        public async Task<IEnumerable<GameViewModel>> GetBestRatedGames()
        {
            return _mapper.Map<IEnumerable<GameViewModel>>(await _unit.Games.GetBestRatedGamesAsync());
        }
    }
}