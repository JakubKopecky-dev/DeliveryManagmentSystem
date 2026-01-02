using MassTransit;
using NotificationService.Api.Consumers.Delivery;
using Shared.Contracts.Events;

namespace NotificationService.Api.DependencyInjection
{
    public static class MassTransitServiceCollectionExtension
    {
        public static IServiceCollection AddKafkaMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.UsingInMemory((context, cfg) =>
                {
                });

                x.AddRider(rider =>
                {
                    rider.AddConsumer<DeliveryCreatedConsumer>();
                    rider.AddConsumer<DeliveryStatusChangedConsumer>();

                    rider.UsingKafka((context, k) =>
                    {
                        k.Host(configuration["Kafka:BootstrapServers"]);

                        k.TopicEndpoint<DeliveryCreatedEvent>("delivery-created","notification-service-group",e =>
                            {
                                e.ConfigureConsumer<DeliveryCreatedConsumer>(context);
                            });


                        k.TopicEndpoint<DeliveryStatusChangedEvent>("delivery-status-changed","notification-service-group",e =>
                            {
                                e.ConfigureConsumer<DeliveryStatusChangedConsumer>(context);
                            });
                    });
                });
            });

            return services;
        }

    }
}
