using GameStore.Domain.Entities;
using GameStore.Infra.Data.Context;
using GameStore.Infra.Data.Repositories;
using GameStore.Tests.Mocks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameStore.Tests
{
    public class GameSelectsTests
    {
        private FakeGameRepository _repository;

        public GameSelectsTests()
        {
            
            _repository = new FakeGameRepository();
        }

        [Fact]
        public void ShoulReturnGamesList()
        {
            var list = _repository.GetAllAsync().GetAwaiter().GetResult();
            var count = list.Count();
            Assert.True(count == 10);
        }
    }
}

