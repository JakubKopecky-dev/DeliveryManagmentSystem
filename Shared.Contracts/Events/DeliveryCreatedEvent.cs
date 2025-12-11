using Shared.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events
{
    public sealed record DeliveryCreatedEvent
    {
        public Guid Id { get; init; }

        public Guid OwnerId { get; init; }

        public Guid ExternalOrderId { get; init; }

        public Guid CourierId { get; init; }

        public string RecipientName { get; init; } = "";

        public string Address { get; init; } = "";

        public string Phone { get; init; } = "";

        public uint PackageCount { get; init; }

        public double? PackageWeightKg { get; init; }

        public double? TotalVolumeM3 { get; init; }

        public DateTime CreatedAt { get; init; }
    }
}
