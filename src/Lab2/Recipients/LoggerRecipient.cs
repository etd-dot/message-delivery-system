using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class LoggerRecipient : IRecipient
{
    private readonly IRecipient _betweenRecipient;

    public LoggerRecipient(IRecipient betweenRecipient)
    {
        _betweenRecipient = betweenRecipient ?? throw new ArgumentNullException(nameof(betweenRecipient));
    }

    public void Receive(Message message)
    {
        Console.WriteLine($"Received message: {message.Title}");
        _betweenRecipient.Receive(message);
    }
}