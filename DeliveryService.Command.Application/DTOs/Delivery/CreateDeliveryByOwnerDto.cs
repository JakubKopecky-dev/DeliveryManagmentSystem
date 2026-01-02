using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryService.Command.Application.DTOs.Delivery
{
    public sealed record CreateDeliveryByOwnerDto
    {
        public Guid ExternalOrderId { get; init; }

        public Guid CourierId { get; init; }

        public string RecipientName { get; init; } = "";

        public string Address { get; init; } = "";

        public string Phone { get; init; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";

        public int PackageCount { get; init; }

        public double? PackageWeightKg { get; init; }

        public double? TotalVolumeM3 { get; init; }
    }
}
