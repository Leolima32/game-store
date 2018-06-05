using GameStore.Domain.Entities;
using GameStore.Infra.Data.Context;
using GameStore.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameStore.Tests
{
    public class GameSelectsTests
    {
        private FakeRepository _repository;

        public GameSelectsTests(GameStoreContext db)
        {
            _repository = new FakeRepository(db);
        }

        [Fact]
        public void ShoulReturnGamesList()
        {
            var list = _repository.GetAllAsync().GetAwaiter().GetResult();
            Assert.True(list.Count() == 10);
        }
    }
}

