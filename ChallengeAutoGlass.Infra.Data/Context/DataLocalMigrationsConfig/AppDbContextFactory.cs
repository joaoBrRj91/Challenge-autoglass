using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChallengeAutoGlass.Infra.Data.Context.DataLocalMigrationsConfig
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<CustomDbContext>
    {
        public CustomDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomDbContext>();
            optionsBuilder.UseSqlServer(DatabaseConfig.DATABASE_LOCAL_CONNECTION_STRING);

            return new CustomDbContext(optionsBuilder.Options);
        }
    }
}

