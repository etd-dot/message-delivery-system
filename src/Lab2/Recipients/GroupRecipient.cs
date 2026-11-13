using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients = [];

    public string GroupName { get; }

    public IReadOnlyCollection<IRecipient> Recipients => _recipients;

    public GroupRecipient(string groupName)
    {
        ArgumentException.ThrowIfNullOrEmpty(groupName);
        GroupName = groupName;
    }

    public void AddRecipient(IRecipient recipient)
    {
        if (!_recipients.Contains(recipient))
        {
            _recipients.Add(recipient);
        }
    }

    public void Receive(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.Receive(message);
        }
    }
}