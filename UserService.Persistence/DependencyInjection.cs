using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Infrastructure.Identity;
using UserService.Infrastructure.Interfaces.Repositories;
using UserService.Persistence.Repositories;


namespace UserService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure()));


            services.AddScoped<IRefreshTokecRepository, RefreshTokecRepository>();


            return services;
        }
    }
}
