using DeliveryService.Query.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Application.Interfaces.Repositories
{
    public interface IDeliveryRepository
    {
        Task<Delivery?> FindDeliveryByIdAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<Delivery>> GetActiveDeliveriesByCourierId(Guid courierId, CancellationToken ct);
        Task<IReadOnlyList<Delivery>> GetAllDeliveriesAsync(int page, int pageSize, CancellationToken ct = default);
        Task<IReadOnlyList<Delivery>> GetDeliveriesByOwnerIdAsync(Guid ownerId, int page, int pageSize, CancellationToken ct = default);
        Task<IReadOnlyList<Delivery>> GetDeliveriesByExternalOrderIdAsync(Guid externalOrderId, CancellationToken ct = default);
    }
}
