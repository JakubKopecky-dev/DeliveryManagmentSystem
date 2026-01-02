using DeliveryService.Command.Api.Auth;
using DeliveryService.Command.Application.Abstraction.Massaging;
using DeliveryService.Command.Application.DTOs.Delivery;
using DeliveryService.Command.Application.Features.Delivery.ChangeDeliveryStatus;
using DeliveryService.Command.Application.Features.Delivery.CreateDelivery;
using DeliveryService.Command.Application.Features.Delivery.DeleteDelivery;
using HotChocolate.Authorization;
using System.Security.Claims;

namespace DeliveryService.Command.Api.GraphQL
{
    public class Mutation(ICommandExecutor executor, IHttpContextAccessor httpContextAccessor)
    {
        private readonly ICommandExecutor _executor = executor;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;


        [Authorize(Roles = [UserRoles.Admin])]
        public async Task<DeliveryDto> CreateDelivery(CreateDeliveryDto input, CancellationToken ct)
        {
            CreateDeliveryCommand command = new(input);

            return await _executor.Execute<CreateDeliveryCommand, DeliveryDto>(command, ct);
        }
        


        [Authorize(Roles = [UserRoles.User])]
        public async Task<DeliveryDto> CreateDeliveryByOwner(CreateDeliveryByOwnerDto input, CancellationToken ct)
        {
            var ownerIdString = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(ownerIdString, out var ownerId))
                throw new GraphQLException("Unauthorized");

            CreateDeliveryDto createDelivery = new()
            {
                OwnerId = ownerId,
                ExternalOrderId = input.ExternalOrderId,
                CourierId = input.CourierId,
                RecipientName = input.RecipientName,
                Address = input.Address,
                Phone = input.Phone,
                Email = input.Email,
                PackageCount = input.PackageCount,
                PackageWeightKg = input.PackageWeightKg,
                TotalVolumeM3 = input.TotalVolumeM3
            };

            CreateDeliveryCommand command = new(createDelivery);

            return await _executor.Execute<CreateDeliveryCommand, DeliveryDto>(command, ct);
        }



        [Authorize(Roles = [UserRoles.Admin])]
        public async Task<DeliveryDto?> ChangeDeliveryStatus(Guid id, ChangeDeliveryStatusDto input, CancellationToken ct)
        {
            ChangeDeliveryStatusCommand command = new(id, input);

            return await _executor.Execute<ChangeDeliveryStatusCommand,DeliveryDto?>(command, ct);
        }



        [Authorize(Roles = [UserRoles.Admin])]
        public async Task<DeliveryDto?> DeleteDelivery(Guid id, CancellationToken ct)
        {
            DeleteDeliveryCommand commmand = new(id);

            return await _executor.Execute<DeleteDeliveryCommand,DeliveryDto?>(commmand, ct);
        }




    }
}
