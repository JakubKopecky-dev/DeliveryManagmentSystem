using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using RouteService.Api.DTOs;
using RouteService.Api.Enums;
using RouteService.Api.Interfaces.Services;
using RouteService.Grpc;
using RouteGrpc = RouteService.Grpc.RouteService;

namespace RouteService.Api.Grpc.GrpcService
{
    public class RouteGrpcService(IRouteService routeService,ILogger<RouteGrpcService> logger) : RouteGrpc.RouteServiceBase
    {
        private readonly IRouteService _routeService = routeService;
        private readonly ILogger<RouteGrpcService> _logger = logger;



        public override async Task<GetDistanceAndDurationResponse> GetDistanceAndDuration(GetDistanceAndDurationRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Retrieved rpc request from courierService");


            GeoRequestDto geoRequest = new()
            {
                Locations =
                [
                    [request.Longitude1, request.Latitude1],
                    [request.Longitude2,request.Latitude2]
                ],
                Metrics = ["distance", "duration"],
                ResolveLocations = false,
                Sources = [0],
                Units = "m",
            };

            var type = (Enums.VehicleType)(int)request.VehicleType;

            GeoResponseDto? responsetDto = await _routeService.GetDistanceAndDurationAsync(geoRequest, type, context.CancellationToken)
                ?? throw new RpcException(new Status(StatusCode.NotFound, "Location not found"));

            _logger.LogInformation("Retrieved from external system: {Dist} and {Durat}", responsetDto.DistancesInMeters[0][1], responsetDto.DurationsInMinutes[0][1]);

            return new()
            {
                Distance = responsetDto.DistancesInMeters[0][1],
                Duration = responsetDto.DurationsInMinutes[0][1]
            };

        }


    }
}
