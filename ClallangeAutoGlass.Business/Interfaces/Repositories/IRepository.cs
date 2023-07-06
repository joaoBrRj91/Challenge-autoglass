using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ClallangeAutoGlass.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task<List<TEntity>> GetAll(Pagination? pagination = null);
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<int> SaveChanges();
    }
}

