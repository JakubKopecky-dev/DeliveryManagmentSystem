using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace UserService.Api.DependencyInejction
{
    public static class TelemetryServiceExtension
    {
        public static IServiceCollection AddOpenTelemetryService(this IServiceCollection services)
        {
            services.AddOpenTelemetry()
                 .ConfigureResource(resource =>
                 {
                     resource.AddService(serviceName: "UserService.Api");
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

                                 // ignoruj interní endpointy
                                 if (path.StartsWith("/swagger", StringComparison.OrdinalIgnoreCase))
                                     return false;

                                 return true;
                             };
                         })
                         .AddHttpClientInstrumentation()
                         .AddConsoleExporter();
                 });



            return services;
        }
    }
}
