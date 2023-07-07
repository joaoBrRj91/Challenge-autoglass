using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ClallangeAutoGlass.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAll(Pagination? pagination = null);
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task<int> SaveChanges();
    }
}

