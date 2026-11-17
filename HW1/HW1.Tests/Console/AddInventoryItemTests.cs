public class AddInventoryItemTests
{
    private static AddInventoryItem CreateCommand(TestApp app)
    {
        return new(app.IO, app.Formatter, app.Vehicles, app.Items, app.Inventory);
    }

    [Fact]
    public void Run_ElectroScooter_CreatesEnergyConsumingVehicle()
    {
        var app = new TestApp("Самокат", "1", "8", "2", "100");

        CreateCommand(app).Run();

        var scooter = Assert.IsType<ElectroScooter>(Assert.Single(app.Inventory.Items));
        Assert.Equal("Самокат", scooter.Name);
        Assert.True(scooter.NoviceScore.IsSuitableForNovice());
        Assert.Equal(100.0, Assert.IsAssignableFrom<IEnergyConsumer>(scooter).Energy.DailyConsumption);
    }

    [Fact]
    public void Run_Bicycle_CreatesVehicleWithoutEnergy()
    {
        var app = new TestApp("Велик", "2", "5", "6");

        CreateCommand(app).Run();

        var bicycle = Assert.IsType<Bicycle>(Assert.Single(app.Inventory.Items));
        Assert.False(bicycle is IEnergyConsumer);
        Assert.False(bicycle.NoviceScore.IsSuitableForNovice()); // 5 < 6 ого
    }

    [Fact]
    public void Run_ElectroBicycle_CreatesEnergyConsumingVehicle()
    {
        var app = new TestApp("Эвелик", "3", "9", "1", "50");

        CreateCommand(app).Run();

        var ebike = Assert.IsType<ElectroBicycle>(Assert.Single(app.Inventory.Items));
        Assert.Equal(50.0, Assert.IsAssignableFrom<IEnergyConsumer>(ebike).Energy.DailyConsumption);
    }

    [Theory]
    [InlineData("4", typeof(ChargingStation))]
    [InlineData("5", typeof(DockStation))]
    [InlineData("6", typeof(Helmet))]
    public void Run_Thing_CreatesExpectedTypeWithoutExtraQuestions(string choice, Type expectedType)
    {
        var app = new TestApp("Предмет", choice);

        CreateCommand(app).Run();

        Assert.IsType(expectedType, Assert.Single(app.Inventory.Items));
    }

    [Fact]
    public void Run_UnknownType_AddsNothingAndReports()
    {
        var app = new TestApp("Предмет", "9");

        CreateCommand(app).Run();

        Assert.Empty(app.Inventory.Items);
        Assert.Contains(app.IO.Output, line => line.Contains("Неизвестный тип предмета"));
    }

    [Fact]
    public void Run_ScoreOutOfRange_AsksAgainUntilValid()
    {
        var app = new TestApp("Самокат", "1", "0", "11", "8", "2", "100");

        CreateCommand(app).Run();

        Assert.Single(app.Inventory.Items);
        Assert.Contains(app.IO.Output, line => line.Contains("Требуется число от 1 до 10"));
    }

    [Fact]
    public void Run_EnergyNotANumber_AsksAgain()
    {
        var app = new TestApp("Самокат", "1", "8", "2", "много", "100");

        CreateCommand(app).Run();

        Assert.Single(app.Inventory.Items);
        Assert.Contains(app.IO.Output, line => line.Contains("На вход требуется число"));
    }

    [Fact]
    public void Run_PrintsConfirmationWithFormattedItem()
    {
        var app = new TestApp("Шлем M", "6");

        CreateCommand(app).Run();

        var item = Assert.Single(app.Inventory.Items);
        Assert.Contains(app.IO.Output, line => line.Contains("Предмет был добавлен"));
        Assert.Contains(app.Formatter.Format(item), app.IO.Output);
    }

    [Fact]
    public void Run_TwoItems_GetDifferentNumbers()
    {
        var app = new TestApp("Шлем 1", "6", "Шлем 2", "6");
        var command = CreateCommand(app);

        command.Run();
        command.Run();

        Assert.Equal(2, app.Inventory.Items.Count);
        Assert.NotEqual(app.Inventory.Items[0].Number, app.Inventory.Items[1].Number);
    }
}
