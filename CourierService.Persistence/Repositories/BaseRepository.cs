using CourierService.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierService.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly CourierDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

 
        protected BaseRepository(IDbContextFactory<CourierDbContext> contextFactory)
        {
            _dbContext = contextFactory.CreateDbContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity?> FindByIdAsync(Guid id, CancellationToken ct = default) => await _dbSet.FindAsync([id], ct);



        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default) => await _dbSet.ToListAsync(ct);



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


        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }



        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _dbContext.SaveChangesAsync(ct);
        }





    }
}
