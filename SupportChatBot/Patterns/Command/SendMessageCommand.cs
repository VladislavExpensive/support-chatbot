using SupportChatBot.Models;

namespace SupportChatBot.Patterns.Command;

public class SendMessageCommand : IUserCommand
{
    public string Message { get; }

    public SendMessageCommand(string message)
    {
        Message = message;
    }

    public void Execute(SupportBot bot)
    {
        bot.Receive(Message);
    }
}
