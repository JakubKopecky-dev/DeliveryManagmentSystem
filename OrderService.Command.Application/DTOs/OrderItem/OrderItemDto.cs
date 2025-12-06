using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Application.DTOs.OrderItem
{
    public sealed record OrderItemDto(Guid Id,string Title, decimal UnitPrice, int Quantity, DateTime CreatedAt, DateTime? UpdatedAt );

}
