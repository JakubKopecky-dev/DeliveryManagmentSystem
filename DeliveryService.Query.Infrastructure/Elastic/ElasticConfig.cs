using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Infrastructure.Elastic
{
    public static class ElasticConfig
    {
        public static IServiceCollection AddElastic(this IServiceCollection services, IConfiguration configuration)
        {
            Uri uri = new(configuration["Elastic:Uri"]!);

            ElasticsearchClientSettings settings = new(uri);

            ElasticsearchClient client = new(settings);

            services.AddSingleton(client);
            services.AddScoped<ElasticBootstrapper>();

            return services;
        }
    }
}
