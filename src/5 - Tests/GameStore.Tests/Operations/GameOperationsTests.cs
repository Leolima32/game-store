using System;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Enums;
using GameStore.Tests.Mocks;
using Xunit;

namespace GameStore.Tests.Operations
{
    public class GameOperationsTests
    {
        private FakeGameRepository _repository;
        public GameOperationsTests()
        {
            _repository = new FakeGameRepository();
        }

        [Fact]
        public void ShouldAddANewGame() {
            int countBefore = _repository._entities.Count;
            _repository.Add(new Game("Fictional Tests", "New fictional game.",
                "new fictional games.",
                EDepartment.Game, 89.99, new DateTime(2018, 1, 1),5));
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore + 1);
        }

        [Fact]
        public void ShoulDeleteGame() {
            int countBefore = _repository._entities.Count;
            Guid id = _repository._entities.FirstOrDefault().Id;
            _repository.Remove(id);
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore - 1);
        }

        [Fact]
        public void ShouldUpdateGame() {
            var game = _repository._entities.FirstOrDefault();
            game.ChangeName("new super cool name");
            _repository.Update(game);
            Assert.True(_repository._entities.FirstOrDefault().Name == "new super cool name");
        }

        [Fact]
        public void ShouldGetGameById() {
            var game = _repository._entities.FirstOrDefault();
            var id = game.Id;
            var selectedGame = _repository.GetById(id);
            Assert.Equal(game,selectedGame);
        }
    }
}