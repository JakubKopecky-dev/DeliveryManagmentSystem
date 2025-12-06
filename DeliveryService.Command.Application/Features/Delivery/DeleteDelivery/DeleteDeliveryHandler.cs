using DeliveryService.Command.Application.Abstraction.Massaging;
using DeliveryService.Command.Application.DTOs.Delivery;
using DeliveryService.Command.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Application.Features.Delivery.DeleteDelivery
{
    public class DeleteDeliveryHandler(IDeliveryRepisotry deliveryRepisotry) : ICommandHandler<DeleteDeliveryCommand,DeliveryDto?>
    {
        private readonly IDeliveryRepisotry _deliveryRepisotry = deliveryRepisotry;



        public async Task<DeliveryDto?> Handle(DeleteDeliveryCommand command, CancellationToken ct = default)
        {
            Domain.Entities.Delivery? delivery = await _deliveryRepisotry.FindByIdAsync(command.DeliveryId,ct);
            if(delivery is null)
                return null;

            DeliveryDto deletedDelivery = delivery.DeliveryToDeliveryDto();

            _deliveryRepisotry.Remove(delivery);
            await _deliveryRepisotry.SaveChangesAsync(ct);

            return deletedDelivery;
        }





    }
}
