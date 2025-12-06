using DeliveryService.Query.Application.Interfaces.Repositories;
using DeliveryService.Query.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<IDeliveryRepository, DeliveryRepository>();

            return services;
        }
    }
}
