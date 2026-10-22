using SupportChatBot.Models;

namespace SupportChatBot.Patterns.State;

public class OperatorState : IChatState
{
    public string Name => "Переход к оператору";

    public void Handle(SupportBot bot, string message)
    {
        switch (message.ToLowerInvariant())
        {
            case "готово":
                bot.Say("Спасибо за обращение. Диалог завершён.");
                bot.ChangeState(new CompletedState());
                break;
            case "помощь":
                bot.Say("Обращение у оператора. Напишите «готово», когда вопрос будет решён.");
                break;
            default:
                bot.Say("Сообщение добавлено к обращению. Для завершения напишите «готово».");
                break;
        }
    }
}
