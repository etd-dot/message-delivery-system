using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab2.Importances;

public class ImportanceFilter : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ImportanceLevel _minImportanceLevel;

    public ImportanceFilter(IRecipient recipient, ImportanceLevel level)
    {
        _recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        _minImportanceLevel = level;
    }

    public void Receive(Message message)
    {
        if (message.Importance >= _minImportanceLevel)
        {
            _recipient.Receive(message);
        }
    }
}