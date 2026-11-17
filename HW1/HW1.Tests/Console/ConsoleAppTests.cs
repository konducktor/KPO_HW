public class ConsoleAppTests
{
    private static (ConsoleApp App, FakeConsoleIO IO, StubCommand First, StubCommand Second) Create(params string[] inputs)
    {
        var io = new FakeConsoleIO(inputs);
        var first = new StubCommand("Первая команда");
        var second = new StubCommand("Вторая команда");
        var app = new ConsoleApp(io, new IMenuCommand[] { first, second });
        return (app, io, first, second);
    }

    [Fact]
    public void Run_ChoosingFirstCommand_RunsOnlyFirst()
    {
        var (app, _, first, second) = Create("1", "0");

        app.Run();

        Assert.Equal(1, first.Runs);
        Assert.Equal(0, second.Runs);
    }

    [Fact]
    public void Run_ChoosingSecondCommand_RunsOnlySecond()
    {
        var (app, _, first, second) = Create("2", "0");

        app.Run();

        Assert.Equal(0, first.Runs);
        Assert.Equal(1, second.Runs);
    }

    [Fact]
    public void Run_SameCommandSeveralTimes_RunsEachTime()
    {
        var (app, _, first, _) = Create("1", "1", "1", "0");

        app.Run();

        Assert.Equal(3, first.Runs);
    }

    [Fact]
    public void Run_Exit_RunsNothing()
    {
        var (app, _, first, second) = Create("0");

        app.Run();

        Assert.Equal(0, first.Runs);
        Assert.Equal(0, second.Runs);
    }

    [Fact]
    public void Run_PrintsTitlesOfAllCommands()
    {
        var (app, io, _, _) = Create("0");

        app.Run();

        Assert.Contains(io.Output, line => line.Contains("Первая команда"));
        Assert.Contains(io.Output, line => line.Contains("Вторая команда"));
    }

    [Fact]
    public void Run_UnknownChoice_IsIgnoredAndMenuContinues()
    {
        var (app, _, first, second) = Create("99", "1", "0");

        app.Run();

        Assert.Equal(1, first.Runs); // после неверного ввода меню не упало и не вышло
        Assert.Equal(0, second.Runs);
    }
}
