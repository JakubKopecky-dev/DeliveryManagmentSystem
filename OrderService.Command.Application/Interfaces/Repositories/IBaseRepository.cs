using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Command.Application.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> FindByIdAsync(Guid id, CancellationToken ct);
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct);
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken ct);
        void Remove(TEntity entity);
        Task SaveChangesAsync(CancellationToken ct);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);
    }
}
