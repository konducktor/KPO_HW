using HW2.Application;

namespace HW2.ConsoleUI;

public class ShowStudentsCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Показать студентов";

    public void Run()
    {
        IReadOnlyList<StudentData> students = facade.GetStudents();
        if (students.Count == 0)
        {
            console.Print("Студентов пока нет");
            console.Print("");
            return;
        }

        console.Print("Студенты:");
        foreach (StudentData student in students)
            console.Print($"{student.Id}: {student.Name} {student.Surname}");
        console.Print("");
    }
}
