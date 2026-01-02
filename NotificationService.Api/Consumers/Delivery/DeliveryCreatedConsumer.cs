using MassTransit;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Application.DTOs.External;
using NotificationService.Application.DTOs.Notification;
using NotificationService.Application.Interfaces.External;
using NotificationService.Application.Interfaces.Services;
using Shared.Contracts.Events;

namespace NotificationService.Api.Consumers.Delivery
{
    public class DeliveryCreatedConsumer(INotificationService notificationService, IUserReadClient userClient, IHubContext hubContext) : IConsumer<DeliveryCreatedEvent>
    {
        private readonly INotificationService _notificationService = notificationService;
        private readonly IUserReadClient _userClient = userClient;
        private readonly IHubContext _hubContext = hubContext;
        


        public async Task Consume(ConsumeContext<DeliveryCreatedEvent> context)
        {
            var ct = context.CancellationToken;
            var message = context.Message;

            IsUserExistDto userCheck = await _userClient.IsUserExistsByEmailAsync(message.Email, ct);
            bool userExist = userCheck.IsUserExist;
            Guid? customerId = userExist && Guid.TryParse(userCheck.UserId, out var id) ? id : null;


            var title = $"Delivery ({message.Id}) created";
            var messageBody = $"Hello {message.RecipientName},\nwe have created new delivery {message.Id} for your order {message.ExternalOrderId}." +
                $"\nYour address: {message.Address}\nYour phone number: {message.Phone}.";

            CreateNotificationDto creteDto = new(title, customerId, message.Email, messageBody, Domain.Enums.NotificationType.DeliveryCreated);
            NotificationDto createdNotification =  await _notificationService.CreateNotificationAsync(creteDto, ct);


            if (customerId is not null)
            {
                await _hubContext.Clients.User(customerId.ToString()!)
                    .SendAsync("ReceiveNotification", new
                    {
                        createdNotification.Id,
                        createdNotification.Title,
                        createdNotification.Message,
                        createdNotification.CreatedAt,
                    }, ct);
            }

        }



    }
}
