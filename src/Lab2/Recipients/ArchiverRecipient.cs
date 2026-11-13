using Itmo.ObjectOrientedProgramming.Lab2.Archivators;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class ArchiverRecipient : IRecipient
{
    private readonly IMessageArchiver _archiver;

    public ArchiverRecipient(IMessageArchiver archiver)
    {
        _archiver = archiver ?? throw new ArgumentNullException(nameof(archiver));
    }

    public void Receive(Message message)
    {
        _archiver.Archive(message);
    }
}