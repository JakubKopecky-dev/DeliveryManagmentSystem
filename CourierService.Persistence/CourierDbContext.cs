using CourierService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace CourierService.Persistence
{
    public class CourierDbContext(DbContextOptions<CourierDbContext> options) : DbContext(options)
    {
        public DbSet<Courier> Couriers { get; set; }
    }
}
