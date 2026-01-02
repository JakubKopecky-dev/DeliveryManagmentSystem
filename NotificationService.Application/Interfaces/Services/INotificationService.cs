using NotificationService.Application.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.Interfaces.Services
{
    public interface INotificationService
    {
        Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto createDto, CancellationToken ct = default);
        Task<IReadOnlyList<NotificationDto>> GetNotificationsByCustomerEmailAsync(string customerEmail, CancellationToken ct = default);
    }
}
