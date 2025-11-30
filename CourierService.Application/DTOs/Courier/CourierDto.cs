using CourierService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Application.DTOs.Courier
{
    public sealed record CourierDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = "";

        public string Email { get; init; } = "";

        public string PhoneNumber { get; init; } = "";

        public CourierStatus Status { get; init; }

        public int OrderDelivered { get; init; }

        public double? Latitude { get; init; }

        public double? Longitude { get; init; }

        public DateTime CreatedAt { get; init; }

        public DateTime? UpdatedAt { get; init; }
    }
}
