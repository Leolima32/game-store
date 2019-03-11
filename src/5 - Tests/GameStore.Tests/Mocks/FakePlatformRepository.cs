using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;

namespace GameStore.Tests.Mocks {
    public class FakePlatformRepository: FakeRepository<Platform>, IPlatformRepository
    {
        public FakePlatformRepository()
        {
            for (int i = 0; i < 10; i++)
            {
                base._entities.Add(new Platform("Fake Console"));
            }    
        }
    }
}