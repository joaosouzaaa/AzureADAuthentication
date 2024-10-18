using AzureADAuthentication.API.Data.Repositories;
using AzureADAuthentication.API.Interfaces.Repositories;

namespace AzureADAuthentication.API.DependencyInjection;

internal static class RepositoriesDependencyInjection
{
    internal static void AddRepositoriesDependencyInjection(this IServiceCollection services) =>
        services.AddScoped<IUserRepository, UserRepository>();
}
