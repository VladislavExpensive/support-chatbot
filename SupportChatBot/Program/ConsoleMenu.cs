namespace SupportChatBot.Program;

public class ConsoleMenu
{
    private readonly string[] _items =
    {
        "Поговорить с ботом",
        "Посмотреть пример диалога",
        "Сравнить ответы на слово «помощь»",
        "Повторить последний диалог",
        "Открыть журнал",
        "Выйти"
    };

    public string Choose()
    {
        int selected = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Чат поддержки\n");
            Console.WriteLine("Выберите действие стрелками и нажмите Enter.\n");

            for (int i = 0; i < _items.Length; i++)
            {
                if (i == selected)
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{(i == selected ? ">" : " ")} {_items[i]}");
                Console.ResetColor();
            }

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    selected = (selected - 1 + _items.Length) % _items.Length;
                    break;
                case ConsoleKey.DownArrow:
                    selected = (selected + 1) % _items.Length;
                    break;
                case ConsoleKey.Enter:
                    return _items[selected];
                case ConsoleKey.Escape:
                    return "Выйти";
            }
        }
    }
}
