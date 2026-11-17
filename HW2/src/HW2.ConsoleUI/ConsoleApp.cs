namespace HW2.ConsoleUI;

public class ConsoleApp
{
    private const int ExitCommandNumber = 0;

    private readonly IConsoleIO _console;
    private readonly IReadOnlyList<IMenuCommand> _commands;

    public ConsoleApp(IConsoleIO console, IEnumerable<IMenuCommand> commands)
    {
        _console = console;
        _commands = commands.ToList();
    }

    public void Run()
    {
        try
        {
            RunMenuLoop();
        }
        catch (EndOfStreamException)
        {
            _console.Print("Ввод закончился, выход из приложения");
        }
    }

    private void RunMenuLoop()
    {
        while (true)
        {
            PrintMenu();

            int commandNumber = _console.ReadInt("", ExitCommandNumber, _commands.Count);
            if (commandNumber == ExitCommandNumber)
            {
                _console.Print("До свидания!");
                return;
            }

            RunCommand(_commands[commandNumber - 1]);
        }
    }

    private void RunCommand(IMenuCommand command)
    {
        try
        {
            command.Run();
        }
        catch (Exception exception) when (exception is not EndOfStreamException)
        {
            _console.Print($"Ошибка: {exception.Message}");
            _console.Print("");
        }
    }

    private void PrintMenu()
    {
        _console.Print("Команды:");
        _console.Print($"\t{ExitCommandNumber} - Выйти из приложения");
        for (int i = 0; i < _commands.Count; i++)
            _console.Print($"\t{i + 1} - {_commands[i].Title}");
        _console.Print("");
    }
}
