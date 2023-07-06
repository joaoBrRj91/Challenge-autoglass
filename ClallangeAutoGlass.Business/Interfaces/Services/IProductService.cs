using System;
using ClallangeAutoGlass.Business.Entities;

namespace ClallangeAutoGlass.Business.Interfaces.Services
{
	public interface IProductService : IDisposable
	{
        Task<IEnumerable<Product>> GetAll();
        Task Adicionar(Product product);
        Task Atualizar(Product product);
        Task Remover(int id);
    }
}

