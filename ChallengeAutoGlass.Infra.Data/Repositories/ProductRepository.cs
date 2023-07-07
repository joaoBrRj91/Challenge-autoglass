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

        public async Task<Product> GetBySku(string sku)
        {
            var product = await CustomDbContext.Products.FirstOrDefaultAsync(p => p.Sku == sku);

            return product!;
        }

        public async Task<Product> GetBySkuWithSupplier(string sku)
        {
            var product = await CustomDbContext.Products.Include(s => s.Supplier).FirstOrDefaultAsync();

            return product!;
        }

        public async Task<bool> IsHaveProductsSupplier(int supplierId)
			=> await CustomDbContext.Products.AsNoTracking().AnyAsync(s => s.SupplierId == supplierId);


       
    }
}

