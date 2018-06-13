using System;
using GameStore.Domain.Entities;
using GameStore.Domain.ValueObjects;
using Xunit;

namespace GameStore.Tests.Entities {
    public class CompanyTests {
        
        [Fact]
        public void ShouldReturnErrorWhenFantasyNameIsNull() {
            var fakeCompanyName = new CompanyName("");
            var fakeComapany = new Company(fakeCompanyName,DateTime.Now);
            Assert.Equal(false, fakeComapany.IsValid);
            Assert.Equal(true, fakeComapany.IsInvalid);
        }
    }
}