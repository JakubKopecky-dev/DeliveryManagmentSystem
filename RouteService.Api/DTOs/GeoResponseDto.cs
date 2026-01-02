using System.Text.Json.Serialization;

namespace RouteService.Api.DTOs
{
    public sealed record  GeoResponseDto
    {
        [JsonPropertyName("durations")]
        public required double[][] DurationsInMinutes { get; init; }

        [JsonPropertyName("distances")]
        public required double[][] DistancesInMeters { get; init; }
    }
}
