using DeliveryService.Query.Application.Interfaces.Repositories;
using DeliveryService.Query.Domain.Models;
using Elastic.Clients.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Text;
using DeliveryService.Query.Domain.Enums;

namespace DeliveryService.Query.Infrastructure.Repositories
{
    public class DeliveryRepository(ElasticsearchClient client) : IDeliveryRepository
    {
        private readonly ElasticsearchClient _client = client;
        private const string IndexName = "delivery";



        public async Task<Delivery?> FindDeliveryByIdAsync(Guid id, CancellationToken ct = default)
        {
            var response = await _client.GetAsync<Delivery>(id.ToString(), g => g.Index(IndexName), ct);

            return response.Found ? response.Source : null;
        }




        public async Task<IReadOnlyList<Delivery>> GetAllDeliveriesAsync(int page, int pageSize, CancellationToken ct = default)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 20;

            var response = await _client.SearchAsync<Delivery>(s => s
            .Indices(IndexName)
            .Query(q => q.MatchAll())
            .From((page - 1) * pageSize)
            .Size(pageSize), ct);

            return [.. response.Documents];
        }



        public async Task<IReadOnlyList<Delivery>> GetDeliveriesByExternalOrderIdAsync(Guid externalOrderId, CancellationToken ct = default)
        {
            var response = await _client.SearchAsync<Delivery>(s => s
            .Indices(IndexName)
            .Query(q => q
                .Term(t => t
                    .Field(f => f.ExternalOrderId)
                    .Value(externalOrderId.ToString())
                )
            )
            .Size(10), ct);

            return [.. response.Documents];
        }




        public async Task<IReadOnlyList<Delivery>> GetDeliveriesByOwnerIdAsync(Guid ownerId, int page, int pageSize, CancellationToken ct = default)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 20;

            var response = await _client.SearchAsync<Delivery>(s => s
            .Indices(IndexName)
            .Query(q => q
                .Term(t => t
                    .Field(f => f.OwnerId)
                    .Value(ownerId.ToString())
                    )
                )
            .From((page - 1) * pageSize)
            .Size(pageSize), ct);

            return [.. response.Documents];
        }


        public async Task<IReadOnlyList<Delivery>> GetActiveDeliveriesByCourierId(Guid courierId, CancellationToken ct)
        {
            var response = await _client.SearchAsync<Delivery>(s => s
            .Indices(IndexName)
            .Query(q => q
                .Bool(b => b
                    .Filter(
                        f => f.Term(t => t.Field(f => f.CourierId).Value(courierId.ToString())),
                        f => f.Terms(t => t.Field(f => f.Status).Terms(new FieldValue[] { DeliveryStatus.Created.ToString(), DeliveryStatus.InProgress.ToString() }))
                    )
                )
            )
            .Size(100), ct);

            return [.. response.Documents];
        }




    }
}
