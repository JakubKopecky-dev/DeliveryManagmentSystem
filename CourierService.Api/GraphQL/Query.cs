using CourierService.Application.DTOs.Courier;
using CourierService.Application.Interfaces.Services;

namespace CourierService.Api.GraphQL
{
    public class Query(ICourierService courierService)
    {
        private readonly ICourierService _courierService = courierService;



        public async Task<IReadOnlyList<CourierDto>> GetAllCourier(CancellationToken ct) =>
            await _courierService.GetAllCouriersAsync(ct);


        public async Task<CourierDto?> GetCourierById(Guid id, CancellationToken ct) =>
            await _courierService.GetCourierByIdAsync(id, ct);


    }
}
