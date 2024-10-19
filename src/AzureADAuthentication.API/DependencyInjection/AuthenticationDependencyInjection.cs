using AzureADAuthentication.API.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace AzureADAuthentication.API.DependencyInjection;

internal static class AuthenticationDependencyInjection
{
    internal static void AddAuthenticationDependencyInjection(this IServiceCollection services, IConfiguration configuration) =>
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(configuration, OptionsConstants.AzureAdSection);
}
