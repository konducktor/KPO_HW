public class ConsoleApp
{
    private IConsoleIO _console;
    private readonly IReadOnlyList<IMenuCommand> _commands;

    public ConsoleApp(IConsoleIO console, IEnumerable<IMenuCommand> commands)
    {
        _console = console;
        _commands = commands.ToList();
    }

    public void Run()
    {
        while (true)
        {
            PrintMenu();

            int commandIndex = _console.ReadInt("", 0, _commands.Count);

            if (commandIndex == 0)
            {
                _console.Print("До свидания!");
                return;
            }

            _commands[commandIndex - 1].Run();
        }
    }

    void PrintMenu()
    {
        _console.Print("Команды:");
        _console.Print("\t0 - Выйти из приложения");
        for (int i = 0; i < _commands.Count; i++)
            _console.Print($"\t{i+1} - {_commands[i].Title}");
        _console.Print("");
    }
}