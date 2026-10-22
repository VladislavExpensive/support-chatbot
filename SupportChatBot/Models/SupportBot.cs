using SupportChatBot.Patterns.State;

namespace SupportChatBot.Models;

public class SupportBot
{
    private IChatState _state = new GreetingState();
    private readonly TextWriter _output;

    public string StateName => _state.Name;
    public string? Problem { get; private set; }
    public bool IsFinished => _state is CompletedState;

    public SupportBot(TextWriter output)
    {
        _output = output;
    }

    public void Receive(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            Say("Сообщение пустое. Напишите, что случилось.");
            return;
        }

        _state.Handle(this, message.Trim());
    }

    public void ChangeState(IChatState state)
    {
        _state = state;
        ShowState();
    }

    public void SetProblem(string problem)
    {
        Problem = problem;
    }

    public void ShowState()
    {
        _output.WriteLine($"Этап диалога: {StateName}");
    }

    public void Say(string message)
    {
        _output.WriteLine($"Бот: {message}");
    }
}
