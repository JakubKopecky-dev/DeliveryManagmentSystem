using CourierService.Application.Interfaces.Repositories;
using CourierService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Persistence.Repositories
{
    public class CourierRepository(IDbContextFactory<CourierDbContext> factory) : BaseRepository<Courier>(factory), ICourierRepository
    {
    }
}
