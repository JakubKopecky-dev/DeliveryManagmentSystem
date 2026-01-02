using MassTransit;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Application.DTOs.External;
using NotificationService.Application.DTOs.Notification;
using NotificationService.Application.Interfaces.External;
using NotificationService.Application.Interfaces.Services;
using Shared.Contracts.Events;

namespace NotificationService.Api.Consumers.Delivery
{
    public class DeliveryStatusChangedConsumer(INotificationService notificationService, IUserReadClient userClient, IHubContext hubContext) : IConsumer<DeliveryStatusChangedEvent>
    {
        private readonly INotificationService _notificationService = notificationService;
        private readonly IUserReadClient _userClient = userClient;
        private readonly IHubContext _hubContext = hubContext;



        public async Task Consume(ConsumeContext<DeliveryStatusChangedEvent> context)
        {
            var ct = context.CancellationToken;
            var message = context.Message;


            IsUserExistDto userCheck = await _userClient.IsUserExistsByEmailAsync(message.CustomerEmail, ct);
            bool userExist = userCheck.IsUserExist;
            Guid? customerId = userExist && Guid.TryParse(userCheck.UserId, out var id) ? id : null;

            string title = $"Delivery ({message.DeliveryId}) has new status: {message.Status}";

            string messageBody = message.Status == Shared.Contracts.Enums.DeliveryStatus.Delivered ?
                 $"Your delivery {message.DeliveryId} was delivered at {message.DeliveryAt}" :
                 $"Your delivery {message.DeliveryId} has new status: {message.Status}.";

            CreateNotificationDto createDto = new(title, customerId, message.CustomerEmail, messageBody, Domain.Enums.NotificationType.DeliveryStatusChanged);
            NotificationDto createdNotification = await _notificationService.CreateNotificationAsync(createDto, ct);

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
