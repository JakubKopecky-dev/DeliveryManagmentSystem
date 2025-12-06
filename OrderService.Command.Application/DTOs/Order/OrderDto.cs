using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Application.DTOs.Order
{
    public sealed record OrderDto(Guid Id, string? Note, Guid UserId, DateTime CreatedAt, DateTime? UdpateAt);

}
