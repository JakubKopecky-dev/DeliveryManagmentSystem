using NotificationService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.DTOs.Notification
{
    public sealed record NotificationDto(Guid Id,
                                         string Title,
                                         Guid? CustomerId,
                                         string CustomerEmail,
                                         string Message,
                                         NotificationType Type,
                                         DateTime CreatedAt);
}
