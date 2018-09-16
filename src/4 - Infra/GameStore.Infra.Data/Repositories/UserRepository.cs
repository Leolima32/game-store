using System.Collections.Generic;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;
using GameStore.Infra.Data.Repositories.Common;

namespace GameStore.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private GameStoreContext _db;
        public UserRepository(GameStoreContext db) : base(db)
        {
            _db = db;
        }
    }
}