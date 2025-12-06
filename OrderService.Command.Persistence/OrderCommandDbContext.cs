using Microsoft.EntityFrameworkCore;
using OrderService.Command.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Persistence
{
    public class OrderCommandDbContext(DbContextOptions<OrderCommandDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderItem> Items {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<OrderItem>()
                .Property(p => p.UnitPrice)
                .HasPrecision(10, 2);
        }
        
    }
}
