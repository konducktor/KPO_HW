namespace HW2.ConsoleUI;

public interface IMenuCommand
{
    public string Title { get; }
    public void Run();
}
