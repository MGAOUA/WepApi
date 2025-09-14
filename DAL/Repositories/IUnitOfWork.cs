namespace DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
       // IProductRepository Products { get; }
       // ICategoryRepository Categories { get; }
        // IRepository<SomeOtherEntity> SomeOtherEntities { get; }
        Task<int> CompleteAsync(); // Saves all changes and returns number of entries written

    }

}
