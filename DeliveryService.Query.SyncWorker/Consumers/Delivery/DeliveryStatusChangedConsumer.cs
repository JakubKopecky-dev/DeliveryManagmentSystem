using Confluent.Kafka;
using Elastic.Clients.Elasticsearch;
using MassTransit;
using Shared.Contracts.Events;

namespace DeliveryService.Query.SyncWorker.Consumers.Delivery
{
    public class DeliveryStatusChangedConsumer(ElasticsearchClient client) : IConsumer<DeliveryStatusChangedEvent>
    {
        private readonly ElasticsearchClient _client = client;



        public async Task Consume(ConsumeContext<DeliveryStatusChangedEvent> context)
        {
            var message = context.Message;
            var ct = context.CancellationToken;

            await _client.UpdateAsync(new UpdateRequest<Domain.Models.Delivery, Domain.Models.Delivery>("delivery", message.DeliveryId)
            {
                Doc = new()
                {
                    Status = (Domain.Enums.DeliveryStatus)(int)message.Status,
                    UpdatedAt = message.UpdatedAt,
                    DeliveredAt = message.DeliveryAt
                }

            }, ct);



        }


    }
}
