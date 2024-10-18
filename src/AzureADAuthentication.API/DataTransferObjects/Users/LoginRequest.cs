namespace AzureADAuthentication.API.DataTransferObjects.Users;

public sealed record LoginRequest(
    string Email,
    string Password);
