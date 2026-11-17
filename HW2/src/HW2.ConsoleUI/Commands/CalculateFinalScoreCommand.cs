using HW2.Application;

namespace HW2.ConsoleUI;

public class CalculateFinalScoreCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Рассчитать итог студента";

    public void Run()
    {
        int studentId = console.ReadInt("Введите id студента", InputLimits.MinId, InputLimits.MaxId);

        decimal finalScore = facade.CalculateFinalScore(studentId);

        console.Print($"Итоговый балл: {finalScore}");
        console.Print("");
    }
}
