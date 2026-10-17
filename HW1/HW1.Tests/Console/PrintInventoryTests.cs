public class PrintInventoryTests
{
    private static PrintInventory CreateCommand(TestApp app)
    {
        return new(app.IO, app.Formatter, app.Inventory);
    }

    [Fact]
    public void Run_EmptyInventory_PrintsOnlyHeader()
    {
        var app = new TestApp();

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("Предметы в банке"));
        Assert.DoesNotContain(app.IO.Output, line => line.Contains("№"));
    }

    [Fact]
    public void Run_PrintsEveryItemAsFormattedLine()
    {
        var app = new TestApp();
        var scooter = app.AddToInventory(app.Vehicles.CreateElectroScooter("Самокат", 8, 0, 100.0));
        var helmet = app.AddToInventory(app.Items.CreateHelmet("Шлем"));
        var dock = app.AddToInventory(app.Items.CreateDockStation("Док-станция"));

        CreateCommand(app).Run();

        Assert.Contains(app.Formatter.Format(scooter), app.IO.Output);
        Assert.Contains(app.Formatter.Format(helmet), app.IO.Output);
        Assert.Contains(app.Formatter.Format(dock), app.IO.Output);
    }

    [Fact]
    public void Run_KeepsInsertionOrder()
    {
        var app = new TestApp();
        var first = app.AddToInventory(app.Items.CreateHelmet("Первый"));
        var second = app.AddToInventory(app.Vehicles.CreateBicycle("Второй", 7, 0));

        CreateCommand(app).Run();

        int firstIndex = app.IO.Output.IndexOf(app.Formatter.Format(first));
        int secondIndex = app.IO.Output.IndexOf(app.Formatter.Format(second));
        Assert.InRange(firstIndex, 0, secondIndex - 1);
    }

    [Fact]
    public void Run_PrintsItemsNotInParkToo()
    {
        var app = new TestApp();
        app.Inspection.Result = InspectionResult.FailedDamage;
        var rejected = app.AddAndAdmit(app.Vehicles.CreateElectroScooter("Сломанный", 8, 9, 100.0));

        CreateCommand(app).Run();

        Assert.Empty(app.Park.Vehicles);
        Assert.Contains(app.Formatter.Format(rejected), app.IO.Output); // баланс шире парка
    }
}
