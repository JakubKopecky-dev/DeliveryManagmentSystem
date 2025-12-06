using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Application.DTOs.Order
{
    public sealed record CreateOrderDto(string? Note, Guid UserId);

}
