using DeliveryService.Command.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application.DTOs.Delivery
{
    public sealed record ChangeDeliveryStatusDto(DeliveryStatus Status);

}
