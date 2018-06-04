using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGameRepository _gameRepository;
        private ICompanyRepository _companyRepository;
        private IGenreRepository _genreRepository;
        private IPlataformRepository _plataformRepository;
        private IUserRepository _userRepository;

        private readonly GameStoreContext _db;
        public UnitOfWork(GameStoreContext db) { _db = db; }

        public IGameRepository Games
        {
            get
            {
                if (_gameRepository == null)
                {
                    _gameRepository = new FakeRepository(_db);
                }
                return _gameRepository;
            }
        }

        public ICompanyRepository Companies
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new ComapanyRepository(_db);
                }
                return _companyRepository;
            }
        }

        public IGenreRepository Genres
        {
            get
            {
                if (_genreRepository == null)
                {
                    _genreRepository = new GenreRepository(_db);
                }
                return _genreRepository;
            }
        }

        public IPlataformRepository Plataforms
        {
            get
            {
                if (_plataformRepository == null)
                {
                    _plataformRepository = new PlataformRepository(_db);
                }
                return _plataformRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }
                return _userRepository;
            }
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
