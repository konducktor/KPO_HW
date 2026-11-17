// Техосмотр подменён фейком, поэтому тесты не зависят от порога повреждений в настоящем ServiceCenter.
public class AddDemonstrativeTests
{
    private static AddDemonstrative CreateCommand(TestApp app)
        => new(app.IO, app.Vehicles, app.Items, app.Inventory, app.Park);

    [Fact]
    public void Run_FillsInventoryWithSevenItems_FourOfThemVehicles()
    {
        var app = new TestApp();

        CreateCommand(app).Run();

        Assert.Equal(7, app.Inventory.Items.Count);
        Assert.Equal(4, app.Inventory.Items.OfType<Vehicle>().Count());
    }

    [Fact]
    public void Run_InventoryNumbersAreUnique()
    {
        var app = new TestApp();

        CreateCommand(app).Run();

        var numbers = app.Inventory.Items.Select(i => i.Number).ToList();
        Assert.Equal(numbers.Count, numbers.Distinct().Count());
    }

    [Fact]
    public void Run_PassedInspection_AdmitsThreeVehiclesToPark()
    {
        var app = new TestApp();

        CreateCommand(app).Run();

        Assert.Equal(3, app.Park.Vehicles.Count);
        Assert.Equal(3, app.Inspection.Calls);
    }

    [Fact]
    public void Run_FailedInspection_ParkStaysEmptyButInventoryIsFilled()
    {
        var app = new TestApp();
        app.Inspection.Result = InspectionResult.Failed;

        CreateCommand(app).Run();

        Assert.Empty(app.Park.Vehicles);
        Assert.Equal(7, app.Inventory.Items.Count);
    }

    [Fact]
    public void Run_PrintsConfirmation()
    {
        var app = new TestApp();

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("для демонстрации"));
    }

    [Fact]
    public void Run_CalledTwice_DoesNotThrow()
    {
        var app = new TestApp();
        var command = CreateCommand(app);

        command.Run();
        var exception = Record.Exception(command.Run);

        Assert.Null(exception);
    }
}
