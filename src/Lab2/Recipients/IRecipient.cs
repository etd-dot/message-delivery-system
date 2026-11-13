using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public interface IRecipient
{
    void Receive(Message message);
}