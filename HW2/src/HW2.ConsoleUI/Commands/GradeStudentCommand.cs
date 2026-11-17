using HW2.Application;

namespace HW2.ConsoleUI;

public class GradeStudentCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Выставить оценку";

    public void Run()
    {
        int studentId = console.ReadInt("Введите id студента", InputLimits.MinId, InputLimits.MaxId);
        int criterionId = console.ReadInt("Введите id критерия", InputLimits.MinId, InputLimits.MaxId);
        decimal points = console.ReadDecimal("Введите оценку", InputLimits.MinScore, InputLimits.MaxScore);

        facade.GradeStudent(studentId, criterionId, points);

        console.Print("Оценка выставлена");
        console.Print("");
    }
}
