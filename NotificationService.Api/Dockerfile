# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy only csproj files first
COPY NotificationService.Api/*.csproj NotificationService.Api/
COPY NotificationService.Application/*.csproj NotificationService.Application/
COPY NotificationService.Infrastructure/*.csproj NotificationService.Infrastructure/
COPY NotificationService.Domain/*.csproj NotificationService.Domain/
RUN dotnet restore NotificationService.Api/NotificationService.Api.csproj

# Copy rest of the source code
COPY . .
WORKDIR /src/NotificationService.Api
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet","NotificationService.Api.dll"]