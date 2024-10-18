namespace AzureADAuthentication.API.DataTransferObjects.Users;

public sealed record CreateUserRequest(
    string Email,
    string Password);
