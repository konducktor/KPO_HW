public class StubCommand(string title) : IMenuCommand
{
    public string Title { get; } = title;

    public int Runs { get; private set; }

    public void Run()
    {
        Runs++;
    }
}
