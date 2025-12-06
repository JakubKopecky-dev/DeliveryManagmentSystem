using DeliveryService.Command.Application.DTOs.Delivery;
using DeliveryService.Command.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application
{
    public static class MapperConfig
    {


        public static DeliveryDto DeliveryToDeliveryDto(this Delivery delivery) =>
            new()
            {
                Id = delivery.Id,
                OwnerId = delivery.OwnerId,
                ExternalOrderId = delivery.ExternalOrderId,
                CourierId = delivery.CourierId,
                RecipientName = delivery.RecipientName,
                Address = delivery.Address,
                Phone = delivery.Phone,
                PackageCount = (int)delivery.PackageCount,
                PackageWeightKg = delivery.PackageWeightKg,
                TotalVolumeM3 = delivery.TotalVolumeM3,
                Status = delivery.Status,
                CreatedAt = delivery.CreatedAt,
                UpdatedAt = delivery.UpdatedAt,
                DeliveredAt = delivery.DeliveredAt
            };




    }
}
