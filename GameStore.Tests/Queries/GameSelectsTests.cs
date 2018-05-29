using GameStore.Domain.Entities;
using GameStore.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameStore.Tests
{
    public class GameSelectsTests
    {
        private GameRepository _repository;

        public GameSelectsTests(GameRepository repository)
        {
            _repository = repository;
        }

        [Fact]
        public void QueryAllGames()
        {
            var list = _repository.GetAllAsync().GetAwaiter().GetResult();
            Assert.True(list.Count() > 0);
        }
    }
}

