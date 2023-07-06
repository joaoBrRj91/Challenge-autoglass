using System;
using ClallangeAutoGlass.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAutoGlass.Infra.Data.Context
{
	public class CustomDbContext : DbContext
    {
		public CustomDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

