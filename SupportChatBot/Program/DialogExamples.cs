using SupportChatBot.Models;
using SupportChatBot.Patterns.Command;

namespace SupportChatBot.Program;

public class DialogExamples
{
    private readonly TextWriter _output;

    public DialogExamples(TextWriter output)
    {
        _output = output;
    }

    public CommandInvoker FullDialog()
    {
        _output.WriteLine("Пример обращения в поддержку\n");
        return Play(new[] { "привет", "не работает интернет", "оператор", "готово" });
    }

    public CommandInvoker SameMessage()
    {
        _output.WriteLine("Как меняется ответ на слово «помощь»\n");
        return Play(new[]
        {
            "помощь", "привет", "помощь", "не работает интернет",
            "оператор", "помощь", "готово", "помощь"
        });
    }

    private CommandInvoker Play(string[] messages)
    {
        var bot = new SupportBot(_output);
        var invoker = new CommandInvoker(_output);
        bot.ShowState();

        foreach (string message in messages)
        {
            _output.WriteLine($"Вы: {message}");
            invoker.Execute(new SendMessageCommand(message), bot);
        }

        return invoker;
    }
}
