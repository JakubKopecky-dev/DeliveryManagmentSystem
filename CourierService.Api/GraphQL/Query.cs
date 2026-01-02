using CourierService.Application.DTOs.Courier;
using CourierService.Application.DTOs.External.Route;
using CourierService.Application.Interfaces.Services;
using CourierService.Domain.Enums;

namespace CourierService.Api.GraphQL
{
    public class Query(ICourierService courierService)
    {
        private readonly ICourierService _courierService = courierService;



        public async Task<IReadOnlyList<CourierDto>> GetAllCourier(CancellationToken ct) =>
            await _courierService.GetAllCouriersAsync(ct);


        public async Task<CourierDto?> GetCourierById(Guid id, CancellationToken ct) =>
            await _courierService.GetCourierByIdAsync(id, ct);


        public async Task<GetDistanceAndDurationResponseDto?> GetDistanceAndDurationBetweenCourierAndDelivery(Guid courierId, LocationDto deliveryLocation, VehicleType vehicleType, CancellationToken ct) =>
            await _courierService.GetDistanceAndDurationAsync(courierId, deliveryLocation, vehicleType, ct);

    }
}
