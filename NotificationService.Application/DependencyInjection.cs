using Microsoft.Extensions.DependencyInjection;
using NotificationService.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, Services.NotificationService>();

            return services;
        }
    }
}
