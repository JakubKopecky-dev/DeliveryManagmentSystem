using DeliveryService.Command.Application.Abstraction.Massaging;
using DeliveryService.Command.Application.DTOs.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application.Features.Delivery.DeleteDelivery
{
    public sealed record DeleteDeliveryCommand(Guid DeliveryId) :ICommand<DeliveryDto?>;

}
