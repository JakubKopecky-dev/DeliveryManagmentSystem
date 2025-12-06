using CourierService.Application.DTOs.Courier;
using CourierService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Application
{
    public static class MapperConfig
    {
        public static CourierDto CourierToCourierDto(this Courier courier) =>
            new()
            {
                Id = courier.Id,
                Name = courier.Name,
                Email = courier.Email,
                PhoneNumber = courier.PhoneNumber,
                Status = courier.Status,
                OrderDelivered = (int)courier.OrderDelivered,
                Latitude = courier.Latitude,
                Longitude = courier.Longitude,
                CreatedAt = courier.CreatedAt,
                UpdatedAt = courier.UpdatedAt,
            };

       
    }
}
