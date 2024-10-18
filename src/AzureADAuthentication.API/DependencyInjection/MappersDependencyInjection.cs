using AzureADAuthentication.API.Interfaces.Mappers;
using AzureADAuthentication.API.Mappers;

namespace AzureADAuthentication.API.DependencyInjection;

internal static class MappersDependencyInjection
{
    internal static void AddMappersDependencyInjection(this IServiceCollection services) =>
        services.AddScoped<IUserMapper, UserMapper>();
}
