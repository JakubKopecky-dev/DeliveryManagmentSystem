using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using DeliveryService.Query.Application.Features.Delivery.GetActiveDeliveriesByCourierId;
using DeliveryService.Query.Application.Features.Delivery.GetAllDeliveries;
using DeliveryService.Query.Application.Features.Delivery.GetDeliveriesByExternalOrderId;
using DeliveryService.Query.Application.Features.Delivery.GetDeliveriesByOwnerId;
using DeliveryService.Query.Application.Features.Delivery.GetDeliveryById;

namespace DeliveryService.Query.Api.GraphQL
{
    public class Query(IQueryExecutor executor)
    {
        private readonly IQueryExecutor _executor = executor;



        public async Task<IReadOnlyList<DeliveryDto>> GetActiveDeliveriesByCourierId(Guid courierId, CancellationToken ct)
        {
            GetActiveDeliveriesByCourierIdQuery query = new(courierId);

            return await _executor.Execute<GetActiveDeliveriesByCourierIdQuery, IReadOnlyList<DeliveryDto>>(query, ct);
        }



        public async Task<IReadOnlyList<DeliveryDto>> GetAllDeliveries(int? page, int? pageSize, CancellationToken ct)
        {
            GetAllDeliveriesQuery query = new(page ?? 1, pageSize ?? 30);

            return await _executor.Execute<GetAllDeliveriesQuery,IReadOnlyList<DeliveryDto>>(query, ct);
        }



        public async Task<IReadOnlyList<DeliveryDto>> GetDeliveriesByExternalOrderId(Guid externalOrderId, CancellationToken ct)
        {
            GetDeliveriesByExternalOrderIdQuery query = new(externalOrderId);

            return await _executor.Execute<GetDeliveriesByExternalOrderIdQuery, IReadOnlyList<DeliveryDto>>(query, ct);
        }



        public async Task<IReadOnlyList<DeliveryDto>> GetDeliveriesByOwnerId(Guid ownerId, int? page, int? pageSize, CancellationToken ct)
        {
            GetDeliveriesByOwnerIdQuery query =new(ownerId, page ??1, pageSize ?? 30);

            return await _executor.Execute<GetDeliveriesByOwnerIdQuery, IReadOnlyList<DeliveryDto>>(query, ct);
        }



        public async Task<DeliveryDto?> GetDeliveryById(Guid deliveryId, CancellationToken ct)
        {
            GetDeliveryByIdQuery query = new(deliveryId);

            return await _executor.Execute<GetDeliveryByIdQuery,DeliveryDto?>(query, ct);
        }





    }
}
