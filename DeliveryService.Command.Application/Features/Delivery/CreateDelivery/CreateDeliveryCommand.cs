using DeliveryService.Command.Application.Abstraction.Massaging;
using DeliveryService.Command.Application.DTOs.Delivery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DeliveryService.Command.Application.Features.Delivery.CreateDelivery
{
    public sealed record CreateDeliveryCommand(CreateDeliveryDto CreateDeliveryDto) : ICommand<DeliveryDto>;

}
