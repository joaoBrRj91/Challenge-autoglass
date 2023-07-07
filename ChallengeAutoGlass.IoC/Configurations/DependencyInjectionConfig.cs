using System;
using ChallengeAutoGlass.Application.AppServices;
using ChallengeAutoGlass.Application.AppServices.Interfaces;
using ChallengeAutoGlass.Infra.Data.Context;
using ChallengeAutoGlass.Infra.Data.Repositories;
using ClallangeAutoGlass.Business.Implementations.Notifications;
using ClallangeAutoGlass.Business.Implementations.Services;
using ClallangeAutoGlass.Business.Interfaces.Notifications;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using ClallangeAutoGlass.Business.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeAutoGlass.IoC.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CustomDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });


            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierAppService, SupplierAppService>();
            services.AddScoped<IProductAppService, ProductsAppService>();


            return services;
        }
    }
}

