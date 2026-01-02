using NotificationService.Application.DTOs.Notification;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.Application.Interfaces.Services;
using NotificationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.Services
{
    public class NotificationService(INotificationRepository notificationRepository) : INotificationService
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;



        public async Task<IReadOnlyList<NotificationDto>> GetNotificationsByCustomerEmailAsync(string customerEmail, CancellationToken ct = default)
        {
            IReadOnlyList<Notification> notifications = await _notificationRepository.GetNotificationsByCustomerEmail(customerEmail, ct);

            return [.. notifications.Select(s => new NotificationDto(s.Id, s.Title, s.CustomerId, s.CustomerEmail, s.Message, s.Type, s.CreatedAt))];
        }



        public async Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto createDto, CancellationToken ct = default)
        {
            Notification notification = new()
            {
                Id = Guid.NewGuid(),
                Title = createDto.Title,
                CustomerId = createDto.CustomerId,
                CustomerEmail = createDto.CustomerEmail,
                Message = createDto.Message,
                Type = createDto.Type,
                CreatedAt = DateTime.UtcNow,
            };


            Notification createdNotification = await _notificationRepository.CreateAsync(notification, ct);

            return new(createdNotification.Id,
                    createdNotification.Title,
                    createdNotification.CustomerId,
                    createdNotification.CustomerEmail,
                    createdNotification.Message,
                    createdNotification.Type,
                    createdNotification.CreatedAt);
        }



    }
}
