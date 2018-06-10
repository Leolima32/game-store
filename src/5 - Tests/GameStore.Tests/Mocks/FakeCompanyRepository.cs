using System;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Domain.ValueObjects;

namespace GameStore.Tests.Mocks
{
    public class FakeCompanyRepository : FakeRepository<Company>, ICompanyRepository {
        public FakeCompanyRepository()
        {
            for (var i = 0; i < 10; i++)
            {
                base._entities.Add(new Company(new CompanyName("Fake Company"),DateTime.Now));
            }
        }
    }
}