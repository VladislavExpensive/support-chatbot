namespace SupportChatBot.Models;

public class ActionJournal
{
    private readonly List<JournalEntry> _entries = new();

    public IReadOnlyList<JournalEntry> Entries => _entries.AsReadOnly();

    public void Add(string message, string before, string after)
    {
        _entries.Add(new JournalEntry(message, before, after));
    }

    public void Print(TextWriter output)
    {
        output.WriteLine("Журнал последнего диалога\n");

        if (_entries.Count == 0)
        {
            output.WriteLine("В этом диалоге пока нет сообщений.");
            return;
        }

        foreach (var entry in _entries)
        {
            output.WriteLine($"Вы написали: {entry.Message}");
            if (entry.Before == entry.After)
                output.WriteLine($"Этап не изменился: {entry.After}");
            else
                output.WriteLine($"{entry.Before} → {entry.After}");
            output.WriteLine();
        }
    }
}
