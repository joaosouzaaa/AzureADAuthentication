using AzureADAuthentication.API.Arguments;
using AzureADAuthentication.API.DataTransferObjects.Users;
using AzureADAuthentication.API.Entities;
using AzureADAuthentication.API.Interfaces.Mappers;

namespace AzureADAuthentication.API.Mappers;

public sealed class UserMapper : IUserMapper
{
    public User CreateRequestToDomain(CreateUserRequest createRequest) =>
        new()
        {
            Email = createRequest.Email,
            UserName = createRequest.Email,
            PasswordHash = createRequest.Password
        };

    public GetUserByIdResponse DomainToGetByIdResponse(User user) =>
        new(user.Id,
            user.UserName!);

    public LoginArgument LoginRequestToDomain(LoginRequest loginRequest) =>
        new(loginRequest.Email,
            loginRequest.Password);
}
