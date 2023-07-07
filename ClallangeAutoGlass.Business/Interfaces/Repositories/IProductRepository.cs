using System;
using ClallangeAutoGlass.Business.Entities;

namespace ClallangeAutoGlass.Business.Interfaces.Repositories
{
	public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetBySku(string sku);
        Task<Product> GetBySkuWithSupplier(string sku);
        Task<bool> IsHaveProductsSupplier(int supplierId);
	}
}

