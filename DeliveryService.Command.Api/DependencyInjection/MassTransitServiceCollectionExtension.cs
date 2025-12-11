using MassTransit;
using Shared.Contracts.Events;

namespace DeliveryService.Command.Api.DependencyInjection
{
    public static class MassTransitServiceCollectionExtension
    {
        public static IServiceCollection AddKafkaMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });


                x.AddRider(rider =>
                {
                    rider.AddProducer<DeliveryCreatedEvent>("delivery-created");
                    rider.AddProducer<DeliveryStatusChangedEvent>("delivery-status-changed");
                    rider.AddProducer<DeliveryDeletedEvent>("delivery-deleted");


                    var bootstrapServers = configuration["Kafka:BootstrapServers"];

                    rider.UsingKafka((context, k) =>
                    {
                        k.Host(bootstrapServers);
                    });

                });


            });



            return services;

        }
    }
}
