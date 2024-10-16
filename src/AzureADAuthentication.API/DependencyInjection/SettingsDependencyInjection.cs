using AzureADAuthentication.API.Filters;
using AzureADAuthentication.API.Interfaces.Settings;
using AzureADAuthentication.API.Settings.NotificationSettings;
using FluentValidation;
using System.Reflection;

namespace AzureADAuthentication.API.DependencyInjection;

internal static class SettingsDependencyInjection
{
    internal static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
        services.AddScoped<NotificationFilter>();

        services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));
    }
}
