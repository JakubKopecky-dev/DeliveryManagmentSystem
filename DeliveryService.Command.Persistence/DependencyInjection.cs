using DeliveryService.Command.Application.Interfaces.Repositories;
using DeliveryService.Command.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectinString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DeliveryDbContext>(options =>
                options.UseSqlServer(connectinString));

            services.AddScoped<IDeliveryRepisotry, DeliveryRepository>();


            return services;
        }
    }
}
