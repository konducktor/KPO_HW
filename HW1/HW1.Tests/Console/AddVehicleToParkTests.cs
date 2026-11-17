public class AddVehicleToParkTests
{
    private static AddVehicleToPark CreateCommand(TestApp app)
    {
        return new(app.IO, app.Inventory, app.Park);
    }

    [Fact]
    public void Run_PassedInspection_AdmitsVehicleToPark()
    {
        var app = new TestApp("0");
        var scooter = app.AddToInventory(app.Vehicles.CreateElectroScooter("Самокат", 8, 0, 100.0));

        CreateCommand(app).Run();

        Assert.Same(scooter, Assert.Single(app.Park.Vehicles));
        Assert.Contains(app.IO.Output, line => line.Contains("успешно добавлен"));
    }

    [Theory]
    [InlineData(InspectionResult.FailedDamage, "слишком сильно повреждён")]
    [InlineData(InspectionResult.Failed, "не прошёл проверку")]
    public void Run_InspectionFailed_VehicleNotAdmitted_ReasonPrinted(InspectionResult result, string expectedText)
    {
        var app = new TestApp("0");
        app.Inspection.Result = result;
        app.AddToInventory(app.Vehicles.CreateElectroScooter("Самокат", 8, 9, 100.0));

        CreateCommand(app).Run();

        Assert.Empty(app.Park.Vehicles);
        Assert.Single(app.Inventory.Items); // отклонённый транспорт остаётся на балансе
        Assert.Contains(app.IO.Output, line => line.Contains(expectedText));
    }

    [Fact]
    public void Run_InspectionFailed_InspectsOnlyOnce()
    {
        var app = new TestApp("0");
        app.Inspection.Result = InspectionResult.Failed;
        app.AddToInventory(app.Vehicles.CreateBicycle("Велик", 5, 6));

        CreateCommand(app).Run();

        Assert.Equal(1, app.Inspection.Calls);
    }

    [Fact]
    public void Run_VehicleAlreadyInPark_ReportsItAndDoesNotInspectAgain()
    {
        var app = new TestApp("0");
        app.AddAndAdmit(app.Vehicles.CreateElectroScooter("Самокат", 8, 0, 100.0));

        CreateCommand(app).Run();

        Assert.Single(app.Park.Vehicles);
        Assert.Equal(1, app.Inspection.Calls); // единственный осмотр был при AddAndAdmit
        Assert.Contains(app.IO.Output, line => line.Contains("уже есть в парке"));
    }

    [Fact]
    public void Run_NumberOfNonVehicle_AsksAgain()
    {
        var app = new TestApp("0", "1"); // 0 - шлем, 1 - самокат
        app.AddToInventory(app.Items.CreateHelmet("Шлем"));
        app.AddToInventory(app.Vehicles.CreateElectroScooter("Самокат", 8, 0, 100.0));

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("не является транспортом"));
        Assert.IsType<ElectroScooter>(Assert.Single(app.Park.Vehicles));
    }

    [Fact]
    public void Run_NumberBeyondLastItem_IsRejectedAndAskedAgain()
    {
        var app = new TestApp("1", "0"); // на балансе один предмет: "1" недопустимо
        app.AddToInventory(app.Vehicles.CreateElectroScooter("Самокат", 8, 0, 100.0));

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("Требуется число от"));
        Assert.Single(app.Park.Vehicles);
    }

    [Fact]
    public void Run_EmptyInventory_PrintsMessageAndAsksNothing()
    {
        var app = new TestApp(); // если команда спросит номер, FakeConsoleIO бросит исключение

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("нет транспорта"));
        Assert.Empty(app.Park.Vehicles);
    }

    [Fact]
    public void Run_OnlyThingsOnBalance_PrintsMessageAndAsksNothing()
    {
        var app = new TestApp();
        app.AddToInventory(app.Items.CreateHelmet("Шлем"));

        CreateCommand(app).Run();

        Assert.Contains(app.IO.Output, line => line.Contains("нет транспорта"));
        Assert.Empty(app.Park.Vehicles);
    }
}
