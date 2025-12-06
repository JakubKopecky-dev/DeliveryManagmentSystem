using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using DeliveryService.Query.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Features.Delivery.GetActiveDeliveriesByCourierId
{
    public class GetActiveDeliveriesByCourierIdHandler(IDeliveryRepository deliveryRepository) : IQueryHandler<GetActiveDeliveriesByCourierIdQuery,IReadOnlyList<DeliveryDto>>
    {
        private readonly IDeliveryRepository _deliveryRepository = deliveryRepository;



        public async Task<IReadOnlyList<DeliveryDto>> Handle(GetActiveDeliveriesByCourierIdQuery query, CancellationToken ct = default)
        {
            IReadOnlyList<Domain.Models.Delivery> deliveries = await _deliveryRepository.GetActiveDeliveriesByCourierId(query.CourierId, ct);

            return [.. deliveries.Select(s => s.DeliveryToDeliveryDto())];
        }
    }
}
