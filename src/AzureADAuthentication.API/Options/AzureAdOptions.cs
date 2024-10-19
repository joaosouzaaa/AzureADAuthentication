namespace AzureADAuthentication.API.Options;

public sealed class AzureAdOptions
{
    public required string Instance { get; init; }
    public required string ClientId { get; init; }
    public required string TenantId { get; init; }
    public required string Scopes { get; init; }
    public required string ClientSecret { get; init; }
}
