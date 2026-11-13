namespace Itmo.ObjectOrientedProgramming.Lab2.Notifications;

public class TextNotification : INotification
{
    private readonly string _notificationPrefix;

    public TextNotification(string notificationPrefix)
    {
        _notificationPrefix = notificationPrefix;
    }

    public void Notify(string message)
    {
        Console.WriteLine(_notificationPrefix + '\n' + message);
    }
}