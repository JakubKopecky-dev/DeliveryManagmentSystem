using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Application.DTOs.Courier
{
    public sealed record UpdateLocationDto(double? Latitude, double? Longitude);
 
}
