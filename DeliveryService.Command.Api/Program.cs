using DeliveryService.Command.Api.GraphQL;
using DeliveryService.Command.Application;
using DeliveryService.Command.Persistence;
using DeliveryService.Command.Api.Middleware;
using HotChocolate.Types;

var builder = WebApplication.CreateBuilder(args);

// Persistence
builder.Services.AddPersistenceServices(builder.Configuration);

// Application
builder.Services.AddApplicationServices();



builder.Services
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();


var app = builder.Build();

// Client cancellation logging
app.UseClientCancellationLogging();

app.UseHttpsRedirection();
app.MapGraphQL();


app.Run();
