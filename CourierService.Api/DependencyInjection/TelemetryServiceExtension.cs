using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CourierService.Api.DependencyInjection
{
    public static class TelemetryServiceExtension
    {
        public static IServiceCollection AddOpenTelemetryService(this IServiceCollection services)
        {
            services.AddOpenTelemetry()
                .ConfigureResource(resource =>
                {
                resource.AddService(serviceName: "CourierService.Api");
                })
                .WithTracing(tracing =>
                {
                    tracing
                        .AddAspNetCoreInstrumentation(options =>
                        {
                            options.Filter = httpContext =>
                            {
                                var path = httpContext.Request.Path.Value;

                                if (path is null)
                                    return true;

                                if (path.Contains("service-worker", StringComparison.OrdinalIgnoreCase))
                                    return false;

                                if (httpContext.Request.Method == HttpMethods.Get &&
                                    path.StartsWith("/graphql", StringComparison.OrdinalIgnoreCase))
                                    return false;

                                return true;
                            };
                        })
                        .AddHttpClientInstrumentation(options =>
                        {
                            options.FilterHttpRequestMessage = request =>
                            {
                                return !request.RequestUri!.Host.Contains("chillicream.com");
                            };
                        })
                        .AddConsoleExporter();
                });



            return services;
        }
    }
}
