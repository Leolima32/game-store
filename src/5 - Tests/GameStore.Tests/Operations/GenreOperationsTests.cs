using System;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Tests.Mocks;
using Xunit;

namespace GameStore.Tests.Operations
{
    public class GenreOperationsTests {
        private FakeGenreRepository _repository;
        public GenreOperationsTests()
        {
            _repository = new FakeGenreRepository();
        }

        [Fact]
        public void ShouldAddANewGenre()
        {
            int countBefore = _repository._entities.Count;
            _repository.Add(new Genre("new fake genre"));
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore + 1);
        }

        [Fact]
        public void ShoulDeleteGenre()
        {
            int countBefore = _repository._entities.Count;
            Guid id = _repository._entities.FirstOrDefault().Id;
            _repository.Remove(id);
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore - 1);
        }

        [Fact]
        public void ShouldUpdateGenre()
        {
            var genre = _repository._entities.FirstOrDefault();
            genre.ChangeName("new super cool name");
            _repository.Update(genre);
            Assert.True(_repository._entities.FirstOrDefault().Name == "new super cool name");
        }

        [Fact]
        public void ShouldGetGenreById()
        {
            var genre = _repository._entities.FirstOrDefault();
            var id = genre.Id;
            var selectedGenre = _repository.GetById(id);
            Assert.Equal(genre, selectedGenre);
        }
    }  
}