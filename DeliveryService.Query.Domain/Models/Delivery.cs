using DeliveryService.Query.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Domain.Models
{
    public class Delivery
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public Guid ExternalOrderId { get; set; }

        public Guid CourierId { get; set; }

        public string RecipientName { get; set; } = "";

        public string Address { get; set; } = "";

        public string Phone { get; set; } = "";

        public string Email { get; set; } = "";

        public uint PackageCount { get; set; }

        public double? PackageWeightKg { get; set; }

        public double? TotalVolumeM3 { get; set; }

        public DeliveryStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeliveredAt { get; set; }
    }
}
