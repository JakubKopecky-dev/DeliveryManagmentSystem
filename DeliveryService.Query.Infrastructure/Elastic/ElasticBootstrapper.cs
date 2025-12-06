using DeliveryService.Query.Infrastructure.Elastic.Indexes;
using Elastic.Clients.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Infrastructure.Elastic
{
    public class ElasticBootstrapper(ElasticsearchClient client)
    {
        private readonly ElasticsearchClient _client = client;



        public async Task EnsureIndicesExistAsync(CancellationToken ct = default)
        {
            DeliveryIndexBuilder deliveryIndex = new(_client);
            await deliveryIndex.EnsureExistsAsync(ct);
        }



    }
}
