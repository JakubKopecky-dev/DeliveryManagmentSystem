using DeliveryService.Query.Infrastructure.Elastic;
using DeliveryService.Query.SyncWorker.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKafkaMassTransit(builder.Configuration);
builder.Services.AddElastic(builder.Configuration);

var app = builder.Build();


app.Run();
