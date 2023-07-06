using System;
using ClallangeAutoGlass.Business.Entities;

namespace ClallangeAutoGlass.Business.Interfaces.Services
{
	public interface ISupplierService : IDisposable
	{
        Task<IEnumerable<Supplier>> GetAll();
        Task Add(Supplier product);
        Task Update(Supplier product);
        Task Remove(int id);
    }
}

