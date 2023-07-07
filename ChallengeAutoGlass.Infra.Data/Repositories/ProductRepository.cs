using System;
using ChallengeAutoGlass.Infra.Data.Context;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Interfaces.Repositories;

namespace ChallengeAutoGlass.Infra.Data.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(CustomDbContext customDbContext) : base(customDbContext)
		{
		}
	}
}

