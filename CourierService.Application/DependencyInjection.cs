using CourierService.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CourierServiceService = CourierService.Application.Services.CourierService;

namespace CourierService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICourierService, CourierServiceService>();

            return services;
        }
    }
}
