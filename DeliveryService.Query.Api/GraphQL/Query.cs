using DeliveryService.Query.Api.Auth;
using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using DeliveryService.Query.Application.Features.Delivery.GetActiveDeliveriesByCourierId;
using DeliveryService.Query.Application.Features.Delivery.GetAllDeliveries;
using DeliveryService.Query.Application.Features.Delivery.GetDeliveriesByExternalOrderId;
using DeliveryService.Query.Application.Features.Delivery.GetDeliveriesByOwnerId;
using DeliveryService.Query.Application.Features.Delivery.GetDeliveryById;
using HotChocolate.Authorization;
using System.Security.Claims;

namespace DeliveryService.Query.Api.GraphQL
{
    public class Query(IQueryExecutor executor, IHttpContextAccessor httpContextAccessor)
    {
        private readonly IQueryExecutor _executor = executor;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;



        [Authorize(Roles = [UserRoles.Admin])]
        public async Task<IReadOnlyList<DeliveryDto>> GetActiveDeliveriesByCourierId(Guid courierId, CancellationToken ct)
        {
            GetActiveDeliveriesByCourierIdQuery query = new(courierId);

            return await _executor.Execute<GetActiveDeliveriesByCourierIdQuery, IReadOnlyList<DeliveryDto>>(query, ct);
        }



        [Authorize(Roles = [UserRoles.Admin])]
        public async Task<IReadOnlyList<DeliveryDto>> GetAllDeliveries(int? page, int? pageSize, CancellationToken ct)
        {
            GetAllDeliveriesQuery query = new(page ?? 1, pageSize ?? 30);

            return await _executor.Execute<GetAllDeliveriesQuery, IReadOnlyList<DeliveryDto>>(query, ct);
        }



        public async Task<IReadOnlyList<DeliveryDto>> GetDeliveriesByExternalOrderId(Guid externalOrderId, CancellationToken ct)
        {
            GetDeliveriesByExternalOrderIdQuery query = new(externalOrderId);

            return await _executor.Execute<GetDeliveriesByExternalOrderIdQuery, IReadOnlyList<DeliveryDto>>(query, ct);
        }



        [Authorize(Roles = [UserRoles.Admin])]
        public async Task<IReadOnlyList<DeliveryDto>> GetDeliveriesByOwnerId(Guid ownerId, int? page, int? pageSize, CancellationToken ct)
        {

            GetDeliveriesByOwnerIdQuery query = new(ownerId, page ?? 1, pageSize ?? 30);

            return await _executor.Execute<GetDeliveriesByOwnerIdQuery, IReadOnlyList<DeliveryDto>>(query, ct);
        }



        [Authorize(Roles = [UserRoles.User])]
        public async Task<IReadOnlyList<DeliveryDto>> GetDeliveriesOwnCompany(int? page, int? pageSize, CancellationToken ct)
        {
            var ownerIdString = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(ownerIdString, out var ownerId))
                throw new GraphQLException("Unauthorized");

            GetDeliveriesByOwnerIdQuery query = new(ownerId, page ?? 1, pageSize ?? 30);

            return await _executor.Execute<GetDeliveriesByOwnerIdQuery, IReadOnlyList<DeliveryDto>>(query, ct);
        }



        public async Task<DeliveryDto?> GetDeliveryById(Guid deliveryId, CancellationToken ct)
        {
            GetDeliveryByIdQuery query = new(deliveryId);

            return await _executor.Execute<GetDeliveryByIdQuery, DeliveryDto?>(query, ct);
        }





    }
}
