using System;
using ClallangeAutoGlass.Business.Entities;

namespace ClallangeAutoGlass.Business.Interfaces.Repositories
{
	public interface ISupplierRepository : IRepository<Supplier>
    {
		Task<bool> IsHaveSupplierWithDocument(string document);

        Task<Supplier>? GetByDocument(string document);
    }
}

