using System;
using System.Collections.Generic;
using System.Text;
using CourierService.Domain.Enums;

namespace CourierService.Application.DTOs.External.Route
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Locations">First item is the courier and second is the delivery</param>
    /// <param name="VehicleType"></param>
    public sealed record GetDistanceAndDurationRequestDto(List<LocationDto> Locations, VehicleType VehicleType);

}
