using SupportChatBot.Models;

namespace SupportChatBot.Patterns.State;

public class GreetingState : IChatState
{
    public string Name => "Приветствие";

    public void Handle(SupportBot bot, string message)
    {
        switch (message.ToLowerInvariant())
        {
            case "привет":
            case "здравствуйте":
                bot.Say("Здравствуйте! Расскажите, с чем нужна помощь.");
                bot.ChangeState(new ClarificationState());
                break;
            case "помощь":
                bot.Say("Сначала напишите «привет», чтобы начать разговор.");
                break;
            default:
                bot.Say("Давайте начнём с приветствия. Напишите «привет».");
                break;
        }
    }
}
