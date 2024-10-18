using AzureADAuthentication.API.DataTransferObjects.Users;

namespace AzureADAuthentication.API.Interfaces.Services;

public interface IUserService
{
    Task CreateAsync(CreateUserRequest createUser, CancellationToken cancellationToken);
    Task<GetUserByIdResponse?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<BearerResponse?> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken);
}
