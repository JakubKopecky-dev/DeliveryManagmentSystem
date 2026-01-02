using CourierService.Application.DTOs.Courier;
using CourierService.Application.DTOs.External.Route;
using CourierService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Application.Interfaces.Services
{
    public interface ICourierService
    {
        Task<CourierDto> CreateCourierAsync(CreateUpdateCourierDto CreateDto, CancellationToken ct = default);
        Task<CourierDto?> DeleteCourierAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<CourierDto>> GetAllCouriersAsync(CancellationToken ct = default);
        Task<CourierDto?> GetCourierByIdAsync(Guid courierId, CancellationToken ct = default);
        Task<GetDistanceAndDurationResponseDto?> GetDistanceAndDurationAsync(Guid courierId, LocationDto deliveryLocation, VehicleType vehicleType, CancellationToken ct = default);
        Task<CourierDto?> UpdateCourierAsync(Guid courierId, CreateUpdateCourierDto UpdateDto, CancellationToken ct = default);
    }
}
