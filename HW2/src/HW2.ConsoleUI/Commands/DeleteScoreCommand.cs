using HW2.Application;

namespace HW2.ConsoleUI;

public class DeleteScoreCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Отменить оценку";

    public void Run()
    {
        int studentId = console.ReadInt("Введите id студента", InputLimits.MinId, InputLimits.MaxId);
        int criterionId = console.ReadInt("Введите id критерия", InputLimits.MinId, InputLimits.MaxId);

        facade.DeleteScore(studentId, criterionId);

        console.Print("Оценка отменена");
        console.Print("");
    }
}
