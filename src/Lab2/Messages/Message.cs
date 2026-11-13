using Itmo.ObjectOrientedProgramming.Lab2.Importances;

namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public record Message
{
    public string Title { get; private set; }

    public string Content { get; init; }

    public ImportanceLevel Importance { get; init; }

    public Message(string title, string content, ImportanceLevel importance)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(content);
        Title = title;
        Content = content;
        Importance = importance;
    }
}