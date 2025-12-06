using OrderService.Command.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Application.Interfaces.Repositories
{
    public interface IOrderItemRespository : IBaseRepository<OrderItem>
    {
    }
}
