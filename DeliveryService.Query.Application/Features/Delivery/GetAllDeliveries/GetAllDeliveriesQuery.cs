using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Features.Delivery.GetAllDeliveries
{
    public sealed record GetAllDeliveriesQuery(int Page , int PageSize ) : IQuery<IReadOnlyList<DeliveryDto>>;

}
