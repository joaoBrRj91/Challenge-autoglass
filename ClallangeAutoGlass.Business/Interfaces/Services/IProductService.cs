using System;
using ClallangeAutoGlass.Business.Entities;

namespace ClallangeAutoGlass.Business.Interfaces.Services
{
	public interface IProductService : IDisposable
	{
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
        Task Update(Product product);
        Task Remove(int id);
    }
}

