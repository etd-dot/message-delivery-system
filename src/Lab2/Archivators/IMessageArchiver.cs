using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivators;

public interface IMessageArchiver
{
    void Archive(Message message);
}