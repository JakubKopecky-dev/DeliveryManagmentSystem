using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events
{
    public sealed record DeliveryDeletedEvent(Guid DeliveryId);

}
