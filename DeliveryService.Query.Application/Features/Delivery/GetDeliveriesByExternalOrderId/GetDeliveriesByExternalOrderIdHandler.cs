using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using DeliveryService.Query.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Features.Delivery.GetDeliveriesByExternalOrderId
{
    public class GetDeliveriesByExternalOrderIdHandler(IDeliveryRepository deliveryRepository) : IQueryHandler<GetDeliveriesByExternalOrderIdQuery, IReadOnlyList<DeliveryDto>>
    {
        private readonly IDeliveryRepository _deliveryRepository =  deliveryRepository;



        public async Task<IReadOnlyList<DeliveryDto>> Handle(GetDeliveriesByExternalOrderIdQuery query, CancellationToken ct = default)
        {
            IReadOnlyList<Domain.Models.Delivery> deliveries = await _deliveryRepository.GetDeliveriesByExternalOrderIdAsync(query.ExternalOrderId, ct);

            return [.. deliveries.Select(d => d.DeliveryToDeliveryDto())];
        }


    }
}
