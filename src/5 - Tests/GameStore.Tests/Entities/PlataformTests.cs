using GameStore.Domain.Entities;
using Xunit;

namespace GameStore.Tests.Entities {
    public class PlatformTests
    {
        [Fact]
        public void ShouldReturnErrorWhenPlatformNameIsNull()
        {
            var platform = new Platform(string.Empty);

            Assert.True(platform.Nonconformities.Count == 1);
            Assert.Equal("platform.name", platform.Nonconformities[0].Property);
            Assert.Equal(false,platform.IsValid);
        }
    }
}