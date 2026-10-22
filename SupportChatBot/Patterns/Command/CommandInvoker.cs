using SupportChatBot.Models;

namespace SupportChatBot.Patterns.Command;

public class CommandInvoker
{
    private readonly List<IUserCommand> _history = new();
    private readonly TextWriter _output;

    public ActionJournal Journal { get; } = new();
    public int Count => _history.Count;

    public CommandInvoker(TextWriter output)
    {
        _output = output;
    }

    public void Execute(IUserCommand command, SupportBot bot)
    {
        string before = bot.StateName;
        command.Execute(bot);
        _history.Add(command);
        Journal.Add(command.Message, before, bot.StateName);
    }

    public SupportBot Replay()
    {
        var bot = new SupportBot(_output);
        bot.ShowState();

        foreach (var command in _history)
        {
            _output.WriteLine($"Вы: {command.Message}");
            command.Execute(bot);
        }

        return bot;
    }
}
