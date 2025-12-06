using DeliveryService.Command.Application.Interfaces.Repositories;
using DeliveryService.Command.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Persistence.Repositories
{
    public class DeliveryRepository(DeliveryDbContext dbContext) : BaseRepository<Delivery>(dbContext), IDeliveryRepisotry
    {
    }
}
