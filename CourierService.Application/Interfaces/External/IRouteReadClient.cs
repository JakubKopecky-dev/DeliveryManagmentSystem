using CourierService.Application.DTOs.External.Route;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Application.Interfaces.External
{
    public interface IRouteReadClient
    {
        Task<GetDistanceAndDurationResponseDto?> GetDistanceAndDurationForCourierAndDeliveryAsync(GetDistanceAndDurationRequestDto requestDto, CancellationToken ct = default);
    }
}
