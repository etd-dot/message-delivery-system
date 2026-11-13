using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public interface IFormatter
{
    string Format(Message message);
}