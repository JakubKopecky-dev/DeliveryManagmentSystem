using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using DeliveryService.Query.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Features.Delivery.GetDeliveryById
{
    public class GetDeliveryByIdHandler(IDeliveryRepository deliveryRepository) : IQueryHandler<GetDeliveryByIdQuery, DeliveryDto?>
    {
        private readonly IDeliveryRepository _deliveryRepository = deliveryRepository;



        public async Task<DeliveryDto?> Handle(GetDeliveryByIdQuery query, CancellationToken ct = default)
        {
            Domain.Models.Delivery? delivery = await _deliveryRepository.FindDeliveryByIdAsync(query.DeliveryId, ct);

            return delivery?.DeliveryToDeliveryDto(); 
        }

    }
}
