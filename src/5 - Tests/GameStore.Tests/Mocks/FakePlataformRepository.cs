using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;

namespace GameStore.Tests.Mocks {
    public class FakePlataformRepository: FakeRepository<Plataform>, IPlataformRepository
    {
        public FakePlataformRepository()
        {
            for (int i = 0; i < 10; i++)
            {
                base._entities.Add(new Plataform("Fake Console"));
            }    
        }
    }
}