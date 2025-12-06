using Microsoft.EntityFrameworkCore;
using OrderService.Command.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity>(OrderCommandDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly OrderCommandDbContext _dbContext = dbContext;
        protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();



        public async Task<TEntity?> FindByIdAsync(Guid id, CancellationToken ct) => await _dbSet.FindAsync([id], ct);



        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct) => await _dbSet.ToListAsync(ct);



        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
            await _dbContext.SaveChangesAsync(ct);

            return entity;
        }



        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct)
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
            _dbContext.Remove(entity);
        }





    }

}
