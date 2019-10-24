using GameStore.Domain.Entities;
using GameStore.Domain.Entities.ReleationshipEntities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;
using GameStore.Infra.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace GameStore.Infra.Data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private GameStoreContext _db;
        public GameRepository(GameStoreContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Game> SearchByName(string search)
        {
            return _db.Games.Where(p => p.Name.Contains(search));
        }

        public async Task<IEnumerable<dynamic>> GetAllGamesWithDevelopersAsync()
        {
            var query = from game in _db.Games
                        select new { game };

            return await query.ToListAsync();
        }

        
        public async Task<IEnumerable<Game>> GetAllGamesFromThisGenreAsync(Guid genreId)
        {
            return await _db.Games
                      .Include(_ => _.GameDevelopers)
                      .ThenInclude(_ => _.Developer)
                      .Include(_ => _.GameGenres)
                      .ThenInclude(_ => _.Genre)
                      .Include(_ => _.GamePlatforms)
                      .ThenInclude(_ => _.Platform)
                      .Include(_ => _.GamePublishers)
                      .ThenInclude(_ => _.Publisher)
                      .Where(_ => _.GameGenres.Any(x => x.GenreId == genreId))
                      .ToListAsync();
        }

        public override async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _db.Games
                      .Include(_ => _.GameDevelopers)
                      .ThenInclude(_ => _.Developer)
                      .Include(_ => _.GameGenres)
                      .ThenInclude(_ => _.Genre)
                      .Include(_ => _.GamePlatforms)
                      .ThenInclude(_ => _.Platform)
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
                      .Include(_ => _.GamePlatforms)
                      .ThenInclude(_ => _.Platform)
                      .Include(_ => _.GamePublishers)
                      .ThenInclude(_ => _.Publisher)
                      .Include(_ => _.Reviews)
                      .Where(_ => _.Id == id)
                      .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Game>> GetBestRatedGamesAsync()
        {
            var query = (from games in _db.Games
                         orderby games.UsersScore descending
                         select games).Take(5);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetBestSellerGamesAsync()
        {
            return await Task.Run(() =>
            {
                return (
                from cartItems in _db.CartItems
                join carts in _db.ShoppingCarts on cartItems.ShoppingCartId equals carts.Id
                join orders in _db.Orders on carts.Id equals orders.ShoppingCartId
                group cartItems by cartItems.ProductId into ctGroup
                let count = ctGroup.Count()
                join games in _db.Games on ctGroup.Key equals games.Id
                orderby count descending
                select games
                ).Take(5);
            });
        }

        public override void Update(Game obj)
        {
            Game game = _db.Games.Include(_ => _.GameDevelopers)
                      .ThenInclude(_ => _.Developer)
                      .Include(_ => _.GameGenres)
                      .ThenInclude(_ => _.Genre)
                      .Include(_ => _.GamePlatforms)
                      .ThenInclude(_ => _.Platform)
                      .Include(_ => _.GamePublishers)
                      .ThenInclude(_ => _.Publisher).FirstOrDefault(x => x.Id == obj.Id);
            if (game is null)
                throw new ArgumentException();

            // var result = _db.GameDevelopers.FromSql($"SELECT FROM gameDevelopers WHERE GameId = {obj.Id}").ToList();

            game.ChangeName(obj.Name);
            game.ChangePrice(obj.Price);
            game.ChangeReleaseDate(obj.ReleaseDate);
            game.ChangeDescription(obj.Description);
            game.ChangeShortDescription(obj.ShortDescription);
            game.ChangeDevelopersList(obj.GameDevelopers);
            game.ChangePublishersList(obj.GamePublishers);
            game.ChangeGenresList(obj.GameGenres);
            game.ChangePlatformsList(obj.GamePlatforms);
            _db.SaveChanges();
        }

    }
}