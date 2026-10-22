using SupportChatBot.Models;

namespace SupportChatBot.Patterns.State;

public class ClarificationState : IChatState
{
    public string Name => "Уточнение проблемы";

    public void Handle(SupportBot bot, string message)
    {
        switch (message.ToLowerInvariant())
        {
            case "помощь":
                bot.Say("Опишите проблему. Если нужен человек, напишите «оператор».");
                break;
            case "оператор":
                if (bot.Problem == null)
                {
                    bot.Say("Сначала опишите проблему, чтобы я мог передать её оператору.");
                    return;
                }
                bot.Say($"Передаю оператору ваше обращение: «{bot.Problem}».");
                bot.Say("В учебном примере подключение оператора имитируется.");
                bot.ChangeState(new OperatorState());
                break;
            case "решено":
                bot.Say("Хорошо, обращение закрыто. Если понадобится помощь, напишите снова.");
                bot.ChangeState(new CompletedState());
                break;
            default:
                bot.SetProblem(message);
                bot.Say("Записал. Напишите «оператор», чтобы передать обращение человеку.");
                bot.Say("Если вопрос уже решён, напишите «решено».");
                break;
        }
    }
}
