using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivators;

public class FormattingArchiver : IMessageArchiver
{
    private readonly IFormatter _formatter;

    private readonly List<string> _formattedMessages = [];

    public IReadOnlyList<string> FormattedMessages => _formattedMessages;

    public FormattingArchiver(IFormatter formatter)
    {
        _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
    }

    public void Archive(Message message)
    {
        string formattedMessage = _formatter.Format(message);
        _formattedMessages.Add(formattedMessage);
    }
}