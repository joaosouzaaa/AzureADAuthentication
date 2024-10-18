using AzureADAuthentication.API.Entities;

namespace AzureADAuthentication.API.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}
