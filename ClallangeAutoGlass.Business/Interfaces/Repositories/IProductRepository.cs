using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ClallangeAutoGlass.Business.Interfaces.Repositories
{
	public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllWithSupplier(Pagination? pagination = null);
        Task<Product> GetBySku(string sku);
        Task<Product> GetBySkuWithSupplier(string sku);
        Task<bool> IsHaveProductsSupplier(int supplierId);
	}
}

