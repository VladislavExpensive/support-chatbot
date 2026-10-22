using SupportChatBot.Models;

namespace SupportChatBot.Patterns.Command;

public interface IUserCommand
{
    string Message { get; }
    void Execute(SupportBot bot);
}
