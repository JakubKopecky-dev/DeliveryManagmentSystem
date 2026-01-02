using NotificationService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Domain.Models
{
    public class Notification
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = "";

        public Guid? CustomerId { get; set; }

        public string CustomerEmail { get; set; } = "";

        public string Message { get; set; } = "";

        public NotificationType Type { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
