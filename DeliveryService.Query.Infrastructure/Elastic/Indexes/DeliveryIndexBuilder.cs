using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Query.Infrastructure.Elastic.Indexes
{
    public class DeliveryIndexBuilder(ElasticsearchClient client)
    {
        private readonly ElasticsearchClient _client = client;
        private const string IndexName = "delivery";



        public async Task EnsureExistsAsync(CancellationToken ct = default)
        {
            var exists = await _client.Indices.ExistsAsync(IndexName, ct);

            if (exists.Exists) 
                return;


            Properties props = new()
            {
                {"id",new KeywordProperty() },
                {"ownerId", new KeywordProperty()  },
                {"externalOrderId", new KeywordProperty()  },
                {"courierId", new KeywordProperty()  },
                {"recipientName", new TextProperty() },
                { "address", new TextProperty()},
                {"phone", new TextProperty() },
                {"packageCount",  new IntegerNumberProperty()},
                {"packageWeightKg",new DoubleNumberProperty() },
                {"deliveryStatus", new KeywordProperty() },
                {"createdAt", new DateProperty() },
                {"updatedAt",new DateProperty() },
                {"deliveryAt", new DateProperty() }
            };

            var response = await _client.Indices.CreateAsync(
                IndexName,
                c => c
                    .Settings(s => s.NumberOfShards(1).NumberOfReplicas(1))
                    .Mappings(m => m.Properties(props)),
                ct
                );


            if (!response.IsValidResponse)
                throw new Exception($"Failed to create index {IndexName}: {response.DebugInformation}");
        }



    }
}
