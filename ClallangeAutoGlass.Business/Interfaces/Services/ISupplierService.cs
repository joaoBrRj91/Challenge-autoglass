using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ClallangeAutoGlass.Business.Interfaces.Services
{
	public interface ISupplierService : IDisposable
	{
        Task<IEnumerable<Supplier>> GetAll(Pagination? pagination = null);
        Task<bool> Add(Supplier supplier);
        Task<bool> Update(Supplier supplier);
        Task<bool> Remove(string document);
    }
}

