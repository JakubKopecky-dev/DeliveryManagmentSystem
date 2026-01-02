using CourierService.Application.DTOs.External.Route;
using CourierService.Application.Interfaces.External;
using Grpc.Core;
using RouteService.Grpc;
using GrpcRouteClientClient = RouteService.Grpc.RouteService.RouteServiceClient;

namespace CourierService.Api.Grpc.GrpcClient
{
    public class GrpcRouteClient(GrpcRouteClientClient client) : IRouteReadClient
    {
        private readonly GrpcRouteClientClient _client = client;



        public async Task<GetDistanceAndDurationResponseDto?> GetDistanceAndDurationForCourierAndDeliveryAsync(GetDistanceAndDurationRequestDto requestDto, CancellationToken ct = default) 
        {
            GetDistanceAndDurationRequest request = new()
            {
                Latitude1 = requestDto.Locations[0].Latitude,
                Latitude2 = requestDto.Locations[1].Latitude,
                Longitude1 = requestDto.Locations[0].Longitude,
                Longitude2 = requestDto.Locations[1].Longitude,
                VehicleType = (VehicleType)(int)(requestDto.VehicleType)
            };
            try
            {
                GetDistanceAndDurationResponse response = await _client.GetDistanceAndDurationAsync(request, cancellationToken: ct);

                return new(response.Duration, response.Distance);

            }
            catch(RpcException ex) when (StatusCode.NotFound == ex.StatusCode)
            {
                return null;
            }
        }
    }
}
