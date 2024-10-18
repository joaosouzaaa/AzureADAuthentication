using AzureADAuthentication.API.Arguments;
using AzureADAuthentication.API.DataTransferObjects.Users;
using AzureADAuthentication.API.Entities;

namespace AzureADAuthentication.API.Interfaces.Mappers;

public interface IUserMapper
{
    User CreateRequestToDomain(CreateUserRequest createRequest);
    GetUserByIdResponse DomainToGetByIdResponse(User user);
    LoginArgument LoginRequestToDomain(LoginRequest loginRequest);
}
