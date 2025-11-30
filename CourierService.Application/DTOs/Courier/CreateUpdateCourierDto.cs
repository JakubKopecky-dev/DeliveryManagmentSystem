using CourierService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Application.DTOs.Courier
{
    public sealed record CreateUpdateCourierDto
    {

        public string Name { get; init; } = "";

        public string Email { get; init; } = "";

        public string PhoneNumber { get; init; } = "";

    }
}
