using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Context;

namespace GameStore.Tests.Mocks {
    public class FakeGenreRepository: FakeRepository<Genre>, IGenreRepository
    {
        public FakeGenreRepository()
        {
            for (int i = 0; i < 10; i++)
            {
                base._entities.Add(new Genre("Fake Genre"));
            }
        }
    }
}
