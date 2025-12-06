using DeliveryService.Command.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application.DTOs.Delivery
{
    public sealed record  DeliveryDto
    {
        public Guid Id { get; init; }

        public Guid OwnerId { get; init; }

        public Guid ExternalOrderId { get; init; }

        public Guid CourierId { get; init; }

        public string RecipientName { get; init; } = "";

        public string Address { get; init; } = "";

        public string Phone { get; init; } = "";

        public int PackageCount { get; init; }

        public double? PackageWeightKg { get; init; }

        public double? TotalVolumeM3 { get; init; }

        public DeliveryStatus Status { get; init; }

        public DateTime CreatedAt { get; init; }

        public DateTime? UpdatedAt { get; init; }

        public DateTime? DeliveredAt { get; init; }
    }
}
