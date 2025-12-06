using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Command.Application.Interfaces.Repositories;
using OrderService.Command.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<OrderCommandDbContext>(options =>
                options.UseSqlServer(connectionString));



            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRespository,OrderItemRepository>();

            return services;
        }
    }
}
