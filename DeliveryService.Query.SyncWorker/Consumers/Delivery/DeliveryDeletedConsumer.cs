using Elastic.Clients.Elasticsearch;
using MassTransit;
using Shared.Contracts.Events;

namespace DeliveryService.Query.SyncWorker.Consumers.Delivery
{
    public class DeliveryDeletedConsumer(ElasticsearchClient client) :IConsumer<DeliveryDeletedEvent>
    {
        private readonly ElasticsearchClient _client = client;



        public async Task Consume(ConsumeContext<DeliveryDeletedEvent> context)
        {
            var message = context.Message;
            var ct = context.CancellationToken;

            await _client.DeleteAsync<Domain.Models.Delivery>(message.DeliveryId, d => d.Index("delivery"), ct);
        }


    }
}
