using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    private readonly Dictionary<int, Message> _inbox = new();

    private readonly Dictionary<int, bool> _readStatus = new Dictionary<int, bool>();

    private int _nextId;

    public IReadOnlyDictionary<int, Message> Inbox => _inbox;

    public bool TryReceive(Message message, out int id)
    {
        if (message == null)
        {
            id = 0;
            return false;
        }

        id = ++_nextId;
        _readStatus[id] = false;
        _inbox[id] = message;
        return true;
    }

    public bool TryMarkMessageAsRead(int id, out string? error)
    {
        if (_readStatus.ContainsKey(id))
        {
            if (_readStatus[id])
            {
                error = "Message already read";
                return false;
            }

            _readStatus[id] = true;
            error = null;
            return true;
        }

        error = "Message not found";
        return false;
    }

    public bool IsRead(int id)
    {
        return _readStatus.ContainsKey(id) && _readStatus[id];
    }
}