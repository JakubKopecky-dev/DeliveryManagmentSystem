using System.Text.Json.Serialization;

namespace RouteService.Api.DTOs
{
    public sealed record GeoRequestDto
    {
        [JsonPropertyName("locations")]
        public required double[][] Locations { get; init; }

        [JsonPropertyName("metrics")]
        public required string[] Metrics { get; init; }

        [JsonPropertyName("resolve_locations")]
        public bool ResolveLocations { get; init; }

        [JsonPropertyName("sources")]
        public int[]? Sources { get; init; }

        [JsonPropertyName("units")]
        public string? Units { get; init; }
    }
}
