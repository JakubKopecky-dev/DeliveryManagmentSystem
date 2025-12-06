using DeliveryService.Query.Application.Abstraction.Messaging;
using DeliveryService.Query.Application.DTOs.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Features.Delivery.GetActiveDeliveriesByCourierId
{
    public sealed record  GetActiveDeliveriesByCourierIdQuery(Guid CourierId) : IQuery<IReadOnlyList<DeliveryDto>>;

}
