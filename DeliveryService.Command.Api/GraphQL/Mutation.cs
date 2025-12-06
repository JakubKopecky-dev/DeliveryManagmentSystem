using DeliveryService.Command.Application.Abstraction.Massaging;
using DeliveryService.Command.Application.DTOs.Delivery;
using DeliveryService.Command.Application.Features.Delivery.ChangeDeliveryStatus;
using DeliveryService.Command.Application.Features.Delivery.CreateDelivery;
using DeliveryService.Command.Application.Features.Delivery.DeleteDelivery;

namespace DeliveryService.Command.Api.GraphQL
{
    public class Mutation(ICommandExecutor executor)
    {
        private readonly ICommandExecutor _executor = executor;



        public async Task<DeliveryDto> CreateDelivery(CreateDeliveryDto input, CancellationToken ct)
        {
            CreateDeliveryCommand command = new(input);

            return await _executor.Execute<CreateDeliveryCommand, DeliveryDto>(command, ct);
        }



        public async Task<DeliveryDto?> ChangeDeliveryStatus(Guid id, ChangeDeliveryStatusDto input, CancellationToken ct)
        {
            ChangeDeliveryStatusCommand command = new(id, input);

            return await _executor.Execute<ChangeDeliveryStatusCommand,DeliveryDto?>(command, ct);
        }



        public async Task<DeliveryDto?> DeleteDelivery(Guid id, CancellationToken ct)
        {
            DeleteDeliveryCommand commmand = new(id);

            return await _executor.Execute<DeleteDeliveryCommand,DeliveryDto?>(commmand, ct);
        }




    }
}
