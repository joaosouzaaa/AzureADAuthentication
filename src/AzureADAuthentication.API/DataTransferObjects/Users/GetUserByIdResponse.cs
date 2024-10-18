namespace AzureADAuthentication.API.DataTransferObjects.Users;

public sealed record GetUserByIdResponse(
    string Id,
    string Email);
