using SupportChatBot.Models;

namespace SupportChatBot.Patterns.State;

public class CompletedState : IChatState
{
    public string Name => "Завершение";

    public void Handle(SupportBot bot, string message)
    {
        if (message.ToLowerInvariant() == "помощь")
            bot.Say("Этот диалог уже закрыт. Новый разговор можно начать из меню.");
        else
            bot.Say("Обращение закрыто. Вернитесь в меню, чтобы начать новый разговор.");
    }
}
