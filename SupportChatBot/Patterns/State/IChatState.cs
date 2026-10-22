using SupportChatBot.Models;

namespace SupportChatBot.Patterns.State;

public interface IChatState
{
    string Name { get; }
    void Handle(SupportBot bot, string message);
}
