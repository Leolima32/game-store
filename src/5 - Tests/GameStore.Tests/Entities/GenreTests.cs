using GameStore.Domain.Entities;
using Xunit;

namespace GameStore.Tests.Entities
{
    public class GenreTests
    {
        [Fact]
        public void ShouldReturnErrorWhenNameIsEmpty()
        {
            var fakeGenre = new Genre(null);
            Assert.Equal(false, fakeGenre.IsValid);
        }
    }
}