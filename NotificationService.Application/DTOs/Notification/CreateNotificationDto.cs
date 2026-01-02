using NotificationService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.DTOs.Notification
{
    public sealed record CreateNotificationDto(string Title,
                                         Guid? CustomerId,
                                         string CustomerEmail,
                                         string Message,
                                         NotificationType Type);
  
}
