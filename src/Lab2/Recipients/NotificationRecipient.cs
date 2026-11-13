using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Notifications;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class NotificationRecipient : IRecipient
{
    private readonly INotification _notification;

    private readonly List<string> _bannedWords;

    public NotificationRecipient(INotification notification, IEnumerable<string> bannedWords)
    {
        _notification = notification ?? throw new ArgumentNullException(nameof(notification));
        ArgumentNullException.ThrowIfNull(bannedWords);
        _bannedWords = bannedWords.ToList();
    }

    public void Receive(Message message)
    {
        if (_bannedWords.Count == 0)
        {
            return;
        }

        string title = message.Title;
        string content = message.Content;

        foreach (string bannedWord in _bannedWords)
        {
            if (title.Contains(bannedWord, StringComparison.OrdinalIgnoreCase) || content.Contains(bannedWord, StringComparison.OrdinalIgnoreCase))
            {
                _notification.Notify($"Detected banned word: {bannedWord}");
                return;
            }
        }
    }
}