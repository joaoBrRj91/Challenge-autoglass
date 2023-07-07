using System;
using ClallangeAutoGlass.Business.Entities;

namespace ClallangeAutoGlass.Business.Interfaces.Repositories
{
	public interface IProductRepository : IRepository<Product>
    {
		Task<bool> IsHaveProductsSupplier(int supplierId);
	}
}

