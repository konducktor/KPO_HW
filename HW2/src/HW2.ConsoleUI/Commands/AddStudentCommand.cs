using HW2.Application;

namespace HW2.ConsoleUI;

public class AddStudentCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Добавить студента";

    public void Run()
    {
        string name = console.ReadString("Введите имя студента");
        string surname = console.ReadString("Введите фамилию студента");

        int studentId = facade.AddStudent(name, surname);

        console.Print($"Студент добавлен, id: {studentId}");
        console.Print("");
    }
}
