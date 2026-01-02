using RouteService.Api.DTOs;
using RouteService.Api.Enums;

namespace RouteService.Api.Interfaces.Services
{
    public interface IRouteService
    {
        Task<GeoResponseDto?> GetDistanceAndDurationAsync(GeoRequestDto requestDto, VehicleType vehicleType, CancellationToken ct);
    }
}
