using System;
using ChallengeAutoGlass.Infra.Data.Context;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAutoGlass.Infra.Data.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(CustomDbContext customDbContext) : base(customDbContext)
		{
		}

        public async Task<bool> IsHaveProductsSupplier(int supplierId)
			=> await CustomDbContext.Products.AsNoTracking().AnyAsync(s => s.SupplierId == supplierId);
    }
}

