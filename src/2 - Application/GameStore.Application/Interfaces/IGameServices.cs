using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Application.DTOS.Games;
using GameStore.Application.ViewModels;

namespace GameStore.Application.Interfaces
{
    public interface IGameServices
    {
        Task<IEnumerable<GameDetailViewModel>> GetAllGames();
        Task<IEnumerable<dynamic>> GetAllGamesWithDevelopersAsync();
        Task<GameDetailViewModel> GetGameById(Guid game);
        void InsertGame(AddOrUpdateGameDTO game);
        void UpdateGame(AddOrUpdateGameDTO game);
        void DeleteGame(Guid id);
        Task<IEnumerable<GameDetailViewModel>> GetBestRatedGames();
    }
}