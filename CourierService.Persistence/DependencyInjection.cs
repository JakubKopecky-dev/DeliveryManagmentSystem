using CourierService.Application.Interfaces.Repositories;
using CourierService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectiotString = configuration.GetConnectionString("DefaultConnection");

            services.AddPooledDbContextFactory<CourierDbContext>(options =>
                options.UseSqlServer(connectiotString));

            services.AddScoped<ICourierRepository,CourierRepository>();

            return services;
        }
    }
}
