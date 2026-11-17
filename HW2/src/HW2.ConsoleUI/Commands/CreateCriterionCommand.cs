using HW2.Application;

namespace HW2.ConsoleUI;

public class CreateCriterionCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Добавить критерий";

    public void Run()
    {
        string name = console.ReadString("Введите название критерия");
        decimal maxScore = console.ReadDecimal("Введите максимальный балл", InputLimits.MinScore, InputLimits.MaxScore);
        decimal weight = console.ReadDecimal("Введите вес критерия", InputLimits.MinScore, InputLimits.MaxScore);

        int criterionId = facade.CreateCriterion(name, maxScore, weight);

        console.Print($"Критерий добавлен, id: {criterionId}");
        console.Print("");
    }
}
