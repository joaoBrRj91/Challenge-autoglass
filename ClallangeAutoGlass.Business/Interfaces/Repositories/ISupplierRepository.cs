using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ClallangeAutoGlass.Business.Interfaces.Repositories
{
	public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<List<Supplier>> GetAllWithProducts(Pagination? pagination = null);
        Task<bool> IsHaveSupplierWithDocument(string document);
        Task<Supplier>? GetByDocument(string document);
    }
}

