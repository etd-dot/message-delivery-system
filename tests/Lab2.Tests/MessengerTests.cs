using Itmo.ObjectOrientedProgramming.Lab2.Archivators;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Importances;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Topics;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class MessengerTests
{
    [Fact]
    public void Test1_Receive()
    {
        var user = new User();
        var message = new Message("TestTitle", "TestContent", ImportanceLevel.MediumImportance);

        bool result = user.TryReceive(message, out int id);

        Assert.True(result);
        Assert.False(user.IsRead(id));
    }

    [Fact]
    public void Test2_ReceiveAndRead()
    {
        var user = new User();
        var message = new Message("TestTitle", "TestContent", ImportanceLevel.MediumImportance);
        user.TryReceive(message, out int id);

        bool result = user.TryMarkMessageAsRead(id, out string? error);

        Assert.True(result);
        Assert.Null(error);
        Assert.True(user.IsRead(id));
    }

    [Fact]
    public void Test3_ReceiveAndReread()
    {
        var user = new User();
        var message = new Message("TestTitle", "TestContent", ImportanceLevel.MediumImportance);
        user.TryReceive(message, out int id);
        user.TryMarkMessageAsRead(id, out _);

        bool result = user.TryMarkMessageAsRead(id, out string? error);

        Assert.False(result);
        Assert.NotNull(error);
        Assert.True(user.IsRead(id));
    }

    private class MockRecipient : IRecipient
    {
        public int RecievedMessages { get; set; }

        public Message? LastMessage { get; set; }

        public void Receive(Message message)
        {
            RecievedMessages++;
            LastMessage = message;
        }
    }

    [Fact]
    public void Test4_ReceiveUnimportant()
    {
        var mock = new MockRecipient();
        var filter = new ImportanceFilter(mock, ImportanceLevel.MediumImportance);
        var lowImportance = new Message("TestTitleLow", "TestContent", ImportanceLevel.LowImportance);
        var mediumImportance = new Message("TestTitleMedium", "TestContent", ImportanceLevel.MediumImportance);

        filter.Receive(lowImportance);
        filter.Receive(mediumImportance);

        Assert.Equal(1, mock.RecievedMessages);
        Assert.Equal("TestTitleMedium", mock.LastMessage?.Title);
    }

    [Fact]
    public void Test5_LoggerTest()
    {
        var mock = new MockRecipient();
        var logger = new LoggerRecipient(mock);
        var message = new Message("TestTitle", "TestContent", ImportanceLevel.MediumImportance);
        var sw = new StringWriter();
        TextWriter original = Console.Out;
        Console.SetOut(sw);

        try
        {
            logger.Receive(message);
        }
        finally
        {
            Console.SetOut(original);
        }

        string output = sw.ToString();

        Assert.Contains("Received message:", output, StringComparison.Ordinal);
        Assert.Contains("TestTitle", output, StringComparison.Ordinal);
        Assert.Equal(1, mock.RecievedMessages);
        Assert.Equal(message, mock.LastMessage);
    }

    public class MockFormatter : IFormatter
    {
        private readonly string _formattedMessage;

        public int Count { get; private set; }

        public MockFormatter(string formattedMessage)
        {
            _formattedMessage = formattedMessage;
        }

        public string Format(Message message)
        {
            Count++;
            return _formattedMessage;
        }
    }

    [Fact]
    public void Test6_FormatterTest()
    {
        var formatter = new MockFormatter("formatted message");
        var archiver = new FormattingArchiver(formatter);
        var message = new Message("TestTitle", "TestContent", ImportanceLevel.MediumImportance);

        archiver.Archive(message);

        Assert.Equal("formatted message", archiver.FormattedMessages[0]);
        Assert.Equal(1, formatter.Count);
    }

    [Fact]
    public void Test7_DifferentImportanceSettings()
    {
        var user1 = new User();
        var user2 = new User();

        var user1Recipient = new UserRecipient(user1);
        var user2FilteredRecipient = new ImportanceFilter(new UserRecipient(user2), ImportanceLevel.MediumImportance);

        var topic = new Topic("general");
        topic.AddRecipient(user1Recipient);
        topic.AddRecipient(user2FilteredRecipient);

        var lowImportance = new Message("low", "body", ImportanceLevel.LowImportance);
        var mediumImportance = new Message("low", "body", ImportanceLevel.MediumImportance);
        var highImportance = new Message("low", "body", ImportanceLevel.HighImportance);

        topic.SendToRecipients(lowImportance);
        topic.SendToRecipients(mediumImportance);
        topic.SendToRecipients(highImportance);

        Assert.Equal(3, user1.Inbox.Count);
        Assert.Equal(2, user2.Inbox.Count);
    }
}