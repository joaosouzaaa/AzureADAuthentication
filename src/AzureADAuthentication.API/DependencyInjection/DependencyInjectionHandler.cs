using AzureADAuthentication.API.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace AzureADAuthentication.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();
        services.AddSwaggerDependencyInjection();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentityDependencyInjection();
        services.AddOptionsDependencyInjection(configuration);
        services.AddAuthenticationDependencyInjection(configuration);
        services.AddSettingsDependencyInjection();
        services.AddRepositoriesDependencyInjection();
        services.AddMappersDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
