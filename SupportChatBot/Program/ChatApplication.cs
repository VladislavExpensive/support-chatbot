using System.Text;
using SupportChatBot.Models;
using SupportChatBot.Patterns.Command;

namespace SupportChatBot.Program;

public class ChatApplication
{
    private CommandInvoker? _lastDialog;

    public void Run()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        var menu = new ConsoleMenu();
        var examples = new DialogExamples(Console.Out);

        while (true)
        {
            string choice = menu.Choose();
            Console.Clear();

            switch (choice)
            {
                case "Поговорить с ботом":
                    StartDialog();
                    break;
                case "Посмотреть пример диалога":
                    _lastDialog = examples.FullDialog();
                    break;
                case "Сравнить ответы на слово «помощь»":
                    _lastDialog = examples.SameMessage();
                    break;
                case "Повторить последний диалог":
                    if (_lastDialog == null || _lastDialog.Count == 0)
                        Console.WriteLine("Сначала начните диалог или откройте пример.");
                    else
                    {
                        Console.WriteLine("Повтор последнего диалога\n");
                        _lastDialog.Replay();
                        Console.WriteLine("Повтор завершён. Исходный журнал не изменился.");
                    }
                    break;
                case "Открыть журнал":
                    if (_lastDialog == null)
                        Console.WriteLine("Пока нет диалога, который можно посмотреть.");
                    else
                        _lastDialog.Journal.Print(Console.Out);
                    break;
                case "Выйти":
                    return;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню.");
            Console.ReadKey(true);
        }
    }

    private void StartDialog()
    {
        Console.WriteLine("Чат поддержки\n");
        Console.WriteLine("Пустая строка возвращает в меню. История диалога сохранится.");
        var bot = new SupportBot(Console.Out);
        _lastDialog = new CommandInvoker(Console.Out);
        bot.ShowState();
        bot.Say("Напишите «привет», чтобы начать.");

        while (!bot.IsFinished)
        {
            Console.Write("Вы: ");
            string? message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message))
                return;

            _lastDialog.Execute(new SendMessageCommand(message), bot);
        }
    }
}
