using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Common;
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
    public class FakeGameRepository : FakeRepository<Game>, IGameRepository
    {
        private GameStoreContext _db;
        // private IList<Game> _games;
        public FakeGameRepository()
        {
            for (var i = 0; i < 10; i++)
            {
                base._entities.Add(new Game("Fictional Tests", "New fictional game.",
                "new fictional games.",
                9.8, EDepartment.Game, 89.99, new DateTime(2018, 1, 1)));
            }
        }

        public async Task<IEnumerable<dynamic>> GetAllGamesWithDevelopersAsync()
        {
            var query = from game in _db.Games
                        select new { game };

            return await query.ToListAsync();
        }

        public IEnumerable<Game> SearchByName(string search)
        {
            return _db.Games.Where(p => p.Name.Contains(search));
        }
    }
}
