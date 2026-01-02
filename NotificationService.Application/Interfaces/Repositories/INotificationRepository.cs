using NotificationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> CreateAsync(Notification notification, CancellationToken ct = default);
        Task<IReadOnlyList<Notification>> GetNotificationsByCustomerEmail(string customerEmail, CancellationToken ct = default);
    }
}
