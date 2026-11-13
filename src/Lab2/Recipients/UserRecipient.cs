using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class UserRecipient : IRecipient
{
    private readonly User _user;

    public UserRecipient(User user)
    {
        _user = user ?? throw new ArgumentNullException(nameof(user));
    }

    public void Receive(Message message)
    {
        _user.TryReceive(message, out _);
    }
}