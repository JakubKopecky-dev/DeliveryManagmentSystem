using CourierService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Domain.Entities
{
    public class Courier
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public CourierStatus Status { get; set; }

        public uint OrderDelivered { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


    }
}
