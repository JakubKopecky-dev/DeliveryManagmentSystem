using CourierService.Application.DTOs.Courier;
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
        Task<CourierDto?> UpdateCourierAsync(Guid courierId, CreateUpdateCourierDto UpdateDto, CancellationToken ct = default);
    }
}
