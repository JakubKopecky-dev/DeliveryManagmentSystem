using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Domain.Enums
{
    public enum DeliveryStatus
    {
        Created,
        InProgress,
        Delivered,
        Canceled
    }
}
