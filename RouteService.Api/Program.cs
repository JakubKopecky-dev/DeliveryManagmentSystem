using Microsoft.AspNetCore.Server.Kestrel.Core;
using RouteService.Api.DependencyInjection;
using RouteService.Api.Grpc.GrpcService;
using RouteService.Api.Interfaces.Services;
using RouteServiceService = RouteService.Api.Services.RouteService;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel();

builder.Services.AddScoped<IRouteService, RouteServiceService>();

builder.Services.AddHttpClient("GeoClient",client =>
{
    client.BaseAddress = new Uri("https://api.openrouteservice.org/");
    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", builder.Configuration["OpenRouteService:ApiKey"]);
});

builder.Services.AddGrpc();

// Open Telemetry
builder.Services.AddOpenTelemetryService();


var app = builder.Build();

// Grpc server
app.MapGrpcService<RouteGrpcService>();

app.Run();
