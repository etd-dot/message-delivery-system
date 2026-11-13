namespace Itmo.ObjectOrientedProgramming.Lab2.Notifications;

public class SoundNotification : INotification
{
    public void Notify(string message)
    {
        Console.Beep();
    }
}