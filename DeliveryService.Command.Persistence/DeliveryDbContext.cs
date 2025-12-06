using DeliveryService.Command.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Persistence
{
    public class DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : DbContext(options)
    {
        public DbSet<Delivery> Deliveries { get; set; }
    }
}
