﻿using AzureADAuthentication.API.Constants;
using AzureADAuthentication.API.Options;

namespace AzureADAuthentication.API.DependencyInjection;

internal static class OptionsDependencyInjection
{
    internal static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<TokenOptions>(configuration.GetSection(OptionsConstants.TokenSection));
}
