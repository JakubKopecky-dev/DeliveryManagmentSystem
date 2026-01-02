using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Application.DTOs.External.Route
{
    public sealed record GetDistanceAndDurationResponseDto(double DurationInMinutes, double DistanceInMeters);

}
