using CourierService.Application.DTOs.Courier;
using CourierService.Application.Interfaces.Repositories;
using CourierService.Application.Interfaces.Services;
using CourierService.Domain.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using CourierService.Domain.Enum;
using System.Security.Cryptography.X509Certificates;

namespace CourierService.Application.Services
{
    public class CourierService(ICourierRepository courierRepository, ILogger<CourierService> logger) : ICourierService
    {
        private readonly ICourierRepository _courierRepository = courierRepository;
        private readonly ILogger<CourierService> _logger = logger;



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
                return null;
            }

            courier.Name = UpdateDto.Name;
            courier.Email = UpdateDto.Email;
            courier.PhoneNumber = UpdateDto.PhoneNumber;
            courier.UpdatedAt = DateTime.UtcNow;

            Courier updatedCourier = await _courierRepository.UpdateAsync(courier, ct);

            return updatedCourier.CourierToCourierDto();
        }



        public async Task<CourierDto?> DeleteCourierAsync(Guid id, CancellationToken ct = default)
        {
            Courier? courier = await _courierRepository.FindByIdAsync(id, ct);
            if (courier is null)
            {
                return null;
            }

            CourierDto deltedCourier = courier.CourierToCourierDto();

            _courierRepository.Remove(courier);
            await _courierRepository.SaveChangesAsync(ct);

            return deltedCourier;
        }




    }
}
