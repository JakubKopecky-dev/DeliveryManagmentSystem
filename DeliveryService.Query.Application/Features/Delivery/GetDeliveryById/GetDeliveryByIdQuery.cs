using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Features.Delivery.GetDeliveryById
{
     public sealed record GetDeliveryByIdQuery(Guid DeliveryId) : IQuery<DeliveryDto?>;

}
