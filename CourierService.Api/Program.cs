using CourierService.Api.GraphQL;
using CourierService.Application;
using CourierService.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Persistence (DbContext, Repositories)
builder.Services.AddPersistenceServices(builder.Configuration);

// Application
builder.Services.AddApplicationServices();

// GraphQL
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddAuthorization();
    

var app = builder.Build();

// Redirection
app.UseHttpsRedirection();

// Auth
/*
app.UseAuthentication();
app.UseAuthorization();
*/
app.MapGraphQL();

app.Run();
