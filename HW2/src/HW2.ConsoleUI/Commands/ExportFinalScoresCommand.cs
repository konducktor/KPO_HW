using HW2.Application;

namespace HW2.ConsoleUI;

public class ExportFinalScoresCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Экспортировать итоги";

    public void Run()
    {
        facade.ExportFinalScores();

        console.Print("Итоги экспортированы");
        console.Print("");
    }
}
