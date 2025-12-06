using OrderService.Command.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Domain.Entity
{
    public class OrderItem : BaseEntity
    {
        public string Title { get; set; } = "";

        public decimal UnitPrice { get; set; }

        public uint Quantity { get; set; }

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

    }
}
