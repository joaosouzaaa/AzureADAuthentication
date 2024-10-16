using AzureADAuthentication.API.Settings.NotificationSettings;

namespace AzureADAuthentication.API.Interfaces.Settings;

public interface INotificationHandler
{
    void AddNotification(string key, string message);
    List<Notification> GetNotifications();
    bool HasNotifications();
}
