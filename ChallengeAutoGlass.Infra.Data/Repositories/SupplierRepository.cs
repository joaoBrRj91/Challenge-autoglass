using System;
using ChallengeAutoGlass.Infra.Data.Context;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAutoGlass.Infra.Data.Repositories
{
	public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
		public SupplierRepository(CustomDbContext customDbContext) : base(customDbContext)
		{
		}

        public async Task<Supplier>? GetByDocument(string document)
        {
            var supplier = await CustomDbContext.Suppliers.AsNoTracking().FirstOrDefaultAsync(s => s.Document == document);

            return supplier!;
        }

        public async Task<bool> IsHaveSupplierWithDocument(string document)
			=> await CustomDbContext.Suppliers.AsNoTracking().AnyAsync(d => d.Document == document);
    }
}

