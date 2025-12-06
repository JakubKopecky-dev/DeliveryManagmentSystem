using OrderService.Command.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OrderService.Command.Domain.Entity
{
    public class Order : BaseEntity
    {
        public string? Note { get; set; } = "";

        public Guid UserId { get; set; }

        public ICollection<OrderItem> Items { get; set; } = [];
    }
}
