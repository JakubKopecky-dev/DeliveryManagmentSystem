using DeliveryService.Command.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Command.Persistence.Repositories
{
    public class BaseRepository<TEntity>(DeliveryDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DeliveryDbContext _dbContext = dbContext;
        protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();



        public async Task<TEntity?> FindByIdAsync(Guid id, CancellationToken ct = default) => await _dbSet.FindAsync([id], ct);



        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct) => await _dbSet.ToListAsync(ct);



        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
            await _dbContext.SaveChangesAsync(ct);

            return entity;
        }



        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync(ct);

            return entity;
        }



        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _dbContext.SaveChangesAsync(ct);
        }



        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }



    }
}
