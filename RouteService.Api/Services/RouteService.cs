using RouteService.Api.DTOs;
using RouteService.Api.Enums;
using RouteService.Api.Interfaces.Services;

namespace RouteService.Api.Services
{
    public class RouteService(IHttpClientFactory clientFactory) : IRouteService
    {
        private readonly IHttpClientFactory _httpClientFactory = clientFactory;



        public async Task<GeoResponseDto?> GetDistanceAndDurationAsync(GeoRequestDto requestDto,VehicleType vehicleType, CancellationToken ct)
        {

            string vehType = vehicleType switch
            {
                VehicleType.Car => "driving-car",
                VehicleType.Walking => "foot-walking",
                VehicleType.Cycling => "cycling-regular",
                _ => "driving-car"
            };

                HttpClient client = _httpClientFactory.CreateClient("GeoClient");

                var response = await client.PostAsJsonAsync($"v2/matrix/{vehType}", requestDto,ct);
                
                response.EnsureSuccessStatusCode();

                var dtoResponse = await response.Content.ReadFromJsonAsync<GeoResponseDto>(ct);

                return dtoResponse;
        }



    }
}
