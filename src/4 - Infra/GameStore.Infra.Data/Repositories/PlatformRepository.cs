using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;
using GameStore.Infra.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infra.Data.Repositories
{
    public class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        private GameStoreContext _db;
        public PlatformRepository(GameStoreContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Platform>> GetAllAsync() {
            return await  _db.Platforms
                            .Include(x => x.GamePlatforms)
                            .ThenInclude(x => x.Game)
                            .ToListAsync();
        }
    }
}