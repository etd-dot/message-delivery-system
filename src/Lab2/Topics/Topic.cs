using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    public string Name { get; }

    private readonly List<IRecipient> _recipients = [];

    public IReadOnlyList<IRecipient> Recipients => _recipients;

    public Topic(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        Name = name;
    }

    public void AddRecipient(IRecipient recipient)
    {
        if (!_recipients.Contains(recipient))
        {
            _recipients.Add(recipient);
        }
    }

    public void SendToRecipients(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.Receive(message);
        }
    }
}