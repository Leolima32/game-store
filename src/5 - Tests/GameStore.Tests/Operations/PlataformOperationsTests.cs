using System;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Tests.Mocks;
using Xunit;

namespace GameStore.Tests.Operations
{
    public class PlataformOperationsTests
    {
        private FakePlataformRepository _repository;
        public PlataformOperationsTests()
        {
            _repository = new FakePlataformRepository();
        }

        [Fact]
        public void ShouldAddANewPlataform()
        {
            int countBefore = _repository._entities.Count;
            _repository.Add(new Plataform("new fake console"));
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore + 1);
        }

        [Fact]
        public void ShoulDeletePlataform()
        {
            int countBefore = _repository._entities.Count;
            Guid id = _repository._entities.FirstOrDefault().Id;
            _repository.Remove(id);
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore - 1);
        }

        [Fact]
        public void ShouldUpdatePlataform()
        {
            var plataform = _repository._entities.FirstOrDefault();
            plataform.ChangeName("new super cool name");
            _repository.Update(plataform);
            Assert.True(_repository._entities.FirstOrDefault().Name == "new super cool name");
        }

        [Fact]
        public void ShouldGetPlataformById()
        {
            var plataform = _repository._entities.FirstOrDefault();
            var id = plataform.Id;
            var selectedPlataform = _repository.GetById(id);
            Assert.Equal(plataform, selectedPlataform);
        }
    }
}