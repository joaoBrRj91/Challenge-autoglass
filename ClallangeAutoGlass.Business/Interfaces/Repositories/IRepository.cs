using System;
using System.Linq.Expressions;
using ClallangeAutoGlass.Business.Entities;

namespace ClallangeAutoGlass.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task<List<TEntity>> ObterTodos();
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<int> SaveChanges();
    }
}

