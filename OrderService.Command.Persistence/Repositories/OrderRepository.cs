using Microsoft.EntityFrameworkCore;
using OrderService.Command.Application.Interfaces.Repositories;
using OrderService.Command.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Persistence.Repositories
{
    public class OrderRepository(OrderCommandDbContext dbContext) :BaseRepository<Order>(dbContext), IOrderRepository
    {
    }
}
