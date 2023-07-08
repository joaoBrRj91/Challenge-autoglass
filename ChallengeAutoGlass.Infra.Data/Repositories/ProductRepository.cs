using System;
using ChallengeAutoGlass.Infra.Data.Context;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAutoGlass.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CustomDbContext customDbContext) : base(customDbContext)
        {
        }

        public async Task<List<Product>> GetAllWithSupplier(Pagination? pagination = null)
        {
            IQueryable<Product>? queryable = null;
     
            if (pagination is not null)
                queryable = CustomDbContext.Products.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize);

            return await queryable!
                .Where(p => p.Status == true)
                .Include(s => s.Supplier)
                .AsNoTracking()
                .ToListAsync();

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

