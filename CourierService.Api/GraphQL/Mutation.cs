using CourierService.Api.Auth;
using CourierService.Application.DTOs.Courier;
using CourierService.Application.Interfaces.Services;
using HotChocolate.Authorization;

namespace CourierService.Api.GraphQL
{
    [Authorize(Roles = [UserRoles.Admin])]
    public class Mutation(ICourierService courierService)
    {
        private readonly ICourierService _courierService = courierService;



        public async Task<CourierDto> CreateCourier(CreateUpdateCourierDto input, CancellationToken ct) =>
            await _courierService.CreateCourierAsync(input, ct);



        public async Task<CourierDto?> UpdateCourier(Guid courierId, CreateUpdateCourierDto input, CancellationToken ct) =>
            await _courierService.UpdateCourierAsync(courierId, input, ct);



        public async Task<CourierDto?> DeleteCourier(Guid courierId,CancellationToken ct) =>
            await _courierService.DeleteCourierAsync(courierId,ct);




    }
}
