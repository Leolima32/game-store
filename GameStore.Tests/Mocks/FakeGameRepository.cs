using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Enums;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;
using GameStore.Infra.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Tests.Mocks
{
    public class FakeGameRepository : Repository<Game>, IGameRepository
    {
        private GameStoreContext _db;
        private IList<Game> _games;
        public FakeGameRepository(GameStoreContext db) : base(db)
        {
            _db = db;
            _games = new List<Game>();
            for (var i = 0; i <= 10; i++)
            {
                _games.Add(new Game("Fictional Tests","New fictional game.",
                "new fictional games.",
                9.8, EDepartment.Game, 89.99, new DateTime(2018, 1, 0)));
            }
        }

        public IEnumerable<Game> SearchByName(string search)
        {
            return _games.Where(p => p.Name.Contains(search));
        }

        public async Task<IEnumerable<dynamic>> GetAllGamesWithDevelopersAsync()
        {
            var query = from game in _games.AsQueryable()
                        select new { game.Name, game.Description, game.ShortDescription, game.Score, game.Department, game.Price, game.ReleaseDate };

            return await query.ToListAsync();
        }

        public override async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _db.Games
                      .Include(_ => _.GameDevelopers)
                      .ThenInclude(_ => _.Developer)
                      .Include(_ => _.GameGenres)
                      .ThenInclude(_ => _.Genre)
                      .Include(_ => _.GamePlataforms)
                      .ThenInclude(_ => _.Plataform)
                      .Include(_ => _.GamePublishers)
                      .ThenInclude(_ => _.Publisher)
                      .ToListAsync();
        }

        public override async Task<Game> GetByIdAsync(Guid id)
        {
            return await _db.Games
                      .Include(_ => _.GameDevelopers)
                      .ThenInclude(_ => _.Developer)
                      .Include(_ => _.GameGenres)
                      .ThenInclude(_ => _.Genre)
                      .Include(_ => _.GamePlataforms)
                      .ThenInclude(_ => _.Plataform)
                      .Include(_ => _.GamePublishers)
                      .ThenInclude(_ => _.Publisher)
                      .Where(_ => _.Id == id)
                      .FirstOrDefaultAsync();
        }
    }
}
