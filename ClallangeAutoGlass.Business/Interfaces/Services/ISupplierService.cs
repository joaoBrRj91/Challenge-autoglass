using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ClallangeAutoGlass.Business.Interfaces.Services
{
	public interface ISupplierService : IDisposable
	{
        Task<IEnumerable<Supplier>> GetAll(Pagination? pagination = null);
        Task Add(Supplier product);
        Task Update(Supplier product);
        Task Remove(int id);
    }
}

