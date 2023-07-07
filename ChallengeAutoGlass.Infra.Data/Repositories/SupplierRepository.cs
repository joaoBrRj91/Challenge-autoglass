using System;
using ChallengeAutoGlass.Infra.Data.Context;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAutoGlass.Infra.Data.Repositories
{
	public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
		public SupplierRepository(CustomDbContext customDbContext) : base(customDbContext)
		{
		}

        public async Task<List<Supplier>> GetAllWithProducts(Pagination? pagination = null)
        {
            var queryable = CustomDbContext.Suppliers.AsNoTracking();

            if (pagination is not null)
                queryable.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize);

            return await queryable
                .Where(p => p.Status == true)
                .Include(s => s.Products)
                .ToListAsync();
        }

        public async Task<Supplier>? GetByDocument(string document)
        {
            var supplier = await CustomDbContext.Suppliers.FirstOrDefaultAsync(s => s.Document == document);

            return supplier!;
        }

        public async Task<bool> IsHaveSupplierWithDocument(string document)
			=> await CustomDbContext.Suppliers.AsNoTracking().AnyAsync(d => d.Document == document);
    }
}

