namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IGameRepository Games { get; }
        IGenreRepository Genres { get; }
        IPlatformRepository Platforms { get; }
        IUserRepository Users { get ;}
        IOrderRepository Orders { get; }
        IReviewRepository Reviews { get;}
        IShoppingCartRepository Carts { get; }
        void Dispose();
    }
}