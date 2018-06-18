using GameStore.Domain.Entities;
using Xunit;

namespace GameStore.Tests.Entities {
    public class PlataformTests
    {
        [Fact]
        public void ShouldReturnErrorWhenPlataformNameIsNull()
        {
            var plataform = new Plataform(string.Empty);

            Assert.True(plataform.Nonconformities.Count == 1);
            Assert.Equal("plataform.name", plataform.Nonconformities[0].Property);
            Assert.Equal(false,plataform.IsValid);
        }
    }
}