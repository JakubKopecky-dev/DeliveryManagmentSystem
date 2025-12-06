using DeliveryService.Command.Application.Abstraction.Massaging;
using DeliveryService.Command.Application.DTOs.Delivery;
using DeliveryService.Command.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application.Features.Delivery.ChangeDeliveryStatus
{
    public class ChangeDeliveryStatusHandler(IDeliveryRepisotry deliveryRepository) : ICommandHandler<ChangeDeliveryStatusCommand,DeliveryDto?>
    {
        private readonly IDeliveryRepisotry _deliveryRepisotry = deliveryRepository;



        public async Task<DeliveryDto?> Handle(ChangeDeliveryStatusCommand command, CancellationToken ct = default)
        {
            Domain.Entities.Delivery? delivery = await _deliveryRepisotry.FindByIdAsync(command.Id, ct);
            if(delivery is null)
                return null;

            delivery.UpdatedAt = DateTime.UtcNow;

            if (command.ChangeDeliveryStatusDto.Status is Domain.Enums.DeliveryStatus.Delivered)
                delivery.DeliveredAt = DateTime.UtcNow;

            Domain.Entities.Delivery updatedDelivery = await _deliveryRepisotry.UpdateAsync(delivery,ct);

            return updatedDelivery.DeliveryToDeliveryDto();
        }



    }
}
