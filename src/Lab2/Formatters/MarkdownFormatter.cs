using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkdownFormatter : IFormatter
{
    public string Format(Message message)
    {
        return $"# {message.Title}\n\n{message.Content}";
    }
}