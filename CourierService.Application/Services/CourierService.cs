using CourierService.Application.DTOs.Courier;
using CourierService.Application.DTOs.External.Route;
using CourierService.Application.Interfaces.External;
using CourierService.Application.Interfaces.Repositories;
using CourierService.Application.Interfaces.Services;
using CourierService.Domain.Entities;
using CourierService.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace CourierService.Application.Services
{
    public class CourierService(ICourierRepository courierRepository, ILogger<CourierService> logger, IRouteReadClient routeReadClient) : ICourierService
    {
        private readonly ICourierRepository _courierRepository = courierRepository;
        private readonly ILogger<CourierService> _logger = logger;
        private readonly IRouteReadClient _routeReadClient = routeReadClient;



        public async Task<IReadOnlyList<CourierDto>> GetAllCouriersAsync(CancellationToken ct = default)
        {
            IReadOnlyList<Courier> couriers = await _courierRepository.GetAllAsync(ct);

            return [.. couriers.Select(c => c.CourierToCourierDto())];

        }


        public async Task<CourierDto?> GetCourierByIdAsync(Guid courierId, CancellationToken ct = default)
        {
            Courier? courier = await _courierRepository.FindByIdAsync(courierId, ct);

            return courier?.CourierToCourierDto();
        }



        public async Task<CourierDto> CreateCourierAsync(CreateUpdateCourierDto CreateDto, CancellationToken ct = default)
        {
            Courier courier = new()
            {
                Id = Guid.Empty,
                Name = CreateDto.Name,
                Email = CreateDto.Email,
                PhoneNumber = CreateDto.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
                Status = CourierStatus.Offline
            };


            Courier createdCourier = await _courierRepository.InsertAsync(courier, ct);

            return createdCourier.CourierToCourierDto();
        }



        public async Task<CourierDto?> UpdateCourierAsync(Guid courierId, CreateUpdateCourierDto UpdateDto, CancellationToken ct = default)
        {
            Courier? courier = await _courierRepository.FindByIdAsync(courierId, ct);
            if (courier is null)
            {
                _logger.LogWarning("Courier not found during update. CourierId={CourierId}", courierId);
                return null;
            }

            courier.Name = UpdateDto.Name;
            courier.Email = UpdateDto.Email;
            courier.PhoneNumber = UpdateDto.PhoneNumber;
            courier.UpdatedAt = DateTime.UtcNow;

            Courier updatedCourier = await _courierRepository.UpdateAsync(courier, ct);

            return updatedCourier.CourierToCourierDto();
        }



        public async Task<CourierDto?> DeleteCourierAsync(Guid courierId, CancellationToken ct = default)
        {
            Courier? courier = await _courierRepository.FindByIdAsync(courierId, ct);
            if (courier is null)
            {
                _logger.LogWarning("Courier not found during deleting. CourierId={CourierId}", courierId);
                return null;
            }

            CourierDto deltedCourier = courier.CourierToCourierDto();

            _courierRepository.Remove(courier);
            await _courierRepository.SaveChangesAsync(ct);

            return deltedCourier;
        }



        public async Task<GetDistanceAndDurationResponseDto?> GetDistanceAndDurationAsync(Guid courierId, LocationDto deliveryLocation, VehicleType vehicleType, CancellationToken ct = default)
        {
            Courier? courier = await _courierRepository.FindByIdAsync(courierId, ct);
            if (courier is null)
            {
                _logger.LogWarning("Courier not found when calculating distance. CourierId={CourierId}",courierId);
                return null;
            }

            if (courier.Status == CourierStatus.Offline)
            {
                _logger.LogInformation("Distance calculation skipped because courier is offline. CourierId={CourierId}",courierId);
                return null;
            }

            if (courier.Latitude is null || courier.Longitude is null)
            {
                _logger.LogWarning("Courier has no location data. CourierId={CourierId}",courierId);
                return null;
            }


            List<LocationDto> locationDtos =
            [
                new(courier.Longitude.Value,courier.Latitude.Value),
                new(deliveryLocation.Longitude, deliveryLocation.Latitude)
            ];

            GetDistanceAndDurationRequestDto request = new(locationDtos, vehicleType);

            
            GetDistanceAndDurationResponseDto? response = await _routeReadClient.GetDistanceAndDurationForCourierAndDeliveryAsync(request,ct);
            if (response is null)
            {
                _logger.LogWarning("Route service returned no data for courier. CourierId={CourierId}, VehicleType={VehicleType}", courierId, vehicleType);
            }

            return response;
        }



    }
}
