using System;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Tests.Mocks;
using Xunit;

namespace GameStore.Tests.Operations
{
    public class PlatformOperationsTests
    {
        private FakePlatformRepository _repository;
        public PlatformOperationsTests()
        {
            _repository = new FakePlatformRepository();
        }

        [Fact]
        public void ShouldAddANewPlatform()
        {
            int countBefore = _repository._entities.Count;
            _repository.Add(new Platform("new fake console"));
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore + 1);
        }

        [Fact]
        public void ShoulDeletePlatform()
        {
            int countBefore = _repository._entities.Count;
            Guid id = _repository._entities.FirstOrDefault().Id;
            _repository.Remove(id);
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore - 1);
        }

        [Fact]
        public void ShouldUpdatePlatform()
        {
            var platform = _repository._entities.FirstOrDefault();
            platform.ChangeName("new super cool name");
            _repository.Update(platform);
            Assert.True(_repository._entities.FirstOrDefault().Name == "new super cool name");
        }

        [Fact]
        public void ShouldGetPlatformById()
        {
            var platform = _repository._entities.FirstOrDefault();
            var id = platform.Id;
            var selectedPlatform = _repository.GetById(id);
            Assert.Equal(platform, selectedPlatform);
        }
    }
}