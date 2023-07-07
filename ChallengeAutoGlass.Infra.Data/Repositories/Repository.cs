using System;
using ChallengeAutoGlass.Infra.Data.Context;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAutoGlass.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly CustomDbContext CustomDbContext;
        protected readonly DbSet<TEntity> DbSet;


        public Repository(CustomDbContext customDbContext)
        {
            CustomDbContext = customDbContext;
            DbSet = customDbContext.Set<TEntity>();
        }


        public async Task<List<TEntity>> GetAll(Pagination? pagination = null)
        {
            var queryable = DbSet.AsNoTracking();

            if (pagination is not null)
                queryable.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize);

            return await queryable.ToListAsync();

        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await DbSet.FindAsync(id);

            return entity!;
        }


        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }


        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public  async Task<int> SaveChanges()
        {
            return await CustomDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            CustomDbContext?.Dispose();
        }

    }
}

