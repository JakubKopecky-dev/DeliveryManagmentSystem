
using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using DeliveryService.Query.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Features.Delivery.GetAllDeliveries
{
    public class GetAllDeliveriesHandler(IDeliveryRepository deliveryRepository) :IQueryHandler<GetAllDeliveriesQuery, IReadOnlyList<DeliveryDto>>
    {
        private readonly IDeliveryRepository _deliveryRepository = deliveryRepository;



        public async Task<IReadOnlyList<DeliveryDto>> Handle(GetAllDeliveriesQuery query, CancellationToken ct = default)
        {
            IReadOnlyList<Domain.Models.Delivery> deliveries = await _deliveryRepository.GetAllDeliveriesAsync(query.Page, query.PageSize, ct);

            return [.. deliveries.Select(d => d.DeliveryToDeliveryDto())];
        }
    }
}
