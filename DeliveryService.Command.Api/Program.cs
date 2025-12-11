using DeliveryService.Command.Api.GraphQL;
using DeliveryService.Command.Application;
using DeliveryService.Command.Persistence;
using DeliveryService.Command.Api.Middleware;
using HotChocolate.Types;
using DeliveryService.Command.Api.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Persistence
builder.Services.AddPersistenceServices(builder.Configuration);

// Application
builder.Services.AddApplicationServices();

// Auth
builder.Services.AddAuthenticationAndIdentityServiceCollection(builder.Configuration);

// HttpContext accessor
builder.Services.AddHttpContextAccessor();

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();


var app = builder.Build();

// Client cancellation logging
app.UseClientCancellationLogging();

app.UseHttpsRedirection();

// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();


app.Run();
