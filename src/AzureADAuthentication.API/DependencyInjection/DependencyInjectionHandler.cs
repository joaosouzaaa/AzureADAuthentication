namespace AzureADAuthentication.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();
        services.AddSwaggerDependencyInjection();

        services.AddOptionsDependencyInjection(configuration);
        services.AddAuthenticationDependencyInjection(configuration);
    }
}
