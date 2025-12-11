using System;
using System.Collections.Generic;
using System.Text;
using Shared.Contracts.Enums;

namespace Shared.Contracts.Events
{
    public sealed record DeliveryStatusChangedEvent(Guid DeliveryId,DeliveryStatus Status, DateTime UpdatedAt, DateTime? DeliveryAt);

}
