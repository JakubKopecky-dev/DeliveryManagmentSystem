using CourierService.Api.Grpc.GrpcClient;
using CourierService.Application.Interfaces.External;

namespace CourierService.Api.DependencyInjection
{
    public static class GrpcServiceCollectionExtension
    {
        public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration config)
        {
            services.AddGrpcClient<RouteService.Grpc.RouteService.RouteServiceClient>(o =>
            {
                o.Address = new Uri(config["RouteService:GrpcAddress"]!);
            });


            services.AddScoped<IRouteReadClient, GrpcRouteClient>();


            return services;
        }
    }
}
