using OrderService.Command.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Persistence
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();


app.Run();
