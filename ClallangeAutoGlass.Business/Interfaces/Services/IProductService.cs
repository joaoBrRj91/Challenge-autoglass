using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ClallangeAutoGlass.Business.Interfaces.Services
{
	public interface IProductService : IDisposable
	{
        Task<IEnumerable<Product>> GetAll(Pagination? pagination = null);
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Remove(string sku);
    }
}

