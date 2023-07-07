using System;
using ChallengeAutoGlass.Infra.Data.Context;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Interfaces.Repositories;

namespace ChallengeAutoGlass.Infra.Data.Repositories
{
	public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
		public SupplierRepository(CustomDbContext customDbContext) : base(customDbContext)
		{
		}
	}
}

