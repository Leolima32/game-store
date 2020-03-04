using System;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Domain.ValueObjects;
using GameStore.Tests.Mocks;
using Xunit;

namespace GameStore.Tests.Operations {
    public class ComapanyOperationsTests {
        private FakeCompanyRepository _repository;
        public ComapanyOperationsTests()
        {
            _repository = new FakeCompanyRepository();
        }

        [Fact]
        public void ShouldAddANewCompany()
        {
            int countBefore = _repository._entities.Count;
            _repository.Add(new Company("new super cool Company",DateTime.Now));
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore + 1);
        }

        [Fact]
        public void ShoulDeleteCompany()
        {
            int countBefore = _repository._entities.Count;
            Guid id = _repository._entities.FirstOrDefault().Id;
            _repository.Remove(id);
            int countAfter = _repository._entities.Count;
            Assert.Equal(countAfter, countBefore - 1);
        }

        [Fact]
        public void ShouldUpdateCompany()
        {
            var company = _repository._entities.FirstOrDefault();
            company.ChangeName("new super cool name");
            _repository.Update(company);
            Assert.True(_repository._entities.FirstOrDefault().Name == "new super cool name");
        }

        [Fact]
        public void ShouldGetCompanyById()
        {
            var company = _repository._entities.FirstOrDefault();
            var id = company.Id;
            var selectedCompany = _repository.GetById(id);
            Assert.Equal(company, selectedCompany);
        }
    }
}