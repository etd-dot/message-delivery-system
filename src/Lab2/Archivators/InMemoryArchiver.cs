using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivators;

public class InMemoryArchiver : IMessageArchiver
{
    private readonly List<Message> _archivedMessages = [];

    public IReadOnlyList<Message> ArchivedMessages => _archivedMessages;

    public void Archive(Message message)
    {
        _archivedMessages.Add(message);
    }
}