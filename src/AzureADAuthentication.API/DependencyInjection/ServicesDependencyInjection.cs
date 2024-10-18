using AzureADAuthentication.API.Interfaces.Services;
using AzureADAuthentication.API.Services;

namespace AzureADAuthentication.API.DependencyInjection;

internal static class ServicesDependencyInjection
{
    internal static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserService, UserService>();
    }
}
